namespace MagicVilla_VillaAPI.Logger
{
    public class Logging : ILogging
    {
        public void log(string message, string type)
        {
            if(type =="error")
            {
                Console.WriteLine("Error -", message);
            }
            else 
            {
                Console.WriteLine(message);
            }
        }
    }
}
