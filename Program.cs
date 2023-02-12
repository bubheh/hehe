using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Spara ID-nummer och tider
            //Skriv ut ID-numret och de sparade tiderna
            //Sök efter ett specifikt ID
            //Avsluta

            List<int[]> tidsLista= new List<int[]>();
            bool isRunning = true;

            while (isRunning) //Programmet påbörjar loopen.
            {
                Console.Clear(); //En clear metod som tar bort texten på cmd fönstret så fortsatt användning utav det inte fyller den utav text.
                Console.WriteLine("\nVälkommen!");
                Console.WriteLine("\n\t[1] Spara dina tider");
                Console.WriteLine("\n\t[2] Skriv ut alla sparade tider");
                Console.WriteLine("\n\t[3] Sök efter sparade tider");
                Console.WriteLine("\n\t[4] Avsluta");
                Console.WriteLine("\n\tVälj: ");

                bool result = int.TryParse(Console.ReadLine(), out int val); //Felhantering så programmet inte kraschar om användaren skriver in fel inmatning.
                switch (val)
                {
                    case 1:

                        int[] tempTid = new int[3]; //En int vektor som sparar användarens svar

                        Console.WriteLine("Skriv in ditt ID-nummer: ");
                        int.TryParse(Console.ReadLine(), out tempTid[0]); //En felhantering och konventering utav ReadLine metoden så vi kan spara användarens inmatning och gör så att vi inte sparar fel värde.
                        if (tempTid[0] < 1 || tempTid[0] > 100) //Programmet använder sig utav en logisk operator så att användaren endast kan skriva ett nummer mellan 1-100.
                        {
                            Console.WriteLine("Du måste skriva ett nummer mellan 1-100.");
                            continue; //Ett continue villkor som gör att vi hoppar över detta kodblocket om användaren gett en giltig inmatning.
                        }

                        Console.WriteLine("Skriv in din bästa tid: ");
                        if (!int.TryParse(Console.ReadLine(), out tempTid[1]))
                        {
                            Console.WriteLine("Du måste skriva en siffra.");
                            continue;
                        }

                        Console.WriteLine("Skriv in din sämsta tid: ");
                        if (!int.TryParse(Console.ReadLine(), out tempTid[2]))
                        {
                            Console.WriteLine("Du måste skriva en siffra.");
                            continue;
                        }

                        //Sparar värdet som användaren inmatat i listan.
                        tidsLista.Add(tempTid); 

                        Console.WriteLine("Dina tider har sparats!");

                        break;

                    case 2:
                        for (int i = 0; i < tidsLista.Count; i++) //En for-loop som visar alla värden som är sparade i listan.
                        {
                            Console.WriteLine("-------------------------");
                            Console.WriteLine("ID-nummer: " + tidsLista[i][0]);
                            Console.WriteLine("Bästa tiden: " + tidsLista[i][1] + " sek");
                            Console.WriteLine("Sämsta tid: " + tidsLista[i][2] + " sek");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Sök efter ett ID-nummer: "); //Gör så att användaren kan söka efter en specifikt ID för att se deras tider.
                        bool knapp = false; //En bool variabel som programmet använder sig utav för att antingen ge ett felmeddelande eller det man sökte baserat på inmatningen.

                        if (!int.TryParse(Console.ReadLine(), out int sparad))
                        {
                            Console.WriteLine("Idrottarens ID-nummer hittas inte. Försök igen.");
                            continue;
                        }

                        for (int i = 0; i < tidsLista.Count; i++)
                        {
                            if (tidsLista[i][0] == sparad) //En jämförelseoperator som kollar om det användaren skrivit in matchar med ett värde som är sparat i listan.
                            {
                                Console.WriteLine("Vi hittade " + "\nID: " + tidsLista[i][0] + "\nBästa tid: " + tidsLista[i][1] + "\nSämsta tid: " + tidsLista[i][2]);
                                knapp = true;
                            }
                        }

                        if (knapp == false) //Om användaren sökt fel så får den testa igen.
                        {
                            Console.WriteLine("Idrottarens ID-nummer hittas inte. Försök igen.");
                        }
                        break;

                    case 4:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Du måste skriva ett nummer mellan 1-4.");
                        break;

                }
                Console.WriteLine("Tryck ENTER för att återgå.");
                Console.ReadLine();
            }

        }
    }
}
