using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public abstract class TrackField
    {
        private char _displayChar;
        public int X { get; set; }
        public int Y { get; set; }

        public TrackField Next { get; set; }

        //Juiste symbool voor kar laten zien wanneer er een kar is..
        public virtual char DisplayChar
        {
            get
            {
                if (Car == null)
                {
                    return _displayChar;
                }
                else
                {
                    return Car.DisplayChar;
                }
            }
            set
            {
                _displayChar = value;
            }
        }

        public Car Car { get; set; }

        public TrackField(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetCar(Car car)
        {
            Car = car;
        }

        public bool Move(out int scoresum, int score, bool isShip = false)
        {
            scoresum = score;
            if (X == 0 && Y == 2)
            {
                Car = null;
            // Score ophogen met 1, lege kar
                scoresum += 1;
                return true;
            }
            else if (Next != null)
            {
            //Aankomen bij de kade..
                if (Next.DisplayChar == 'K')
                {
                    Quay quay = (Quay)Next;
                    Ship ship = (Ship)quay.ship;
                    ship.Load += 10;
                    Car.Empty();
                    Next.Car = Car;
                    Car = null;
                    return true;
                }
                // Destination behaald dus niks meer doen..
                else if (this is DestinationField && Next.DisplayChar == '0')
                {
                    return true;
                }
            //botsing..
                else if (Next.DisplayChar == 'O' || Next.DisplayChar == '0')
                {
                    return false;
                }
                else if (Next.DisplayChar != ' ')
                {
                    Next.Car = Car;
                    Car = null;
                    return true;
                }
                // Karretje kan niet verder, dus zet hem stil..
                return true;

            }
            else
            {
                Car = null;
                return false;
            }
           
        }
    }

