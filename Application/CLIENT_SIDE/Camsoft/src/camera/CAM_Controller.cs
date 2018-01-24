using System;
using AXISMEDIACONTROLLib;
using System.IO;

namespace Camsoft
{
   public static class camController
    {
        public static bool isRecording {
            get
            {
            return (Achp.i.AMC.Status & (int)AMC_STATUS.AMC_STATUS_RECORDING) > 0;
            }
        }
        private static string idd;
        public static bool isCamOn
        {
            get
            {
                try
                {
                    return (AMC_STATUS.AMC_STATUS_PLAYING > 0);
                }
                catch (System.Runtime.InteropServices.InvalidComObjectException e)
                {
                    Achp.i.myConsoleWrite(e.Message);
                    return false;
                }
            }
        }

        public static void record(String id)
        { 
            if (isCamOn && !isRecording)
            {
                try
                {
                    Achp.i.AMC.StartRecordMedia("video/" + id + ".asf", (int)AMC_RECORD_FLAG.AMC_RECORD_FLAG_VIDEO, "0");
                    Achp.i.AMC.SaveCurrentImage(0, "foto/" + id + ".jpg");
                    idd = id;
                    Achp.i.myConsoleWrite("OK - nahravanie zacalo.");
                }
                catch (Exception e)
                {
                    Achp.i.myConsoleWrite(e.Message);
                }
            }
            else
            {
                Achp.i.myConsoleWrite("Nedokážem začať nahrávať video. Už sa nahráva alebo kamera nieje prístupná.");
            }
        }

        public static void stop_record()
        {
            if ( isRecording )
            {
                Achp.i.AMC.StopRecordMedia();
                Achp.i.myConsoleWrite("OK- nahravanie sa zastavilo");
                ftpController.foto.addToSendBuffer(idd, "jpg");
                ftpController.video.addToSendBuffer(idd, "asf");
            }
        }
    }
}
