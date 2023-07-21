internal class PaymentSystem3 : IPaymentSystem
{
    private readonly string _secretKey;

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
