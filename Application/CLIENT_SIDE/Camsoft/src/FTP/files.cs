using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Camsoft
{
    public class Files
    {
        public string folder = "";
        public List<file> data = new List<file>();

        public Files(string a_folder)
        {
            this.folder = a_folder;
            try
            {
                List<string> g = Directory.GetFiles("./" + this.folder)
                   .Select(file => Path.GetFileName(file)).ToList<string>();
                foreach(string fullname in g)
                {
                    string[] split = fullname.Split('.');
                    string ext = split[1];
                    string name = split[0];
                    data.Add(new file(name, ext));
                }
            }catch(Exception)
            {
                Achp.i.myConsoleWrite("Nenašiel sa priečinok " + this.folder);
            }
        }

        public void addToSendBuffer(string id, string ext)
        {
            data.Add(new file(id, ext));
        }
    }
}
