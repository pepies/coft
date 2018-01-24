namespace Camsoft
{
    partial class Achp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {            
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Achp));
            this.lbl_stredisko_id = new System.Windows.Forms.Label();
            this.lbl_cam_ip = new System.Windows.Forms.Label();
            this.lbl_cam_pw = new System.Windows.Forms.Label();
            this.toolTip_stredisko = new System.Windows.Forms.ToolTip(this.components);
            this.id_strediska = new System.Windows.Forms.TextBox();
            this.cam_ip = new System.Windows.Forms.TextBox();
            this.cam_pw = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.myconsole = new System.Windows.Forms.RichTextBox();
            this.lbl_meno_cam = new System.Windows.Forms.Label();
            this.cam_name = new System.Windows.Forms.TextBox();
            this.lbl_codec = new System.Windows.Forms.Label();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.lbl_server_ip = new System.Windows.Forms.Label();
            this.server_ip = new System.Windows.Forms.TextBox();
            this.status_camera = new System.Windows.Forms.PictureBox();
            this.lbl_ftp_mmeno = new System.Windows.Forms.Label();
            this.ftp_meno = new System.Windows.Forms.TextBox();
            this.lbl_ftp_heslo = new System.Windows.Forms.Label();
            this.ftp_heslo = new System.Windows.Forms.TextBox();
            this.lbl_SQL_pw = new System.Windows.Forms.Label();
            this.sql_pw = new System.Windows.Forms.TextBox();
            this.sql_box = new System.Windows.Forms.GroupBox();
            this.SQL_buffer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.status_sql = new System.Windows.Forms.PictureBox();
            this.lbl_sql_meno = new System.Windows.Forms.Label();
            this.sql_meno = new System.Windows.Forms.TextBox();
            this.FTP_box = new System.Windows.Forms.GroupBox();
            this.Nxml = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Nfoto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Nvideo = new System.Windows.Forms.Label();
            this.status_ftp = new System.Windows.Forms.PictureBox();
            this.cam_box = new System.Windows.Forms.GroupBox();
            this.vaha_horna_hranica = new System.Windows.Forms.NumericUpDown();
            this.Vaha = new System.Windows.Forms.GroupBox();
            this.actualWeight = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.log_file_button = new System.Windows.Forms.Button();
            this.text_od = new System.Windows.Forms.Label();
            this.vaha_status_img = new System.Windows.Forms.PictureBox();
            this.AMC = new AxAXISMEDIACONTROLLib.AxAxisMediaControl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.status_camera)).BeginInit();
            this.sql_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.status_sql)).BeginInit();
            this.FTP_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.status_ftp)).BeginInit();
            this.cam_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vaha_horna_hranica)).BeginInit();
            this.Vaha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vaha_status_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMC)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_stredisko_id
            // 
            this.lbl_stredisko_id.AutoSize = true;
            this.lbl_stredisko_id.Location = new System.Drawing.Point(16, 152);
            this.lbl_stredisko_id.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_stredisko_id.Name = "lbl_stredisko_id";
            this.lbl_stredisko_id.Size = new System.Drawing.Size(131, 25);
            this.lbl_stredisko_id.TabIndex = 0;
            this.lbl_stredisko_id.Text = "ID strediska:";
            // 
            // lbl_cam_ip
            // 
            this.lbl_cam_ip.AutoSize = true;
            this.lbl_cam_ip.Location = new System.Drawing.Point(26, 60);
            this.lbl_cam_ip.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_cam_ip.Name = "lbl_cam_ip";
            this.lbl_cam_ip.Size = new System.Drawing.Size(113, 25);
            this.lbl_cam_ip.TabIndex = 1;
            this.lbl_cam_ip.Text = "IP kamery:";
            // 
            // lbl_cam_pw
            // 
            this.lbl_cam_pw.AutoSize = true;
            this.lbl_cam_pw.Location = new System.Drawing.Point(4, 160);
            this.lbl_cam_pw.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_cam_pw.Name = "lbl_cam_pw";
            this.lbl_cam_pw.Size = new System.Drawing.Size(134, 25);
            this.lbl_cam_pw.TabIndex = 2;
            this.lbl_cam_pw.Text = "PW  kamery:";
            // 
            // id_strediska
            // 
            this.id_strediska.Location = new System.Drawing.Point(160, 146);
            this.id_strediska.Margin = new System.Windows.Forms.Padding(6);
            this.id_strediska.MaxLength = 10;
            this.id_strediska.Name = "id_strediska";
            this.id_strediska.Size = new System.Drawing.Size(196, 31);
            this.id_strediska.TabIndex = 12;
            // 
            // cam_ip
            // 
            this.cam_ip.Location = new System.Drawing.Point(158, 54);
            this.cam_ip.Margin = new System.Windows.Forms.Padding(6);
            this.cam_ip.Name = "cam_ip";
            this.cam_ip.Size = new System.Drawing.Size(196, 31);
            this.cam_ip.TabIndex = 4;
            // 
            // cam_pw
            // 
            this.cam_pw.Location = new System.Drawing.Point(158, 154);
            this.cam_pw.Margin = new System.Windows.Forms.Padding(6);
            this.cam_pw.Name = "cam_pw";
            this.cam_pw.PasswordChar = '*';
            this.cam_pw.Size = new System.Drawing.Size(196, 31);
            this.cam_pw.TabIndex = 6;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(442, 329);
            this.save.Margin = new System.Windows.Forms.Padding(6);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(1048, 44);
            this.save.TabIndex = 15;
            this.save.Text = "Ulož nastavenia";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // myconsole
            // 
            this.myconsole.Location = new System.Drawing.Point(442, 385);
            this.myconsole.Margin = new System.Windows.Forms.Padding(6);
            this.myconsole.Name = "myconsole";
            this.myconsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.myconsole.Size = new System.Drawing.Size(1048, 360);
            this.myconsole.TabIndex = 20;
            this.myconsole.Text = "";
            // 
            // lbl_meno_cam
            // 
            this.lbl_meno_cam.AutoSize = true;
            this.lbl_meno_cam.Location = new System.Drawing.Point(18, 110);
            this.lbl_meno_cam.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_meno_cam.Name = "lbl_meno_cam";
            this.lbl_meno_cam.Size = new System.Drawing.Size(120, 25);
            this.lbl_meno_cam.TabIndex = 15;
            this.lbl_meno_cam.Text = "ID  kamery:";
            // 
            // cam_name
            // 
            this.cam_name.Location = new System.Drawing.Point(158, 104);
            this.cam_name.Margin = new System.Windows.Forms.Padding(6);
            this.cam_name.Name = "cam_name";
            this.cam_name.Size = new System.Drawing.Size(196, 31);
            this.cam_name.TabIndex = 5;
            // 
            // lbl_codec
            // 
            this.lbl_codec.AutoSize = true;
            this.lbl_codec.Location = new System.Drawing.Point(1, 212);
            this.lbl_codec.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_codec.Name = "lbl_codec";
            this.lbl_codec.Size = new System.Drawing.Size(137, 25);
            this.lbl_codec.TabIndex = 18;
            this.lbl_codec.Text = "Typ streamu:";
            // 
            // TypeBox
            // 
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Items.AddRange(new object[] {
            Camsoft.MediaType.h264,
            Camsoft.MediaType.mpeg4,
            Camsoft.MediaType.Mjpeg});
            this.TypeBox.Location = new System.Drawing.Point(158, 204);
            this.TypeBox.Margin = new System.Windows.Forms.Padding(6);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(196, 33);
            this.TypeBox.TabIndex = 7;
            // 
            // lbl_server_ip
            // 
            this.lbl_server_ip.AutoSize = true;
            this.lbl_server_ip.Location = new System.Drawing.Point(12, 99);
            this.lbl_server_ip.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_server_ip.Name = "lbl_server_ip";
            this.lbl_server_ip.Size = new System.Drawing.Size(115, 25);
            this.lbl_server_ip.TabIndex = 19;
            this.lbl_server_ip.Text = "IP servera:";
            // 
            // server_ip
            // 
            this.server_ip.Location = new System.Drawing.Point(580, 115);
            this.server_ip.Margin = new System.Windows.Forms.Padding(6);
            this.server_ip.Name = "server_ip";
            this.server_ip.Size = new System.Drawing.Size(596, 31);
            this.server_ip.TabIndex = 8;
            // 
            // status_camera
            // 
            this.status_camera.Image = global::Camsoft.Properties.Resources.camera_noinfo;
            this.status_camera.Location = new System.Drawing.Point(147, 0);
            this.status_camera.Margin = new System.Windows.Forms.Padding(6);
            this.status_camera.Name = "status_camera";
            this.status_camera.Size = new System.Drawing.Size(32, 31);
            this.status_camera.TabIndex = 22;
            this.status_camera.TabStop = false;
            // 
            // lbl_ftp_mmeno
            // 
            this.lbl_ftp_mmeno.AutoSize = true;
            this.lbl_ftp_mmeno.Location = new System.Drawing.Point(12, 160);
            this.lbl_ftp_mmeno.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_ftp_mmeno.Name = "lbl_ftp_mmeno";
            this.lbl_ftp_mmeno.Size = new System.Drawing.Size(117, 25);
            this.lbl_ftp_mmeno.TabIndex = 23;
            this.lbl_ftp_mmeno.Text = "FTP meno:";
            // 
            // ftp_meno
            // 
            this.ftp_meno.Enabled = false;
            this.ftp_meno.Location = new System.Drawing.Point(138, 154);
            this.ftp_meno.Margin = new System.Windows.Forms.Padding(6);
            this.ftp_meno.Name = "ftp_meno";
            this.ftp_meno.ReadOnly = true;
            this.ftp_meno.Size = new System.Drawing.Size(196, 31);
            this.ftp_meno.TabIndex = 9;
            // 
            // lbl_ftp_heslo
            // 
            this.lbl_ftp_heslo.AutoSize = true;
            this.lbl_ftp_heslo.Location = new System.Drawing.Point(14, 210);
            this.lbl_ftp_heslo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_ftp_heslo.Name = "lbl_ftp_heslo";
            this.lbl_ftp_heslo.Size = new System.Drawing.Size(116, 25);
            this.lbl_ftp_heslo.TabIndex = 25;
            this.lbl_ftp_heslo.Text = "FTP heslo:";
            // 
            // ftp_heslo
            // 
            this.ftp_heslo.Enabled = false;
            this.ftp_heslo.Location = new System.Drawing.Point(138, 204);
            this.ftp_heslo.Margin = new System.Windows.Forms.Padding(6);
            this.ftp_heslo.Name = "ftp_heslo";
            this.ftp_heslo.PasswordChar = '*';
            this.ftp_heslo.ReadOnly = true;
            this.ftp_heslo.Size = new System.Drawing.Size(196, 31);
            this.ftp_heslo.TabIndex = 10;
            // 
            // lbl_SQL_pw
            // 
            this.lbl_SQL_pw.AutoSize = true;
            this.lbl_SQL_pw.Location = new System.Drawing.Point(30, 252);
            this.lbl_SQL_pw.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_SQL_pw.Name = "lbl_SQL_pw";
            this.lbl_SQL_pw.Size = new System.Drawing.Size(118, 25);
            this.lbl_SQL_pw.TabIndex = 28;
            this.lbl_SQL_pw.Text = "SQL heslo:";
            // 
            // sql_pw
            // 
            this.sql_pw.Enabled = false;
            this.sql_pw.Location = new System.Drawing.Point(162, 246);
            this.sql_pw.Margin = new System.Windows.Forms.Padding(6);
            this.sql_pw.Name = "sql_pw";
            this.sql_pw.PasswordChar = '*';
            this.sql_pw.ReadOnly = true;
            this.sql_pw.Size = new System.Drawing.Size(196, 31);
            this.sql_pw.TabIndex = 14;
            // 
            // sql_box
            // 
            this.sql_box.Controls.Add(this.SQL_buffer);
            this.sql_box.Controls.Add(this.label2);
            this.sql_box.Controls.Add(this.status_sql);
            this.sql_box.Controls.Add(this.lbl_sql_meno);
            this.sql_box.Controls.Add(this.sql_meno);
            this.sql_box.Controls.Add(this.sql_pw);
            this.sql_box.Controls.Add(this.lbl_SQL_pw);
            this.sql_box.Controls.Add(this.id_strediska);
            this.sql_box.Controls.Add(this.lbl_stredisko_id);
            this.sql_box.Location = new System.Drawing.Point(820, 19);
            this.sql_box.Margin = new System.Windows.Forms.Padding(6);
            this.sql_box.Name = "sql_box";
            this.sql_box.Padding = new System.Windows.Forms.Padding(6);
            this.sql_box.Size = new System.Drawing.Size(382, 298);
            this.sql_box.TabIndex = 30;
            this.sql_box.TabStop = false;
            this.sql_box.Text = "SQL";
            // 
            // SQL_buffer
            // 
            this.SQL_buffer.AutoSize = true;
            this.SQL_buffer.Location = new System.Drawing.Point(117, 44);
            this.SQL_buffer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.SQL_buffer.Name = "SQL_buffer";
            this.SQL_buffer.Size = new System.Drawing.Size(24, 25);
            this.SQL_buffer.TabIndex = 37;
            this.SQL_buffer.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 36;
            this.label2.Text = "Buffer:";
            // 
            // status_sql
            // 
            this.status_sql.Image = global::Camsoft.Properties.Resources.sql_noinfo;
            this.status_sql.Location = new System.Drawing.Point(73, 0);
            this.status_sql.Margin = new System.Windows.Forms.Padding(6);
            this.status_sql.Name = "status_sql";
            this.status_sql.Size = new System.Drawing.Size(32, 31);
            this.status_sql.TabIndex = 30;
            this.status_sql.TabStop = false;
            // 
            // lbl_sql_meno
            // 
            this.lbl_sql_meno.AutoSize = true;
            this.lbl_sql_meno.Location = new System.Drawing.Point(28, 202);
            this.lbl_sql_meno.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_sql_meno.Name = "lbl_sql_meno";
            this.lbl_sql_meno.Size = new System.Drawing.Size(119, 25);
            this.lbl_sql_meno.TabIndex = 31;
            this.lbl_sql_meno.Text = "SQL meno:";
            // 
            // sql_meno
            // 
            this.sql_meno.Enabled = false;
            this.sql_meno.Location = new System.Drawing.Point(160, 196);
            this.sql_meno.Margin = new System.Windows.Forms.Padding(6);
            this.sql_meno.Name = "sql_meno";
            this.sql_meno.ReadOnly = true;
            this.sql_meno.Size = new System.Drawing.Size(196, 31);
            this.sql_meno.TabIndex = 13;
            // 
            // FTP_box
            // 
            this.FTP_box.Controls.Add(this.Nxml);
            this.FTP_box.Controls.Add(this.label4);
            this.FTP_box.Controls.Add(this.Nfoto);
            this.FTP_box.Controls.Add(this.label3);
            this.FTP_box.Controls.Add(this.label1);
            this.FTP_box.Controls.Add(this.Nvideo);
            this.FTP_box.Controls.Add(this.status_ftp);
            this.FTP_box.Controls.Add(this.ftp_heslo);
            this.FTP_box.Controls.Add(this.lbl_ftp_heslo);
            this.FTP_box.Controls.Add(this.ftp_meno);
            this.FTP_box.Controls.Add(this.lbl_ftp_mmeno);
            this.FTP_box.Controls.Add(this.lbl_server_ip);
            this.FTP_box.Location = new System.Drawing.Point(442, 19);
            this.FTP_box.Margin = new System.Windows.Forms.Padding(6);
            this.FTP_box.Name = "FTP_box";
            this.FTP_box.Padding = new System.Windows.Forms.Padding(6);
            this.FTP_box.Size = new System.Drawing.Size(360, 298);
            this.FTP_box.TabIndex = 31;
            this.FTP_box.TabStop = false;
            this.FTP_box.Text = "FTP";
            // 
            // Nxml
            // 
            this.Nxml.AutoSize = true;
            this.Nxml.Location = new System.Drawing.Point(308, 51);
            this.Nxml.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Nxml.Name = "Nxml";
            this.Nxml.Size = new System.Drawing.Size(36, 25);
            this.Nxml.TabIndex = 39;
            this.Nxml.Text = "?  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 25);
            this.label4.TabIndex = 38;
            this.label4.Text = "Xml:";
            // 
            // Nfoto
            // 
            this.Nfoto.AutoSize = true;
            this.Nfoto.Location = new System.Drawing.Point(206, 51);
            this.Nfoto.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Nfoto.Name = "Nfoto";
            this.Nfoto.Size = new System.Drawing.Size(36, 25);
            this.Nfoto.TabIndex = 37;
            this.Nfoto.Text = "?  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "Fotiek:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 35;
            this.label1.Text = "Videí:";
            // 
            // Nvideo
            // 
            this.Nvideo.AutoSize = true;
            this.Nvideo.Location = new System.Drawing.Point(90, 51);
            this.Nvideo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Nvideo.Name = "Nvideo";
            this.Nvideo.Size = new System.Drawing.Size(36, 25);
            this.Nvideo.TabIndex = 34;
            this.Nvideo.Text = "?  ";
            // 
            // status_ftp
            // 
            this.status_ftp.Image = global::Camsoft.Properties.Resources.ftp_noinfo;
            this.status_ftp.Location = new System.Drawing.Point(63, 0);
            this.status_ftp.Margin = new System.Windows.Forms.Padding(6);
            this.status_ftp.Name = "status_ftp";
            this.status_ftp.Size = new System.Drawing.Size(32, 31);
            this.status_ftp.TabIndex = 24;
            this.status_ftp.TabStop = false;
            // 
            // cam_box
            // 
            this.cam_box.Controls.Add(this.status_camera);
            this.cam_box.Controls.Add(this.lbl_codec);
            this.cam_box.Controls.Add(this.TypeBox);
            this.cam_box.Controls.Add(this.cam_name);
            this.cam_box.Controls.Add(this.lbl_meno_cam);
            this.cam_box.Controls.Add(this.cam_pw);
            this.cam_box.Controls.Add(this.cam_ip);
            this.cam_box.Controls.Add(this.lbl_cam_pw);
            this.cam_box.Controls.Add(this.lbl_cam_ip);
            this.cam_box.Location = new System.Drawing.Point(36, 21);
            this.cam_box.Margin = new System.Windows.Forms.Padding(6);
            this.cam_box.Name = "cam_box";
            this.cam_box.Padding = new System.Windows.Forms.Padding(6);
            this.cam_box.Size = new System.Drawing.Size(390, 352);
            this.cam_box.TabIndex = 32;
            this.cam_box.TabStop = false;
            this.cam_box.Text = "Axis Kamera";
            // 
            // vaha_horna_hranica
            // 
            this.vaha_horna_hranica.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.vaha_horna_hranica.Location = new System.Drawing.Point(143, 196);
            this.vaha_horna_hranica.Margin = new System.Windows.Forms.Padding(6);
            this.vaha_horna_hranica.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.vaha_horna_hranica.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.vaha_horna_hranica.Name = "vaha_horna_hranica";
            this.vaha_horna_hranica.Size = new System.Drawing.Size(86, 31);
            this.vaha_horna_hranica.TabIndex = 35;
            // 
            // Vaha
            // 
            this.Vaha.Controls.Add(this.actualWeight);
            this.Vaha.Controls.Add(this.label6);
            this.Vaha.Controls.Add(this.log_file_button);
            this.Vaha.Controls.Add(this.text_od);
            this.Vaha.Controls.Add(this.vaha_status_img);
            this.Vaha.Controls.Add(this.vaha_horna_hranica);
            this.Vaha.Location = new System.Drawing.Point(1214, 21);
            this.Vaha.Margin = new System.Windows.Forms.Padding(6);
            this.Vaha.Name = "Vaha";
            this.Vaha.Padding = new System.Windows.Forms.Padding(6);
            this.Vaha.Size = new System.Drawing.Size(276, 294);
            this.Vaha.TabIndex = 37;
            this.Vaha.TabStop = false;
            this.Vaha.Text = "Váha";
            // 
            // actualWeight
            // 
            this.actualWeight.AutoSize = true;
            this.actualWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualWeight.Location = new System.Drawing.Point(66, 92);
            this.actualWeight.Name = "actualWeight";
            this.actualWeight.Size = new System.Drawing.Size(155, 37);
            this.actualWeight.TabIndex = 45;
            this.actualWeight.Text = "      ?      ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 198);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 25);
            this.label6.TabIndex = 44;
            this.label6.Text = "kg";
            // 
            // log_file_button
            // 
            this.log_file_button.Location = new System.Drawing.Point(0, 242);
            this.log_file_button.Margin = new System.Windows.Forms.Padding(6);
            this.log_file_button.Name = "log_file_button";
            this.log_file_button.Size = new System.Drawing.Size(272, 44);
            this.log_file_button.TabIndex = 42;
            this.log_file_button.UseVisualStyleBackColor = true;
            this.log_file_button.Click += new System.EventHandler(this.log_file_btn_Click);
            // 
            // text_od
            // 
            this.text_od.AutoSize = true;
            this.text_od.Location = new System.Drawing.Point(1, 195);
            this.text_od.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.text_od.Name = "text_od";
            this.text_od.Size = new System.Drawing.Size(130, 25);
            this.text_od.TabIndex = 41;
            this.text_od.Text = "Nahrávať od";
            // 
            // vaha_status_img
            // 
            this.vaha_status_img.Image = global::Camsoft.Properties.Resources.log_noinfo;
            this.vaha_status_img.InitialImage = global::Camsoft.Properties.Resources.log_noinfo;
            this.vaha_status_img.Location = new System.Drawing.Point(82, 2);
            this.vaha_status_img.Margin = new System.Windows.Forms.Padding(6);
            this.vaha_status_img.Name = "vaha_status_img";
            this.vaha_status_img.Size = new System.Drawing.Size(32, 35);
            this.vaha_status_img.TabIndex = 40;
            this.vaha_status_img.TabStop = false;
            // 
            // AMC
            // 
            this.AMC.Enabled = true;
            this.AMC.Location = new System.Drawing.Point(0, 3);
            this.AMC.Name = "AMC";
            this.AMC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AMC.OcxState")));
            this.AMC.Size = new System.Drawing.Size(387, 354);
            this.AMC.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AMC);
            this.panel1.Location = new System.Drawing.Point(36, 385);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 360);
            this.panel1.TabIndex = 39;
            // 
            // Achp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1524, 774);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Vaha);
            this.Controls.Add(this.cam_box);
            this.Controls.Add(this.server_ip);
            this.Controls.Add(this.FTP_box);
            this.Controls.Add(this.sql_box);
            this.Controls.Add(this.myconsole);
            this.Controls.Add(this.save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Achp";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Load += new System.EventHandler(this.Achp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.status_camera)).EndInit();
            this.sql_box.ResumeLayout(false);
            this.sql_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.status_sql)).EndInit();
            this.FTP_box.ResumeLayout(false);
            this.FTP_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.status_ftp)).EndInit();
            this.cam_box.ResumeLayout(false);
            this.cam_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vaha_horna_hranica)).EndInit();
            this.Vaha.ResumeLayout(false);
            this.Vaha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vaha_status_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AMC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_stredisko_id;
        private System.Windows.Forms.Label lbl_cam_ip;
        private System.Windows.Forms.Label lbl_cam_pw;
        private System.Windows.Forms.ToolTip toolTip_stredisko;
        private System.Windows.Forms.TextBox id_strediska;
        private System.Windows.Forms.TextBox cam_ip;
        private System.Windows.Forms.TextBox cam_pw;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.RichTextBox myconsole;
        private System.Windows.Forms.TextBox cam_name;
        private System.Windows.Forms.Label lbl_meno_cam;
        private System.Windows.Forms.Label lbl_codec;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.PictureBox status_camera;
        private System.Windows.Forms.TextBox server_ip;
        private System.Windows.Forms.Label lbl_server_ip;
        private System.Windows.Forms.GroupBox cam_box;
        private System.Windows.Forms.GroupBox FTP_box;
        private System.Windows.Forms.TextBox ftp_heslo;
        private System.Windows.Forms.Label lbl_ftp_heslo;
        private System.Windows.Forms.TextBox ftp_meno;
        private System.Windows.Forms.Label lbl_ftp_mmeno;
        private System.Windows.Forms.GroupBox sql_box;
        private System.Windows.Forms.Label lbl_sql_meno;
        private System.Windows.Forms.TextBox sql_meno;
        private System.Windows.Forms.TextBox sql_pw;
        private System.Windows.Forms.Label lbl_SQL_pw;
        private System.Windows.Forms.PictureBox status_ftp;
        private System.Windows.Forms.PictureBox status_sql;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Nvideo;
        private System.Windows.Forms.Label SQL_buffer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox Vaha;
        private System.Windows.Forms.NumericUpDown vaha_horna_hranica;
        private System.Windows.Forms.Label text_od;
        private System.Windows.Forms.PictureBox vaha_status_img;
        private System.Windows.Forms.Button log_file_button;
        private System.Windows.Forms.Label Nfoto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Nxml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public AxAXISMEDIACONTROLLib.AxAxisMediaControl AMC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label actualWeight;
    }
}


