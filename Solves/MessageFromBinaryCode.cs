namespace CodeChallenges.Solves
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class MessageFromBinaryCode
    {
        public string messageFromBinaryCode(string code)
        {
            List<byte> bytes = new List<byte>();

            for (int i = 0; i < code.Length; i += 8)
            {
                string t = code.Substring(i, 8);

                bytes.Add(Convert.ToByte(t, 2));
            }

            return Encoding.ASCII.GetString(bytes.ToArray());
        }
    }
}