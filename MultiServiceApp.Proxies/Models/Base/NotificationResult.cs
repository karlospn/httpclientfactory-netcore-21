using System.Collections.Generic;

namespace MultiServiceApp.Proxies.Models.Base
{
    public class NotificationResult<TData>
    {
        public NotificationResult()
        {
            Errors = new List<Error>();
        }
        public TData Data { get; set; }

        public IEnumerable<Error> Errors { get; set; }
    }
}
