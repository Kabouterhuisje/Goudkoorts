using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class DestinationField : TrackField
    {
        public DestinationField(int x, int y) : base(x, y)
        {
            X = x;
            Y = y;
            DisplayChar = '=';
        }
    }

