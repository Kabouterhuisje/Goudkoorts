using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class BasicField : TrackField
    {
        public BasicField(int x, int y) : base(x, y)
        {
            X = x;
            Y = y;
            DisplayChar = '-';
        }
    }

