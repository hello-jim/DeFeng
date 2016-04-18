using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Log
    {
        private string msg;//日志消息
        private LogType type;//日志类型

        public string Msg
        {
            get
            {
                return msg;
            }

            set
            {
                msg = value;
            }
        }

        public LogType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

    }
    public enum LogType
    {
        Error = 1
    }
}
