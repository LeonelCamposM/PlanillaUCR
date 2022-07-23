using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class InputValidator
    {
        public bool ValidateStringSafety(string data)
        {
            bool error = true;
            Regex queryPattern = new Regex(@"(?i)\b(ALTER|CREATE|DELETE|DROP|EXEC(UTE){0,1}|INSERT( +INTO){0,1}|MERGE|SELECT|UPDATE|UNION( +ALL){0,1})\b");
            Match queytValidaton = queryPattern.Match(data);
            Regex injectionPattern = new Regex(@"((WHERE | OR)[ ] +[\(] *[ ] * ([\(] *[0 - 9] +[\)]*)[ ]*=[ ] *[\)]*[ ] *\3)| AND[ ] +[\(] *[ ] * ([\(] * 1[0 - 9] +|[2 - 9][0 - 9] *[\)]*)[ ] *[\(] *[ ] *=[ ] *[\)]*[ ] *\4");
            Match injectionValidaton = queryPattern.Match(data);

            if (!queytValidaton.Success || data.Length() > 255 || !injectionValidaton.Success)
            {
                error = false;
            }
            return error;
        }
    }
}
