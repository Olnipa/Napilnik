using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string ID;
        string Amount;

        int minAmount = 1;
        int maxAmount = 100000;
        int minID = 100000;
        int maxID = 999999;

        AbstractPaymentSystem paySystem1 = new PaymentSystem1();
        AbstractPaymentSystem paySystem2 = new PaymentSystem2();
        AbstractPaymentSystem paySystem3 = new PaymentSystem3();

        Order randomOrder = new Order(GetRandomNumber(minID, maxID), GetRandomNumber(minAmount, maxAmount), Currency.RUB);
        string payLink1 = paySystem1.GetPayingLink(randomOrder);
        

        //Выведите платёжные ссылки для трёх разных систем платежа: 
        //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
        //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
        //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}
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

abstract class AbstractPaymentSystem : IPaymentSystem
{
    public string DomainAddress { get; protected set; }

    public abstract string GetPayingLink(Order order);
}

class PaymentSystem1 : AbstractPaymentSystem
{
    public PaymentSystem1(string domain = "pay.system1.ru/order?")
    {
        DomainAddress = domain;
    }

    //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}

    public override string GetPayingLink(Order order)
    {
        StringBuilder stringBuilder = new StringBuilder(DomainAddress);
        string amount = $"amount=" + order.Amount;
        string currency = Convert.ToString(order.Currency);
        string hash = ComputeMD5(Convert.ToString(order.Id));

        stringBuilder.Append(amount);
        stringBuilder.Append(amount);
        stringBuilder.Append(amount);

        return 
    }

    private string ComputeMD5(string s)
    {
        using (MD5 md5 = MD5.Create())
        {
            return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(s))).Replace("-", "");
        }
    }
}

class PaymentSystem2 : AbstractPaymentSystem
{
    public PaymentSystem2(string domain = "order.system2.ru/pay?")
    {
        DomainAddress = domain;
    }

    //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
    
    public override string GetPayingLink(Order order)
    {
        throw new NotImplementedException();
    }
}

class PaymentSystem3 : AbstractPaymentSystem
{
    public PaymentSystem3(string domain = "system3.com/pay?")
    {
        DomainAddress = domain;
    }

    //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}

    public override string GetPayingLink(Order order)
    {
        throw new NotImplementedException();
    }
}