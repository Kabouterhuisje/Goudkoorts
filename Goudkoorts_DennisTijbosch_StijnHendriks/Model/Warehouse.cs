using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Warehouse : TrackField
    {
        public Warehouse(int x, int y, char letter) : base(x, y)
        {
            X = x;
            Y = y;
            DisplayChar = letter;
        }
    }

