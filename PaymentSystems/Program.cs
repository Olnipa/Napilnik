using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
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

    static private int GetRandomNumber(int min, int max)
    {
        Random random = new Random();

        return random.Next(min, max);
    }
}

public enum Currency
{
    RUB,
    USD
}

public class Order
{
    public readonly int Id;
    public readonly int Amount;
    public readonly Currency Currency;

    public Order(int id, int amount, Currency currency) => (Id, Amount, Currency) = (id, amount, currency);
}

public interface IPaymentSystem
{
    public string GetPayingLink(Order order);
}

class PaymentSystem1 : IPaymentSystem
{
    public string GetPayingLink(Order order)
    {
        string hash = Cryptography.ComputeMD5(Convert.ToString(order.Id));

        return $"pay.system1.ru/order?amount={order.Amount}{order.Currency}&hash={hash}";
    }
}

class PaymentSystem2 : IPaymentSystem
{
    public string GetPayingLink(Order order)
    {
        string hash = Cryptography.ComputeMD5(Convert.ToString(order.Id + order.Amount));

        return $"order.system2.ru/pay?hash={hash}";
    }
}

class PaymentSystem3 : IPaymentSystem
{
    private string _secretKey;

    public PaymentSystem3(string secretKey)
    {
        _secretKey = secretKey;
    }

    public string GetPayingLink(Order order)
    {
        string hash = Cryptography.ComputeSHA1(Convert.ToString(order.Amount + order.Id + _secretKey.ToString()));

        return $"system3.com/pay?amount={order.Amount}&curency={order.Currency}&hash={hash}";
    }
}

static class Cryptography
{
    public static string ComputeMD5(string text)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }

    public static string ComputeSHA1(string text)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }
}