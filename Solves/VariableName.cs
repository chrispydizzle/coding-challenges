namespace Pdrome2.Solves
{
    using System.Text.RegularExpressions;

    internal class VariableName
    {
        public bool variableName(string name)
        {
            Regex r = new Regex(@"^[A-Za-z_][A-Za-z_0-9]*");
            Match match = r.Match(name);

            if (match.Success && match.Length == name.Length)
            {
                return true;
            }

            return false;
        }
    }
}