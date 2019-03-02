namespace ComputerGr
{
    partial class Form1
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.angleTb = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.dxtextBox = new System.Windows.Forms.TextBox();
            this.dytextBox = new System.Windows.Forms.TextBox();
            this.moveBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xStretchTb = new System.Windows.Forms.TrackBar();
            this.yStretchTb = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.reflectXBtn = new System.Windows.Forms.Button();
            this.reflectYBtn = new System.Windows.Forms.Button();
            this.reflectXYBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.ptXtextBox = new System.Windows.Forms.TextBox();
            this.ptYtextBox = new System.Windows.Forms.TextBox();
            this.ptCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleTb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xStretchTb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yStretchTb)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(717, 695);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // angleTb
            // 
            this.angleTb.Location = new System.Drawing.Point(735, 11);
            this.angleTb.Maximum = 1000;
            this.angleTb.Name = "angleTb";
            this.angleTb.Size = new System.Drawing.Size(169, 45);
            this.angleTb.TabIndex = 1;
            this.angleTb.Scroll += new System.EventHandler(this.angleTb_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(732, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rotate";
            // 
            // dxtextBox
            // 
            this.dxtextBox.Location = new System.Drawing.Point(735, 138);
            this.dxtextBox.Name = "dxtextBox";
            this.dxtextBox.Size = new System.Drawing.Size(145, 20);
            this.dxtextBox.TabIndex = 3;
            // 
            // dytextBox
            // 
            this.dytextBox.Location = new System.Drawing.Point(735, 164);
            this.dytextBox.Name = "dytextBox";
            this.dytextBox.Size = new System.Drawing.Size(145, 20);
            this.dytextBox.TabIndex = 4;
            // 
            // moveBtn
            // 
            this.moveBtn.Location = new System.Drawing.Point(735, 190);
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(169, 23);
            this.moveBtn.TabIndex = 5;
            this.moveBtn.Text = "Move by (dx, dy)";
            this.moveBtn.UseVisualStyleBackColor = true;
            this.moveBtn.Click += new System.EventHandler(this.moveBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(890, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "dx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(890, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "dy";
            // 
            // xStretchTb
            // 
            this.xStretchTb.Location = new System.Drawing.Point(735, 219);
            this.xStretchTb.Maximum = 100;
            this.xStretchTb.Minimum = 1;
            this.xStretchTb.Name = "xStretchTb";
            this.xStretchTb.Size = new System.Drawing.Size(169, 45);
            this.xStretchTb.TabIndex = 8;
            this.xStretchTb.Value = 50;
            this.xStretchTb.Scroll += new System.EventHandler(this.xStretchTb_Scroll);
            // 
            // yStretchTb
            // 
            this.yStretchTb.Location = new System.Drawing.Point(735, 283);
            this.yStretchTb.Maximum = 100;
            this.yStretchTb.Minimum = 1;
            this.yStretchTb.Name = "yStretchTb";
            this.yStretchTb.Size = new System.Drawing.Size(169, 45);
            this.yStretchTb.TabIndex = 9;
            this.yStretchTb.Value = 50;
            this.yStretchTb.Scroll += new System.EventHandler(this.yStretchTb_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(732, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Stretch by x";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(735, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Stretch by y";
            // 
            // reflectXBtn
            // 
            this.reflectXBtn.Location = new System.Drawing.Point(735, 347);
            this.reflectXBtn.Name = "reflectXBtn";
            this.reflectXBtn.Size = new System.Drawing.Size(169, 23);
            this.reflectXBtn.TabIndex = 12;
            this.reflectXBtn.Text = "Reflect x";
            this.reflectXBtn.UseVisualStyleBackColor = true;
            this.reflectXBtn.Click += new System.EventHandler(this.reflectXBtn_Click);
            // 
            // reflectYBtn
            // 
            this.reflectYBtn.Location = new System.Drawing.Point(735, 376);
            this.reflectYBtn.Name = "reflectYBtn";
            this.reflectYBtn.Size = new System.Drawing.Size(169, 23);
            this.reflectYBtn.TabIndex = 13;
            this.reflectYBtn.Text = "Reflect y";
            this.reflectYBtn.UseVisualStyleBackColor = true;
            this.reflectYBtn.Click += new System.EventHandler(this.reflectYBtn_Click);
            // 
            // reflectXYBtn
            // 
            this.reflectXYBtn.Location = new System.Drawing.Point(735, 405);
            this.reflectXYBtn.Name = "reflectXYBtn";
            this.reflectXYBtn.Size = new System.Drawing.Size(168, 23);
            this.reflectXYBtn.TabIndex = 14;
            this.reflectXYBtn.Text = "Reflect y = x";
            this.reflectXYBtn.UseVisualStyleBackColor = true;
            this.reflectXYBtn.Click += new System.EventHandler(this.reflectXYBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(735, 434);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(168, 23);
            this.resetBtn.TabIndex = 15;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // ptXtextBox
            // 
            this.ptXtextBox.Enabled = false;
            this.ptXtextBox.Location = new System.Drawing.Point(735, 63);
            this.ptXtextBox.Name = "ptXtextBox";
            this.ptXtextBox.Size = new System.Drawing.Size(141, 20);
            this.ptXtextBox.TabIndex = 16;
            this.ptXtextBox.Text = "0";
            // 
            // ptYtextBox
            // 
            this.ptYtextBox.Enabled = false;
            this.ptYtextBox.Location = new System.Drawing.Point(735, 89);
            this.ptYtextBox.Name = "ptYtextBox";
            this.ptYtextBox.Size = new System.Drawing.Size(142, 20);
            this.ptYtextBox.TabIndex = 17;
            this.ptYtextBox.Text = "0";
            // 
            // ptCheckBox
            // 
            this.ptCheckBox.AutoSize = true;
            this.ptCheckBox.Location = new System.Drawing.Point(735, 115);
            this.ptCheckBox.Name = "ptCheckBox";
            this.ptCheckBox.Size = new System.Drawing.Size(82, 17);
            this.ptCheckBox.TabIndex = 18;
            this.ptCheckBox.Text = "By the point";
            this.ptCheckBox.UseVisualStyleBackColor = true;
            this.ptCheckBox.CheckedChanged += new System.EventHandler(this.ptCheckBox_CheckedChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(886, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "x";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(886, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 719);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ptCheckBox);
            this.Controls.Add(this.ptYtextBox);
            this.Controls.Add(this.ptXtextBox);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.reflectXYBtn);
            this.Controls.Add(this.reflectYBtn);
            this.Controls.Add(this.reflectXBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yStretchTb);
            this.Controls.Add(this.xStretchTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.moveBtn);
            this.Controls.Add(this.dytextBox);
            this.Controls.Add(this.dxtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.angleTb);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleTb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xStretchTb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yStretchTb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TrackBar angleTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dxtextBox;
        private System.Windows.Forms.TextBox dytextBox;
        private System.Windows.Forms.Button moveBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar xStretchTb;
        private System.Windows.Forms.TrackBar yStretchTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button reflectXBtn;
        private System.Windows.Forms.Button reflectYBtn;
        private System.Windows.Forms.Button reflectXYBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.TextBox ptXtextBox;
        private System.Windows.Forms.TextBox ptYtextBox;
        private System.Windows.Forms.CheckBox ptCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

