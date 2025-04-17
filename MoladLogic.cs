using MoladAPI.MoladObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoladWithSearch
{
    public class MoladLogic
    {

        private MoladObject _seedMolad;

        private static List<JewishMonths> _cycle19Year;

        private int _jewishYear;

        private int _index;


        public MoladLogic()
        {
            _cycle19Year = JewishMonths();
            _jewishYear = 5777;
            _index = 0;
            _seedMolad = new MoladObject
            {
                Molad = new DateTime(2016, 10, 01, 14, 40, 13, 000),
                JewishMonth = _cycle19Year[_index],
                JewishYear = _jewishYear
            };
        }

        public MoladObject GetMolad()
        {
            try
            {
                return _seedMolad;
            }
            catch (Exception exc)
            {
                return null;
            }
        }

        public void HebrewSearch(string month, int year)
        {
            try
            {
                // Searches For Input month and year

                if (year >= _jewishYear)
                {
                    while (!(month.ToUpper() == _cycle19Year[_index].ToString().ToUpper() && year == _jewishYear))
                    {
                        GoForward();
                    }
                }

                else if (year <= _jewishYear)
                {
                    while (!(month.ToUpper() == _cycle19Year[_index].ToString().ToUpper() && year == _jewishYear))
                    {
                        GoBackward();
                    }
                }

            }
            catch (Exception exc)
            {

            }
        }

        public void EnglishSearch(DateTime search)
        {
            //Finds the closest molad to the given date
            try
            {
                var range = new MoladRange(search.AddDays(-14).AddHours(-18).AddMinutes(-22).AddSeconds(-3).AddMilliseconds(-(1000 / 3)),
                                             search.AddDays(14).AddHours(18).AddMinutes(22).AddSeconds(3).AddMilliseconds(1000 / 3));
                if (search >= _seedMolad.Molad)
                {
                    while (!range.IsInRange(_seedMolad.Molad))
                    {
                        GoForward();
                    }
                }
                else
                {
                    while (!range.IsInRange(_seedMolad.Molad))
                    {
                        GoBackward();
                    }
                }
            }
            catch (Exception exc)
            {

            }
        }

        public void GoForward()
        {
            try
            {
                // Increments The Molad By One

                if (_cycle19Year[_index].ToString().ToUpper() == "ELUL")
                {
                    _jewishYear++;
                }

                if (_index == _cycle19Year.Count - 1)
                {
                    _index = 0;
                }
                else
                {
                    _index++;
                }

                _seedMolad.Molad = _seedMolad.Molad.AddDays(29).AddHours(12).AddMinutes(44).AddSeconds(3).AddMilliseconds(1000 / 3);
                _seedMolad.JewishMonth = _cycle19Year[_index];
                _seedMolad.JewishYear = _jewishYear;

                //to be implemented later the max hebrew year is 13760 which would equal datetime.maxvalue
                //add error handling for when date tries going further

            }
            catch (Exception exc)
            {

            }
        }

        public void GoBackward()
        {
            try
            {
                // Decrements The Molad By One

                if (_cycle19Year[_index].ToString().ToUpper() == "TISHREI")
                {
                    _jewishYear--;
                }

                if (_index == 0)
                {
                    _index = _cycle19Year.Count - 1;
                }
                else
                {
                    _index--;
                }

                _seedMolad.Molad = _seedMolad.Molad.AddDays(-29).AddHours(-12).AddMinutes(-44).AddSeconds(-3).AddMilliseconds(-(1000 / 3));
                _seedMolad.JewishMonth = _cycle19Year[_index];
                _seedMolad.JewishYear = _jewishYear;

                //to be implemented later the min hebrew year is 3761 which would equal datetime.minvalue
                //add error handling for when date tries going further

            }
            catch (Exception exc)
            {

            }

        }

        private static List<JewishMonths> JewishMonths()
        {
            try
            {
                // Creates A List Of Jewish Months For A 19 Year Cycle

                List<JewishMonths> regularYear = new List<JewishMonths>();

                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Tishrei);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Cheshvan);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Kislev);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Teves);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Shevat);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Adar);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Nissan);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Iyar);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Sivan);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Tamuz);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Av);
                regularYear.Add(MoladAPI.MoladObjects.JewishMonths.Elul);

                List<JewishMonths> leapYear = new List<JewishMonths>();

                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Tishrei);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Cheshvan);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Kislev);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Teves);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Shevat);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Adar1);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Adar2);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Nissan);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Iyar);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Sivan);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Tamuz);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Av);
                leapYear.Add(MoladAPI.MoladObjects.JewishMonths.Elul);



                List<JewishMonths> allYears = new List<JewishMonths>();

                for (int i = 1; i <= 19; i++)
                {
                    if (new List<int> { 3, 6, 8, 11, 14, 17, 19 }.Contains(i))
                        allYears.AddRange(leapYear);
                    else
                        allYears.AddRange(regularYear);
                }
                return allYears;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}



