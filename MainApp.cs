using System;

namespace EX13_2
{
    delegate int MyDelegate(int a);

    class Market
    {
        public event MyDelegate CustomerEvent;
      
        public void BuySomething(int CustomerNo)
        {
            if (CustomerNo == 30)
                CustomerEvent(CustomerNo);
        }
    }

    class MainApp
    {
        static int MyHandler(int customerNo)
        {
            Console.WriteLine($"축하합니다! {customerNo}번째 고객 이벤트에 당첨되셨습니다.");
            return 0; 
        }

        static void Main(string[] args)
        {
            Market market = new Market();
            market.CustomerEvent += new MyDelegate(MyHandler);

            for (int customerNo = 0; customerNo < 100; customerNo += 10)
                market.BuySomething(customerNo);
        }
    }
}