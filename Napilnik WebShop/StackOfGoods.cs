namespace Napilnik_AppleStore
{
    internal class StackOfGoods : IReadOnlyStackOfGoods
    {
        public Good Good { get; private set; }
        public int Quantity { get; private set; }

        public StackOfGoods(Good good, int quantity)
        {
            if(quantity >= 0)
            {
                Quantity = quantity;
                Good = good;
            }
            else
            {
                throw new Exception("Количество должно быть больше или равно 0");
            }
        }

        public void WriteGoodOnStock(int index)
        {
            Console.WriteLine($"{index}. {Good.Name} - {Quantity}");
        }

        public void Merge(StackOfGoods newStack)
        {
            if (newStack.Good != Good)
                throw new InvalidOperationException();

            Quantity += newStack.Quantity;
        }

        public void Remove(StackOfGoods newStack)
        {
            if (newStack.Good != Good)
                throw new InvalidOperationException();

            if (Quantity < newStack.Quantity)
                throw new InvalidOperationException();

            Quantity -= newStack.Quantity;
        }
    }
}
