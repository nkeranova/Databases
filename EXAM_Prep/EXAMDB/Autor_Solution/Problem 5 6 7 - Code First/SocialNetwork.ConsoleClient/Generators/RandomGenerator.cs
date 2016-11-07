namespace SocialNetwork.ConsoleClient.Generator
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This class is only used for generating the test files. It is not part of the solution to the task.
    /// </summary>
    public static class RandomGenerator
    {
        private static readonly char[] Alphabet;

        private static Random random = new Random();

        static RandomGenerator()
        {
            Alphabet =
                Enumerable.Range('A', 26).Select(c => (char)c).Concat(
                Enumerable.Range('a', 26).Select(c => (char)c).Concat(
                Enumerable.Range('0', 10).Select(c => (char)c)))
                .ToArray();
        }

        public static bool RandomBool()
        {
            return RandomNumber(0, 1) == 1;
        }

        public static int RandomNumber(int min = 0, int max = int.MaxValue / 2)
        {
            if (min > max)
            {
                return random.Next(max, min + 1);
            }

            return random.Next(min, max + 1);
        }

        public static string RandomString(int minLength = 0, int maxLength = int.MaxValue / 2)
        {
            var length = RandomNumber(minLength, maxLength);
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(Alphabet[random.Next(0, Alphabet.Length)]);
            }

            return result.ToString();
        }

        public static DateTime RandomDateTime(DateTime? after = null, DateTime? before = null)
        {
            var afterValue = after ?? new DateTime(2010, 1, 1, 0, 0, 0);
            var beforeValue = before ?? DateTime.Now.AddDays(-60);

            var second = RandomNumber(afterValue.Second, beforeValue.Second);
            var minute = RandomNumber(afterValue.Minute, beforeValue.Minute);
            var hour = RandomNumber(afterValue.Hour, beforeValue.Hour);
            var day = RandomNumber(afterValue.Day, beforeValue.Day);
            var month = RandomNumber(afterValue.Month, beforeValue.Month);
            var year = RandomNumber(afterValue.Year, beforeValue.Year);

            if (day > 28)
            {
                day = 28;
            }

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
