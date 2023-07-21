internal class PaymentSystem1 : IPaymentSystem
{
    public string GetPayingLink(Order order)
    {
        string hash = Cryptography.ComputeMD5(Convert.ToString(order.Id));

        return $"pay.system1.ru/order?amount={order.Amount}{order.Currency}&hash={hash}";
    }
}
