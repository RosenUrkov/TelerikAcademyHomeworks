using System;

namespace RabinKarp
{
    class SingleRollingHash
    {
        private readonly int Base;
        private readonly int Mod;
        private readonly long BasePower;
        private long hash;

        public SingleRollingHash(int base1, int mod, string str)
            : this(base1, mod, str, str.Length)
        {
        }

        public SingleRollingHash(int base1, int mod, string str, int endIndex)
        {
            this.Base = base1;
            this.Mod = mod;

            this.BasePower = 1;
            this.hash = 0;

            for (int i = 0; i < endIndex; ++i)
            {
                this.AddRight(str[i]);
                this.BasePower = this.BasePower * this.Base % this.Mod;
            }
            //Console.WriteLine($"hash of {str.Substring(0, endIndex)} is {this.hash}");
        }

        public override bool Equals(object obj)
        {
            var other = obj as SingleRollingHash;
            return /*this.Base == other.Base && this.Mod == other.Mod &&*/ this.hash == other.hash;
        }

        public void Roll(char right, char left)
        {
            this.AddRight(right);
            this.RemoveLeft(left);
        }

        private void AddRight(char c)
        {
            this.hash = (this.hash * this.Base + c) % this.Mod;
        }

        private void RemoveLeft(char c)
        {
            this.hash = (this.Mod + this.hash - c * this.BasePower % this.Mod) % this.Mod;
        }
    }

    class Program
    {
        static void PrintMatch(int index, string pattern)
        {
            for (int i = 0; i < index; ++i)
            {
                Console.Write(" ");
            }

            Console.WriteLine(pattern);
        }

        static void Main()
        {
            var pattern = "alabala";
            var text = "xalabalabala";

            var patternHash = new SingleRollingHash(211, 1000000007, pattern);
            var textHash = new SingleRollingHash(211, 1000000007, text, pattern.Length);

            if (patternHash.Equals(textHash))
            {
                PrintMatch(0, pattern);
            }

            for (int i = 0; i < text.Length - pattern.Length; i++)
            {
                textHash.Roll(text[i + pattern.Length], text[i]);

                if (patternHash.Equals(textHash))
                {
                    PrintMatch(i + 1, pattern);
                }
            }
        }
    }
}