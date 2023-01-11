using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CppSharp.Runtime
{
    // HACK: .NET Standard 2.0 which we use in auto-building to support .NET Framework, lacks UnmanagedType.LPUTF8Str
    public class ASCIIMarshaller : ICustomMarshaler
    {
        int m_size = -1;
        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
            => Marshal.FreeHGlobal(pNativeData);

        public int GetNativeDataSize() {

            return m_size;

        }

        public IntPtr MarshalManagedToNative(object managedObj)
        {
            if (managedObj == null)
                return IntPtr.Zero;
            if (!(managedObj is string))
                throw new MarshalDirectiveException(
                    "UTF8Marshaler must be used on a string.");

            // not null terminated
            IntPtr buffer = Marshal.StringToHGlobalAnsi((string)managedObj);
            return buffer;
        }

        public unsafe object MarshalNativeToManaged(IntPtr str)
        {
            if (str == IntPtr.Zero)
                return null;

            var strAnsi = Marshal.PtrToStringAnsi(str);

            return strAnsi;
        }

        public static ICustomMarshaler GetInstance(string pstrCookie)
        {
            if (marshaler == null)
                marshaler = new ASCIIMarshaller();
            return marshaler;
        }

        private static ASCIIMarshaller marshaler;
    }
}
