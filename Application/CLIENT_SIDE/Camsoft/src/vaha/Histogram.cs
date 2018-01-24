using System;
using System.Collections.Generic;
using System.Linq;

namespace Camsoft
{
    public class Histogram
    {

        /* vaha:
        * 1 = unset;
        * 2 = each is unique
        * 3 = default hodnota (neodoslana aale log vytvoreny)
        */
        private List<int> hodnota = new List<int>();
        private List<int> nasobnost = new List<int>();
        public int vaha { get; }

        public Histogram(List<ActualLogData> udaje)
        {
            fill(udaje);
            vaha = get_effective_weight();
        }

        private void fill(List<ActualLogData> udaje)
        {
            foreach (ActualLogData zaznam in udaje)
            {
                if (hodnota.Contains(zaznam.weight))
                {
                    nasobnost[
                         najdi_index(hodnota, zaznam.weight)
                     ]++;
                }
                else
                {
                    hodnota.Add(zaznam.weight);
                    nasobnost.Add(1);
                }
            }
        }
        /// <summary>
        /// BUGGY .... niekedy dáva strašnú blbosť za výsledok
        /// TODO: Mal by som napísať custom Max() funkciu... 
        /// </summary>
        /// <returns></returns>
        private int get_effective_weight()
        {
            try
            {
                int vrchol = nasobnost.Max();
                int vrchol_vaha;
                int vrchol_index;

                if (nasobnost.Max() == 1)
                {
                    return hodnota.Max();
                } // Vid legendu


                vrchol_index = najdi_index(nasobnost, nasobnost.Max());
                vrchol_vaha = hodnota[vrchol_index];

                hodnota.RemoveAt(vrchol_index);
                nasobnost.RemoveAt(vrchol_index);

                if (nasobnost.Max() == vrchol)
                {
                    return (hodnota[najdi_index(nasobnost, nasobnost.Max())] * vrchol_vaha) / 2;
                }
                else return vrchol_vaha;
            }
            catch (Exception e)
            {
                Achp.i.myConsoleWrite("Histogram" + e.Message);
                return 2;
            }
        }

        private int najdi_index(List<int> kde, int co)
        {
            return kde.FindIndex(
                delegate (int bk)
                {
                    return bk == co;
                }
            );
        }
    }
}
