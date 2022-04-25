
using System.ComponentModel.DataAnnotations;


namespace DemoLibrary.Models.Book
{
    internal class MaxFileSizeAttribute:ValidationAttribute
    {
        private readonly int maxFileSizeAtr;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            maxFileSizeAtr = maxFileSize;
        }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        protected override ValidationResult IsValid(
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > maxFileSizeAtr)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

#pragma warning disable CS8603 // Possible null reference return.
            return ValidationResult.Success;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public string GetErrorMessage()
        {
            return $"Максималният разрешен размер на файла е {maxFileSizeAtr} байта.";
        }
    }
}