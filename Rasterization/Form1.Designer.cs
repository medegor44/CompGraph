namespace Rasterization
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
            this.segmentRB = new System.Windows.Forms.RadioButton();
            this.circleRB = new System.Windows.Forms.RadioButton();
            this.x0TB = new System.Windows.Forms.TextBox();
            this.y0TB = new System.Windows.Forms.TextBox();
            this.x1TB = new System.Windows.Forms.TextBox();
            this.y1TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.xTB = new System.Windows.Forms.TextBox();
            this.yTB = new System.Windows.Forms.TextBox();
            this.rTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(701, 701);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // segmentRB
            // 
            this.segmentRB.AutoSize = true;
            this.segmentRB.Location = new System.Drawing.Point(720, 13);
            this.segmentRB.Name = "segmentRB";
            this.segmentRB.Size = new System.Drawing.Size(67, 17);
            this.segmentRB.TabIndex = 1;
            this.segmentRB.TabStop = true;
            this.segmentRB.Text = "Segment";
            this.segmentRB.UseVisualStyleBackColor = true;
            this.segmentRB.CheckedChanged += new System.EventHandler(this.segmentRB_CheckedChanged);
            // 
            // circleRB
            // 
            this.circleRB.AutoSize = true;
            this.circleRB.Location = new System.Drawing.Point(720, 136);
            this.circleRB.Name = "circleRB";
            this.circleRB.Size = new System.Drawing.Size(51, 17);
            this.circleRB.TabIndex = 2;
            this.circleRB.TabStop = true;
            this.circleRB.Text = "Circle";
            this.circleRB.UseVisualStyleBackColor = true;
            this.circleRB.CheckedChanged += new System.EventHandler(this.circleRB_CheckedChanged);
            // 
            // x0TB
            // 
            this.x0TB.Location = new System.Drawing.Point(720, 37);
            this.x0TB.Name = "x0TB";
            this.x0TB.Size = new System.Drawing.Size(100, 20);
            this.x0TB.TabIndex = 3;
            this.x0TB.Text = "0";
            // 
            // y0TB
            // 
            this.y0TB.Location = new System.Drawing.Point(719, 63);
            this.y0TB.Name = "y0TB";
            this.y0TB.Size = new System.Drawing.Size(100, 20);
            this.y0TB.TabIndex = 4;
            this.y0TB.Text = "0";
            // 
            // x1TB
            // 
            this.x1TB.Location = new System.Drawing.Point(719, 89);
            this.x1TB.Name = "x1TB";
            this.x1TB.Size = new System.Drawing.Size(100, 20);
            this.x1TB.TabIndex = 5;
            this.x1TB.Text = "1";
            // 
            // y1TB
            // 
            this.y1TB.Location = new System.Drawing.Point(719, 115);
            this.y1TB.Name = "y1TB";
            this.y1TB.Size = new System.Drawing.Size(100, 20);
            this.y1TB.TabIndex = 6;
            this.y1TB.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(827, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "x0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(826, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "y0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(826, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "x1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(826, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "y1";
            // 
            // xTB
            // 
            this.xTB.Location = new System.Drawing.Point(720, 160);
            this.xTB.Name = "xTB";
            this.xTB.Size = new System.Drawing.Size(100, 20);
            this.xTB.TabIndex = 11;
            this.xTB.Text = "0";
            // 
            // yTB
            // 
            this.yTB.Location = new System.Drawing.Point(720, 188);
            this.yTB.Name = "yTB";
            this.yTB.Size = new System.Drawing.Size(100, 20);
            this.yTB.TabIndex = 12;
            this.yTB.Text = "0";
            // 
            // rTB
            // 
            this.rTB.Location = new System.Drawing.Point(719, 214);
            this.rTB.Name = "rTB";
            this.rTB.Size = new System.Drawing.Size(100, 20);
            this.rTB.TabIndex = 13;
            this.rTB.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(826, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "x";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(826, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(823, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "R";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(719, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 722);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rTB);
            this.Controls.Add(this.yTB);
            this.Controls.Add(this.xTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.y1TB);
            this.Controls.Add(this.x1TB);
            this.Controls.Add(this.y0TB);
            this.Controls.Add(this.x0TB);
            this.Controls.Add(this.circleRB);
            this.Controls.Add(this.segmentRB);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.RadioButton segmentRB;
        private System.Windows.Forms.RadioButton circleRB;
        private System.Windows.Forms.TextBox x0TB;
        private System.Windows.Forms.TextBox y0TB;
        private System.Windows.Forms.TextBox x1TB;
        private System.Windows.Forms.TextBox y1TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox xTB;
        private System.Windows.Forms.TextBox yTB;
        private System.Windows.Forms.TextBox rTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}

