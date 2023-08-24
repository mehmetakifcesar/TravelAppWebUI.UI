using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TravalAppWebUI.Core.Result
{
    public class ApiResult<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }

        public ErrorInfo ErrorInfo { get; set; }
    }
}
