
namespace ATM
{
    abstract class BaseATM : ILog
    {
        List<int> bills_amount = new List<int>() { 10, 10, 10, 10 };
        List<int> bills = new List<int>() {5000, 1000, 500, 100};
        int[] bills_out = new int[4];
        public BaseATM() { }
        public virtual void Log(string message) { }
        private void Deposit(int a, int b, int c, int d)
        {
            bills_amount.Add(d);
            bills_amount.Add(c);
            bills_amount.Add(b);
            bills_amount.Add(a);
        }
        private void Withdraw(int money)
        {
            string s = "Выдача ";
            Array.Clear(bills_out);
            if (money < 100)
            {
                Log("Банкомат не может выдать сумму меньше 100");
                return;
            }
            if (money % 100 > 0)
            {
                Log("Банкомат выдает суммы кратные 100. Ошибка.");
                return;
            }
            int check_all_money = (bills_amount[3] * 100) + (bills_amount[2] * 500) + (bills_amount[1] * 1000) + (bills_amount[0] * 5000);
            if (check_all_money < money)
            {
                Log("В банкомате нет такого количества денег.");
                return;
            }
            Counting(money);
            for (int i = 0; i < 4; i++)
            {
                if (bills_out[i] == 0) continue;
                if (i == 0) s += $"{" 5000: "}{bills_out[i]}{"; "}";
                if (i == 1) s += $"{" 1000: "}{bills_out[i]}{"; "}";
                if (i == 2) s += $"{" 500: "}{bills_out[i]}{"; "}";
                if (i == 3) s += $"{" 100: "}{bills_out[i]}{"; "}";
            }
            Log(s);
        }
        private void Counting(int money)
        {
            int i = 0;
            foreach (var bill in bills)
            {
                while (bills_amount[i] > 0)
                {
                    if (money - bill >= 0)
                    {
                        money = money - bill;
                        bills_amount[i]--;
                        bills_out[i]++;
                    }
                    else { break; }
                }
                i++;
            }
        }
        public void Withdraw_Call(int money)
        {
            Withdraw(money);
        }
        public void Deposit_Call(int a, int b, int c, int d)
        {
            Deposit(a, b, c, d);
        }
    }
    interface ILog
    {
        public void Log(string message);
    }
}
