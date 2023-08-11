using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
            return "لطفا از کلمات ممنوعه در عنوان استفاده نکنید";
        }

        public override bool IsValid(object value)
        {
            var title = (string)value;
            if (BanKeywords.Contains(title.ToLower())) return false;
            return true;
        }
    }
}
