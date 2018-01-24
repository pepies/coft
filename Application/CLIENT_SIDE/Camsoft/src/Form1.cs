using System;
using System.Windows.Forms;
using AXISMEDIACONTROLLib;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Reflection;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.IO;

namespace Camsoft
{
    public enum MediaType
    {
        Mjpeg,
        h264,
        mpeg4
    }

    public partial class Achp : Form
    {
        public InputData data;
        public static Achp i;
        
        private string folderpath;
        private string file;

        public Achp()
        {
            i = this;
            data = Serialize.inputs;
            InitializeComponent();
            Achp.i.Text = "coft - v." + Assembly.GetExecutingAssembly().GetName().Version.ToString();            
        }

        private void Achp_Load(object sender, EventArgs e)
        {
            id_strediska.DataBindings.Add("Text", data, "ser_id", true, DataSourceUpdateMode.OnPropertyChanged);
            cam_ip.DataBindings.Add("Text", data, "ser_cam_ip", true, DataSourceUpdateMode.OnPropertyChanged);
            cam_pw.DataBindings.Add("Text", data, "ser_cam_pw", true, DataSourceUpdateMode.OnPropertyChanged);
            cam_name.DataBindings.Add("Text", data, "ser_cam_id", true, DataSourceUpdateMode.OnPropertyChanged);
            TypeBox.DataBindings.Add("SelectedItem", data, "ser_stream_type", true, DataSourceUpdateMode.OnPropertyChanged);
            server_ip.DataBindings.Add("Text", data, "ser_server_ip", true, DataSourceUpdateMode.OnPropertyChanged);
            ftp_meno.DataBindings.Add("Text", data, "ser_ftp_id", true, DataSourceUpdateMode.OnPropertyChanged);
            ftp_heslo.DataBindings.Add("Text", data, "ser_ftp_pw", true, DataSourceUpdateMode.OnPropertyChanged);
            sql_pw.DataBindings.Add("Text", data, "ser_sql_pw", true, DataSourceUpdateMode.OnPropertyChanged);
            sql_meno.DataBindings.Add("Text", data, "ser_sql_id", true, DataSourceUpdateMode.OnPropertyChanged);
            vaha_horna_hranica.DataBindings.Add("Text", data, "ser_ignore_max", true, DataSourceUpdateMode.OnPropertyChanged);
            log_file_button.DataBindings.Add("Text", data, "ser_log_file", true, DataSourceUpdateMode.OnPropertyChanged);

            Directory.CreateDirectory("video");
            Directory.CreateDirectory("foto");
            Directory.CreateDirectory("xml");

            SQL_Controll();
            FTP_Controll();
            Vaha_Contoll();
            CAM_Controll();

        }
        public void myVahaWrite(int vaha, bool isRecording) {
            if (myconsole.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    this.actualWeight.Text = vaha.ToString();
                    if (isRecording) { 
                        actualWeight.ForeColor = Color.Red;
                    }else
                    {
                        actualWeight.ForeColor = Color.Black;
                    }

                });
            }
        }
        public void myConsoleWrite(String vec)
        {
            if (myconsole.InvokeRequired) { 
                this.Invoke((MethodInvoker)delegate ()
                {
                    myConsoleWrite(vec);
                    myconsole.SelectionStart = myconsole.Text.Length;
                    myconsole.ScrollToCaret();
                });
            }
            else
            {
                myconsole.Text += vec + "\n";
            }
        }

        private void imgStatusVaha()
        {
            try
            {
                if (vahaController.isVahaOn)
                {
                    vaha_status_img.Image = (Bitmap)Properties.Resources.log_on.Clone();
                }
                else
                {
                    vaha_status_img.Image = (Bitmap)Properties.Resources.log_off.Clone();
                }
            }
            catch (Exception)
            {
                myConsoleWrite("Súbor kontrol.txt nieje zadaný.");
            }
            
        }
        private void imgStatusFtp()
        { 
            //status_ftp.Image = (Bitmap)Properties.Resources.ftp_noinfo.Clone();
            if (ftpController.isFtpOn)
            {
                status_ftp.Image = (Bitmap)Properties.Resources.ftp_on.Clone();
            }
            else
            {
                status_ftp.Image = (Bitmap)Properties.Resources.ftp_off.Clone();
            }
                
        }
        private void imgStatusSql() {
           
                    //status_sql.Image = (Bitmap)Properties.Resources.sql_noinfo.Clone();
                    if (sqlController.isSqlOn)
                    {
                        status_sql.Image = (Bitmap)Properties.Resources.sql_on.Clone();
                    }
                    else
                    {
                        status_sql.Image = (Bitmap)Properties.Resources.sql_off.Clone();
                    }
        }
        private void imgStatusCam()
        {
            if (camController.isCamOn)
            {
                status_camera.Image = (Bitmap)Properties.Resources.camera_on.Clone();
            }
            else
            {
                status_camera.Image = (Bitmap)Properties.Resources.camera_off.Clone();
            }
                
        }

        private async void Vaha_Contoll()
        {
            vahaController.watch_for_changes(data.ser_log_folderpath, data.ser_log_file);
            await Task.Delay(1000);
            while (true)
            {
                imgStatusVaha();
                await Task.Delay(10000);
            };                
        }
        private async void FTP_Controll()
        {
            await Task.Delay(1000);
            while (true)
            {
                await Task.Run(new Action(ftp_buffer_count));
                await Task.Run(new Action(imgStatusFtp));
                await Task.Delay(5000);
                status_ftp.Image = (Bitmap)Properties.Resources.ftp_uploading.Clone();
                await Task.Run(new Action(ftpController.upload_all));
            };

        }
        private async void SQL_Controll()
        {
            await Task.Delay(1000);
            while (true)
            {
                await Task.Run(new Action(imgStatusSql));
                await Task.Run(new Action(sql_buffer_count));
                await Task.Delay(25000);
                await Task.Run(()=> {
                    if (sqlController.isSqlOn) { 
                        status_sql.Image = (Bitmap)Properties.Resources.sql_uploading.Clone();
                        sqlController.upload();
                    }
                });
            };
        }
        private async void CAM_Controll()
        {
            AMC.MediaUsername = data.ser_cam_id;
            AMC.MediaPassword = data.ser_cam_pw;
            AMC.MediaURL = data.ser_cam_url;
            await Task.Delay(1000);
            while (true)
            {
                if(!camController.isCamOn) AMC.Play();
                await Task.Run(new Action(imgStatusCam));
                await Task.Delay(6000);
            };
        }

        private void ftp_buffer_count()
        {
            Nvideo.Invoke((MethodInvoker)delegate ()
            {
                Nvideo.Text = ftpController.video.data.Count.ToString();
            });
            Nxml.Invoke((MethodInvoker)delegate ()
            {
                Nxml.Text = ftpController.xml.data.Count.ToString();
            });
            Nfoto.Invoke((MethodInvoker)delegate ()
            {
                Nfoto.Text = ftpController.foto.data.Count.ToString();
            });
        }
        private void sql_buffer_count()
        {
            SQL_buffer.Invoke((MethodInvoker)delegate ()
            {
                SQL_buffer.Text = SQL_Buffer_list.data.Count.ToString();
            });
        }
        
        private async void save_Click(object sender, EventArgs e)
        {
            Serialize.inputs = data;
            myConsoleWrite("Program sa reštartuje.");
            for (int i = 3; i >= 0; i--) {
                myConsoleWrite(i.ToString());
                await Task.Delay(1000);
            }
            Application.Restart();
        }
        private void log_file_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                folderpath = dialog.FileName;
                try
                {
                    string[] last = Regex.Split(folderpath, @"\\");
                    file = last[last.Length - 1];
                    string path = "";
                    for (int i = 0; i < last.Length - 1; i++)
                    {
                        path += last[i] + @"\";
                    }
                    data.ser_log_file = file;
                    data.ser_log_folderpath = path;
                    log_file_button.Text = file;
                    myConsoleWrite("Sledovaný súbor nastavený na: " + path + file);
                }
                catch (Exception err)
                {
                    myConsoleWrite(err.ToString());
                }
            }
        }
    }
}