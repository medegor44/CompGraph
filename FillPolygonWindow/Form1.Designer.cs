namespace FillPolygonWindow
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
            this.components = new System.ComponentModel.Container();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.polygonPts = new System.Windows.Forms.TextBox();
            this.startPt = new System.Windows.Forms.TextBox();
            this.fillBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(801, 801);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            // 
            // polygonPts
            // 
            this.polygonPts.Location = new System.Drawing.Point(819, 12);
            this.polygonPts.Multiline = true;
            this.polygonPts.Name = "polygonPts";
            this.polygonPts.Size = new System.Drawing.Size(114, 266);
            this.polygonPts.TabIndex = 1;
            // 
            // startPt
            // 
            this.startPt.Location = new System.Drawing.Point(819, 285);
            this.startPt.Name = "startPt";
            this.startPt.Size = new System.Drawing.Size(114, 20);
            this.startPt.TabIndex = 2;
            // 
            // fillBtn
            // 
            this.fillBtn.Location = new System.Drawing.Point(819, 311);
            this.fillBtn.Name = "fillBtn";
            this.fillBtn.Size = new System.Drawing.Size(114, 23);
            this.fillBtn.TabIndex = 3;
            this.fillBtn.Text = "Fill";
            this.fillBtn.UseVisualStyleBackColor = true;
            this.fillBtn.Click += new System.EventHandler(this.FillBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 817);
            this.Controls.Add(this.fillBtn);
            this.Controls.Add(this.startPt);
            this.Controls.Add(this.polygonPts);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TextBox polygonPts;
        private System.Windows.Forms.TextBox startPt;
        private System.Windows.Forms.Button fillBtn;
        private System.Windows.Forms.Timer timer1;
    }
}

