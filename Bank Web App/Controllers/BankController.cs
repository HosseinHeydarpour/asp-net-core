using Bank_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bank_Web_App.Controllers
{
    public class BankController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank");
        }

        [Route("/account-details/{id:int}")]
        public IActionResult GetAccountDetail()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),"Data/accounts.json");
            string jsonString = System.IO.File.ReadAllText(filePath);

            List<BankAccount> accounts = JsonSerializer.Deserialize<List<BankAccount>>(jsonString);


            BankAccount targetAccount = accounts.FirstOrDefault(a => a.AccountNumber == id);

            if(targetAccount == null)
            {
                return NotFound("Bank account not found!");
            }

            return Json(targetAccount);
        }

        [Route("/account-statement")]
        public IActionResult GetAccountStatement()
        {
            return File("docs.pdf","application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetAccountBalance() 
        {

            string? accountNumber = Convert.ToString(Request.RouteValues["accountNumber"]);
            int intAccountNumber = Convert.ToInt32(accountNumber);

            if (string.IsNullOrEmpty(accountNumber))
            {
                return BadRequest("Account number was not provided.");
            }


            if (intAccountNumber > 1015)
            {
                return BadRequest("Account Number should be below 1015");
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data/accounts.json");
            string jsonString = System.IO.File.ReadAllText(filePath);
            List<BankAccount> accounts = JsonSerializer.Deserialize<List<BankAccount>>(jsonString);

           

            

            

            

            BankAccount targetAccount = accounts.FirstOrDefault(b => b.AccountNumber == intAccountNumber);



            if (targetAccount == null)
            {
                return NotFound($"Account with number {accountNumber} not found.");
            }

           



            return Content($"Balance is: {targetAccount.CurrentBalance} for account with number: {accountNumber}");


        }
    }
}
