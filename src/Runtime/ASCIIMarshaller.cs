using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CppSharp.Runtime
{
    // HACK: .NET Standard 2.0 which we use in auto-building to support .NET Framework, lacks UnmanagedType.LPUTF8Str
    public class ASCIIMarshaller : ICustomMarshaler
    {
        public readonly static Encoding ANSI = Encoding.GetEncoding("GB18030");
        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
            => Marshal.FreeHGlobal(pNativeData);

        public int GetNativeDataSize() => -1;

        public static IntPtr MarshalManagedToNativeANSI(object managedObj){
            if (managedObj == null)
                return IntPtr.Zero;
            if (!(managedObj is string))
                throw new MarshalDirectiveException(
                    "UTF8Marshaler must be used on a string.");

            // not null terminated
            byte[] strbuf = ANSI.GetBytes((string)managedObj);
            IntPtr buffer = Marshal.AllocHGlobal(strbuf.Length + 1);
            Marshal.Copy(strbuf, 0, buffer, strbuf.Length);

            // write the terminating null
            Marshal.WriteByte(buffer + strbuf.Length, 0);
            return buffer;
        }

        public IntPtr MarshalManagedToNative(object managedObj)
        {
            return MarshalManagedToNativeANSI(managedObj);
        }

        public unsafe object MarshalNativeToManaged(IntPtr str)
        {
            return NativeANSIToMarshalManaged(str);
        }

        public static unsafe object NativeANSIToMarshalManaged(IntPtr str)
        {
            if (str == IntPtr.Zero)
                return null;

            int byteCount = 0;
            var str8 = (byte*)str;
            while (*(str8++) != 0) byteCount += sizeof(byte);

            return ANSI.GetString((byte*)str, byteCount);
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
