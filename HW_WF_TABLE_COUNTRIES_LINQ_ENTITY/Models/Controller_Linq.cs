using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_WF_TABLE_COUNTRIES_LINQ_ENTITY.Models
{
    class Controller_Linq
    {
        public CountriesDataContext db;

        public Controller_Linq() { }

        public List<Countries> Top1_ByArea()
        {
            List<Countries> res = new List<Countries>();
            using (db = new CountriesDataContext())
            {
                var request = from el in db.contries
                              orderby el.Area descending
                              select el;

                res.Add(request.First());
            }
            return res.ToList();

        }
        public List<Countries> Top1_ByHumans()
        {
            List<Countries> res = new List<Countries>();
            using (db = new CountriesDataContext())
            {
                var request = from el in db.contries
                              orderby el.AmountHumans descending
                              select el;

                res.Add(request.First());
            }
            return res.ToList();

        }
        public List<Countries> Top5_ByHumans()
        {
            List<Countries> res = new List<Countries>();
            using (db = new CountriesDataContext())
            {
                var request = from el in db.contries
                              orderby el.AmountHumans descending
                              select el;

                res.AddRange(request.Take(5));

            }
            return res.ToList();

        }
        public List<Countries> Top5_ByArea()
        {
            List<Countries> res = new List<Countries>();
            using (db = new CountriesDataContext())
            {
                var request = from el in db.contries
                              orderby el.Area descending
                              select el;

                res.AddRange(request.Take(5));

            }
            return res.ToList();

        }
        public List<Countries> Smallest_ByArea()
        {
            List<Countries> res = new List<Countries>();
            using (db = new CountriesDataContext())
            {
                var request = from el in db.contries
                              where el.Continent == "Europe" || el.Continent == "Европа"
                              orderby el.Area
                              select el;

                res.AddRange(request.Take(1));

            }
            return res.ToList();

        }

        public string AmountByCountries()
        {
            string res = string.Empty;
            using (db = new CountriesDataContext())
            {
                res = db.contries.Count().ToString();

            }
            return "Общее количество стран : " + res;

        }

        public List<string> ContinentWithMaxAmountCountries()
        {
            List<string> obj = new List<string>();
            using (db = new CountriesDataContext())
            {

                var res = (from el in db.contries
                           group el by el.Continent into x
                           orderby x.Key descending

                           select new
                           {
                               Name = x.Key,
                               Count = x.Count()
                           }).ToList();

                    obj.Add(res.First().Name + res.First().Count.ToString());

            }
            return obj;

        }

        public List<string> AmountCountriesInEveryContinent()
        {
            List<string> obj = new List<string>();
            using (db = new CountriesDataContext())
            {

                var res = (from el in db.contries
                           group el by el.Continent into x
                           orderby x.Key descending

                           select new
                           {
                               Name = x.Key,
                               Count = x.Count()
                           }).ToList();

                foreach (var c in res)
                    obj.Add(c.Name +" : "+ c.Count.ToString());

            }
            return obj;

        }

        public List<string> MidAreaaCountriesInEurope()
        {
            List<string> obj = new List<string>();
            int summ = 0; 
            using (db = new CountriesDataContext())
            {

                var request = from el in db.contries
                              where el.Continent == "Europe" || el.Continent == "Европа"
                              
                              select el;

                foreach (var el in request)
                    summ += el.Area;
                    summ/=request.Count();
                obj.Add("Средняя площадь по Европе = " + summ.ToString());
            }
            return obj;

        }


    }
}
