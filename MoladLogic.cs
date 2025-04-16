using Microsoft.OpenApi.Extensions;
using MoladAPI;
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

        //public string _jewishMonthAndYear;

        public MoladLogic()
        {
            // _seedMolad = new DateTime(2016, 10, 01, 14, 40, 13, 000);
            _cycle19Year = JewishMonths();
            _jewishYear = 5777;
            _index = 0;
            _seedMolad = new MoladObject
            {
                Molad = new DateTime(2016, 10, 01, 14, 40, 13, 000),
                JewishMonth = _cycle19Year[_index],
                JewishYear = _jewishYear
            };
            //_jewishMonthAndYear = $"{_cycle19Year[_index]} of {_jewishYear}";

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

        #region for win forms


        //private void btnNext_Click(object sender, EventArgs e)
        //{
        //    // Increments The Molad By One And Displays It

        //    btnPrev.Enabled = true;

        //    GoForward();

        //    btnNext.Enabled = _molad <= DateTime.MaxValue.AddDays(-4);


        //    txtMolad.Text = _molad.ToString();

        //    txtMonth.Text = $"Molad Of {_cycle19Year[_index]} {_jewishYear}";
        //}

        //private void btnPrev_Click_1(object sender, EventArgs e)
        //{

        //    // Decrements The Molad By One And Displays It

        //    btnNext.Enabled = true;

        //    GoBackward();

        //    btnPrev.Enabled = _molad >= DateTime.MinValue.AddMonths(1);

        //    txtMolad.Text = _molad.ToString();

        //    txtMonth.Text = $"Molad Of {_cycle19Year[_index]} {_jewishYear}";

        //}

        //private void btnSearch_Click_1(object sender, EventArgs e)
        //{
        //    // Opens Form To Enter Search And Displays It

        //    Searcher s = new Searcher();

        //    s.ShowDialog();

        //    if (s.GetMonthSearch() == "" || s.GetYearSearch() == "")
        //    {
        //        return;
        //    }


        //    MoladSearch(s.GetMonthSearch(), int.Parse(s.GetYearSearch()));

        //    txtMolad.Text = _molad.ToString();

        //    txtMonth.Text = $"Molad Of {_cycle19Year[_index]} {_jewishYear}";


        //}
        #endregion
        public void HebrewSearch(string month, int year)
        {
            try
            {
                // Searches For Input Molad

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
                //return null;
            }
        }

        public void EnglishSearch(DateTime search)
        {
            //Finds the closest molad to the given date
            try
            {
                var range = new MoladRange(search.AddDays(-14).AddHours(-18).AddMinutes(-22).AddSeconds(-3).AddMilliseconds(-(1000 / 3)),
                                             search.AddDays(14).AddHours(18).AddMinutes(22).AddSeconds(3).AddMilliseconds(1000 / 3));
                if(search >= _seedMolad.Molad)
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
            catch(Exception exc)
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

                regularYear.Add(MoladAPI.JewishMonths.Tishrei);
                regularYear.Add(MoladAPI.JewishMonths.Cheshvan);
                regularYear.Add(MoladAPI.JewishMonths.Kislev);
                regularYear.Add(MoladAPI.JewishMonths.Teves);
                regularYear.Add(MoladAPI.JewishMonths.Shevat);
                regularYear.Add(MoladAPI.JewishMonths.Adar);
                regularYear.Add(MoladAPI.JewishMonths.Nissan);
                regularYear.Add(MoladAPI.JewishMonths.Iyar);
                regularYear.Add(MoladAPI.JewishMonths.Sivan);
                regularYear.Add(MoladAPI.JewishMonths.Tamuz);
                regularYear.Add(MoladAPI.JewishMonths.Av);
                regularYear.Add(MoladAPI.JewishMonths.Elul);

                List<JewishMonths> leapYear = new List<JewishMonths>();

                leapYear.Add(MoladAPI.JewishMonths.Tishrei);
                leapYear.Add(MoladAPI.JewishMonths.Cheshvan);
                leapYear.Add(MoladAPI.JewishMonths.Kislev);
                leapYear.Add(MoladAPI.JewishMonths.Teves);
                leapYear.Add(MoladAPI.JewishMonths.Shevat);
                leapYear.Add(MoladAPI.JewishMonths.Adar1);
                leapYear.Add(MoladAPI.JewishMonths.Adar2);
                leapYear.Add(MoladAPI.JewishMonths.Nissan);
                leapYear.Add(MoladAPI.JewishMonths.Iyar);
                leapYear.Add(MoladAPI.JewishMonths.Sivan);
                leapYear.Add(MoladAPI.JewishMonths.Tamuz);
                leapYear.Add(MoladAPI.JewishMonths.Av);
                leapYear.Add(MoladAPI.JewishMonths.Elul);



                List<JewishMonths> allYears = new List<JewishMonths>();

                for (int i = 1; i <= 19; i++)
                {
                    if (new List<int> { 3, 6, 8, 11, 14, 17, 19 }.Contains(i))
                        allYears.AddRange(leapYear);
                    else
                        allYears.AddRange(regularYear);
                }
                return allYears;
                ////1
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////2
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////3
                //for (int i = 0; i < leapYear.Count; i++)
                //{
                //    allYears.Add(leapYear[i]);
                //}

                ////4
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////5
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////6
                //for (int i = 0; i < leapYear.Count; i++)
                //{
                //    allYears.Add(leapYear[i]);
                //}

                ////7
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////8
                //for (int i = 0; i < leapYear.Count; i++)
                //{
                //    allYears.Add(leapYear[i]);
                //}

                ////9
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////10
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////11
                //for (int i = 0; i < leapYear.Count; i++)
                //{
                //    allYears.Add(leapYear[i]);
                //}

                ////12
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////13
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////14
                //for (int i = 0; i < leapYear.Count; i++)
                //{
                //    allYears.Add(leapYear[i]);
                //}

                ////15
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////16
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////17
                //for (int i = 0; i < leapYear.Count; i++)
                //{
                //    allYears.Add(leapYear[i]);
                //}

                ////18
                //for (int i = 0; i < regularYear.Count; i++)
                //{
                //    allYears.Add(regularYear[i]);
                //}

                ////19
                //for (int i = 0; i < leapYear.Count; i++)
                //{
                //    allYears.Add(leapYear[i]);
                //}

                //return allYears;
            }
            catch (Exception exc)
            {
                return null;
            }
        }
    }
}



