using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Slagsmålspel
{
    class Program
    {
        static void Main(string[] args)
        {

            Random generator = new Random();

            
            //Jag deklarerar båda karaktärernas hp i början så de inte behövs deklareras senare och håller då en struktur.
            int redHP = 40;
            int blueHP = 40;

            //Jag låter användaren deklarera vad sin karaktär ska heta.
            Console.WriteLine("Welcome to fighting simulator with 100% real people. " +
                "\nName the fighter you want to see (5 to 14 characters).");
            string userFighter = Console.ReadLine();

            //Jag begränsar användaren att den inte kan gå vidare om namnet är för långt eller för kort.
            while (userFighter.Length >= 15 || userFighter.Length <= 4)
            {
                

                Console.WriteLine("\nName the fighter you want to see (4 to 15 characters).");
                userFighter = Console.ReadLine();
            }
            //För att göra det i samma stil som resten av texten som är redan skriven.
            userFighter = userFighter.ToUpper().Trim();
            
            //Jag använder en random generator som ger 0, 1 eller 2 som i sin tur ger olika namn till den andra karaktären.
            int choseSecondFighter = generator.Next(3);
            string secondFighter = "";

            if (choseSecondFighter == 0)
            {
                secondFighter = "BERT THE FERT";
            }

            if (choseSecondFighter == 1)
            {
                secondFighter = "PAM THE HAM";
            }

            if (choseSecondFighter == 2)
            {
                secondFighter = "PONTUS THE GAME DEV";
            }

            //Jag frågar användaren om den är redo att börja matchen och gör så att den inte kan gå vidare om den inte skriver yes.
            Console.WriteLine("LET'S SEE THE FIGHT OF THE CENTURY. " + userFighter + " VS. " + secondFighter + "!!!" +
                "\nDO YOU WANT TO SEE IT?!!!");
            string wantToSee = Console.ReadLine();

            while (wantToSee != "yes" && wantToSee != "Yes" && wantToSee != "YES")
            {
                Console.WriteLine("I ASK AGAIN, DO YOU WANT TO SEE?!!!");
                wantToSee = Console.ReadLine();
            }

            if (wantToSee == "yes" || wantToSee == "Yes" || wantToSee == "YES")
            {
                Console.WriteLine("lET'S BEGIN THE FIGHT!");
                
                //Jag skapar en while loop som gör så att fighten pågår så länge som båda karaktärerna har hp.
                while (redHP > 0 && blueHP > 0)
                    
                {

                    //Jag slumpar båda karaktärernas attack, de är generarade separat så båda inte får samma attack
                    int redATK = generator.Next(5, 20);
                    int blueATK = generator.Next(5, 20);
                    redHP = redHP - blueATK;
                    blueHP = blueHP - redATK;

                    //För att inte en karaktär ska få minus hp så gör jag så att om resultatet av hp - atk blir under 0 så ändrar jag inten till att vara 0.
                    if (redHP < 0)
                    {
                        redHP = 0;
                    }

                    if (blueHP < 0)
                    {
                        blueHP = 0;
                    }

                    //Så det är lite delay mellan varje runda så användaren kan läsa resultatet av rundan innan det går till nästa runda.
                    Thread.Sleep(4000);

                    Console.WriteLine("=======================================" +
                        "\n" + userFighter + " HAS: " + redHP + " HP AFTER " + secondFighter + " DID " + blueATK + " DAMAGE!" +
                        "\n(9^n^)9 (/*U*)/" +
                        "\n---------------" +
                        "\n" + secondFighter + " HAS: " + blueHP + " HP AFTER " + userFighter + " DID " + redATK + " DAMAGE!" +
                        "\n(9*U*)9 (/^n^)/");
                }

                Thread.Sleep(1000);

                //Här är vad som händer när karaktärernas hp blir 0, matchen slutar och antingen förlorar ena eller så förlorar båda
                if (redHP == 0 && blueHP > 0)
                {
                    Console.WriteLine("=======================================\n" + userFighter + " LOSES!!!");
                }

                if (blueHP == 0 && redHP > 0)
                {
                    Console.WriteLine("=======================================\n" + secondFighter + " LOSES!!!");
                }

                if (blueHP == 0 && redHP == 0)
                {
                    Console.WriteLine("=======================================\nBOTH " + userFighter + " AND " + secondFighter + " ARE LOSERS!!!");
                }

                Console.ReadLine();
            }



        }
    }
}
