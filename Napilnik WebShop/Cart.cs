namespace Napilnik_AppleStore
{
    internal class Cart
    {
        private Warehouse _warehouse;

        private readonly Dictionary<Good, int> _goodsInCart = new Dictionary<Good, int>();

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void Add(Good good, int quantity)
        {
            try
            {
                if (_warehouse.TryGetQuantityOfGood(good, out int quantityInWarehouse) == false)
                    throw new Exception($"Ошибка. Товар {good.Name} на складе отсутствует.");

                if (quantityInWarehouse < quantity)
                    throw new Exception($"Ошибка. Вы запросили {quantity} шт. {good.Name}, но на складе только {quantityInWarehouse} шт.");

                _warehouse.TakeGood(good, quantity);

                if (_goodsInCart.ContainsKey(good))
                    _goodsInCart[good] += quantity;
                else
                    _goodsInCart.Add(good, quantity);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void WriteGoodsInCart()
        {
            int index = 1;
            Console.WriteLine("Товаров в корзине:");

            foreach (KeyValuePair<Good, int> good in _goodsInCart)
            {
                Console.WriteLine($"{index}. {good.Key.Name} - {good.Value}");
                index++;
            }
        }

        public Order Order()
        {
            return new Order();
        }
    }
}