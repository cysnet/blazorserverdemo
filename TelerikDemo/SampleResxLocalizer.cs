using Telerik.Blazor.Services;
using TelerikDemo.Resources;

namespace TelerikDemo
{
    
    public class SampleResxLocalizer : ITelerikStringLocalizer
    {
        // this is the indexer you must implement
        public string this[string name]
        {
            get
            {
                return GetStringFromResource(name);
            }
        }

        // sample implementation - uses .resx files in the ~/Resources folder named TelerikMessages.<culture-locale>.resx
        public string GetStringFromResource(string key)
        {
            return TelerikMessages.ResourceManager.GetString(key, Resources.TelerikMessages.Culture); ;
        }
    }
}
