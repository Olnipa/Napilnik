public class Program
{
    private static void Main(string[] args)
    {
        int minAmount = 1;
        int maxAmount = 100000;
        int minID = 100000;
        int maxID = 999999;
        string secretKey = "OchenSecretKey";

        IPaymentSystem paySystem1 = new PaymentSystem1();
        IPaymentSystem paySystem2 = new PaymentSystem2();
        IPaymentSystem paySystem3 = new PaymentSystem3(secretKey);

        Order randomOrder = new Order(GetRandomNumber(minID, maxID), GetRandomNumber(minAmount, maxAmount), Currency.RUB);

        string payLink1 = paySystem1.GetPayingLink(randomOrder);
        string payLink2 = paySystem2.GetPayingLink(randomOrder);
        string payLink3 = paySystem3.GetPayingLink(randomOrder);

        Console.WriteLine(payLink1);
        Console.WriteLine(payLink2);
        Console.WriteLine(payLink3);

        Console.ReadLine();
    }

    private static int GetRandomNumber(int min, int max)
    {
        Random random = new Random();

        return random.Next(min, max);
    }
}