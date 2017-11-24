using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Track
    {
        public List<TrackField> trackList { get; set; }

        public Track(char[,] array)
        {
            BuildTrack(array);
            SetNexts();
        }

        // Nieuwe kar toevoegen op random plek
        public void addCar()
        {
            int random;
            Random r = new Random();
            random = r.Next(1, 4);
            List<Warehouse> Warehouses = new List<Warehouse>();
            Warehouses.Add((Warehouse)trackList.First(v => v.DisplayChar == 'A'));
            Warehouses.Add((Warehouse)trackList.First(v => v.DisplayChar == 'B'));
            Warehouses.Add((Warehouse)trackList.First(v => v.DisplayChar == 'C'));
            Car car = new Car();
            switch (random)
            {
                case 1:
                    Warehouses.ElementAt(0).Next.Car = car;
                    break;
                case 2:
                    Warehouses.ElementAt(1).Next.Car = car;
                    break;
                case 3:
                    Warehouses.ElementAt(2).Next.Car = car;
                    break;
            }
        }

        //Opbouwen van veld op basis van array uit de game model..
        private void BuildTrack(char[,] array)
        {
            trackList = new List<TrackField>();
            for (int x = 0; x < 13; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    switch (array[x, y])
                    {
                        case '~':
                            {
                                trackList.Add(new Sea(x, y));
                                break;
                            }
                        case 'S':
                            {
                                trackList.Add(new Ship(x, y));
                                break;
                            }
                        case '-':
                            {
                                trackList.Add(new BasicField(x, y));
                                break;
                            }
                        case ' ':
                            {
                                trackList.Add(new EmptyField(x, y));
                                break;
                            }
                        case '┐':
                            {
                                trackList.Add(new LeftChangeableTrack(x, y, false));
                                break;
                            }
                        case '┘':
                            {
                                trackList.Add(new LeftChangeableTrack(x, y, true));
                                break;
                            }
                        case '┌':
                            {
                                trackList.Add(new RightChangeableTrack(x, y, false));
                                break;
                            }
                        case '└':
                            {
                                trackList.Add(new RightChangeableTrack(x, y, true));
                                break;
                            }
                        case '=':
                            {
                                trackList.Add(new DestinationField(x, y));
                                break;
                            }
                        case 'K':
                            {
                                trackList.Add(new Quay(x, y));
                                break;
                            }
                        case 'A':
                            {
                                trackList.Add(new Warehouse(x, y, 'A'));
                                break;
                            }
                        case 'B':
                            {
                                trackList.Add(new Warehouse(x, y, 'B'));
                                break;
                            }
                        case 'C':
                            {
                                trackList.Add(new Warehouse(x, y, 'C'));
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }

        //Nexts goedzetten zodat ze goed op elkaar overlopen..
        public void SetNexts()
        {
            int highest_x = trackList.Aggregate((i1, i2) => i1.X > i2.X ? i1 : i2).X;
            int highest_y = trackList.Aggregate((i1, i2) => i1.Y > i2.Y ? i1 : i2).Y;

            for (int x_i = 0; x_i < highest_x; x_i++)
            {
                for (int y_i = 0; y_i <= highest_y; y_i++)
                {
                    TrackField tempFieldStart = null;
                    TrackField tempFieldNext = null;
                    if (y_i == 2 )
                    {
                        tempFieldStart = trackList.FirstOrDefault(f => f.X == x_i && f.Y == y_i);
                        tempFieldNext = trackList.FirstOrDefault(f => f.X == x_i - 1 && f.Y == y_i);
                    }
                    else if (y_i == highest_y)
                    {
                        tempFieldStart = trackList.FirstOrDefault(f => f.X == x_i && f.Y == y_i);
                        tempFieldNext = trackList.FirstOrDefault(f => f.X == x_i - 1 && f.Y == y_i);
                    }
                    else
                    {
                        tempFieldStart = trackList.FirstOrDefault(f => f.X == x_i && f.Y == y_i);
                        tempFieldNext = trackList.FirstOrDefault(f => f.X == x_i + 1 && f.Y == y_i);
                    }
                  
                    if (tempFieldNext != null && tempFieldStart != null)
                    {
                        tempFieldStart.Next = tempFieldNext;
                    }
                }
            }
            //de kolom omhoog
            trackList.First(v => v.X == 11 && v.Y == 2).Next = trackList.First(v => v.X == 10 && v.Y == 2);
            trackList.First(v => v.X == 11 && v.Y == 3).Next = trackList.First(v => v.X == 11 && v.Y == 2);
            trackList.First(v => v.X == 11 && v.Y == 4).Next = trackList.First(v => v.X == 11 && v.Y == 3);
            trackList.First(v => v.X == 11 && v.Y == 5).Next = trackList.First(v => v.X == 11 && v.Y == 4);

            //de bocht omlaag in de laatste rij/kolom
            trackList.First(v => v.X == 11 && v.Y == 8).Next = trackList.First(v => v.X == 11 && v.Y == 9);

            //koppel het schip aan het dek, schip is opgebouwd uit 3 vakken, middelste vak word de lading in geteld
            TrackField quayField = trackList.FirstOrDefault(v => v.X == 9 && v.Y == 2);
            if (quayField != null)
            {
                 Quay quay = (Quay)quayField;//kade gevonden, koppel het schip aan de kade
                quay.ship = trackList.FirstOrDefault(v => v.X == 9 && v.Y == 1);
            }


            //Bij een splitsing wordt er gekeken welke kant de wissel op staat voor de koppeling
            ChangeableTrack tempW = (RightChangeableTrack)trackList.First(v => v.X == 3 && v.Y == 5);
            if (tempW.IsUp)
            {
                trackList.First(v => v.X == 3 && v.Y == 4).Next = trackList.First(v => v.X == 3 && v.Y == 5);
            }
            else
            {
                trackList.First(v => v.X == 3 && v.Y == 6).Next = trackList.First(v => v.X == 3 && v.Y == 5);
            }
            tempW = (LeftChangeableTrack)trackList.First(v => v.X == 5 && v.Y == 5);
            if (tempW.IsUp)
            {
                trackList.First(v => v.X == 5 && v.Y == 5).Next = trackList.First(v => v.X == 5 && v.Y == 4);
                trackList.First(v => v.X == 5 && v.Y == 4).Next = trackList.First(v => v.X == 6 && v.Y == 4);
            }
            else
            {
                trackList.First(v => v.X == 5 && v.Y == 5).Next = trackList.First(v => v.X == 5 && v.Y == 6);
                trackList.First(v => v.X == 5 && v.Y == 6).Next = trackList.First(v => v.X == 6 && v.Y == 6);
            }
            tempW = (RightChangeableTrack)trackList.First(v => v.X == 6 && v.Y == 7);
            if (tempW.IsUp)
            {
                trackList.First(v => v.X == 6 && v.Y == 6).Next = trackList.First(v => v.X == 6 && v.Y == 7);
            }
            else
            {
                trackList.First(v => v.X == 6 && v.Y == 8).Next = trackList.First(v => v.X == 6 && v.Y == 7);
            }
            tempW = (LeftChangeableTrack)trackList.First(v => v.X == 8 && v.Y == 7);
            if (tempW.IsUp)
            {
                trackList.First(v => v.X == 8 && v.Y == 7).Next = trackList.First(v => v.X == 8 && v.Y == 6);
                trackList.First(v => v.X == 8 && v.Y == 6).Next = trackList.First(v => v.X == 9 && v.Y == 6);
            }
            else
            {
                trackList.First(v => v.X == 8 && v.Y == 7).Next = trackList.First(v => v.X == 8 && v.Y == 8);
                trackList.First(v => v.X == 8 && v.Y == 8).Next = trackList.First(v => v.X == 9 && v.Y == 8);
            }
            tempW = (RightChangeableTrack)trackList.First(v => v.X == 9 && v.Y == 5);
            if (tempW.IsUp)
            {
                trackList.First(v => v.X == 9 && v.Y == 4).Next = trackList.First(v => v.X == 9 && v.Y == 5);
            }
            else
            {
                trackList.First(v => v.X == 9 && v.Y == 6).Next = trackList.First(v => v.X == 9 && v.Y == 5);
            }
        }
    }

