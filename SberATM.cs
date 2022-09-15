
namespace ATM
{
    internal class SberATM : BaseATM
    {
        public SberATM() { }
        public override void Log(string message)
        {
            Console.WriteLine("[" + DateTime.Now + "]" + "  " + message);
        }
    }
}
