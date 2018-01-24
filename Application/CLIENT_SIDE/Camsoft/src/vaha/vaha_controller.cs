using System;
using System.Collections.Generic;
using System.IO;

namespace Camsoft
{
    public static class vahaController
    {
        private static FileSystemWatcher watcher = new FileSystemWatcher();
        private static ActualLogData actual;
        private static ActualLogData previous;
        private static xmlCreator xml;
        private static int ignoreMax = Convert.ToInt32(Achp.i.data.ser_ignore_max);
        private static bool isRecording;
        private static int max = int.MinValue + 33333;
        private static string id;
        private static int waitCoupleSeconds = 0;

        public static bool isVahaOn
        {
            get { 
                return File.Exists(Achp.i.data.ser_log_folderpath + "/" + Achp.i.data.ser_log_file);
            }
        }
        public static void watch_for_changes(string path, string subor) {
            watcher.Path = path;
            watcher.NotifyFilter =  NotifyFilters.LastWrite;  
            // Only watch log file.
            watcher.Filter = subor;
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            // Begin watching.
            try {
                watcher.EnableRaisingEvents = true;
            }
            catch(Exception e)
            {
                Achp.i.myConsoleWrite("watcher:" + e.Message);
            }
         }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            previous = actual; // posúvam sa v čase
            actual = new ActualLogData();
            if (actual.state) {
                if (actual.weight > ignoreMax && !isRecording)
                {
                   initRecord();
                }

                if(isRecording){
                    Achp.i.myVahaWrite(actual.weight, true);
                    xml.add(actual);
                    stopOnEscape();
                }else{
                    Achp.i.myVahaWrite(actual.weight, false);
                }
            }
        }
        /// <summary>
        /// STOPs rerding at the best time
        /// </summary>
        /// <param name="a"></param>
        private static void stopOnEscape()
        {
            // Ak váha klesne pod 250kg od doteraz maximálnej nameranej váhy
            // znamená to, že auto odchádza (nie šofér z auta)
            if (actual.weight < (max - 250))
            {
                //čakám či nepríde ďalšie auto skorej ako aktuálne neodíde
                waitCoupleSeconds++;
                if (waitCoupleSeconds >= 10)
                {
                    stopRecord();
                }
                if (actual.weight > previous.weight)
                {
                    stopRecord();
                }
            }
            else
            {
                if (actual.weight > max)
                {
                    max = actual.weight;
                }
            }

        }
        public static void initRecord()
        {
            if(isRecording != true) { 
                id = DateTime.Now.ToString(@"ddMMyyyy_hhmmss"); 
                xml = new xmlCreator();
                camController.record(id);
                isRecording = true;
            }
        }
        public static void stopRecord()
        {
            if (isRecording != false)
            {
                max = int.MinValue + 33333;
                waitCoupleSeconds = 0;
                camController.stop_record();
                SQL_Buffer_list.addToSendBuffer(id, xml.list);
                xml.stop_record(id);
                isRecording = false;
            }
        }
    }
}