using System.Collections.Generic;

namespace MAFIL.Common.WebExtension
{
    public class CustomHttpResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public T Content { get; set; }
        public IEnumerable<T> ContentList { get; set; }
    }
}
