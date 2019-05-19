namespace ConvexHullWindow
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
            this.pointsTb = new System.Windows.Forms.TextBox();
            this.buildCHBtn = new System.Windows.Forms.Button();
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
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // pointsTb
            // 
            this.pointsTb.Location = new System.Drawing.Point(820, 12);
            this.pointsTb.Multiline = true;
            this.pointsTb.Name = "pointsTb";
            this.pointsTb.Size = new System.Drawing.Size(136, 307);
            this.pointsTb.TabIndex = 1;
            // 
            // buildCHBtn
            // 
            this.buildCHBtn.Location = new System.Drawing.Point(819, 325);
            this.buildCHBtn.Name = "buildCHBtn";
            this.buildCHBtn.Size = new System.Drawing.Size(137, 23);
            this.buildCHBtn.TabIndex = 2;
            this.buildCHBtn.Text = "Build";
            this.buildCHBtn.UseVisualStyleBackColor = true;
            this.buildCHBtn.Click += new System.EventHandler(this.buildCHBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 821);
            this.Controls.Add(this.buildCHBtn);
            this.Controls.Add(this.pointsTb);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TextBox pointsTb;
        private System.Windows.Forms.Button buildCHBtn;
        private System.Windows.Forms.Timer timer1;
    }
}

