using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Core.Helpers
{
    public static class Extensions
    {
        /// <summary>
        /// Метод получения описания поля перечисления
        /// </summary>
        /// <param name="source">Пользовательское перечисление</param>
        /// <returns>Описание поля</returns>
        public static string GetDescription(this Enum source)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }

            FieldInfo fi = source.GetType().GetField(source.ToString());
            if(fi != null)
            {
                DescriptionAttribute attribute = fi.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;
                return attribute.Description;
            }
            else
            {
                throw new ArgumentNullException("fi");
            }
        }

        /// <summary>
        /// Преобразование массива байтов в HEX строку
        /// </summary>
        /// <param name="source">Массив байтов</param>
        /// <returns>HEX строка</returns>
        public static string ToHexString(this byte[] source)
        {
            StringBuilder sb = new StringBuilder(source.Length * 3);
            foreach (byte b in source)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            }

            return sb.ToString().ToUpper();
        }
    }
}
