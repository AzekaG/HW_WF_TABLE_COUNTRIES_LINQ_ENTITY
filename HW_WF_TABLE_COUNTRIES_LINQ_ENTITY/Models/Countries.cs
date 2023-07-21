using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WF_TABLE_COUNTRIES_LINQ_ENTITY.Models
{
    
        class Countries
        {
            public int id { get; set; }
            public string Name { get; set; }
            public string Capital { get; set; }
            public int AmountHumans { get; set; }
            public int Area { get; set; }

            public string Continent { get; set; }

            public Countries() { }
        public override string ToString() 
        {
                return $"Name :{Name}  Cap :{Capital}  " +
                $"Humans:{AmountHumans}  {Continent}  Area:{Area} km";
        }
        }
    
}
