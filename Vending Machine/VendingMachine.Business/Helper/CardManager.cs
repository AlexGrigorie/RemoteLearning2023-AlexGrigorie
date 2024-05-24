namespace VendingMachine.Business
{
    internal static class CardManager
    {
        public static bool CardValidator(string cardNumber)
        {
            int totalSum = ToInt(cardNumber[cardNumber.Length - 1]);

            for (int i = cardNumber.Length - 2; i >= 0; i--)
            {
                int sum;
                int digit = ToInt(cardNumber[i]);

                if (i % 2 == 0)
                {
                    digit *= 2;
                }
                sum = digit / 10 + digit % 10;
                totalSum += sum;
            }

            return totalSum % 10 == 0;
        }
        private static int ToInt(char c)
        {
            return c - '0';
        }
    }
}
