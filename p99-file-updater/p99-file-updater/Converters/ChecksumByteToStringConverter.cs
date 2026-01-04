using System;
using System.Text;
using Windows.UI.Xaml.Data;

namespace p99FileUpdater.Converters
{
    internal class SHA256ChecksumByteToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value == null)
                return String.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in (byte[])value)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            const int sha256strlength = 32;
            string strValue = (string)value;
            char[] str = strValue.ToCharArray();
            try
            {
                if (str.Length != sha256strlength)
                    throw new ArgumentException($"str value cast is not of length {sha256strlength} but {str.Length}");
                byte[] checksum = new byte[sha256strlength];
                for (int i = 0; i < sha256strlength; i++)
                {
                    byte b = System.Convert.ToByte(String.Concat(str[i * 2], str[(i * 2) + 1]), sha256strlength / 2);
                    checksum[i] = b;
                }
                return checksum;
            }
            catch (Exception ex)
            {
                {
                    return null;
                }
            }
        }
    }
}
