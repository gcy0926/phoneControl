using System.Text;

namespace InOut.Utils
{
    public static class StringUtil
    {
        public static byte[] GetBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string ParseString(this byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return string.Empty;
            return Encoding.UTF8.GetString(bytes);
        }

        public static int Len(this string str)
        {
            return str.GetBytes().Length;
        }
    }
}
