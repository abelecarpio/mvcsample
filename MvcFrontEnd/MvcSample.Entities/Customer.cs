
using System.ComponentModel.DataAnnotations;

namespace MvcSample.Entities
{
    public class Customer
    {
        public long CustomerId { get; set; }

        [Display(Name = "Account Number", Prompt = "Enter account number...")]
        [StringLength(16, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 16)]
        [Required(AllowEmptyStrings = false, ErrorMessage ="{0} should not be empty." )]
        [RegularExpression("[0-9]+", ErrorMessage = "Invalid {0}.")]
        public string AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
