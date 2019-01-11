namespace lab1
{
    partial class FormCarConfig
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelBuldozer = new System.Windows.Forms.Label();
            this.labelCar = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelW = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panelBlue = new System.Windows.Forms.Panel();
            this.panelGrean = new System.Windows.Forms.Panel();
            this.panelRed = new System.Windows.Forms.Panel();
            this.panelYellow = new System.Windows.Forms.Panel();
            this.panelBlack = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(3, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(167, 157);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.labelCar);
            this.groupBox1.Controls.Add(this.labelBuldozer);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 230);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelBuldozer
            // 
            this.labelBuldozer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelBuldozer.Location = new System.Drawing.Point(6, 104);
            this.labelBuldozer.Name = "labelBuldozer";
            this.labelBuldozer.Size = new System.Drawing.Size(100, 23);
            this.labelBuldozer.TabIndex = 1;
            this.labelBuldozer.Text = "Бульдозер";
            this.labelBuldozer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelBuldozer_MouseDown);
            // 
            // labelCar
            // 
            this.labelCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCar.Location = new System.Drawing.Point(6, 33);
            this.labelCar.Name = "labelCar";
            this.labelCar.Size = new System.Drawing.Size(100, 23);
            this.labelCar.TabIndex = 0;
            this.labelCar.Text = "Трактор";
            this.labelCar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelCar_MouseDown);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(156, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 316);
            this.panel1.TabIndex = 2;
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelCar_DragDrop);
            this.panel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelCar_DragEnter);
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(36, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дополнительный цвет";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelBaseColor_DragDrop);
            this.label2.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelDopColor_DragEnter);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(36, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Основной цвет";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelBaseColor_DragDrop);
            this.label1.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelBaseColor_DragEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelW);
            this.groupBox2.Controls.Add(this.panel8);
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.panelBlue);
            this.groupBox2.Controls.Add(this.panelGrean);
            this.groupBox2.Controls.Add(this.panelRed);
            this.groupBox2.Controls.Add(this.panelYellow);
            this.groupBox2.Controls.Add(this.panelBlack);
            this.groupBox2.Location = new System.Drawing.Point(350, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 296);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Цвета";
            // 
            // panelW
            // 
            this.panelW.BackColor = System.Drawing.Color.White;
            this.panelW.Location = new System.Drawing.Point(112, 206);
            this.panelW.Name = "panelW";
            this.panelW.Size = new System.Drawing.Size(52, 55);
            this.panelW.TabIndex = 7;
            this.panelW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel8.Location = new System.Drawing.Point(26, 206);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(58, 55);
            this.panel8.TabIndex = 6;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            this.panel8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel7.Location = new System.Drawing.Point(112, 138);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(52, 62);
            this.panel7.TabIndex = 5;
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelBlue
            // 
            this.panelBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panelBlue.Location = new System.Drawing.Point(26, 138);
            this.panelBlue.Name = "panelBlue";
            this.panelBlue.Size = new System.Drawing.Size(58, 62);
            this.panelBlue.TabIndex = 4;
            this.panelBlue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelGrean
            // 
            this.panelGrean.BackColor = System.Drawing.Color.Lime;
            this.panelGrean.Location = new System.Drawing.Point(112, 78);
            this.panelGrean.Name = "panelGrean";
            this.panelGrean.Size = new System.Drawing.Size(52, 54);
            this.panelGrean.TabIndex = 3;
            this.panelGrean.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelRed
            // 
            this.panelRed.BackColor = System.Drawing.Color.Red;
            this.panelRed.Location = new System.Drawing.Point(26, 78);
            this.panelRed.Name = "panelRed";
            this.panelRed.Size = new System.Drawing.Size(58, 54);
            this.panelRed.TabIndex = 2;
            this.panelRed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelYellow
            // 
            this.panelYellow.BackColor = System.Drawing.Color.Yellow;
            this.panelYellow.Location = new System.Drawing.Point(112, 19);
            this.panelYellow.Name = "panelYellow";
            this.panelYellow.Size = new System.Drawing.Size(52, 53);
            this.panelYellow.TabIndex = 1;
            this.panelYellow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelBlack
            // 
            this.panelBlack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelBlack.Location = new System.Drawing.Point(26, 19);
            this.panelBlack.Name = "panelBlack";
            this.panelBlack.Size = new System.Drawing.Size(58, 53);
            this.panelBlack.TabIndex = 0;
            this.panelBlack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // FormCarConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 340);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCarConfig";
            this.Text = "FormCarConfig";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelBuldozer;
        private System.Windows.Forms.Label labelCar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelW;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panelBlue;
        private System.Windows.Forms.Panel panelGrean;
        private System.Windows.Forms.Panel panelRed;
        private System.Windows.Forms.Panel panelYellow;
        private System.Windows.Forms.Panel panelBlack;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}