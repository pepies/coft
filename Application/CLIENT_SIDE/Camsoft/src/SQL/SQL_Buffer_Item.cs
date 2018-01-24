using System;

namespace Camsoft
{
    [Serializable]
    public class SQL_Buffer_Item
    {
        public string id { get; set; }
        public int vaha { get; set; }
        public DateTime cas { get; set; }

        public SQL_Buffer_Item(string id, int vaha, DateTime cas)
        {
            this.id = id;
            this.vaha = vaha;
            this.cas = cas;
        }
        

    }
}