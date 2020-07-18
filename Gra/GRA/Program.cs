using System;
using System.Linq.Expressions;

namespace GRA
{
    class Program
    {

        public static int Trafione(string[] a, string[] b)
        {
            int x = 0;
            for (int i = 0; i < 4; i++)
            {
                if (a[i] == b[i])
                {
                    x += 1;
                }
            }
            return x;
        }

        public static int Odgadniete(string[] a, string[] b)
        {
            int x = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[i] == b[j])
                    {
                        x += 1;
                    }
                }
            }

            return x;
        }

        public static string Sprawdzenie(string x)
        {
            int spr = 0;
            while (spr == 0)
            {
                try
                {
                    Convert.ToInt32(x);
                }
                catch (FormatException)
                {
                    Console.Write("Musisz podać liczby. \nSpróbuj ponownie: ");
                    x = Console.ReadLine();
                    continue;
                }
                if (x.Length < 4)
                {
                    Console.Write("Musisz podać Cztery Liczby. \nSpróbuj ponownie: ");
                    x = Console.ReadLine();
                    continue;
                }
                if (x.Length > 4)
                {
                    Console.Write("Musisz podaćcztery liczby \nSpróbuj ponownie: ");
                    x = Console.ReadLine();
                    continue;
                }
                if (Convert.ToInt32(x[0]) == Convert.ToInt32(x[1]) || Convert.ToInt32(x[0]) == Convert.ToInt32(x[2]) || Convert.ToInt32(x[0]) == Convert.ToInt32(x[3]) || Convert.ToInt32(x[1]) == Convert.ToInt32(x[2]) || Convert.ToInt32(x[1]) == Convert.ToInt32(x[3]) || Convert.ToInt32(x[2]) == Convert.ToInt32(x[3]))
                {
                    Console.Write("liczby nie mogą się powtarzać. \nSpróbuj ponownie: ");
                    x = Console.ReadLine();

                }
                else
                {
                    spr = 1;
                }
            }
            
            return x;
        }

        static void Wybór()
        {
            Console.WriteLine("Wpisz:");
            Console.WriteLine("1. Aby zacząć grę.");
            Console.WriteLine("2. Aby zacząć grę na wyższym poziomie trudności.");
            Console.WriteLine("3. Aby poznać zasady");
            Console.WriteLine("4. Aby wyjść.");
        }

        static void Zasady()
        {
            Console.Clear();
            Console.WriteLine("Program zapyta Cię  o podanie czterech liczb np. 1234. Liczby nie mogą się powtarzać i byćwpisane po kolei bez żadnej spacji i innych znaków. ");
            Console.WriteLine();
            Console.WriteLine("Gra polega na odgadnięciu ciągu czterech liczb w kolejności uzgodnionej na początku, które program losowo wygeneruje za każdym razem jak go uruchomisz. Twoimi jedynymi podpowiedziami będzie ilość liczb, które zgadłeś, oraz liczbą które zgadłeś i znajdują się w dobrym miejscu. \n \nOdpowiednio: 'Odgadnięte liczby' i 'Trafione liczby'");
        }

        static void Gra()
        {
            Liczby pierwsze = new Liczby();
            int wygrana = 0;
            Console.Clear();

            while (wygrana != 1)
            {

                Console.Write("Podaj swoje liczby: ");
                string x = Console.ReadLine();

                if (x == "czity")
                {
                    foreach (var item in pierwsze.tab)
                    {
                        Console.WriteLine(item);
                    }
                    continue;
                }

                x = Sprawdzenie(x);

                string[] a = new string[4];
                for (int i = 0; i < x.Length; i++)
                {
                    a[i] = x[i].ToString();
                }

                if (Trafione(a, pierwsze.tab) == 4)
                {
                    wygrana = 1;
                    Console.Clear();
                    Console.WriteLine("Gratulacje! Udało ci się wytypować poprawną kolejność liczb");
                    
                    
                }
                else
                {
                    Console.WriteLine($"Trafione: {Trafione(a, pierwsze.tab)}");
                    Console.WriteLine($"Odgadniete: {Odgadniete(a, pierwsze.tab) - Trafione(a, pierwsze.tab)}");
                }

            }
        }

        static void Gra2()
        {
            Liczby pierwsze = new Liczby();
            int wygrana = 0;
            Console.Clear();
            Console.WriteLine("Na wyższym poziomie trudności masz tylko 10 prób, aby odgadnąć ciąg cyfr. Powodzenia!\n");

            for (int k = 0; k < 10; k++)
            {

                Console.Write("Podaj swoje liczby: ");
                string x = Console.ReadLine();

                if (x == "czity")
                {
                    foreach (var item in pierwsze.tab)
                    {
                        Console.WriteLine(item);
                    }
                    k -= 1;
                    continue;
                }

                x = Sprawdzenie(x);
                Console.WriteLine(k);

                string[] a = new string[4];
                for (int i = 0; i < x.Length; i++)
                {
                    a[i] = x[i].ToString();
                }

                if (Trafione(a, pierwsze.tab) == 4)
                {
                    wygrana = 1;
                    Console.Clear();
                    Console.WriteLine($"Gratulacje! Udało ci się wytypować poprawną kolejność liczb: {x}");
                }
                else
                {
                    Console.WriteLine($"Trafione: {Trafione(a, pierwsze.tab)}");
                    Console.WriteLine($"Odgadniete: {Odgadniete(a, pierwsze.tab) - Trafione(a, pierwsze.tab)}");
                }

                if (wygrana == 1)
                {
                    break;
                }

                if (k == 9)
                {
                    Console.WriteLine("Niestety nie udało ci się. Spróbuj na łątwiejszym poziomie trudości i wróć później.");
                }

            }
        }

        static void Main(string[] args)
        {


            
            int tekst = 0;

            while (tekst != 4)
            {
                Wybór();
                Console.Write("Co chcesz zrobić? ");
                tekst = int.Parse(Console.ReadLine());

                switch (tekst)
                {
                    case 1:
                        Gra();
                        break;
                    case 2:
                        Gra2();
                        break;
                    case 3:
                        Zasady();
                        break;
                    case 4:
                        break;

                }
            }



            

            
            
        }
    }
}
