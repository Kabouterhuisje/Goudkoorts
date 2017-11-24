using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class LeftChangeableTrack : ChangeableTrack
    {
        public override bool IsUp { get; set; }

        public LeftChangeableTrack(int x, int y, bool isUp) : base(x, y, isUp)
        {
            X = x;
            Y = y;
            IsUp = isUp;
            if (IsUp)
            {
                DisplayChar = '┘';
            }
            else
            {
                DisplayChar = '┐';
            }
        }

        public override void Toggle()
        {
            IsUp = !IsUp;
            if (IsUp)
            {
                DisplayChar = '┘';
            }
            else
            {
                DisplayChar = '┐';
            }
            
        }
    }

