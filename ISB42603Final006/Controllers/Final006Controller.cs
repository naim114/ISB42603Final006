using ISB42603Final006.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ISB42603Final006.Controllers
{
    public class Final006Controller : Controller
    {
        private readonly IConfiguration configuration;
        public Final006Controller(IConfiguration config)
        {
            this.configuration = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoanApplication006()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoanApplication006(HousingLoan m)
        {
            //return m.MonthlyPayment;

            // if (ModelState.IsValid)
            // {
            SqlConnection conn = new SqlConnection(configuration.GetConnectionString("ConnLoan"));
            SqlCommand cmd = new SqlCommand("spInsertData006", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", m.Id);
            cmd.Parameters.AddWithValue("@Name", m.Name);
            cmd.Parameters.AddWithValue("@Gender", m.Gender);
            cmd.Parameters.AddWithValue("@CreditRisk", m.CreditRisk);
            cmd.Parameters.AddWithValue("@Principal", m.Principal);
            cmd.Parameters.AddWithValue("@InterestRate", m.InterestRate);
            cmd.Parameters.AddWithValue("@NumberOfYears", m.NumberOfYears);
            cmd.Parameters.AddWithValue("@MonthlyPayment", m.MonthlyPayment);

            // try
            // {
            conn.Open();
            cmd.ExecuteNonQuery();
            // }
            // catch
            // {
            // return View(p);
            // }
            // finally
            // {
            conn.Close();
            // }

            return View("LoanApplicationResult006", m);
            // }
            // else
            //  return View(p);

        }
    }
}
