using System;
using System.Text;

namespace PDFManipulations.Common
{
    public class Utility
    {
        public static String ConvertImageURLToBase64(String url)
        {
            StringBuilder _sb = new StringBuilder();

            Byte[] _byte = System.IO.File.ReadAllBytes(url);

            _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

            return _sb.ToString();
        }

        public static String ConvertBase64ToImageURL(String value)
        {
            return Convert.FromBase64String(value).ToString(); 
        }
    }
}
