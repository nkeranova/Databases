using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySampleDataImporter.Importer
{
    public static class RandomGenerator
    {
        private static Random random = new Random();

        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static int GetRandomNumber(int min = 0, int max = int.MaxValue - 1)
        {
            return random.Next(min, max + 1);
        }

        public static string GetRandomString(int minLength = 0, int maxLength = int.MaxValue / 2)
        {
            var length = random.Next(minLength, maxLength);

            var result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                result.Append(Letters[random.Next(0, Letters.Length)]);
            }

            return result.ToString();
        }

        public static DateTime GetRandomDate(DateTime? after = null, DateTime? before = null)
        {
            var minDate = after ?? new DateTime(1950, 1, 1, 0, 0, 0); //DateTime.MinValue;

            var maxDate = before ?? new DateTime(2050, 12, 31, 23, 59, 59);

            var second = GetRandomNumber(minDate.Second, maxDate.Second);
            var minute = GetRandomNumber(minDate.Minute, maxDate.Minute);
            var hour = GetRandomNumber(minDate.Hour, maxDate.Hour);
            var day = GetRandomNumber(minDate.Day, maxDate.Day);
            var month = GetRandomNumber(minDate.Month, maxDate.Month);
            var year = GetRandomNumber(minDate.Year, maxDate.Year);

            if (day > 28)
            {
                day = 28;
            }

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}

