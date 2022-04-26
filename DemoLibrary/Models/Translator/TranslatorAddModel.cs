using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Models.Translator
{
    public class TranslatorAddModel
    {
        [Required]
        [StringLength(80, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string LastName { get; set; }

        public string CountryId { get; set; }

        public IEnumerable<TranslatorCountryViewModel> Countries { get; set; }
    }
}
