using System.Text;

namespace Napilnik_AppleStore
{
    internal class Order
    {
        private Random random = new Random();

        private const int defaultLinkLenght = 15;
        private const string Symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ/.1234567890";
        private const string linkMessage = "Ссылка для оплаты: ";

        public IReadOnlyList<IReadOnlyStackOfGoods> OrderOfGoods { get; }
        public string Paylink { get => GetRandomString(); }

        public Order(IReadOnlyList<IReadOnlyStackOfGoods> stacksOfGoods)
        {
            OrderOfGoods = stacksOfGoods;
        }

        private string GetRandomString()
        {
            StringBuilder stringBuilder = new StringBuilder(linkMessage);

            for (int i = 0; i < defaultLinkLenght; i++)
            {
                stringBuilder.Append(Symbols[random.Next(0, Symbols.Length)]);
            }
            stringBuilder.Append("\n");
            return stringBuilder.ToString();
        }
    }
}
