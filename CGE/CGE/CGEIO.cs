using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CGE.CGE
{
    public static class CGEIO
    {
        public static string FileToString(string _path)
        {
            if (File.Exists(_path)) { return File.ReadAllText(_path); }
            return "";
        }
    }
}
