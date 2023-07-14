namespace Napilnik_AppleStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Good iPhone12 = new Good("IPhone 12");
            Good iPhone11 = new Good("IPhone 11");

            Warehouse _warehouse = new Warehouse();
            Shop _shop = new Shop(_warehouse);

            Console.WriteLine($"Добро пожаловать в Apple Store!\n\n");

            _warehouse.Delive(iPhone12, 10);
            _warehouse.Delive(iPhone11, 1);

            _warehouse.WriteGoodsOnStock(); //Вывод всех товаров на складе с их остатком

            Cart cart = _shop.Cart();

            cart.Add(iPhone12, 4);
            Console.ReadLine();
            cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе
            Console.ReadLine();

            cart.WriteGoodsInCart(); //Вывод всех товаров в корзине
            Console.ReadLine();

            Console.WriteLine(cart.Order().Paylink);

            cart.Add(iPhone12, 9); //Ошибка, после заказа со склада убираются заказанные товары
            Console.ReadLine();
        }
    }
}