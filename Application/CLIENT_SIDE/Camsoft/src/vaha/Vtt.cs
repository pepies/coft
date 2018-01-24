using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Camsoft
{
    public static class Vtt
    {
        public static void listToFile(List<ActualLogData> list, String idd)
        {
            if (list.Count > 0)
            {
                DirectoryInfo di = Directory.CreateDirectory("xml");
                write_out(@"xml\" + idd + ".vtt", generate_xml(list));
            }   
        }

        private static String generate_xml(List<ActualLogData> list)
        {
            String content = "WEBVTT\r\n\r\n";
            DateTime defaulttime = list[0].datetime;   
            foreach (ActualLogData zaznam in list)
            {
                TimeSpan diff = zaznam.datetime.Subtract(defaulttime);
                content += "\r\n";
                if (diff.Minutes <= 9) { content += "0" + diff.Minutes; } else { content += diff.Minutes; }
                content += ":";
                if (diff.Seconds <= 9) { content += "0" + diff.Seconds; } else { content += diff.Seconds; }
                content += ".000 --> ";
                if (diff.Minutes <= 9) { content += "0" + diff.Minutes; } else { content += diff.Minutes; }
                content += ":";

                if ((diff.Seconds+1) <= 9) { content += "0" + (diff.Seconds+1); } else { content += (diff.Seconds+1); }
                content += ".000\r\n" + zaznam.weight+ "\r\n\r\n";
            }
            return content;
        }

        private static void write_out(String path, String content)
        {
            if (File.Exists(path))
            {  
                File.Delete(path);
            }

            // Create the file. 
            using (FileStream fs = File.Create(path))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(content);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
        }
        
    }
}
