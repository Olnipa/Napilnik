namespace Napilnik_AppleStore
{
    internal class Cart
    {
        private Warehouse _warehouse;

        private readonly List<StackOfGoods> _cartStacks = new List<StackOfGoods>();

        public IReadOnlyList<IReadOnlyStackOfGoods> CartStacks => _cartStacks;

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void Add(Good good, int quantity)
        {
            try
            {
                StackOfGoods newStack = new StackOfGoods(good, quantity);

                IReadOnlyStackOfGoods? existedStackInWarehouse = _warehouse.WarehouseStacks.FirstOrDefault(stack => stack.Good == good);

                if (existedStackInWarehouse == null)
                    throw new Exception($"Ошибка. На складе отсутствует {good.Name}.");

                if (existedStackInWarehouse.Quantity < quantity)
                    throw new Exception($"Ошибка. Вы запросили {quantity} шт. {good.Name}, но на складе только {existedStackInWarehouse.Quantity} шт.");

                _warehouse.TakeGood(newStack);

                StackOfGoods? stackInCart = _cartStacks.FirstOrDefault(stack => stack.Good == good);

                if (stackInCart == null)
                    _cartStacks.Add(newStack);
                else
                    stackInCart.Merge(newStack);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteGoodsInCart()
        {
            Console.WriteLine("Товаров в корзине:");

            for (int i = 0; i < _cartStacks.Count; i++)
            {
                _cartStacks[i].WriteGoodOnStock(i + 1);
            }
        }

        public Order Order()
        {
            return new Order(CartStacks);
        }
    }
}