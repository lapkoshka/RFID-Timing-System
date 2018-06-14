using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
    }
}
