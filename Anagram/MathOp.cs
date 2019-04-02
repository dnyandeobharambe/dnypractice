using System;
using System.Collections.Generic;
using System.Text;

namespace Anagram
{
    //note << is euvalant to multiply by 2 say 5<<2 means 5*2powerof2 that is 5*4
    //>> is divide by 2
    public class MathOp
    {

        public int Add(int x,int y)
        {
            while(y!= 0)
            {
                int carry = x & y;
                 x = x ^ y;
                y = carry << 1;
            }

            return x;
        }

        public int Substract(int x, int y)
        {
            while (y != 0)
            {
                int borrow = (~x) & y;
                x = x ^ y;
                y = borrow << 1;
            }

            return x;
        }

        public int Multiply(int x,int y)
        {
            if (y == 0)
                return 0;
            if (y > 0)
                return x + Multiply(x, y - 1);
            if (y < 0)
                return -Multiply(x, -y);
            return -1;
        }

        public int Division(int x,int y)
        {
            int q = 0;
            while(x >= y)
            {
                x = x - y;
                q++;
            }

            return q;

        }

        //public int Product(int x,int y)
        //{
        //    return x + (x << 1);
        //}
    }
}
