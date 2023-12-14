using System;

namespace Morris_The_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Morris The Miner!");
            int gold = 0;

            byte hunger = 0;
            byte sleepiness = 0;
            byte thirst = 0;

            byte whisky = 0;
            // byte thirstandHunger = Convert.ToByte(hunger + thirst); - fix int calculation
            bool isdead = false;
            string choice = "Mining";
            
            for (short turns = 0; turns <= 1000 && isdead == false; turns++)
            {
                // hvad 
                //score: 1464, 1469,  1470(squezed og død),  1475 

                if (turns == 1000)
                {
                    choice = "Mining";
                }
                /*else if (turns >= 980)
                {

                }*/

                else if (sleepiness >= 100)
                {
                    choice = "Sleeping";
                }
                else if (hunger >= 95) //&& turns < 995, ødelægger det..
                {
                    choice = "Eat";
                }
                else if (whisky==0 && gold>1 && turns < 983) // && turns < 990
                {
                    choice = "Shop4Whisky";

                }
                else if (thirst >=70 &&  turns < 990) // && turns < 990
                {
                    choice = "Drink";
                }
                else
                {
                    choice = "Mining";
                }
                /*else 4 til sidst?
                {
                    choice = "Drink";
                }*/

                switch (choice)
                {
                    case "Sleeping":
                        sleepiness = Convert.ToByte(sleepiness - 10);
                        thirst = Convert.ToByte(thirst + 1);
                        hunger += 1;

                        break;
                    case "Mining":
                        sleepiness = Convert.ToByte(sleepiness + 5);
                        thirst = Convert.ToByte(thirst + 5);
                        hunger = Convert.ToByte(hunger + 5);

                        gold = gold + 5;
                        break;
                    case "Eat":
                        sleepiness = Convert.ToByte(sleepiness + 5);
                        thirst = Convert.ToByte(thirst - 5);
                        hunger = Convert.ToByte(hunger - 20);

                        gold = gold - 2;
                        break;
                    case "Shop4Whisky":
                        sleepiness = Convert.ToByte(sleepiness + 5);
                        thirst = Convert.ToByte(thirst + 1);
                        hunger = Convert.ToByte(hunger + 1);
                        if (whisky <= 10) { whisky = Convert.ToByte(whisky + 1); }
                        gold = gold - 1;
                        break;
                    case "Drink":
                        sleepiness = Convert.ToByte(sleepiness + 5);
                        thirst = Convert.ToByte(thirst - 15);
                        hunger = Convert.ToByte(hunger - 1);

                        whisky = Convert.ToByte(whisky - 1);
                        break;
                }
                // wtf ændre alt til 100: sleepiness >= 100 || thirst >= 100 || hunger >= 100, skrev jeg noget andet end if? nå, virker nu.

                //statistics:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Turn: "+turns+", turn choice: "+choice);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("sleepiness: " + sleepiness+", hunger: " +hunger+", thirst: "+ thirst +", whisky: "+ whisky+ ", gold: "+gold);
                if (sleepiness > 100 || thirst > 100 || hunger > 100)
                {
                    isdead = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("isdead: " + isdead);
                }
            }
        }
    }
}
