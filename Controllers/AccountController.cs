using Day7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Day7.Controllers
{
    public class AccountController : Controller
    {
        private static List<Account> _accounts = new List<Account>();
        public IActionResult Index()
        {
            return View(_accounts);
        }
        public IActionResult Create()
        {
            Account model = new Account();
            model.BirthDay = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account model)
        {
            if (ModelState.IsValid)
            {
                model.Id = _accounts.Count + 1;
                _accounts.Add(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string phone) 
        {
            Regex _isPhone = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            if(_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} không đúng định dạng");
            }
            return Json(true);
        }
    }
}
