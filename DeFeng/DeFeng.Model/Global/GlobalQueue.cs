using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model.Global
{
    public class GlobalQueue
    {
        public static ConcurrentQueue<Log> LogGlobalQueue = new ConcurrentQueue<Log>();
    }
}
