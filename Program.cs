using System;
using static System.Console;

class Program
{
    static void Main()
    {

        
        string personnummer = "011011649";
        char kontrollsiffra = BeraknaKontrollsiffra(personnummer);
        WriteLine($"Kontrollsiffra: {kontrollsiffra}");

        
    }

    static char BeraknaKontrollsiffra(string personnummer)
    {
        int summa = 0;

        for (int i = 0; i < personnummer.Length; i++)
        {
            int siffra = int.Parse(personnummer[i].ToString());
            int viktadSiffra = i % 2 == 0 ? siffra * 2 : siffra;

            // Om viktad siffra är större än 9, subtrahera 9
            viktadSiffra = viktadSiffra > 9 ? viktadSiffra - 9 : viktadSiffra;

            summa += viktadSiffra;
        }

        // Beräkna kontrollsiffra så att summan blir jämnt delbar med 10
        int kontrollsiffra = (10 - (summa % 10)) % 10;

        return kontrollsiffra.ToString()[0];
    }
}
