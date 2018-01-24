using System;

namespace Camsoft
{
    [Serializable]
    public class InputData
    {
        /*
        Trieda nastavení
        */

        public String ser_id { get; set; } = "aosxx";
        public String ser_cam_ip { get; set; } = "192.168.0.0";
        public String ser_cam_pw { get; set; } = "password";
        public String ser_cam_id { get; set; } = "root";
        public String ser_cam_url { get; set; } //This property sets only at serialization();
        
        public MediaType ser_stream_type { get; set; } = MediaType.Mjpeg;
        public string vid_type { get; set; } = "h264";

        public String ser_server_ip { get; set; } = "8.8.8.8";

        public String ser_ftp_id { get; set; } = "ftp_user";
        public String ser_ftp_pw { get; set; } = "password";

        public String ser_sql_id { get; set; } = "sql_user";
        public String ser_sql_pw { get; set; } = "password";
        public decimal ser_ignore_max { get; set; } = 500;

        public string ser_log_folderpath { get; set; } //Only path to folder
        public string ser_log_file { get; set; } = "Cesta pre txt log."; //filename with logs

    }
}

