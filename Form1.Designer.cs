namespace Perspective
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPosXval = new System.Windows.Forms.Label();
            this.lblPosYVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Perspective.Properties.Resources.source1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 574);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(538, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(500, 574);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "原始圖片";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(538, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "結果";
            // 
            // lblPosXval
            // 
            this.lblPosXval.AutoSize = true;
            this.lblPosXval.Location = new System.Drawing.Point(248, 20);
            this.lblPosXval.Name = "lblPosXval";
            this.lblPosXval.Size = new System.Drawing.Size(42, 15);
            this.lblPosXval.TabIndex = 4;
            this.lblPosXval.Text = "label3";
            this.lblPosXval.Visible = false;
            // 
            // lblPosYVal
            // 
            this.lblPosYVal.AutoSize = true;
            this.lblPosYVal.Location = new System.Drawing.Point(296, 20);
            this.lblPosYVal.Name = "lblPosYVal";
            this.lblPosYVal.Size = new System.Drawing.Size(42, 15);
            this.lblPosYVal.TabIndex = 5;
            this.lblPosYVal.Text = "label4";
            this.lblPosYVal.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 669);
            this.Controls.Add(this.lblPosYVal);
            this.Controls.Add(this.lblPosXval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Label lblPosXval;
        private Label lblPosYVal;
    }
}