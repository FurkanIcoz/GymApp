using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
    class Exercise
    {
        static string filePath = "path/to/your/csv/file.csv";
        DataTable dataTable = new DataTable();
        StreamReader reader = new StreamReader(filePath);

        static string[] lines = File.ReadAllLines(filePath);
        string[] headers = lines[0].Split(',');

        
    }
}
