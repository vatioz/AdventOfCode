using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    public class FileLineParser
    {
        public static IEnumerable<string> GetAllLines(string fileName)
        {
            return File.ReadAllLines(fileName);
        } 
    }
}
