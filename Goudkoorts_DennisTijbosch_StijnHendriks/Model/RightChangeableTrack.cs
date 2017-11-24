using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class RightChangeableTrack : ChangeableTrack
    {
        public override bool IsUp { get; set; }

        public RightChangeableTrack(int x, int y, bool isUp) : base(x, y, isUp)
        {
            X = x;
            Y = y;
            IsUp = isUp;
            if (IsUp)
            {
                DisplayChar = '└';
            }
            else
            {
                DisplayChar = '┌';
            }
            
        }

        public override void Toggle()
        {
            if (IsUp)
            {
                DisplayChar = '┌';
            }
            else
            {
                DisplayChar = '└';
            }
            IsUp = !IsUp;
        }
    }

