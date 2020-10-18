namespace House.API.Models.Request
{
    using System.ComponentModel.DataAnnotations;

    public class RequestModel
    {
        [Display(Name = "Who are you:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter who you are!")]
        public string Requester { get; set; }

        [Display(Name = "Whachu need:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter what you need!")]
        public decimal Amount { get; set; }
        
        public bool? Success { get; set; }
    }
}
