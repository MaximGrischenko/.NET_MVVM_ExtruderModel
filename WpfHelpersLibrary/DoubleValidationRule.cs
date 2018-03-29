using System;
using System.Globalization;
using System.Windows.Controls;

namespace WpfHelpersLibrary
{
    public class DoubleValidationRule : ValidationRule
    {
        public double Max { get; set; }
        public double Min { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double val = 0;
            try
            {
                if (!string.IsNullOrEmpty((string)value))
                {
                    val = double.Parse((string)value);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Некорректный ввод данных: " + e.Message);
            }
            if ((val < this.Min) || (val > this.Max))
            {
                return new ValidationResult(false, "Введите значение в пределах: " + this.Min + " - " + this.Max);
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
