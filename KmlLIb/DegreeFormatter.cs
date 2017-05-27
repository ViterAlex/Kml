using System;

namespace Kml
{
    /// <summary>
    /// Класс для форматирования числового значения градусов в 0°00'00".000
    /// </summary>
    public class DegreeFormatter : IFormatProvider, ICustomFormatter
    {
        #region Implementation of IFormatProvider

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        #endregion

        #region Implementation of ICustomFormatter

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is double) && !(arg is float) && !(arg is decimal)) return arg.ToString();
            if (format == null || format.ToLower().Equals("ns") || format.ToLower().Equals("we"))
            {
                return FromDouble((double)arg, format);
            }
            return arg.ToString();
        }

        #endregion

        /// <summary>
        /// Перевод в градусы, минуты, секунды и миллисекунды
        /// </summary>
        /// <param name="angleInDegrees">Значение в градусах</param>
        /// <param name="format">Долгота или широта. NS для широты, WE для долготы</param>
        private static string FromDouble(double angleInDegrees, string format)
        {
            while (angleInDegrees < -180.0)
                angleInDegrees += 360.0;

            while (angleInDegrees > 180.0)
                angleInDegrees -= 360.0;
            var isNeg = Math.Sign(angleInDegrees) < 0;
            angleInDegrees = Math.Abs(angleInDegrees);
            var degrees = (int)Math.Floor(angleInDegrees);
            var delta = angleInDegrees - degrees;
            var seconds = (int)Math.Floor(3600.0 * delta);
            seconds %= 60;
            var minutes = (int)Math.Floor(seconds / 60d);
            var milliseconds = (int)(1000.0 * (delta * 3600 - seconds));
            switch (format)
            {
                case "NS":
                    return string.Format("{0}°{1:00}'{2:00}\".{3} {4}", degrees, minutes, seconds, milliseconds, isNeg ? "Ю" : "С");
                case "WE":
                    return string.Format("{0}°{1:00}'{2:00}\".{3} {4}", degrees, minutes, seconds, milliseconds, isNeg ? "З" : "В");
                default:
                    return string.Format("{4}{0}°{1:00}'{2:00}\".{3}", degrees, minutes, seconds, milliseconds, isNeg ? "-" : "");
            }
        }
    }
}
