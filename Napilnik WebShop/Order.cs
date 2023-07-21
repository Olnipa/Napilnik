using System.Text;

namespace Napilnik_AppleStore
{
    internal class Order
    {
        private const int DefaultLinkLenght = 15;
        private const string Symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ/.1234567890";
        private const string LinkMessage = "Ссылка для оплаты: ";

        private readonly Random random = new Random();

        public string Paylink { get => GetRandomString(); }

        private string GetRandomString()
        {
            StringBuilder stringBuilder = new StringBuilder(LinkMessage);

            for (int i = 0; i < DefaultLinkLenght; i++)
            {
                stringBuilder.Append(Symbols[random.Next(0, Symbols.Length)]);
            }

            stringBuilder.Append('\n');

            return stringBuilder.ToString();
        }
    }
}
