using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Output
    {
        internal void ShowGameStart()
        {
            //start screen
            Console.Clear();
            Console.WriteLine(
                "┌────────────────────────────────────────────────────┐\n" +
                "| Welkom bij Goudkoorts                              |\n" +
                "|                                                    |\n" +
                "| betekenis van de symbolen   |   doel van het spel  |\n" +
                "|                             |                      |\n" +
                "| spatie : outerspace         |   Loots de karretjes |\n" +
                "|      - : Horizontale vloer  |   via de juiste      |\n" +
                "|      | : Verticale vloer    |   route naar de      |\n" +
                "| └/┌/┐/┘: hoeken             |   boot toe           |\n" +
                "|      O : Karretje zonder    |                      |\n" +
                "|          Lading             |                      |\n" +
                "|      0 : Karretje met       |                      |\n" +
                "|          Lading             |                      |\n" +
                "|      K : Eindpunt / Kade    |                      |\n" +
                "|  A/B/C : Loods              |                      |\n" +
                "|      S : Schip              |                      |\n" +
                "|      ~ : Zee                |                      |\n" +
                "└────────────────────────────────────────────────────┘\n" +
                "\n" + "Druk op een willekeurige toets om te starten.."
            );
        }

        internal void WrongInput()
        {
            Console.WriteLine("Foutive invoer! Probeer het nog eens..");
        }

        internal void Drawmap(Track track)
        {
            Console.WriteLine("Map:\n");

            try
            {
                for (int y = 0; y <= 9; y++)
                {
                    string temp = "";
                    for (int x = 0; x <= 12; x++)
                    {
                        temp = temp + track.trackList.First(v => v.X == x && v.Y == y).DisplayChar;
                    }
                    Console.WriteLine(temp);
                }

                Console.WriteLine("\nGebruik de toetsen 1 t/m 5 om de wissels te bedienen..");
            }
        //TODO: Exceptions geven op basis van de custom exceptions..
            catch (InvalidMapLayoutException)
            {
                Console.WriteLine("De map is niet juist ingedeeld!");
                Console.ReadLine();
            }
            catch (CannotDrawMapException)
            {
                Console.WriteLine("De map kan niet juist worden afgebeeld!");
                Console.ReadLine();
            }
        }

        public void TrackChanged()
        {
            Console.WriteLine("De map is gewijzigd!");
        }

        public void ShipLoad(int load, int maxLoad)
        {
            Console.WriteLine(String.Format("De lading van het schip is: {0}/{1}", load.ToString(), maxLoad.ToString()));
        }

        internal void DrawScore(int score)
        {
            Console.WriteLine(String.Format("Uw score is: {0}", score.ToString()));
        }

        public void GameOver()
        {
            Console.WriteLine("GAME OVER! JE HEBT GEFAALD!!!");
        }

        internal void CleanConsole()
        {
            Console.Clear();
        }
    }

