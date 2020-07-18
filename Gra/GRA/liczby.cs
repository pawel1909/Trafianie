using System;
using System.Collections.Generic;
using System.Text;

namespace GRA
{
    public class Liczby
    {
        public string[] tab; 
        Random rnd = new Random();

        public Liczby()
        {
            tab = new string[4]; 
            
            tab[0] = Convert.ToString(rnd.Next(1, 10));

            
            tab[1] = Convert.ToString(rnd.Next(1, 10));
            if (tab[1] == tab[0])
            {
                tab[1] = Convert.ToString(rnd.Next(1, 10));
                while (tab[1] == tab[0])
                {
                    tab[1] = Convert.ToString(rnd.Next(1, 10));
                }
            }
            
            tab[2] = Convert.ToString(rnd.Next(1, 10));
            if (tab[2] == tab[0] || tab[2] == tab[1])
            {
                tab[2] = Convert.ToString(rnd.Next(1, 10));
                while (tab[2] == tab[0] || tab[2] == tab[1])
                {
                    tab[2] = Convert.ToString(rnd.Next(1, 10));
                }
            }

            tab[3] = Convert.ToString(rnd.Next(1, 10));
            if (tab[3] == tab[0] || tab[3] == tab[1] || tab[3] == tab[2])
            {
                tab[3] = Convert.ToString(rnd.Next(1, 10));
                while (tab[3] == tab[0] || tab[3] == tab[1] || tab[3] == tab[2])
                {
                    tab[3] = Convert.ToString(rnd.Next(1, 10));
                }
            }


        }
    }
}
