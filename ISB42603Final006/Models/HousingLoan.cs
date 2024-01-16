using System.ComponentModel.DataAnnotations;

namespace ISB42603Final006.Models
{
    public class HousingLoan
    {
        [Display(Name = "Loan Id")]
        public string Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        public char Gender { get; set; }

        [Display(Name = "Credit Risk")]
        public char CreditRisk { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Principal")]
        public float Principal { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Interest Rate")]
        public float InterestRate
        {
            get
            {
                if (CreditRisk == 'A')
                {
                    return 3;
                }
                else
                {
                    return (float)3.1;
                }
            }

            set
            {
            }
        }

        [Display(Name = "Number of Years")]
        public int NumberOfYears { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Monthly Payment")]
        public float MonthlyPayment
        {
            get
            {
                float P = Principal;
                float I = InterestRate / 1200;
                int N = NumberOfYears * 12;

                return P * (I * (float)Math.Pow((1 + I), N)) / ((float)Math.Pow((1 + I), N) - 1);
            }

            set { }
        }
    }
}
