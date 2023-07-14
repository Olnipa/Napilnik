using System;

namespace Napilnik_AppleStore
{
    internal class Warehouse
    {
        private readonly Dictionary<Good, int> _goods = new Dictionary<Good, int>();

        public void Delive(Good good, int quantity)
        {
            if (quantity < 0)
                throw new Exception("Количество должно быть больше или равно 0");

            if (_goods.ContainsKey(good))
                _goods[good] += quantity;
            else
                _goods.Add(good, quantity);
        }

        public void TakeGood(Good good, int quantity)
        {
            if (_goods.ContainsKey(good) == false || _goods[good] < quantity)
                throw new Exception($"Невозможно получить {good.Name}, так как на складе нет или недостаточно этого товара.");

            _goods[good] -= quantity;
        }

        public bool TryGetQuantityOfGood(Good good, out int quantity)
        {
            if (_goods.ContainsKey(good))
            {
                quantity = _goods[good];
                return true;
            }
            else
            {
                quantity = 0;
                return false;
            }
        }

        public void WriteGoodsOnStock()
        {
            int index = 1;
            Console.WriteLine("Товаров на складе:");

            foreach (KeyValuePair<Good, int> good in _goods)
            {
                Console.WriteLine($"{index}. {good.Key.Name} - {good.Value}");
                index++;
            }
        }
    }
}
