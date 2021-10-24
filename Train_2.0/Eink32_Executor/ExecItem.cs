using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eink32_Executor
{
    public class ExecItem
    {
        public String FileName = String.Empty;
        public char ControlChar = char.MinValue;
        public int StartPreDelayMs = 0;
        public int StartPostDelayMs = 0;
        public bool AutoStart = true;
        public bool AutoRestart = true;
        public String Parameter = String.Empty;
        
    }
}