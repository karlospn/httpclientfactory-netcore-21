using System.Collections.Generic;

namespace ProxyLibrary.WebApp2.Models
{
    public class WebApp2Model
    {
        public WebApp2Model()
        {
            DataList = new List<string>();
        }
        public bool Flag { get; set; }
        public IEnumerable<string> DataList { get; set; }
    }
}
