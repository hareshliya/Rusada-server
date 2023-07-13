using System.ComponentModel.DataAnnotations;

namespace Aviation.BL.Validators
{
    public class RegexValidationAttribute : RegularExpressionAttribute
    {
        public RegexValidationAttribute(string pattern) : base(pattern)
        {
            ErrorMessage = "The field {0} is not in the correct format.";
        }
    }
}
