using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class InputValidator
    {
        public bool ValidateStringSafety(string data)
        {
            bool dangerous = false;
            Regex queryPattern = new Regex(@"(?i)\b(ALTER|CREATE|DELETE|DROP|EXEC(UTE){0,1}|INSERT( +INTO){0,1}|MERGE|SELECT|UPDATE|UNION( +ALL){0,1})\b");
            Match queytValidaton = queryPattern.Match(data);
            Regex injectionPattern = new Regex(@"(?i)\b(1=1|'|--)\b");
            Match injectionValidaton = injectionPattern.Match(data);

            if (queytValidaton.Success || data.Length() > 255 || injectionValidaton.Success)
            {
                dangerous = true;
            }
            return !dangerous;
        }
    }
}
