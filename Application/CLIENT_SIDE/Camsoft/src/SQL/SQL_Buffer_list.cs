using System;
using System.Collections.Generic;

namespace Camsoft
{
    public static class SQL_Buffer_list
    {
        // pole so subormi, ktoré ešte neboli odoslané a sú na disku ( spravuje to SQL_upload.cs)
        public static List<SQL_Buffer_Item> data = Serialize.SQL; 

        public static void addToSendBuffer(string id, List<ActualLogData> list)
        {
            int vaha = new Histogram(list).vaha;
            data.Add(new SQL_Buffer_Item(id, vaha , list[0].datetime));
            string v;
            if (vaha == 2) { v = "Nepodarilo sa zistiť váhu."; }else { v = vaha.ToString(); }
            Achp.i.myConsoleWrite("--------------------------------------------------------------------------------------");
            Achp.i.myConsoleWrite(id + ":   " + list[0].datetime + "  -  " + v + " kg");
            Achp.i.myConsoleWrite("--------------------------------------------------------------------------------------");
        
            Serialize.SQL = data;
        }
        public static void urez()
        {
            data.RemoveAt(0);
            Serialize.SQL = data;
        }

    }
}

