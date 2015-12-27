using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    public class FileParser
    {
        public static string GetAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
