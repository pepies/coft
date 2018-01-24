using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;

namespace Camsoft
{
    public static class Serialize
    {
        public static InputData inputs
        {
           get {
                InputData data = new InputData();
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("Nastavenia.bin", FileMode.Open);
                    if (stream.Length != 0)
                    {
                        data = (InputData)formatter.Deserialize(stream);
                    } else
                    {
                        inputs = new InputData();
                        data = new InputData();
                    }
                    stream.Close();
                }
                catch (Exception) {
                }
                return data;
            }
            set
            {
                value.ser_cam_url = CompleteURL(value.ser_cam_ip, value.ser_stream_type);

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Nastavenia.bin", FileMode.Create, FileAccess.Write);
                try
                {
                    formatter.Serialize(stream, value);
                }
                catch (SerializationException ex)
                {
                    Achp.i.myConsoleWrite(ex.Message);
                }
                finally
                {
                    Achp.i.myConsoleWrite("OK - Nastavenia uložené.");
                    stream.Close();
                }
            }
        }
        public static List<SQL_Buffer_Item> SQL
        {
            get
            {
                List<SQL_Buffer_Item> data;
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("SQL_buffer.bin", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
                if (stream.Length == 0)
                {
                    stream.Close();
                    SQL = new List<SQL_Buffer_Item>();
                    return SQL;
                }
                data = (List<SQL_Buffer_Item>)formatter.Deserialize(stream);
                stream.Close();

                return data;
            }
            set{
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("SQL_buffer.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                try
                {
                    formatter.Serialize(stream, value);
                }
                catch (Exception r)
                {
                    Achp.i.myConsoleWrite(r.Message);
                }

                try
                {
                    stream.Close();
                }
                catch (Exception ser_excc)
                {

                    Achp.i.myConsoleWrite(ser_excc.ToString());

                }
            }
        }

        //Complete URL based on camera stream profile. selected
        private static string CompleteURL(string theMediaURL, MediaType theMediaType)
        {
            string anURL = theMediaURL;
            if (!anURL.EndsWith("/")) anURL += "/";

            switch (theMediaType)
            {
                case MediaType.Mjpeg:
                    anURL += "axis-cgi/mjpg/video.cgi";
                    break;
                case MediaType.mpeg4:
                    anURL += "mpeg4/media.amp";
                    break;
                case MediaType.h264:
                    anURL += "axis-media/media.amp?videocodec=h264";
                    break;
            }

            anURL = CompleteProtocol(anURL, theMediaType);
            return anURL;
        }

        private static string CompleteProtocol(string theMediaURL, MediaType theMediaType)
        {
            if (theMediaURL.IndexOf("://") >= 0) return theMediaURL;

            string anURL = theMediaURL;

            switch (theMediaType)
            {
                case MediaType.Mjpeg:
                    anURL = "http://" + anURL;
                    break;
                case MediaType.mpeg4:
                case MediaType.h264:
                    // Use RTP over RTSP over HTTP
                    anURL = "axrtsphttp://" + anURL;
                    break;
            }

            return anURL;
        }
    }
}
