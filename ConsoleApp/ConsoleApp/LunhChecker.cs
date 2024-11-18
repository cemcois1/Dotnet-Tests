public static class LunhChecker
{
    public static void Check(string cardNumber)
    {
        var sum = 0;

        for (var index = 0; index < cardNumber.Length; index++)
        {
            var digit = cardNumber[index];
            var digitValue = int.Parse(digit.ToString());

            if (index%2 ==1)
            {
                digitValue *= 2;
                if (digitValue > 9)
                {
                    //ilk basamağı al
                    sum += 1 + digitValue % 10;
                }
            }
            else
            {
                sum += digitValue;
            }
        }

        if (sum % 10 == 0)
        {
            Console.WriteLine("Geçerli kart numarası");
        }
        else
        {
            Console.WriteLine($"Geçersiz kart numarası {sum}");
        }
    }
}