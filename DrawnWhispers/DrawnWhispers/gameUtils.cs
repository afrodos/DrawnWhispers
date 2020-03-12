using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawnWhispers
{
    class gameUtils
    {
        public gameUtils()
        {
            //construtor voor later??
        }

        public string[,] getOrder(string[] people)
        {
            string[,] orderedArr = new string[people.Length, people.Length];
            for (int i = 0; i <= people.Length - 1; i++)
            {
                for (int x = 0; x <= people.Length - 1; x++)
                {
                    orderedArr[i, x] = people[overflow(x++, people.Length)];
                }
            }
            return orderedArr; 
        }

        private int overflow(int index, int arrlength) //ik moest een nacht slapen om dit te makken
        {
            if (index >= 0 && index < arrlength)
                return index;
            else
                return overflow(index - arrlength, arrlength);
        }

    }
}
