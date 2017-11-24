using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Ship : TrackField
    {
        public readonly int MaxLoad = 80;
        public int Load { get; set; }

        public Ship(int x, int y) : base(x, y)
        {
            this.Load = 0;
            X = x;
            Y = y;
            DisplayChar = 'S';
        }

        internal bool IsFull()
        {
            if (Load >= MaxLoad)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

