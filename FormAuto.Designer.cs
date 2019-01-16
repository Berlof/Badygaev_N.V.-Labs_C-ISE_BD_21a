namespace Labs
{
    partial class FormAuto
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
            this.pictureBoxBulldozer = new System.Windows.Forms.PictureBox();
            this.buttonCreateBulldozer = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonCreateTractor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBulldozer)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBulldozer
            // 
            this.pictureBoxBulldozer.Location = new System.Drawing.Point(12, 35);
            this.pictureBoxBulldozer.Name = "pictureBoxBulldozer";
            this.pictureBoxBulldozer.Size = new System.Drawing.Size(811, 510);
            this.pictureBoxBulldozer.TabIndex = 0;
            this.pictureBoxBulldozer.TabStop = false;
            // 
            // buttonCreateBulldozer
            // 
            this.buttonCreateBulldozer.Location = new System.Drawing.Point(13, 13);
            this.buttonCreateBulldozer.Name = "buttonCreateBulldozer";
            this.buttonCreateBulldozer.Size = new System.Drawing.Size(143, 23);
            this.buttonCreateBulldozer.TabIndex = 1;
            this.buttonCreateBulldozer.Text = "Cоздать бульдозер";
            this.buttonCreateBulldozer.UseVisualStyleBackColor = true;
            this.buttonCreateBulldozer.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(671, 448);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.Text = "Вверх";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(599, 486);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonLeft.TabIndex = 3;
            this.buttonLeft.Text = "Влево";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(739, 486);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(75, 23);
            this.buttonRight.TabIndex = 4;
            this.buttonRight.Text = "Вправо";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(671, 515);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 5;
            this.buttonDown.Text = "Вниз";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonCreateTractor
            // 
            this.buttonCreateTractor.Location = new System.Drawing.Point(256, 12);
            this.buttonCreateTractor.Name = "buttonCreateTractor";
            this.buttonCreateTractor.Size = new System.Drawing.Size(167, 23);
            this.buttonCreateTractor.TabIndex = 6;
            this.buttonCreateTractor.Text = "Создать тракотор";
            this.buttonCreateTractor.UseVisualStyleBackColor = true;
            this.buttonCreateTractor.Click += new System.EventHandler(this.buttonCreateTractor_Click);
            // 
            // FormAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 552);
            this.Controls.Add(this.buttonCreateTractor);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonCreateBulldozer);
            this.Controls.Add(this.pictureBoxBulldozer);
            this.Name = "FormAuto";
            this.Text = "Грузовик";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBulldozer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBulldozer;
        private System.Windows.Forms.Button buttonCreateBulldozer;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonCreateTractor;
    }
}