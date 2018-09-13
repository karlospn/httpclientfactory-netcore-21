using System.Collections.Generic;

namespace StandAloneApp.Infra.Proxies
{
    public class WebApp2Dto
    {
        public WebApp2Dto()
        {
            DataList = new List<string>();
        }
        public bool Flag { get; set; }
        public IEnumerable<string> DataList { get; set; }
    }
}
