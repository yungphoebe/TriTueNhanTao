namespace TriTueNhanTao
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.btnBasicDemo = new System.Windows.Forms.Button();
            this.btnVietNamDemo = new System.Windows.Forms.Button();
            this.labelBasicDesc = new System.Windows.Forms.Label();
            this.labelVietNamDesc = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelFooter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelTitle.Location = new System.Drawing.Point(80, 30);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(590, 31);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Demo Thuật Toán Di Truyền (GA) - Bài Toán TSP";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelDescription.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelDescription.Location = new System.Drawing.Point(120, 80);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(510, 20);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Nghiên cứu về thuật giải di truyền và ứng dụng trong bài toán TSP";
            // 
            // btnBasicDemo
            // 
            this.btnBasicDemo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBasicDemo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnBasicDemo.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnBasicDemo.Location = new System.Drawing.Point(150, 180);
            this.btnBasicDemo.Name = "btnBasicDemo";
            this.btnBasicDemo.Size = new System.Drawing.Size(200, 60);
            this.btnBasicDemo.TabIndex = 2;
            this.btnBasicDemo.Text = "Demo Cơ Bản";
            this.btnBasicDemo.UseVisualStyleBackColor = false;
            this.btnBasicDemo.Click += new System.EventHandler(this.btnBasicDemo_Click);
            // 
            // btnVietNamDemo
            // 
            this.btnVietNamDemo.BackColor = System.Drawing.Color.LightGreen;
            this.btnVietNamDemo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnVietNamDemo.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnVietNamDemo.Location = new System.Drawing.Point(400, 180);
            this.btnVietNamDemo.Name = "btnVietNamDemo";
            this.btnVietNamDemo.Size = new System.Drawing.Size(200, 60);
            this.btnVietNamDemo.TabIndex = 3;
            this.btnVietNamDemo.Text = "Demo Bản Đồ Việt Nam";
            this.btnVietNamDemo.UseVisualStyleBackColor = false;
            this.btnVietNamDemo.Click += new System.EventHandler(this.btnVietNamDemo_Click);
            // 
            // labelBasicDesc
            // 
            this.labelBasicDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelBasicDesc.Location = new System.Drawing.Point(120, 260);
            this.labelBasicDesc.Name = "labelBasicDesc";
            this.labelBasicDesc.Size = new System.Drawing.Size(260, 80);
            this.labelBasicDesc.TabIndex = 4;
            this.labelBasicDesc.Text = "• Tạo thành phố ngẫu nhiên\r\n• Thêm thành phố bằng chuột\r\n• Visualization cơ bản\r\n• Phù hợp học tập GA";
            // 
            // labelVietNamDesc
            // 
            this.labelVietNamDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelVietNamDesc.Location = new System.Drawing.Point(370, 260);
            this.labelVietNamDesc.Name = "labelVietNamDesc";
            this.labelVietNamDesc.Size = new System.Drawing.Size(260, 80);
            this.labelVietNamDesc.TabIndex = 5;
            this.labelVietNamDesc.Text = "• Bản đồ Việt Nam thực tế\r\n• 63 tỉnh thành chính\r\n• Khoảng cách thực tế (km)\r\n• Ứng dụng thực tiễn";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(350, 370);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.TabIndex = 6;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelFooter
            // 
            this.labelFooter.AutoSize = true;
            this.labelFooter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.labelFooter.ForeColor = System.Drawing.Color.Gray;
            this.labelFooter.Location = new System.Drawing.Point(280, 430);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(190, 15);
            this.labelFooter.TabIndex = 7;
            this.labelFooter.Text = "Đồ án môn Trí Tuệ Nhân Tạo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(750, 470);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelVietNamDesc);
            this.Controls.Add(this.labelBasicDesc);
            this.Controls.Add(this.btnVietNamDemo);
            this.Controls.Add(this.btnBasicDemo);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GA-TSP Demo - Trí Tuệ Nhân Tạo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button btnBasicDemo;
        private System.Windows.Forms.Button btnVietNamDemo;
        private System.Windows.Forms.Label labelBasicDesc;
        private System.Windows.Forms.Label labelVietNamDesc;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelFooter;
    }
}

