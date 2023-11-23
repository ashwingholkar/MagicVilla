using System.Xml.Serialization;

namespace MagicVilla_VillaAPI.Logger
{
    public interface ILogging
    {
        public void log(string message, string type);
    }
}
