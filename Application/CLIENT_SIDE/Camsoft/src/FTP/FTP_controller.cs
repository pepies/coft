using NReco.VideoConverter;
using System;
using System.IO;
using System.Net;

namespace Camsoft
{
    static class ftpController
    {
        private static String ID = Achp.i.data.ser_id;
        private static String IP = Achp.i.data.ser_server_ip;
        private static String user = Achp.i.data.ser_ftp_id;
        private static String pass = Achp.i.data.ser_ftp_pw;
        private static string host = @"ftp://" + IP + "/";
        private static FtpWebRequest ftpRequest = null;
        public static Files xml = new Files("xml");
        public static Files foto = new Files("foto");
        public static Files video = new Files("video");

        private static bool _isFtpOn = true;
        public static bool isFtpOn
        {
            get { return _isFtpOn; }
            set { }
        }

        internal static MyWebClient MyWebClient
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static file file
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Pošle data so statickej triedy Ftp_files
        /// </summary>
        /// <returns> podarilo / nepodarilo </returns>
        public static void upload_all()
        {
            if( upload_foto() || upload_xml() || upload_video())
            {
                _isFtpOn = true;
            }else
            {
                _isFtpOn = false;
            }
        }
        private static bool upload_foto()
        {
            if (foto.data.Count > 0)
            {
            string filename = "./" + foto.folder + "/" + foto.data[0].meno + "." + foto.data[0].pripona;
                if (File.Exists(filename))
                {
                    if (upload_file(foto.data[0].meno, foto.data[0].pripona, "foto"))
                    {
                        File.Delete(filename);
                        foto.data.RemoveAt(0);
                        return true;
                    }
                    else
                    {
                        Achp.i.myConsoleWrite("nepodarilo sa odoslať " + foto.data[0].meno + "."+ foto.data[0].pripona);
                    }
                }
                else
                {
                    Achp.i.myConsoleWrite("nenašiel som: " + filename);
                    foto.data.RemoveAt(0);
                }
            }
            return false;         
        }
       private static bool upload_xml()
        {
            if (xml.data.Count > 0)
            {
            string filename = "./" + xml.folder + "/" + xml.data[0].meno + "." + xml.data[0].pripona;
                if (File.Exists(filename))
                {
                    if (upload_file(xml.data[0].meno, xml.data[0].pripona, "xml"))
                    {
                        File.Delete(filename);
                        xml.data.RemoveAt(0);
                        return true;
                    }
                }else
                {
                    Achp.i.myConsoleWrite(filename + " neexistuje");
                    xml.data.RemoveAt(0);
                }
            }
            return false;
        }
       private static bool upload_video()
        {
            if (video.data.Count > 0)
            {
                if (File.Exists("./" + video.folder + "/" + video.data[0].meno + "." + video.data[0].pripona))
                {
                    if (video.data[0].pripona == "asf")
                    {
                        convert(video.data[0].meno);
                        File.Delete("./" + video.folder + "/" + video.data[0].meno + ".asf");
                    }
                    else if (video.data[0].pripona == "mp4")
                    {
                    }
                    else
                    {
                        Achp.i.myConsoleWrite("Našlo sa video s neznámou príponou.");
                        return false;
                    }
                    //Tu bude urcite iba MP4 video existovať
                    if (upload_file(video.data[0].meno, "mp4", "video"))
                    {
                        File.Delete("./" + video.folder + "/" + video.data[0].meno + ".mp4");
                        video.data.RemoveAt(0);
                        return true;
                    } else { return false; }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        private static void create_dir(String folder)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "web/" + folder);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.KeepAlive = false;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                /* Establish Return Communication with the FTP Server */
                FtpWebResponse resp = (FtpWebResponse)ftpRequest.GetResponse();
                ftpRequest.Abort();
            }
            catch (Exception evv)
            {
                Achp.i.myConsoleWrite("ftp" + evv.ToString());
            }
        }
        private static void create_remote_dir_structure()
        {
            create_dir(ID);
            create_dir(ID + "/" + xml.folder);
            create_dir(ID + "/" + foto.folder);
            create_dir(ID + "/" + video.folder);
        }

        private static bool upload_file(String id, String type, String folder)
        {
            string URL = host + "web/" + ID + "/" + folder + "/" + id + "." + type;
            string LOCAL = "./" + folder + "/" + id + "." + type;
            try { 
                using (WebClient client = new MyWebClient())
                {
                    client.Credentials = new NetworkCredential(user, pass);
                    client.UploadFile(URL, "STOR", LOCAL);
                }
            }catch(Exception e)
            {
                Achp.i.myConsoleWrite(e.Message);
                return false;
            }
            Achp.i.myConsoleWrite("Odoslané " + folder + "/" + id + "." + type);
            return true;
        }
        /// <summary>
        /// Convert .asf to .mp4
        /// </summary>
        /// <param name="id"></param>
        private static void convert(String id)
        {
            try { 
                String OutputPath = "./" + video.folder + "/" + id + ".mp4";
                String AsfPath = "./" + video.folder + "/" + id + ".asf";
                var ffMpeg = new FFMpegConverter();
                ffMpeg.ConvertMedia(AsfPath, OutputPath, Format.mp4);
            }catch(FFMpegException f){
                Achp.i.myConsoleWrite("konverzia: "+f.Message);
                Achp.i.myConsoleWrite("Prosím zvolte iný kodek kamery! - chybné videá budú zmazané.");
            }
        }

    }
}
