using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WF_TABLE_COUNTRIES_LINQ_ENTITY.Models
{
    internal class Controller
    {
       public  CountriesDataContext db;



        public Controller() 
        {
            //AddStandartCountries();
        }


        public ICollection<Countries> GetCountriesAsObj()
        {

            ICollection<Countries> res = new Collection<Countries>();

            using (var db = new CountriesDataContext())
            {
                res = db.contries.ToList();
            }

            return res;
        }

        public void AddStandartCountries()
        {
            Countries country = new Countries() 
            {
                Name = "Ukraine", 
                Capital = "Kyiw",
                Area = 603700,
                AmountHumans = 40000000,
                Continent = "Europe"

            };
            using (var db = new CountriesDataContext())
            {
                db.contries.Add(country);
                db.SaveChanges();
            }
        }

        public void DelCountry(int ID)
        {
            using (var db = new CountriesDataContext())
            {
                Countries temp = db.contries.Where(x=>x.id == ID).FirstOrDefault();
                db.contries.Remove(temp);
                db.SaveChanges();
            }
        }
        public void AddCountry(Countries country)
        {
            using (var db = new CountriesDataContext())
            {
                db.contries.Add(country);
                db.SaveChanges();
            }
        }

    }
}
