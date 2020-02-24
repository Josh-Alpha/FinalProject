using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Calculator
    {
        public string approval { get; set; }

        public string Calculate(string X, List<Country> Y)
        {
            var subset = from c in Y
                         where c.Vote == "Yes"
                         select c;

            float percentage = subset.Count() * 100 / 27;
            if (X == "QM")
            {
                double op = 55;
                if (percentage >= op)
                {
                    approval = "Approved";
                }
                else
                {
                    approval = "Rejected";
                }
            }
            else if (X == "RQM")
            {
                double op = 72;
                if (percentage >= op)
                {
                    approval = "Approved";
                }
                else
                {
                    approval = "Rejected";
                }
            }
            else if (X == "SM")
            {
                double op = 50;
                if (percentage >= op)
                {
                    approval = "Approved";
                }
                else
                {
                    approval = "Rejected";
                }
            }
            if (X == "U")
            {
                double op = 100;
                if (percentage == op)
                {
                    approval = "Approved";
                }
                else
                {
                    approval = "Rejected";
                }
            }
            string output = ($"Using rule: {X}, The vote has been {approval} at {percentage}%");
            return output;
        }
    }
}
