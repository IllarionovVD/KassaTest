using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KassaTest.Models
{
    public class CalculationsResult
    {
        public double Payment { get; set; }
        public double Overpayment { get; set; }

        public List<TableRow> Results;

        public CalculationsResult()
        {
            Results = new List<TableRow>();
        }

    }

    public class TableRow
    {
        public int Number { get; set; }
        public string Date { get; set; }
        public double BodyPayment { get; set; }
        public double PercentPayment { get; set; }
        public double Balance { get; set; }
    }
}