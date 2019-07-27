using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RquestCount005
{
    public interface IRequestCountService
    {
        Dictionary<string, bool> RequestList { get; set; }
    }

    public class RequestCountService : IRequestCountService
    {
        public Dictionary<string, bool> RequestList
        { get; set; } = new Dictionary<string, bool>();
    }
}
