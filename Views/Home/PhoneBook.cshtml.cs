using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagement.Views.Home
{
    public class PhoneBookModel : PageModel
    {
        private readonly ILogger<PhoneBookModel> _logger;

        private readonly IPhoneBookRepository _phoneBookRepository;
        [BindProperty]
        public PhoneBookRequest phoneBook { get; set; }
        public PhoneBookModel(ILogger<PhoneBookModel> logger, IPhoneBookRepository PhoneBookRepository)
        {
            _logger = logger;
            _phoneBookRepository = PhoneBookRepository;

        }
        public IActionResult OnGet(string id)
        {

            if (id == null)
            {
                phoneBook = new PhoneBookRequest();
            }
            else
            {
                phoneBook = new PhoneBookRequest();

                if (phoneBook == null)
                {
                    return RedirectToPage("/Error");
                }

            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                PhoneBook objPhoneBook=new PhoneBook();
                objPhoneBook.ContactName = phoneBook.ContactName;
                objPhoneBook.PhoneNumber = phoneBook.PhoneNumber;
                objPhoneBook.NickName = phoneBook.NickName; 
                objPhoneBook.UserId = phoneBook.UserId;
                if(objPhoneBook.ID==null)
                {
                    _phoneBookRepository.InsertPhoneBook(objPhoneBook);
                    return Page();
                }

            }
            return Page();
        }
    }
}
