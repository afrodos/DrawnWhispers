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
                    if (x + i == 6)
                    {
                        x = 0;
                        break;
                    }
                    orderedArr[i, x + i] = people[x + i];
                }
            }
            return orderedArr; 
        }

    }
}
