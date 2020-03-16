namespace DrawnWhispers
{
    partial class guess
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.topBar = new System.Windows.Forms.Panel();
            this.submitBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.guessBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.topBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(232)))), ((int)(((byte)(219)))));
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(961, 650);
            this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(106)))), ((int)(((byte)(98)))));
            this.topBar.Controls.Add(this.submitBtn);
            this.topBar.Controls.Add(this.textBox1);
            this.topBar.Controls.Add(this.guessBox);
            this.topBar.Controls.Add(this.panel1);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.topBar.Location = new System.Drawing.Point(0, 563);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(961, 87);
            this.topBar.TabIndex = 4;
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(232)))), ((int)(((byte)(219)))));
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.Location = new System.Drawing.Point(868, 16);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(81, 58);
            this.submitBtn.TabIndex = 1;
            this.submitBtn.Text = "submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(232)))), ((int)(((byte)(219)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(12, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(850, 33);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Enter description";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Enter += new System.EventHandler(this.GuessBox_Enter);
            this.textBox1.Leave += new System.EventHandler(this.GuessBox_Leave);
            // 
            // guessBox
            // 
            this.guessBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(232)))), ((int)(((byte)(219)))));
            this.guessBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guessBox.Font = new System.Drawing.Font("Bahnschrift", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guessBox.HideSelection = false;
            this.guessBox.Location = new System.Drawing.Point(12, 27);
            this.guessBox.Name = "guessBox";
            this.guessBox.Size = new System.Drawing.Size(850, 33);
            this.guessBox.TabIndex = 0;
            this.guessBox.Text = "Enter description";
            this.guessBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guessBox.Enter += new System.EventHandler(this.GuessBox_Enter);
            this.guessBox.Leave += new System.EventHandler(this.GuessBox_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(232)))), ((int)(((byte)(219)))));
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 58);
            this.panel1.TabIndex = 2;
            // 
            // guess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 650);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "guess";
            this.Text = "guess";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.TextBox guessBox;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
    }
}