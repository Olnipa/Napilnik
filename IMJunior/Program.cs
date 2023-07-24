namespace IMJunior
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderForm = new OrderForm();
            var paymentSystemFactory = new PaymentSystemFactory();

            string systemId = orderForm.ShowForm();

            IPaymentSystem paymentSystem = paymentSystemFactory.CreatePaymentSystem(systemId);

            if (paymentSystem != null)
            {
                paymentSystem.Connect();
                paymentSystem.ShowPaymentResult();
            }
            else
            {
                Console.WriteLine($"Платежной системы с ID: {systemId} не найдено.");
            }
        }
    }

    public class OrderForm
    {
        public string ShowForm()
        {
            Console.WriteLine("Мы принимаем: QIWI, WebMoney, Card");

            //симуляция веб интерфейса
            Console.WriteLine("Какой системой вы хотите совершить оплату?");
            return Console.ReadLine();
        }
    }

    internal interface IPaymentSystem
    {
        public void Connect();
        public void ShowPaymentResult();
    }

    internal class QIWI : IPaymentSystem
    {
        private bool _isPaymentSuccessfull;

        public void Connect()
        {
            Console.WriteLine("Перевод на страницу QIWI...");
            _isPaymentSuccessfull = true;
        }

        public void ShowPaymentResult()
        {
            Console.WriteLine("Проверка платежа через QIWI...");

            if (_isPaymentSuccessfull)
                Console.WriteLine("Оплата через QIWI прошла успешно!");
            else
                Console.WriteLine("Оплата не принята.");
        }
    }

    internal class Card : IPaymentSystem
    {
        private bool _isPaymentSuccessfull;

        public void Connect()
        {
            Console.WriteLine("Вызов API банка эмитера карты Card...");
            _isPaymentSuccessfull = true;
        }

        public void ShowPaymentResult()
        {
            Console.WriteLine("Проверка платежа через Card...");

            if (_isPaymentSuccessfull)
                Console.WriteLine("Оплата через Card прошла успешно!");
            else
                Console.WriteLine("Оплата не принята.");
        }
    }

    internal class WebMoney : IPaymentSystem
    {
        private bool _isPaymentSuccessfull;

        public void Connect()
        {
            Console.WriteLine("Вызов API WebMoney...");
            _isPaymentSuccessfull = true;
        }

        public void ShowPaymentResult()
        {
            Console.WriteLine("Проверка платежа через WebMoney...");

            if (_isPaymentSuccessfull)
                Console.WriteLine("Оплата через WebMoney прошла успешно!");
            else
                Console.WriteLine("Оплата не принята.");
        }
    }

    internal class PaymentSystemFactory
    {
        private const string QIWIID = "qiwi";
        private const string WebMoneyID = "webmoney";
        private const string CardID = "card";

        public IPaymentSystem CreatePaymentSystem(string ID)
        {
            string lowerID = ID.ToLower();

            if (lowerID == QIWIID)
                return new QIWI();
            else if (lowerID == WebMoneyID)
                return new WebMoney();
            else if (lowerID == CardID)
                return new Card();
            else
                return null;
        }
    }
}