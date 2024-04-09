namespace PrimerProgama
{
    partial class FastEthernet
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastEthernet));
            pictureBox1 = new PictureBox();
            memoriaCache = new Button();
            limpiaCarpetaTemp = new Button();
            limpiaCarpetaTemp2 = new Button();
            desactivarServiciosActu = new Button();
            cambiarDNS = new Button();
            tituloPrograma = new Label();
            LabelCopyright = new Label();
            loadGif = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loadGif).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.FondoGif;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(775, 544);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // memoriaCache
            // 
            memoriaCache.BackColor = Color.Blue;
            memoriaCache.ForeColor = Color.White;
            memoriaCache.Location = new Point(517, 113);
            memoriaCache.Name = "memoriaCache";
            memoriaCache.Size = new Size(183, 72);
            memoriaCache.TabIndex = 3;
            memoriaCache.Text = "Vacía la memoria caché de DNS";
            memoriaCache.UseVisualStyleBackColor = false;
            memoriaCache.Click += memoriaCache_Click;
            // 
            // limpiaCarpetaTemp
            // 
            limpiaCarpetaTemp.BackColor = Color.Blue;
            limpiaCarpetaTemp.ForeColor = Color.White;
            limpiaCarpetaTemp.Location = new Point(56, 221);
            limpiaCarpetaTemp.Name = "limpiaCarpetaTemp";
            limpiaCarpetaTemp.Size = new Size(183, 72);
            limpiaCarpetaTemp.TabIndex = 4;
            limpiaCarpetaTemp.Text = "Limpia la carpeta TEMP del sistema";
            limpiaCarpetaTemp.UseVisualStyleBackColor = false;
            limpiaCarpetaTemp.Click += limpiaCarpetaTemp_Click;
            // 
            // limpiaCarpetaTemp2
            // 
            limpiaCarpetaTemp2.BackColor = Color.Blue;
            limpiaCarpetaTemp2.ForeColor = Color.White;
            limpiaCarpetaTemp2.Location = new Point(56, 329);
            limpiaCarpetaTemp2.Name = "limpiaCarpetaTemp2";
            limpiaCarpetaTemp2.Size = new Size(183, 72);
            limpiaCarpetaTemp2.TabIndex = 5;
            limpiaCarpetaTemp2.Text = "Limpia la carpeta %TEMP% del sistema";
            limpiaCarpetaTemp2.UseVisualStyleBackColor = false;
            limpiaCarpetaTemp2.Click += limpiaCarpetaTemp2_Click;
            // 
            // desactivarServiciosActu
            // 
            desactivarServiciosActu.BackColor = Color.Blue;
            desactivarServiciosActu.ForeColor = Color.White;
            desactivarServiciosActu.Location = new Point(517, 221);
            desactivarServiciosActu.Name = "desactivarServiciosActu";
            desactivarServiciosActu.Size = new Size(183, 72);
            desactivarServiciosActu.TabIndex = 6;
            desactivarServiciosActu.Text = "Desactiva el servicio de actualizaciones de Windows";
            desactivarServiciosActu.UseVisualStyleBackColor = false;
            desactivarServiciosActu.Click += desactivarServiciosActu_Click;
            // 
            // cambiarDNS
            // 
            cambiarDNS.BackColor = Color.Blue;
            cambiarDNS.ForeColor = Color.White;
            cambiarDNS.Location = new Point(56, 113);
            cambiarDNS.Name = "cambiarDNS";
            cambiarDNS.Size = new Size(183, 72);
            cambiarDNS.TabIndex = 7;
            cambiarDNS.Text = "Cambia de servidores DNS";
            cambiarDNS.UseVisualStyleBackColor = false;
            cambiarDNS.Click += cambiarDNS_Click;
            // 
            // tituloPrograma
            // 
            tituloPrograma.AutoSize = true;
            tituloPrograma.BackColor = Color.Transparent;
            tituloPrograma.Font = new Font("VTC-GarageSale", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            tituloPrograma.ForeColor = Color.White;
            tituloPrograma.Location = new Point(161, 34);
            tituloPrograma.Name = "tituloPrograma";
            tituloPrograma.Size = new Size(467, 31);
            tituloPrograma.TabIndex = 10;
            tituloPrograma.Text = "Fast Ehternet By Ing Jefferson Rodriguez ";
            // 
            // LabelCopyright
            // 
            LabelCopyright.AutoSize = true;
            LabelCopyright.BackColor = Color.Transparent;
            LabelCopyright.Font = new Font("Dimitri Swank", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelCopyright.ForeColor = Color.White;
            LabelCopyright.Location = new Point(16, 476);
            LabelCopyright.Name = "LabelCopyright";
            LabelCopyright.Size = new Size(747, 21);
            LabelCopyright.TabIndex = 11;
            LabelCopyright.Text = "© Copyright 2024   |   Todos los Derechos Reservados By Ing. Jefferson Rodriguez";
            // 
            // loadGif
            // 
            loadGif.Image = Properties.Resources.load;
            loadGif.Location = new Point(287, 145);
            loadGif.Name = "loadGif";
            loadGif.Size = new Size(256, 256);
            loadGif.SizeMode = PictureBoxSizeMode.AutoSize;
            loadGif.TabIndex = 12;
            loadGif.TabStop = false;
            loadGif.Visible = false;
            // 
            // FastEthernet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 544);
            Controls.Add(loadGif);
            Controls.Add(LabelCopyright);
            Controls.Add(tituloPrograma);
            Controls.Add(cambiarDNS);
            Controls.Add(desactivarServiciosActu);
            Controls.Add(limpiaCarpetaTemp2);
            Controls.Add(limpiaCarpetaTemp);
            Controls.Add(memoriaCache);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FastEthernet";
            Text = "Fast Ehternet";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)loadGif).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button memoriaCache;
        private Button limpiaCarpetaTemp;
        private Button limpiaCarpetaTemp2;
        private Button desactivarServiciosActu;
        private Button cambiarDNS;
        private Label tituloPrograma;
        private Label LabelCopyright;
        private PictureBox loadGif;
    }
}
