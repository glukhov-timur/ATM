
namespace ATM
{
    internal class OnlineATM : BaseATM
    {
        public override void Log(string message)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\Users\\TGluhov\\Desktop\\OnlineATM.txt", true);
            sw.WriteLine("[" + DateTime.Now + "]" + "  " + message);
            sw.Close();
        }
    }
}
