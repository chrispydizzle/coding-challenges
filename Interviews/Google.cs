namespace CodeChallenges.Interviews
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Google
    {
        //        Please use this Google doc to code during your interview. To free your hands for coding, we recommend that you use a headset or a phone with speaker option.
        //            Works!

        //        Template expansion
        //        Write a function expanding templates in a simple template languages (variables in curly braces). For instance

        //       template = "Dear {name},
        //        We have recently found out that we owe you {sum}. Could you please give us your bank account number in {country} so that the funds can be disbursed.
        //
        //            Truly yours,

        //       {signature}"
        //
        //    dictionary:
        //   name → Jeremy
        //    sum → $1000000
        //    signature → The Prince

        // throw exception on missing keys
        public string TemplateExpand(Dictionary<string, string> dictionary, string template)
        {
            if (template == null) return null;

            int openBrace = template.IndexOf('{');

            if (openBrace == -1) return template;

            StringBuilder sb = new StringBuilder();
            int closeBrace = 0;

            while (openBrace > -1)
            {
                sb.Append(template.Substring(closeBrace, openBrace - 1));
                // go through the input string look for open brace
                // find next close brace

                closeBrace = template.IndexOf('}', openBrace + 1);

                // if no close brace throw
                if (closeBrace == -1) throw new InvalidOperationException("TODO");

                string key = template.Substring(openBrace + 1, closeBrace - openBrace);

                // if open brace inside throw 
                int keySeek = key.IndexOf('{');
                if (keySeek > -1) throw new InvalidOperationException("TODO");
                // check inner content for dictionary inclusion

                // if not in dict throw,	
                if (!dictionary.ContainsKey(key))
                {
                    throw new InvalidOperationException("TODO");
                }

                // if in dict replace
                sb.Append(dictionary[key]);
                openBrace = template.IndexOf('{', closeBrace);
            }

            sb.Append(template.Substring(closeBrace + 1));

            return sb.ToString();
        }
    }
}