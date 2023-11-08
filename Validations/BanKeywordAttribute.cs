using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AliBookStoreApi.Validations
{
    public class BanKeywordAttribute : ValidationAttribute
    {
        public BanKeywordAttribute()
        {
            BanKeywords = new List<string>()
            {
                "shit"
            };
        }

        public List<string> BanKeywords { get; set; }

        public override string FormatErrorMessage(string name)
        {
            return "Please do not use ban keywords in title";
        }

        public override bool IsValid(object value)
        {
            var title = (string)value;
            if (BanKeywords.Contains(title.ToLower()))
            {
                return false;
            }
            return true;
        }
    }
}