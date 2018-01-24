namespace Log_tester
{
    partial class Form1
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
            this.start = new System.Windows.Forms.Button();
            this.startDva = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.start.Location = new System.Drawing.Point(44, 23);
            this.start.Margin = new System.Windows.Forms.Padding(6);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(405, 44);
            this.start.TabIndex = 0;
            this.start.Text = "Start TEST - jedno auto";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // startDva
            // 
            this.startDva.BackColor = System.Drawing.Color.MediumTurquoise;
            this.startDva.Location = new System.Drawing.Point(44, 79);
            this.startDva.Margin = new System.Windows.Forms.Padding(6);
            this.startDva.Name = "startDva";
            this.startDva.Size = new System.Drawing.Size(405, 44);
            this.startDva.TabIndex = 1;
            this.startDva.Text = "Start TEST - dve za sebou idúce autá";
            this.startDva.UseVisualStyleBackColor = false;
            this.startDva.Click += new System.EventHandler(this.startDva_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Plum;
            this.button1.Location = new System.Drawing.Point(44, 135);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(405, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Štart krátkeho TESTu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 201);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startDva);
            this.Controls.Add(this.start);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Simulátor Vt_logu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button startDva;
        private System.Windows.Forms.Button button1;
    }
}

