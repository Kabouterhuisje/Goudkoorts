using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Quay : TrackField
    {
        public TrackField ship { get; set; }
        public Quay(int x, int y) : base(x, y)
        {
            X = x;
            Y = y;
            DisplayChar = 'K';
        }
    }

