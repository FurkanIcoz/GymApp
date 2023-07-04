using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
    class Persons
    {
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            return $"{Isim} {Soyisim}";
        }
    }
}
