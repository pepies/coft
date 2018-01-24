using System;

namespace Camsoft
{
    public class file
    {
        public string meno;
        public string pripona;

        public file(string name, string ext)
        {
            this.meno = name;
            this.pripona = ext;
        }

        public static Files Files
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
