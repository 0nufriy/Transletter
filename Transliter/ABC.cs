using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transliter
{
    internal class ABC
    {
        private  List<Letter> alphabet;
        public ABC(List<Letter> alphabet)
        {
            this.alphabet = alphabet;
        }
        public int length
        {
            get
            {
                return alphabet.Count;
            }
        }

        public Letter this[int index]
        {
            get => alphabet[index];
            set => alphabet[index] = value;
        }
    }
}
