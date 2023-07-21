internal class Order
{
    public Order(int id, int amount, Currency currency) => (Id, Amount, Currency) = (id, amount, currency);

    public int Id { get; private set; }

    public int Amount { get; private set; }

    public Currency Currency { get; private set; }
}