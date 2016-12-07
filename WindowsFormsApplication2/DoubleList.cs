using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class DoubleList
    {
        double id;
        double sum;
        DoubleList()
        {
            id = 0;
            sum = 0;
        }
        DoubleList(int id, int sum)
        {
            this.id = id;
            this.sum = sum;
        }
        public void set(double id, double sum)
        {
            this.id = id;
            this.sum = sum;
        }
        public static void swap(DoubleList a, DoubleList b)
        {
            if (a.sum > b.sum)
            {
                double x = a.id;
                double y = a.sum;
                a.id = b.id;
                a.sum = b.sum;
                b.id = x;
                b.sum = y;
            }
            

        }
    }
}
