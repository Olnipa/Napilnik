internal class PaymentSystem2 : IPaymentSystem
{
    public string GetPayingLink(Order order)
    {
        string hash = Cryptography.ComputeMD5(Convert.ToString(order.Id + order.Amount));

        return $"order.system2.ru/pay?hash={hash}";
    }
}
