using ATM;

internal class Program
{
    private static void Main(string[] args)
    {
        int money;
        List<BaseATM> list = new List<BaseATM>();
        list.Add(new SberATM());
        list.Add(new OnlineATM());
        while (true)
        {
            Console.WriteLine("Введите сумму, которую хотите вывести (не меньше 100).");
            while (!int.TryParse(Console.ReadLine(), out money))
            {
                list[0].Log("Ошибка ввода! Введите целое число");
                list[1].Log("Ошибка ввода! Введите целое число");
            }
            list[0].Withdraw_Call(money);
            list[1].Withdraw_Call(money);
            Console.WriteLine("Для завершения введите N, для продолжения Enter");
            if (Console.ReadLine() == "N") break;
        }
    }
}