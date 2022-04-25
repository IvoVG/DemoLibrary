
using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Models.Book
{
    internal class AllowedExtensionsAttribute :ValidationAttribute
    {
        private readonly string[] extensionsAtribute;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            extensionsAtribute = extensions;
        }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        protected override ValidationResult IsValid(
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!extensionsAtribute.Contains(extension.ToLower()))
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
            return $"Това разширение на изображението не е разрешено!";
        }
    }
}