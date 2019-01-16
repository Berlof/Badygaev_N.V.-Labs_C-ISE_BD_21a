namespace Labs
{
    partial class FormTractorConfig
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.labelTractor = new System.Windows.Forms.Label();
            this.labelTractorBase = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.labelMainColor = new System.Windows.Forms.Label();
            this.labelDopColor = new System.Windows.Forms.Label();
            this.groupBoxColors = new System.Windows.Forms.GroupBox();
            this.panelColor1 = new System.Windows.Forms.Panel();
            this.panelColor2 = new System.Windows.Forms.Panel();
            this.panelColor3 = new System.Windows.Forms.Panel();
            this.panelColor4 = new System.Windows.Forms.Panel();
            this.panelColor5 = new System.Windows.Forms.Panel();
            this.panelColor6 = new System.Windows.Forms.Panel();
            this.panelColor7 = new System.Windows.Forms.Panel();
            this.panelColor8 = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox.SuspendLayout();
            this.panel.SuspendLayout();
            this.groupBoxColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(15, 16);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(150, 100);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.labelTractor);
            this.groupBox.Controls.Add(this.labelTractorBase);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(120, 130);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Тип кузова";
            // 
            // labelTractor
            // 
            this.labelTractor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTractor.Location = new System.Drawing.Point(6, 60);
            this.labelTractor.Name = "labelTractor";
            this.labelTractor.Size = new System.Drawing.Size(100, 30);
            this.labelTractor.TabIndex = 1;
            this.labelTractor.Text = "Бульдозер";
            this.labelTractor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTractor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTractor_MouseDown);
            // 
            // labelTractorBase
            // 
            this.labelTractorBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTractorBase.Location = new System.Drawing.Point(6, 16);
            this.labelTractorBase.Name = "labelTractorBase";
            this.labelTractorBase.Size = new System.Drawing.Size(100, 30);
            this.labelTractorBase.TabIndex = 0;
            this.labelTractorBase.Text = "Трактор";
            this.labelTractorBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTractorBase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTractorBase_MouseDown);
            // 
            // panel
            // 
            this.panel.AllowDrop = true;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.labelDopColor);
            this.panel.Controls.Add(this.labelMainColor);
            this.panel.Controls.Add(this.pictureBox);
            this.panel.Location = new System.Drawing.Point(156, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(182, 236);
            this.panel.TabIndex = 2;
            this.panel.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelTractor_DragDrop);
            this.panel.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelTractor_DragEnter);
            // 
            // labelMainColor
            // 
            this.labelMainColor.AllowDrop = true;
            this.labelMainColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMainColor.Location = new System.Drawing.Point(15, 129);
            this.labelMainColor.Name = "labelMainColor";
            this.labelMainColor.Size = new System.Drawing.Size(150, 40);
            this.labelMainColor.TabIndex = 3;
            this.labelMainColor.Text = "Основной цвет";
            this.labelMainColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMainColor.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelBaseColor_DragDrop);
            this.labelMainColor.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelBaseColor_DragEnter);
            // 
            // labelDopColor
            // 
            this.labelDopColor.AllowDrop = true;
            this.labelDopColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDopColor.Location = new System.Drawing.Point(15, 181);
            this.labelDopColor.Name = "labelDopColor";
            this.labelDopColor.Size = new System.Drawing.Size(150, 40);
            this.labelDopColor.TabIndex = 4;
            this.labelDopColor.Text = "Доп. цвет";
            this.labelDopColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDopColor.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDopColor_DragDrop);
            this.labelDopColor.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelBaseColor_DragEnter);
            // 
            // groupBoxColors
            // 
            this.groupBoxColors.Controls.Add(this.panelColor8);
            this.groupBoxColors.Controls.Add(this.panelColor7);
            this.groupBoxColors.Controls.Add(this.panelColor6);
            this.groupBoxColors.Controls.Add(this.panelColor5);
            this.groupBoxColors.Controls.Add(this.panelColor4);
            this.groupBoxColors.Controls.Add(this.panelColor3);
            this.groupBoxColors.Controls.Add(this.panelColor2);
            this.groupBoxColors.Controls.Add(this.panelColor1);
            this.groupBoxColors.Location = new System.Drawing.Point(366, 12);
            this.groupBoxColors.Name = "groupBoxColors";
            this.groupBoxColors.Size = new System.Drawing.Size(135, 236);
            this.groupBoxColors.TabIndex = 3;
            this.groupBoxColors.TabStop = false;
            this.groupBoxColors.Text = "Цвета";
            // 
            // panelColor1
            // 
            this.panelColor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor1.Location = new System.Drawing.Point(16, 23);
            this.panelColor1.Name = "panelColor1";
            this.panelColor1.Size = new System.Drawing.Size(40, 40);
            this.panelColor1.TabIndex = 0;
            this.panelColor1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelColor2
            // 
            this.panelColor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor2.Location = new System.Drawing.Point(76, 23);
            this.panelColor2.Name = "panelColor2";
            this.panelColor2.Size = new System.Drawing.Size(40, 40);
            this.panelColor2.TabIndex = 1;
            this.panelColor2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelColor3
            // 
            this.panelColor3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelColor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor3.Location = new System.Drawing.Point(16, 77);
            this.panelColor3.Name = "panelColor3";
            this.panelColor3.Size = new System.Drawing.Size(40, 40);
            this.panelColor3.TabIndex = 2;
            this.panelColor3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelColor4
            // 
            this.panelColor4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panelColor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor4.Location = new System.Drawing.Point(76, 77);
            this.panelColor4.Name = "panelColor4";
            this.panelColor4.Size = new System.Drawing.Size(40, 40);
            this.panelColor4.TabIndex = 3;
            this.panelColor4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelColor5
            // 
            this.panelColor5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panelColor5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor5.Location = new System.Drawing.Point(16, 130);
            this.panelColor5.Name = "panelColor5";
            this.panelColor5.Size = new System.Drawing.Size(40, 40);
            this.panelColor5.TabIndex = 4;
            this.panelColor5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelColor6
            // 
            this.panelColor6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelColor6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor6.Location = new System.Drawing.Point(76, 130);
            this.panelColor6.Name = "panelColor6";
            this.panelColor6.Size = new System.Drawing.Size(40, 40);
            this.panelColor6.TabIndex = 5;
            this.panelColor6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelColor7
            // 
            this.panelColor7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelColor7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor7.Location = new System.Drawing.Point(16, 182);
            this.panelColor7.Name = "panelColor7";
            this.panelColor7.Size = new System.Drawing.Size(40, 40);
            this.panelColor7.TabIndex = 6;
            this.panelColor7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // panelColor8
            // 
            this.panelColor8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelColor8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor8.Location = new System.Drawing.Point(76, 182);
            this.panelColor8.Name = "panelColor8";
            this.panelColor8.Size = new System.Drawing.Size(40, 40);
            this.panelColor8.TabIndex = 7;
            this.panelColor8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelColor_MouseDown);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 148);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(120, 40);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(12, 208);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 40);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Отмена";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // FormTractorConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 260);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBoxColors);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.groupBox);
            this.Name = "FormTractorConfig";
            this.Text = "FormTractorConfig";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.groupBoxColors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label labelTractor;
        private System.Windows.Forms.Label labelTractorBase;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label labelDopColor;
        private System.Windows.Forms.Label labelMainColor;
        private System.Windows.Forms.GroupBox groupBoxColors;
        private System.Windows.Forms.Panel panelColor8;
        private System.Windows.Forms.Panel panelColor7;
        private System.Windows.Forms.Panel panelColor6;
        private System.Windows.Forms.Panel panelColor5;
        private System.Windows.Forms.Panel panelColor4;
        private System.Windows.Forms.Panel panelColor3;
        private System.Windows.Forms.Panel panelColor2;
        private System.Windows.Forms.Panel panelColor1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClose;
    }
}