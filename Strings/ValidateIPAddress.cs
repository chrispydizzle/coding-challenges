namespace CodeChallenges.Strings
{
    using System.Linq;

    public class ValidateIPAddress
    {
        public string ValidIPAddress(string IP)
        {
            char[] validHex = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            string result = "Neither";

            string[] strings = IP.Split('.');

            if (strings.Length == 4)
            {
                foreach (string s in strings)
                {
                    int intValue = 0;
                    if (s.Length <= 3 &&
                        s.Length > 0 &&
                        (s.Length > 1 && s[0] != '0' || s.Length == 1) &&
                        int.TryParse(s, out intValue) &&
                        intValue >= 0 &&
                        intValue <= 255)
                    {
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (!char.IsDigit(s[i])) return result;
                        }
                    }
                    else
                    {
                        return result;
                    }
                }

                result = "IPv4";
                return result;
            }

            strings = IP.Split(':');
            if (strings.Length == 8)
            {
                foreach (string s in strings)
                {
                    string str = s.ToUpper();
                    if (str.Length <= 4 && str.Length > 0)
                    {
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (!validHex.Contains(str[i]))
                            {
                                return result;
                            }
                        }
                    }
                    else
                    {
                        return result;
                    }
                }

                result = "IPv6";
                return result;
            }

            return result;
        }
    }