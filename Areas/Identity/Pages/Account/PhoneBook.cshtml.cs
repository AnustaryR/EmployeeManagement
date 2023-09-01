using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Domain;
using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace mployeeManagement.Areas.Identity.Pages.Account
{
    public class PhoneBookModel : PageModel
    {
        private readonly ILogger<PhoneBookModel> _logger;

        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly UserManager<User> _userManager;
        [BindProperty]
        public PhoneBookRequest phoneBook { get; set; }
        public PhoneBookModel(ILogger<PhoneBookModel> logger, IPhoneBookRepository PhoneBookRepository, UserManager<User> userManager)
        {
            _logger = logger;
            _phoneBookRepository = PhoneBookRepository;
            _userManager = userManager;
        }
        public IActionResult OnGet(string id)
        {

            if (id == null)
            {
                phoneBook = new PhoneBookRequest();
                phoneBook.UserId= _userManager.GetUserId(this.User);
            }
            else
            {
                phoneBook = new PhoneBookRequest();
                phoneBook.UserId = _userManager.GetUserId(this.User);

                if (phoneBook == null)
                {
                    return RedirectToPage("/Error");
                }

            }
            return Page();
        }
        public IActionResult OnPost()
        {
            string id = _userManager.GetUserId(this.User);
            if (ModelState.IsValid)
            {
                PhoneBook objPhoneBook=new PhoneBook();
                objPhoneBook.ContactName = phoneBook.ContactName;
                objPhoneBook.PhoneNumber = phoneBook.PhoneNumber;
                objPhoneBook.NickName = phoneBook.NickName; 
                objPhoneBook.UserId = id;
                objPhoneBook.Email = "";
                if(objPhoneBook.ID==null)
                {
                    _phoneBookRepository.InsertPhoneBook(objPhoneBook);
                    phoneBook = new PhoneBookRequest();
                    TempData["sucess"] = "Contact created successfully.";
                    return Page();
                }

            }
            return Page();
        }
    }
}
