from ctypes import ArgumentError
import re
from pathlib import Path
from typing import List
from jinja2 import Environment, FileSystemLoader


# Configuration
HEADER_DIR = "../libpff"
OUTPUT_DIR = "LibPff/Interop"
NAMESPACE = "LibPff.Interop"

# Regex for function declarations
FUNC_REGEX = re.compile(
    r'LIBPFF_EXTERN\s*\\?\s*([a-zA-Z0-9_]+)\s+([a-zA-Z0-9_]+)\s*\(([^)]*)\)\s*;',
    re.MULTILINE | re.DOTALL
)

# Regex for normalization
NORMALIZE_WHITESPACE = re.compile(r'\s+')


CS_KEYWORDS = {
    "string", "int", "long", "uint", "byte", "sbyte", "short", "ushort",
    "char", "object", "decimal", "double", "float", "bool", "nint", "nuint",
    "void"
}

# Type mapping dictionaries
TYPE_MAPPINGS = {
    "out_parameters": {
        ("int", 1): "out int",
        ("size64_t", 1): "out long",
        ("off64_t", 1): "out long",
        ("ssize_t", 1): "out long",
        ("size_t", 1): "out UIntPtr",
        ("uint32_t", 1): "out uint",
        ("uint8_t", 1): "out byte",
        ("uint16_t", 1): "out ushort",
        ("uint64_t", 1): "out ulong",
        ("double", 1): "out double",
    },
    "buffers": {
        ("uint8_t", "buffer"): "byte[]",
        ("uint8_t", "string"): "byte[]",
        ("uint8_t", "data"): "byte[]",
        ("uint8_t", "utf8_string"): "byte[]",
        ("uint8_t", "utf8_entry_name"): "byte[]",
        ("uint8_t", "utf8_sub_folder_name"): "byte[]",
        ("uint8_t", "utf8_sub_message_name"): "byte[]",
        ("uint8_t", "message_body"): "byte[]",
        ("uint8_t", "binary_data"): "byte[]",
        ("uint8_t", "value_data"): "byte[]",
        ("uint8_t", "guid"): "byte[]",
        ("uint8_t", "gui_data"): "byte[]",
        ("uint16_t",): "ushort[]",
        ("uint16_t", "utf16_string"): "ushort[]",
        ("uint16_t", "utf16_entry_name"): "ushort[]",
        ("uint16_t", "utf16_sub_folder_name"): "ushort[]",
        ("uint16_t", "utf16_sub_message_name"): "ushort[]",
    },
    "strings": {
        ("char", 1): "[MarshalAs(UnmanagedType.LPStr)] string",
        ("wchar_t", 1): "[MarshalAs(UnmanagedType.LPWStr)] string",
    },
    "scalars": {
        ("int", 0): "int",
        ("uint32_t", 0): "uint",
        ("uint64_t", 0): "ulong",
        ("size_t", 0): "UIntPtr",
        ("ssize_t", 0): "long",
        ("off64_t", 0): "long",
        ("size64_t", 0): "long",
        ("uint8_t", 0): "byte",
        ("uint16_t", 0): "ushort",
        ("double", 0): "double",
    },
}

RETURN_TYPE_MAPPING = {
    "void": "void",
    "int": "int",
    "ssize_t": "long",
    "off64_t": "long",
    "size64_t": "long",
    "size_t": "UIntPtr",
}


class CParameter:
    def __init__(self, c_type: str, name: str, index: int):
        self.c_type = self._normalize_type(c_type)
        self.name_original = name
        self.index = index
        self.pointer_level = self.c_type.count("*")
        self.base_type = self.c_type.replace("*", "").strip()
        self.name = self._sanitize_name(name, index)

    @staticmethod
    def _normalize_type(c_type: str) -> str:
        c_type = NORMALIZE_WHITESPACE.sub(" ", c_type).strip()
        return c_type.replace("const ", "").replace("\n", "").strip()

    def _sanitize_name(self, name: str, index: int) -> str:
        n = name.strip()
        if not n:
            return f"arg_{index}"
        if n in CS_KEYWORDS:
            return f"{n}_{index}"
        if n and n[0] in "*&":
            return f"{n[1:]}_{index}" if len(n) > 1 else f"arg_{index}"
        return n

    def __str__(self):
        return f"{self.c_type} {self.name}"

    @property
    def cs_type(self) -> str:
        """
        Base C → C# mapping without libpff-specific direction heuristics.
        Direction (in/out) is derived purely from pointer level and type.
        """
        bt = self.base_type
        lvl = self.pointer_level
        pname = self.name.lower()

        # libcerror_error_t** should always be out IntPtr
        if "libcerror_error_t" in self.c_type and lvl >= 2:
            return "out IntPtr"

        # libcerror_error_t* (if it ever appears) is treated as IntPtr
        if "libcerror_error_t" in self.c_type and lvl == 1:
            return "IntPtr"

        # Output buffers for sprint functions
        if bt == "char" and pname in ("string", "string_2", "buffer"):
            return "StringBuilder"

        # Byte buffers
        if bt == "uint8_t" and lvl == 1 and pname in (
            "buffer", "string", "data", "utf8_string", "binary_data",
            "value_data", "guid", "utf8_entry_name", "utf8_sub_folder_name",
            "utf8_sub_message_name", "message_body", "gui_data"
        ):
            return "byte[]"

        # UTF-16 buffers as ushort[]
        if bt == "uint16_t" and lvl == 1 and pname in (
            "utf16_string", "utf16_entry_name", "utf16_sub_folder_name",
            "utf16_sub_message_name"
        ):
            return "ushort[]"

        # Out parameters (scalar pointers)
        key = (bt, lvl)
        if key in TYPE_MAPPINGS["out_parameters"]:
            return TYPE_MAPPINGS["out_parameters"][key]

        # Input strings
        if (bt, lvl) in TYPE_MAPPINGS["strings"]:
            return TYPE_MAPPINGS["strings"][(bt, lvl)]

        # Scalars
        if (bt, lvl) in TYPE_MAPPINGS["scalars"]:
            return TYPE_MAPPINGS["scalars"][(bt, lvl)]

        # Generic pointers (handles, opaque types, etc.)
        if lvl >= 2:
            # For libpff, double pointers are always "out IntPtr"
            return "out IntPtr"
        if lvl == 1:
            # Single pointer is an input handle
            return "IntPtr"

        # Fallback
        return "IntPtr"

    @property
    def cs_signature(self) -> str:
        return f"{self.cs_type} {self.name}"

    @property
    def cs_call_arg(self) -> str:
        cs_type = self.cs_type
        if cs_type.startswith("out "):
            return f"out {self.name}"
        return self.name


class CFunctionSignature:
    def __init__(self, return_type: str, name: str, params: List[CParameter]):
        self.return_type = self._normalize_type(return_type)
        self.name = name
        self.params = params
        self.cs_return_type = map_return_type(self.return_type)

    @staticmethod
    def _normalize_type(c_type: str) -> str:
        c_type = NORMALIZE_WHITESPACE.sub(" ", c_type).strip()
        return c_type.replace("const ", "").replace("\n", "").strip()

    def __str__(self):
        params_str = ", ".join(str(p) for p in self.params)
        return f"{self.return_type} {self.name}({params_str});"


jinja_env = Environment(
    loader=FileSystemLoader("code-templates"),
    trim_blocks=True,
    lstrip_blocks=True,
)


def _parse_parameters(param_str: str) -> List[CParameter]:
    """
    Parse C function parameters into CParameter objects.
    Handles pointer stars attached to the parameter name token.
    """
    if not param_str or param_str.strip() == "void":
        return []

    params: List[CParameter] = []
    raw = [p.strip() for p in param_str.split(",") if p.strip()]

    for index, p in enumerate(raw, 1):
        tokens = NORMALIZE_WHITESPACE.sub(" ", p).split()
        if not tokens:
            continue

        param_name_token = tokens[-1]
        type_tokens = tokens[:-1]

        # Extract pointer characters from the parameter name token
        stars = ""
        while param_name_token.startswith("*"):
            stars += "*"
            param_name_token = param_name_token[1:]

        c_type = (" ".join(type_tokens) + stars).strip()
        param_name = param_name_token.strip()
        params.append(CParameter(c_type, param_name, index))

    return params


def extract_functions(header_dir: str) -> List[CFunctionSignature]:
    """
    Extract function signatures from all .h files in the given directory.
    """
    functions: List[CFunctionSignature] = []
    header_path = Path(header_dir)

    if not header_path.exists():
        print(f"Warning: Header directory '{header_dir}' not found.")
        return functions

    for header_file in header_path.rglob("*.h"):
        try:
            with open(header_file, "r", encoding="utf-8", errors="ignore") as fh:
                content = fh.read()
            for return_type, func_name, params_str in FUNC_REGEX.findall(content):
                params = _parse_parameters(params_str)
                functions.append(CFunctionSignature(return_type, func_name, params))
        except IOError as e:
            print(f"Warning: Could not read '{header_file}': {e}")

    return functions


def map_return_type(ret: str) -> str:
    """
    Map C return type to C# return type.
    """
    r = ret.replace("\n", " ").strip().replace("const ", "").strip()
    return RETURN_TYPE_MAPPING.get(r, "int")


def get_classname(classname: str, platform: dict[str, any]) -> str:
    """
    Build a platform-specific class name, e.g. NativeWin64.
    """
    os_name = platform["os"][0].upper() + platform["os"][1:].lower()
    return f"{classname}{os_name}{platform['bits']}"


def c_to_cs_name(c_name: str) -> str:
    """
    Convert C function name to C# PascalCase without the 'libpff_' prefix.
    """
    s = c_name
    if s.startswith("libpff_"):
        s = s[len("libpff_"):]
    parts = [p for p in s.split("_") if p]
    if not parts:
        cs = c_name
    else:
        cs = "".join(part.capitalize() for part in parts)
    if cs and cs[0].isdigit():
        cs = "_" + cs
    if cs.lower() in CS_KEYWORDS:
        cs = cs + "_"
    return cs


def write_c_signatures(
    output_dir: Path,
    functions: List[CFunctionSignature],
    file_name: Path
) -> None:
    """
    Write a plain C signature list for inspection/debugging.
    """
    template = jinja_env.get_template("c_signatures.txt.j2")

    fn_models = []
    for fn in functions:
        fn_models.append({
            "signature": str(fn)
        })

    output = template.render(
        functions=fn_models,
    )

    output_file = output_dir / file_name
    output_file.write_text(output, encoding="utf-8")


def write_adapter_factory(
    output_dir: Path,
    namespace: str,
    classname: str,
    adapter_classname: str,
    platforms: List[dict]
) -> None:
    """
    Generate a factory that selects the correct platform-specific adapter at runtime.
    """
    template = jinja_env.get_template("adapter_factory.cs.j2")

    runtime_information = {
        "linux": "RuntimeInformation.IsOSPlatform(OSPlatform.Linux)",
        "osx": "RuntimeInformation.IsOSPlatform(OSPlatform.OSX)",
        "win": "RuntimeInformation.IsOSPlatform(OSPlatform.Windows)",
        "freebsd": "RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD)",
    }

    arch_information = {
        32: "!Environment.Is64BitOperatingSystem",
        64: "Environment.Is64BitOperatingSystem",
    }

    enriched = []
    for p in platforms:
        enriched.append({
            **p,
            "adapter_class": get_classname(adapter_classname, p)
        })

    output = template.render(
        namespace=namespace,
        classname=classname,
        platforms=enriched,
        runtime_info=runtime_information,
        arch_info=arch_information,
    )

    output_file = output_dir / f"{classname}.cs"
    output_file.write_text(output, encoding="utf-8")


def write_adapter_interface(
    output_dir: Path,
    namespace: str,
    classname: str,
    functions: List[CFunctionSignature]
) -> None:
    """
    Generate the managed interface (INativeAdapter) that mirrors the C API.
    """
    template = jinja_env.get_template("adapter_interface.cs.j2")

    fn_models = []
    for fn in functions:
        fn_models.append({
            "return_type": fn.cs_return_type,
            "cs_name": c_to_cs_name(fn.name),
            "params_str": ", ".join(p.cs_signature for p in fn.params),
        })

    output = template.render(
        namespace=namespace,
        classname=classname,
        functions=fn_models,
    )

    output_file = output_dir / f"{classname}.cs"
    output_file.write_text(output, encoding="utf-8")


def write_native_class(
    output_dir: Path,
    namespace: str,
    classname: str,
    platform: dict[str, any],
    functions: List[CFunctionSignature]
) -> None:
    """
    Generate the platform-specific P/Invoke class with DllImport signatures.
    """
    template = jinja_env.get_template("native_class.cs.j2")

    classname = get_classname(classname, platform)
    dll_name = f"lib/{platform['os']}{platform['bits']}/libpff.dll"

    fn_models = []
    for fn in functions:
        # Special handling for ssize_t/off64_t/size64_t depending on platform bits
        if fn.return_type in ("ssize_t", "off64_t", "size64_t"):
            if platform["bits"] == 32:
                return_type = "int"
            else:
                return_type = "long"
        else:
            return_type = fn.cs_return_type

        fn_models.append({
            "entrypoint": fn.name,
            "cs_name": c_to_cs_name(fn.name),
            "return_type": return_type,
            "params_str": ", ".join(p.cs_signature for p in fn.params),
        })

    output = template.render(
        namespace=namespace,
        classname=classname,
        dll_name=dll_name,
        functions=fn_models,
        # This is used in the template, e.g. [DllImport(..., {{ charset }})]
        charset="CharSet = CharSet.Unicode",
    )

    output_file = output_dir / f"{classname}.cs"
    output_file.write_text(output, encoding="utf-8")


def write_adapter_class(
    output_dir: Path,
    namespace: str,
    classname: str,
    native_classname: str,
    platform: dict[str, any],
    functions: List[CFunctionSignature]
) -> None:
    """
    Generate the managed adapter class that calls the native P/Invoke class.
    """
    template = jinja_env.get_template("adapter_class.cs.j2")

    classname = get_classname(classname, platform)
    native_classname = get_classname(native_classname, platform)

    fn_models = []
    for fn in functions:
        fn_models.append({
            "cs_name": c_to_cs_name(fn.name),
            "cs_return_type": fn.cs_return_type,
            "params_str": ", ".join(p.cs_signature for p in fn.params),
            "call_args": ", ".join(p.cs_call_arg for p in fn.params),
            "is_special_return": fn.return_type in ("ssize_t", "off64_t", "size64_t"),
        })

    output = template.render(
        namespace=namespace,
        classname=classname,
        native_classname=native_classname,
        functions=fn_models,
        bits=platform["bits"],
    )

    output_file = output_dir / f"{classname}.cs"
    output_file.write_text(output, encoding="utf-8")


def write_safe_handle(
    output_dir: Path,
    namespace: str,
    classname: str,
    function: CFunctionSignature
) -> None:
    """
    Generate a SafeHandle wrapper for cleanup functions (xxx_free).
    """
    template = jinja_env.get_template("safe_handle.cs.j2")

    adapter_cleanup_function = c_to_cs_name(function.name)

    # Very simple heuristic: 1- or 2-parameter free functions
    if len(function.params) == 1:
        adapter_call = f"{adapter_cleanup_function}(out handle)"
    elif len(function.params) == 2:
        adapter_call = f"{adapter_cleanup_function}(out tmp, out error)"
    else:
        raise ArgumentError("SafeHandle generator failed")

    output = template.render(
        namespace=namespace,
        classname=classname,
        return_type=function.return_type,
        adapter_call=adapter_call,
    )

    output_file = output_dir / f"{classname}.cs"
    output_file.write_text(output, encoding="utf-8")


def main() -> None:
    """
    Main entry point: parse headers and generate all interop artifacts.
    """
    Path(OUTPUT_DIR).mkdir(parents=True, exist_ok=True)

    functions = extract_functions(HEADER_DIR)

    if not functions:
        print("Warning: No functions found.")
        return

    platforms = [
        {"os": "win", "bits": 32},
        {"os": "win", "bits": 64},
    ]

    # Raw C signatures for inspection
    write_c_signatures(Path(OUTPUT_DIR), functions, "libpff-capi.txt")

    # Managed interface
    write_adapter_interface(Path(OUTPUT_DIR), NAMESPACE, "INativeAdapter", functions)

    # Platform-specific native classes and adapters
    for platform in platforms:
        write_native_class(Path(OUTPUT_DIR), NAMESPACE, "Native", platform, functions)
        write_adapter_class(Path(OUTPUT_DIR), NAMESPACE, "NativeAdapter", "Native", platform, functions)

    # Factory that selects the correct adapter at runtime
    write_adapter_factory(Path(OUTPUT_DIR), NAMESPACE, "NativeAdapterFactory", "NativeAdapter", platforms)

    # Generate SafeHandle wrappers for cleanup functions (xxx_free)
    cleanup_functions = [obj for obj in functions if obj.name.lower().endswith("free")]
    for function in cleanup_functions:
        classname = c_to_cs_name(function.name)
        classname = re.sub("Free$", "Handle", classname)
        write_safe_handle(Path(OUTPUT_DIR), NAMESPACE, classname, function)

    print(f"Extracted {len(functions)} functions.")
    print(f"Output files written to '{OUTPUT_DIR}'")


if __name__ == "__main__":
    main()
