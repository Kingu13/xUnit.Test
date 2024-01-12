namespace GruppArbete;

using System;
using static System.Console;

public class Program
{
    static void Main() 
    {
        while (true)
        {
            WriteLine("Skriv in ditt personnummer (10 siffor): ");
            string personnummer = ReadLine();
            if (personnummer.Length == 10 && personnummer.All(char.IsDigit))
            {
                char kontrollsiffra = KontrollsiffraCalculator.BeraknaKontrollsiffra(personnummer);
                WriteLine($"Kontrollsiffra: {kontrollsiffra}");
                break;
            }
            else
            {
                WriteLine("Ogiltigt personnummer. Var god skriv in 10 siffror.");
            }
        }
    }
}

public class KontrollsiffraCalculator
{
    public static char BeraknaKontrollsiffra(string personnummer)
    {
        int summa = 0;

        for (int i = 0; i < personnummer.Length - 1; i++)  // Exkluderar den sista siffran för att se om personnumret stämmer.
        {
            int siffra = int.Parse(personnummer[i].ToString());
            int viktadSiffra = (i % 2 == 0) ? (siffra * 2) : siffra;

            // Om viktad siffra är större än 9 så subtrahera 9.
            viktadSiffra = (viktadSiffra > 9) ? (viktadSiffra - 9) : viktadSiffra;

            summa += viktadSiffra;
        }

        // Denna rad beräknar kontrollsiffran för att göra den totala summan (efter att ha viktat siffrorna) jämnt delbar med 10, 
        // vilket är en egenskap hos Luhn-algoritmen som vi använder i denna uträkning.
        int kontrollsiffra = (10 - (summa % 10)) % 10;

        return kontrollsiffra.ToString()[0];
    }
}
