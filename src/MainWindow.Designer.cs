namespace BrightnessControl
{
    partial class MainWindow
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
            this.BrightnessValueLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LastKnownBrightnessValue = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BrightnessValueLabel
            // 
            this.BrightnessValueLabel.AutoSize = true;
            this.BrightnessValueLabel.Location = new System.Drawing.Point(26, 46);
            this.BrightnessValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BrightnessValueLabel.Name = "BrightnessValueLabel";
            this.BrightnessValueLabel.Size = new System.Drawing.Size(19, 21);
            this.BrightnessValueLabel.TabIndex = 0;
            this.BrightnessValueLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "BRIGHTNESS_VALUE";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 106);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(293, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "GET_UPDATED_BRIGHTNESS_VALUE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 106);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(292, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "GET_LAST_BRIGHTNESS_VALUE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 163);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 29);
            this.textBox1.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 203);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(292, 45);
            this.button3.TabIndex = 5;
            this.button3.Text = "SET_CUSTOM_BRIGHTNESS_VALUE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "LAST_KNOWN_BRIGHTNESS_VALUE";
            // 
            // LastKnownBrightnessValue
            // 
            this.LastKnownBrightnessValue.AutoSize = true;
            this.LastKnownBrightnessValue.Location = new System.Drawing.Point(212, 46);
            this.LastKnownBrightnessValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LastKnownBrightnessValue.Name = "LastKnownBrightnessValue";
            this.LastKnownBrightnessValue.Size = new System.Drawing.Size(19, 21);
            this.LastKnownBrightnessValue.TabIndex = 7;
            this.LastKnownBrightnessValue.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(216, 336);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(236, 60);
            this.button4.TabIndex = 8;
            this.button4.Text = "Auto Brightness";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 432);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.LastKnownBrightnessValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrightnessValueLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brightness Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BrightnessValueLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LastKnownBrightnessValue;
        private System.Windows.Forms.Button button4;
    }
}

