namespace lab1
{
    partial class FormAuto
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxBulldozer = new System.Windows.Forms.PictureBox();
            this.create = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonCreateCar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBulldozer)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBulldozer
            // 
            this.pictureBoxBulldozer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBulldozer.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBulldozer.Name = "pictureBoxBulldozer";
            this.pictureBoxBulldozer.Size = new System.Drawing.Size(884, 461);
            this.pictureBoxBulldozer.TabIndex = 0;
            this.pictureBoxBulldozer.TabStop = false;
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(0, 0);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(117, 23);
            this.create.TabIndex = 1;
            this.create.Text = "Создать Бульдозер";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(694, 355);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.TabStop = false;
            this.buttonUp.Text = "Вверх";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(694, 403);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 3;
            this.buttonDown.Text = "Вниз";
            this.buttonDown.UseVisualStyleBackColor = true;
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(605, 403);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonLeft.TabIndex = 4;
            this.buttonLeft.Text = "Влево";
            this.buttonLeft.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(775, 403);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(75, 23);
            this.buttonRight.TabIndex = 5;
            this.buttonRight.Text = "вправо";
            this.buttonRight.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(694, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вниз";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(775, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "вправо";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonCreateCar
            // 
            this.buttonCreateCar.Location = new System.Drawing.Point(176, -1);
            this.buttonCreateCar.Name = "buttonCreateCar";
            this.buttonCreateCar.Size = new System.Drawing.Size(121, 23);
            this.buttonCreateCar.TabIndex = 6;
            this.buttonCreateCar.Text = "Создать Трактор";
            this.buttonCreateCar.UseVisualStyleBackColor = true;
            this.buttonCreateCar.Click += new System.EventHandler(this.buttonCreateCar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.buttonCreateCar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.create);
            this.Controls.Add(this.pictureBoxBulldozer);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBulldozer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBulldozer;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonCreateCar;
    }
}