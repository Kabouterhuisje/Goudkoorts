using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public abstract class ChangeableTrack : TrackField
    {
        public abstract bool IsUp { get; set; }

        public ChangeableTrack(int x, int y, bool isUp) : base(x, y)
        {
            
        }

        public abstract void Toggle();
    }

