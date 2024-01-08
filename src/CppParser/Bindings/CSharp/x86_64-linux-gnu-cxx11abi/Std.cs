// ----------------------------------------------------------------------------
// <auto-generated>
// This is autogenerated code by CppSharp.
// Do not edit this file or all your changes will be lost after re-generation.
// </auto-generated>
// ----------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using __CallingConvention = global::System.Runtime.InteropServices.CallingConvention;
using __IntPtr = global::System.IntPtr;

[assembly:InternalsVisibleTo("CppSharp.Parser.CSharp")]

[assembly:InternalsVisibleTo("CppSharp.CppParser")]

#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required
#pragma warning disable CS9084 // Struct member returns 'this' or other instance members by reference

namespace Std
{
    namespace Allocator
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public unsafe partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity, DllImport("Std-symbols", EntryPoint = "_ZNSaIcEC2Ev", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void ctorc__N_std_S_allocator__C(__IntPtr __instance);

            [SuppressUnmanagedCodeSecurity, DllImport("Std-symbols", EntryPoint = "_ZNSaIcED2Ev", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void dtorc__N_std_S_allocator__C(__IntPtr __instance);
        }
    }

    public unsafe partial class Allocator<_Tp> : IDisposable
    {
        public __IntPtr __Instance { get; protected set; }

        internal static readonly new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.Allocator<_Tp>> NativeToManagedMap =
            new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.Allocator<_Tp>>();

        internal static void __RecordNativeToManagedMapping(IntPtr native, global::Std.Allocator<_Tp> managed)
        {
            NativeToManagedMap[native] = managed;
        }

        internal static bool __TryGetNativeToManagedMapping(IntPtr native, out global::Std.Allocator<_Tp> managed)
        {
    
            return NativeToManagedMap.TryGetValue(native, out managed);
        }

        protected bool __ownsNativeInstance;

        internal static Allocator<_Tp> __CreateInstance(__IntPtr native, bool skipVTables = false)
        {
            if (native == __IntPtr.Zero)
                return null;
            return new Allocator<_Tp>(native.ToPointer(), skipVTables);
        }

        internal static Allocator<_Tp> __GetOrCreateInstance(__IntPtr native, bool saveInstance = false, bool skipVTables = false)
        {
            if (native == __IntPtr.Zero)
                return null;
            if (__TryGetNativeToManagedMapping(native, out var managed))
                return (Allocator<_Tp>)managed;
            var result = __CreateInstance(native, skipVTables);
            if (saveInstance)
                __RecordNativeToManagedMapping(native, result);
            return result;
        }

        internal static Allocator<_Tp> __CreateInstance(global::Std.Allocator.__Internal native, bool skipVTables = false)
        {
            return new Allocator<_Tp>(native, skipVTables);
        }

        private static void* __CopyValue(global::Std.Allocator.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::Std.Allocator.__Internal));
            *(global::Std.Allocator.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private Allocator(global::Std.Allocator.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            __RecordNativeToManagedMapping(__Instance, this);
        }

        protected Allocator(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new __IntPtr(native);
        }

        public Allocator()
        {
            var ___Tp = typeof(_Tp);
            if (___Tp.IsAssignableFrom(typeof(sbyte)))
            {
                __Instance = Marshal.AllocHGlobal(sizeof(global::Std.Allocator.__Internal));
                __ownsNativeInstance = true;
                __RecordNativeToManagedMapping(__Instance, this);
                global::Std.Allocator.__Internal.ctorc__N_std_S_allocator__C(__Instance);
                return;
            }
            throw new ArgumentOutOfRangeException("_Tp", string.Join(", ", new[] { typeof(_Tp).FullName }), "global::Std.Allocator<_Tp> maps a C++ template class and therefore it only supports a limited set of types and their subclasses: <sbyte>.");
        }

        public void Dispose()
        {
            Dispose(disposing: true, callNativeDtor: __ownsNativeInstance);
        }

        partial void DisposePartial(bool disposing);

        internal protected virtual void Dispose(bool disposing, bool callNativeDtor)
        {
            if (__Instance == IntPtr.Zero)
                return;
            NativeToManagedMap.TryRemove(__Instance, out _);
            DisposePartial(disposing);
            if (callNativeDtor)
            {
                var ___Tp = typeof(_Tp);
                if (___Tp.IsAssignableFrom(typeof(sbyte)))
                {
                    global::Std.Allocator.__Internal.dtorc__N_std_S_allocator__C(__Instance);
                    return;
                }
                throw new ArgumentOutOfRangeException("_Tp", string.Join(", ", new[] { typeof(_Tp).FullName }), "global::Std.Allocator<_Tp> maps a C++ template class and therefore it only supports a limited set of types and their subclasses: <sbyte>.");
            }
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }
    }
}

namespace Std
{
    namespace Vector
    {
        [StructLayout(LayoutKind.Sequential, Size = 24)]
        public unsafe partial struct __Internal
        {
            internal global::Std.VectorBase.VectorImpl.__Internal _M_impl;
        }
    }

    namespace VectorBase
    {
        [StructLayout(LayoutKind.Sequential, Size = 24)]
        public unsafe partial struct __Internal
        {
            internal global::Std.VectorBase.VectorImpl.__Internal _M_impl;
        }

        namespace VectorImpl
        {
            [StructLayout(LayoutKind.Sequential, Size = 24)]
            public unsafe partial struct __Internal
            {
                internal __IntPtr _M_start;
                internal __IntPtr _M_finish;
                internal __IntPtr _M_end_of_storage;
            }

        }

        namespace VectorImplData
        {
            [StructLayout(LayoutKind.Sequential, Size = 24)]
            public unsafe partial struct __Internal
            {
                internal __IntPtr _M_start;
                internal __IntPtr _M_finish;
                internal __IntPtr _M_end_of_storage;
            }
        }

    }
}

namespace Std
{
    namespace Less
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public unsafe partial struct __Internal
        {
        }
    }
}

namespace Std
{
    public enum RbTreeColor : uint
    {
    }

    public unsafe partial class RbTreeNodeBase
    {
        [StructLayout(LayoutKind.Sequential, Size = 32)]
        public partial struct __Internal
        {
            internal global::Std.RbTreeColor _M_color;
            internal __IntPtr _M_parent;
            internal __IntPtr _M_left;
            internal __IntPtr _M_right;
        }
    }
}

namespace GnuCxx
{
}

namespace Std
{
}

namespace Std
{
}

namespace Std
{
    namespace CharTraits
    {
        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public unsafe partial struct __Internal
        {
        }
    }

    public unsafe partial class CharTraits<_CharT> : IDisposable
    {
        public __IntPtr __Instance { get; protected set; }

        internal static readonly new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.CharTraits<_CharT>> NativeToManagedMap =
            new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.CharTraits<_CharT>>();

        internal static void __RecordNativeToManagedMapping(IntPtr native, global::Std.CharTraits<_CharT> managed)
        {
            NativeToManagedMap[native] = managed;
        }

        internal static bool __TryGetNativeToManagedMapping(IntPtr native, out global::Std.CharTraits<_CharT> managed)
        {
    
            return NativeToManagedMap.TryGetValue(native, out managed);
        }

        protected bool __ownsNativeInstance;

        internal static CharTraits<_CharT> __CreateInstance(__IntPtr native, bool skipVTables = false)
        {
            if (native == __IntPtr.Zero)
                return null;
            return new CharTraits<_CharT>(native.ToPointer(), skipVTables);
        }

        internal static CharTraits<_CharT> __GetOrCreateInstance(__IntPtr native, bool saveInstance = false, bool skipVTables = false)
        {
            if (native == __IntPtr.Zero)
                return null;
            if (__TryGetNativeToManagedMapping(native, out var managed))
                return (CharTraits<_CharT>)managed;
            var result = __CreateInstance(native, skipVTables);
            if (saveInstance)
                __RecordNativeToManagedMapping(native, result);
            return result;
        }

        internal static CharTraits<_CharT> __CreateInstance(global::Std.CharTraits.__Internal native, bool skipVTables = false)
        {
            return new CharTraits<_CharT>(native, skipVTables);
        }

        private static void* __CopyValue(global::Std.CharTraits.__Internal native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::Std.CharTraits.__Internal));
            *(global::Std.CharTraits.__Internal*) ret = native;
            return ret.ToPointer();
        }

        private CharTraits(global::Std.CharTraits.__Internal native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            __RecordNativeToManagedMapping(__Instance, this);
        }

        protected CharTraits(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new __IntPtr(native);
        }

        public void Dispose()
        {
            Dispose(disposing: true, callNativeDtor: __ownsNativeInstance);
        }

        partial void DisposePartial(bool disposing);

        internal protected virtual void Dispose(bool disposing, bool callNativeDtor)
        {
            if (__Instance == IntPtr.Zero)
                return;
            NativeToManagedMap.TryRemove(__Instance, out _);
            DisposePartial(disposing);
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }
    }
}

namespace Std
{
    namespace BasicString
    {
        [StructLayout(LayoutKind.Explicit, Size = 32)]
        public unsafe partial struct __Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C
        {
            [FieldOffset(0)]
            internal global::Std.BasicString.AllocHider.__Internal _M_dataplus;

            [FieldOffset(8)]
            internal ulong _M_string_length;

            [FieldOffset(16)]
            internal fixed sbyte _M_local_buf[16];

            [FieldOffset(16)]
            internal ulong _M_allocated_capacity;

            [SuppressUnmanagedCodeSecurity, DllImport("Std-symbols", EntryPoint = "_ZNSt7__cxx1112basic_stringIcSt11char_traitsIcESaIcEEC2Ev", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void ctorc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C(__IntPtr __instance);

            [SuppressUnmanagedCodeSecurity, DllImport("Std-symbols", EntryPoint = "_ZNSt7__cxx1112basic_stringIcSt11char_traitsIcESaIcEED2Ev", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern void dtorc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C(__IntPtr __instance);
        }

        namespace AllocHider
        {
            [StructLayout(LayoutKind.Sequential, Size = 8)]
            public unsafe partial struct __Internal
            {
                internal __IntPtr _M_p;
            }

        }

        namespace _0
        {
            [StructLayout(LayoutKind.Explicit, Size = 16)]
            public unsafe partial struct __Internal
            {
                [FieldOffset(0)]
                internal fixed sbyte _M_local_buf[16];

                [FieldOffset(0)]
                internal ulong _M_allocated_capacity;
            }
        }

    }

    public unsafe partial class BasicString<_CharT, _Traits, _Alloc> : IDisposable
    {
        public __IntPtr __Instance { get; protected set; }

        internal static readonly new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.BasicString<_CharT, _Traits, _Alloc>> NativeToManagedMap =
            new global::System.Collections.Concurrent.ConcurrentDictionary<IntPtr, global::Std.BasicString<_CharT, _Traits, _Alloc>>();

        internal static void __RecordNativeToManagedMapping(IntPtr native, global::Std.BasicString<_CharT, _Traits, _Alloc> managed)
        {
            NativeToManagedMap[native] = managed;
        }

        internal static bool __TryGetNativeToManagedMapping(IntPtr native, out global::Std.BasicString<_CharT, _Traits, _Alloc> managed)
        {
    
            return NativeToManagedMap.TryGetValue(native, out managed);
        }

        protected bool __ownsNativeInstance;

        internal static BasicString<_CharT, _Traits, _Alloc> __CreateInstance(__IntPtr native, bool skipVTables = false)
        {
            if (native == __IntPtr.Zero)
                return null;
            return new BasicString<_CharT, _Traits, _Alloc>(native.ToPointer(), skipVTables);
        }

        internal static BasicString<_CharT, _Traits, _Alloc> __GetOrCreateInstance(__IntPtr native, bool saveInstance = false, bool skipVTables = false)
        {
            if (native == __IntPtr.Zero)
                return null;
            if (__TryGetNativeToManagedMapping(native, out var managed))
                return (BasicString<_CharT, _Traits, _Alloc>)managed;
            var result = __CreateInstance(native, skipVTables);
            if (saveInstance)
                __RecordNativeToManagedMapping(native, result);
            return result;
        }

        internal static BasicString<_CharT, _Traits, _Alloc> __CreateInstance(global::Std.BasicString.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C native, bool skipVTables = false)
        {
            return new BasicString<_CharT, _Traits, _Alloc>(native, skipVTables);
        }

        private static void* __CopyValue(global::Std.BasicString.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C native)
        {
            var ret = Marshal.AllocHGlobal(sizeof(global::Std.BasicString.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C));
            global::Std.BasicString.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C
            .ctorc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C(ret);                
            *(global::Std.BasicString.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C*) ret = native;
            return ret.ToPointer();
        }

        private BasicString(global::Std.BasicString.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C native, bool skipVTables = false)
            : this(__CopyValue(native), skipVTables)
        {
            __ownsNativeInstance = true;
            __RecordNativeToManagedMapping(__Instance, this);
        }

        protected BasicString(void* native, bool skipVTables = false)
        {
            if (native == null)
                return;
            __Instance = new __IntPtr(native);
        }

        public BasicString()
        {
            var ___CharT = typeof(_CharT);
            var ___Traits = typeof(_Traits);
            var ___Alloc = typeof(_Alloc);
            if (___CharT.IsAssignableFrom(typeof(sbyte)) && ___Traits.IsAssignableFrom(typeof(global::Std.CharTraits<sbyte>)) && ___Alloc.IsAssignableFrom(typeof(global::Std.Allocator<sbyte>)))
            {
                __Instance = Marshal.AllocHGlobal(sizeof(global::Std.BasicString.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C));
                __ownsNativeInstance = true;
                __RecordNativeToManagedMapping(__Instance, this);
                global::Std.BasicString.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C.ctorc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C(__Instance);
                return;
            }
            throw new ArgumentOutOfRangeException("_CharT, _Traits, _Alloc", string.Join(", ", new[] { typeof(_CharT).FullName, typeof(_Traits).FullName, typeof(_Alloc).FullName }), "global::Std.BasicString<_CharT, _Traits, _Alloc> maps a C++ template class and therefore it only supports a limited set of types and their subclasses: <sbyte, global::Std.CharTraits<sbyte>, global::Std.Allocator<sbyte>>.");
        }

        public void Dispose()
        {
            Dispose(disposing: true, callNativeDtor: __ownsNativeInstance);
        }

        partial void DisposePartial(bool disposing);

        internal protected virtual void Dispose(bool disposing, bool callNativeDtor)
        {
            if (__Instance == IntPtr.Zero)
                return;
            NativeToManagedMap.TryRemove(__Instance, out _);
            DisposePartial(disposing);
            if (callNativeDtor)
            {
                var ___CharT = typeof(_CharT);
                var ___Traits = typeof(_Traits);
                var ___Alloc = typeof(_Alloc);
                if (___CharT.IsAssignableFrom(typeof(sbyte)) && ___Traits.IsAssignableFrom(typeof(global::Std.CharTraits<sbyte>)) && ___Alloc.IsAssignableFrom(typeof(global::Std.Allocator<sbyte>)))
                {
                    global::Std.BasicString.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C.dtorc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C(__Instance);
                    return;
                }
                throw new ArgumentOutOfRangeException("_CharT, _Traits, _Alloc", string.Join(", ", new[] { typeof(_CharT).FullName, typeof(_Traits).FullName, typeof(_Alloc).FullName }), "global::Std.BasicString<_CharT, _Traits, _Alloc> maps a C++ template class and therefore it only supports a limited set of types and their subclasses: <sbyte, global::Std.CharTraits<sbyte>, global::Std.Allocator<sbyte>>.");
            }
            if (__ownsNativeInstance)
                Marshal.FreeHGlobal(__Instance);
            __Instance = IntPtr.Zero;
        }
    }

    public unsafe static partial class BasicStringExtensions
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity, DllImport("Std-symbols", EntryPoint = "_ZNSt7__cxx1112basic_stringIcSt11char_traitsIcESaIcEE6assignEPKc", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern __IntPtr Assign(__IntPtr __instance, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CppSharp.Runtime.UTF8Marshaller))] string __s);

            [SuppressUnmanagedCodeSecurity, DllImport("Std-symbols", EntryPoint = "_ZNKSt7__cxx1112basic_stringIcSt11char_traitsIcESaIcEE4dataEv", CallingConvention = __CallingConvention.Cdecl)]
            internal static extern __IntPtr Data(__IntPtr __instance);
        }

        public static global::Std.BasicString<sbyte, global::Std.CharTraits<sbyte>, global::Std.Allocator<sbyte>> Assign(this global::Std.BasicString<sbyte, global::Std.CharTraits<sbyte>, global::Std.Allocator<sbyte>> @this, string __s)
        {
            var __arg0 = @this is null ? __IntPtr.Zero : @this.__Instance;
            var ___ret = __Internal.Assign(__arg0, __s);
            var __result0 = global::Std.BasicString<sbyte, global::Std.CharTraits<sbyte>, global::Std.Allocator<sbyte>>.__GetOrCreateInstance(___ret, false);
            return __result0;
        }

        public static string Data(this global::Std.BasicString<sbyte, global::Std.CharTraits<sbyte>, global::Std.Allocator<sbyte>> @this)
        {
            var __arg0 = @this is null ? __IntPtr.Zero : @this.__Instance;
            var ___ret = __Internal.Data(__arg0);
            return CppSharp.Runtime.MarshalUtil.GetString(global::System.Text.Encoding.UTF8, ___ret);
        }
    }
}

namespace Std
{
}
