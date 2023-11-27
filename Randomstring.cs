using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB
{
    internal class Randomstring
    {
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private readonly Random _random = new Random();
       /* private readonly int _length;
        public int Length => _length;*/
        public string GenerateRandomString(int n)
        {
            char[] result = new char[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = Characters[_random.Next(Characters.Length)];
            }
            return new string(result);
        }
    }
}
