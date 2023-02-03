using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DenominationRoutine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] payouts = new int[] { 30, 50, 60, 80, 140, 230, 370, 610, 980 }; 

            var program = new Program();
            foreach (int payout in payouts)
            {
                Console.WriteLine("Payout amount: " + payout + " EUR");
                Console.WriteLine("Possible combinations:");
                program.CalculateCombinations(payout, "");
                Console.WriteLine("");
            }


            Console.ReadKey();
        }

        private void CalculateCombinations(int payout, string combinations)
        {      
            if (payout == 0)
            {
                Console.WriteLine(combinations);
                return;
            }

            int[] cartridges = new int[] { 10, 50, 100 };
            foreach (int cartridge in cartridges)
            {
                int cartridgeCount = payout / cartridge;
                int remainAmount = payout - (cartridgeCount * cartridge);

                if (remainAmount >= 0 && payout >= cartridge)
                {
                    string combination = $"{combinations} + {cartridgeCount} x {cartridge} EUR";
                    CalculateCombinations(remainAmount, combination);
                }
            }

        }      

    }
}
