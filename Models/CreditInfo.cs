using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KassaTest.Models
{
    public class CreditInfo
    {
        public double Sum { get; set; }
        public int Period { get; set; }
        public double Percent { get; set; }
        public int TimeStep { get; set; }

        public CalculationsResult Calculate()
        {
            CalculationsResult results = new CalculationsResult();
            int totalPaymentCount;
            if (Period % TimeStep == 0)
                totalPaymentCount = Period / TimeStep;
            else
                totalPaymentCount = Period / TimeStep + 1;
            DateTime date = DateTime.Now;
            double percentPerStep = Percent * TimeStep / 100;
            double coefficient = (percentPerStep * Math.Pow((1 + percentPerStep), totalPaymentCount)) / (Math.Pow((1 + percentPerStep), totalPaymentCount) - 1);
            double monthPayment = Math.Round((coefficient * Sum), 2);
            results.Payment = monthPayment;
            results.Overpayment = monthPayment * totalPaymentCount - Sum;

            double balance = Sum;
            for (int i = 1; i <= totalPaymentCount; i++)
            {
                double percentPayment = Math.Round(balance * percentPerStep, 2);
                double bodyPayment = Math.Round(monthPayment - percentPayment, 2);
                date = date.AddDays(TimeStep);
                balance = Math.Round((balance - bodyPayment), 2);

                results.Results.Add(new TableRow()
                {
                    Number = i,
                    Date = date.ToString("dd.MM.yyyy"),
                    BodyPayment = bodyPayment,
                    PercentPayment = percentPayment,
                    Balance = balance
                });
            }

            return results;
        }
    }
}