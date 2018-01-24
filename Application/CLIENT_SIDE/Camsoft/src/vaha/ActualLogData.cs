using System;
using System.IO;
using System.Linq;

namespace Camsoft
{
    public class ActualLogData
    {
        private string[] sub;  // 001;06/25/15;05:56:48;006560
        private string[] date; // 06/25/15
        private string[] time; // 05:56:48
        public DateTime datetime {
            get {
                return new DateTime(
                2000 + Convert.ToInt32(date[2]),
                Convert.ToInt32(date[0]),
                Convert.ToInt32(date[1]),
                Convert.ToInt32(time[0]),
                Convert.ToInt32(time[1]),
                Convert.ToInt32(time[2])
                );
            }
        }
        public Int32 weight {
        get {
                if (sub[3] == "000000")
                {
                    return 0;
                }
                else
                {
                    try
                    {
                        return Convert.ToInt32(sub[3].TrimStart('0'));
                    }
                    catch {
                        return Convert.ToInt32(sub[3]);
                    }
                }
            }
        }
        public Boolean state; //Podaroli / Nepodarilo sa parsnut
        private string logfile = Achp.i.data.ser_log_folderpath + Achp.i.data.ser_log_file;

        public ActualLogData()
        {
           state = read_and_split();
            
        }
        private bool read_and_split()
        {
            String LogText = File.ReadLines(logfile).Last();
            if (LogText == null) return false;
            try
            {            
                sub = LogText.Split(';');
                date = sub[1].Split('/');
                time = sub[2].Split(':');
            }
            catch (FormatException format_ex)
            {
                Achp.i.myConsoleWrite("Chyba parsovania:" + format_ex.Message);
                return false;
            }catch(Exception e)
            {
                Achp.i.myConsoleWrite(e.Message);
            }
          return true;
        }
    }     
}
