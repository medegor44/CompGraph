namespace SegmentCut
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
            this.polygonPoints = new System.Windows.Forms.TextBox();
            this.segmPoints = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(811, 811);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // polygonPoints
            // 
            this.polygonPoints.Location = new System.Drawing.Point(829, 28);
            this.polygonPoints.Multiline = true;
            this.polygonPoints.Name = "polygonPoints";
            this.polygonPoints.Size = new System.Drawing.Size(132, 166);
            this.polygonPoints.TabIndex = 1;
            // 
            // segmPoints
            // 
            this.segmPoints.Location = new System.Drawing.Point(829, 213);
            this.segmPoints.Multiline = true;
            this.segmPoints.Name = "segmPoints";
            this.segmPoints.Size = new System.Drawing.Size(132, 78);
            this.segmPoints.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(829, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Polygon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(829, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Segment";
            // 
            // cutBtn
            // 
            this.cutBtn.Location = new System.Drawing.Point(830, 298);
            this.cutBtn.Name = "cutBtn";
            this.cutBtn.Size = new System.Drawing.Size(131, 23);
            this.cutBtn.TabIndex = 5;
            this.cutBtn.Text = "Cut";
            this.cutBtn.UseVisualStyleBackColor = true;
            this.cutBtn.Click += new System.EventHandler(this.cutBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 832);
            this.Controls.Add(this.cutBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.segmPoints);
            this.Controls.Add(this.polygonPoints);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TextBox polygonPoints;
        private System.Windows.Forms.TextBox segmPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cutBtn;
    }
}

