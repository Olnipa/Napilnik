namespace Napilnik_AppleStore
{
    internal class Warehouse
    {
        private readonly List<StackOfGoods> _warehouseGoods = new List<StackOfGoods>();

        public IReadOnlyList<IReadOnlyStackOfGoods> WarehouseStacks => _warehouseGoods;

        public void Delive(Good good, int quantity)
        {
            StackOfGoods newStack = new StackOfGoods(good, quantity);
            int intOfExistedStack = _warehouseGoods.FindIndex(stack => stack.Good == good);

            if (intOfExistedStack == -1)
                _warehouseGoods.Add(newStack);
            else
                _warehouseGoods[intOfExistedStack].Merge(newStack);
        }

        public void TakeGood(StackOfGoods stackOfGoods)
        {
            int intOfExistedStack = _warehouseGoods.FindIndex(stack => stack.Good == stackOfGoods.Good);

            if (intOfExistedStack == -1)
                throw new Exception($"Невозможно удалить {stackOfGoods.Good}, так как на складе нет этого товара.");

            _warehouseGoods[intOfExistedStack].Remove(stackOfGoods);
        }

        public void TakeGood(Good good, int quantity)
        {
            StackOfGoods newStack = new StackOfGoods(good, quantity);
            TakeGood(newStack);
        }

        public void WriteGoodsOnStock()
        {
            Console.WriteLine("Товаров на складе:");

            for (int i = 0; i < _warehouseGoods.Count; i++)
            {
                _warehouseGoods[i].WriteGoodOnStock(i + 1);
            }
        }
    }
}
