namespace TriTueNhanTao
{
    partial class BasicTSPForm
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
            this.panelMap = new System.Windows.Forms.Panel();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.labelCities = new System.Windows.Forms.Label();
            this.numericCities = new System.Windows.Forms.NumericUpDown();
            this.labelPopulationSize = new System.Windows.Forms.Label();
            this.numericPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.labelMutationRate = new System.Windows.Forms.Label();
            this.numericMutationRate = new System.Windows.Forms.NumericUpDown();
            this.labelGenerations = new System.Windows.Forms.Label();
            this.numericGenerations = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGenerateCities = new System.Windows.Forms.Button();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.labelBestDistance = new System.Windows.Forms.Label();
            this.textBoxBestDistance = new System.Windows.Forms.TextBox();
            this.labelCurrentGeneration = new System.Windows.Forms.Label();
            this.textBoxCurrentGeneration = new System.Windows.Forms.TextBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBarEvolution = new System.Windows.Forms.ProgressBar();
            this.timerEvolution = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBoxParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMutationRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGenerations)).BeginInit();
            this.groupBoxResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMap
            // 
            this.panelMap.BackColor = System.Drawing.Color.White;
            this.panelMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMap.Location = new System.Drawing.Point(12, 12);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(600, 500);
            this.panelMap.TabIndex = 0;
            this.panelMap.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMap_Paint);
            this.panelMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMap_MouseClick);
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.labelCities);
            this.groupBoxParameters.Controls.Add(this.numericCities);
            this.groupBoxParameters.Controls.Add(this.labelPopulationSize);
            this.groupBoxParameters.Controls.Add(this.numericPopulationSize);
            this.groupBoxParameters.Controls.Add(this.labelMutationRate);
            this.groupBoxParameters.Controls.Add(this.numericMutationRate);
            this.groupBoxParameters.Controls.Add(this.labelGenerations);
            this.groupBoxParameters.Controls.Add(this.numericGenerations);
            this.groupBoxParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxParameters.Location = new System.Drawing.Point(630, 12);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(250, 180);
            this.groupBoxParameters.TabIndex = 1;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Tham Số GA";
            // 
            // labelCities
            // 
            this.labelCities.AutoSize = true;
            this.labelCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCities.Location = new System.Drawing.Point(15, 25);
            this.labelCities.Name = "labelCities";
            this.labelCities.Size = new System.Drawing.Size(140, 18);
            this.labelCities.TabIndex = 0;
            this.labelCities.Text = "Số lượng thành phố:";
            this.labelCities.Click += new System.EventHandler(this.labelCities_Click);
            // 
            // numericCities
            // 
            this.numericCities.Location = new System.Drawing.Point(150, 23);
            this.numericCities.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericCities.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericCities.Name = "numericCities";
            this.numericCities.Size = new System.Drawing.Size(80, 26);
            this.numericCities.TabIndex = 1;
            this.numericCities.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelPopulationSize
            // 
            this.labelPopulationSize.AutoSize = true;
            this.labelPopulationSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPopulationSize.Location = new System.Drawing.Point(15, 55);
            this.labelPopulationSize.Name = "labelPopulationSize";
            this.labelPopulationSize.Size = new System.Drawing.Size(152, 18);
            this.labelPopulationSize.TabIndex = 2;
            this.labelPopulationSize.Text = "Kích Thước Quần Thể";
            // 
            // numericPopulationSize
            // 
            this.numericPopulationSize.Location = new System.Drawing.Point(150, 53);
            this.numericPopulationSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericPopulationSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericPopulationSize.Name = "numericPopulationSize";
            this.numericPopulationSize.Size = new System.Drawing.Size(80, 26);
            this.numericPopulationSize.TabIndex = 3;
            this.numericPopulationSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // labelMutationRate
            // 
            this.labelMutationRate.AutoSize = true;
            this.labelMutationRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMutationRate.Location = new System.Drawing.Point(15, 85);
            this.labelMutationRate.Name = "labelMutationRate";
            this.labelMutationRate.Size = new System.Drawing.Size(95, 18);
            this.labelMutationRate.TabIndex = 4;
            this.labelMutationRate.Text = "Tỷ lệ đột biến";
            // 
            // numericMutationRate
            // 
            this.numericMutationRate.DecimalPlaces = 1;
            this.numericMutationRate.Location = new System.Drawing.Point(150, 83);
            this.numericMutationRate.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericMutationRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericMutationRate.Name = "numericMutationRate";
            this.numericMutationRate.Size = new System.Drawing.Size(80, 26);
            this.numericMutationRate.TabIndex = 5;
            this.numericMutationRate.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            // 
            // labelGenerations
            // 
            this.labelGenerations.AutoSize = true;
            this.labelGenerations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenerations.Location = new System.Drawing.Point(15, 115);
            this.labelGenerations.Name = "labelGenerations";
            this.labelGenerations.Size = new System.Drawing.Size(115, 18);
            this.labelGenerations.TabIndex = 6;
            this.labelGenerations.Text = "Số thế hệ tối đa:";
            this.labelGenerations.Click += new System.EventHandler(this.labelGenerations_Click);
            // 
            // numericGenerations
            // 
            this.numericGenerations.Location = new System.Drawing.Point(150, 113);
            this.numericGenerations.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericGenerations.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericGenerations.Name = "numericGenerations";
            this.numericGenerations.Size = new System.Drawing.Size(80, 26);
            this.numericGenerations.TabIndex = 7;
            this.numericGenerations.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericGenerations.ValueChanged += new System.EventHandler(this.numericGenerations_ValueChanged);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.LightCoral;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(760, 210);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 40);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Đặt Lại";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGenerateCities
            // 
            this.btnGenerateCities.BackColor = System.Drawing.Color.LightBlue;
            this.btnGenerateCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnGenerateCities.Location = new System.Drawing.Point(630, 260);
            this.btnGenerateCities.Name = "btnGenerateCities";
            this.btnGenerateCities.Size = new System.Drawing.Size(250, 30);
            this.btnGenerateCities.TabIndex = 4;
            this.btnGenerateCities.Text = "Tạo Thành Phố Ngẫu Nhiên";
            this.btnGenerateCities.UseVisualStyleBackColor = false;
            this.btnGenerateCities.Click += new System.EventHandler(this.btnGenerateCities_Click);
            // 
            // groupBoxResults
            // 
            this.groupBoxResults.Controls.Add(this.labelBestDistance);
            this.groupBoxResults.Controls.Add(this.textBoxBestDistance);
            this.groupBoxResults.Controls.Add(this.labelCurrentGeneration);
            this.groupBoxResults.Controls.Add(this.textBoxCurrentGeneration);
            this.groupBoxResults.Controls.Add(this.labelProgress);
            this.groupBoxResults.Controls.Add(this.progressBarEvolution);
            this.groupBoxResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxResults.Location = new System.Drawing.Point(630, 300);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(250, 150);
            this.groupBoxResults.TabIndex = 5;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "kết Quả";
            // 
            // labelBestDistance
            // 
            this.labelBestDistance.AutoSize = true;
            this.labelBestDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBestDistance.Location = new System.Drawing.Point(15, 25);
            this.labelBestDistance.Name = "labelBestDistance";
            this.labelBestDistance.Size = new System.Drawing.Size(124, 18);
            this.labelBestDistance.TabIndex = 0;
            this.labelBestDistance.Text = "Đường đi tốt nhất:";
            this.labelBestDistance.Click += new System.EventHandler(this.labelBestDistance_Click);
            // 
            // textBoxBestDistance
            // 
            this.textBoxBestDistance.Location = new System.Drawing.Point(15, 45);
            this.textBoxBestDistance.Name = "textBoxBestDistance";
            this.textBoxBestDistance.ReadOnly = true;
            this.textBoxBestDistance.Size = new System.Drawing.Size(220, 26);
            this.textBoxBestDistance.TabIndex = 1;
            // 
            // labelCurrentGeneration
            // 
            this.labelCurrentGeneration.AutoSize = true;
            this.labelCurrentGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentGeneration.Location = new System.Drawing.Point(15, 75);
            this.labelCurrentGeneration.Name = "labelCurrentGeneration";
            this.labelCurrentGeneration.Size = new System.Drawing.Size(95, 18);
            this.labelCurrentGeneration.TabIndex = 2;
            this.labelCurrentGeneration.Text = "Thể Hiện Tại:";
            this.labelCurrentGeneration.Click += new System.EventHandler(this.labelCurrentGeneration_Click);
            // 
            // textBoxCurrentGeneration
            // 
            this.textBoxCurrentGeneration.Location = new System.Drawing.Point(15, 95);
            this.textBoxCurrentGeneration.Name = "textBoxCurrentGeneration";
            this.textBoxCurrentGeneration.ReadOnly = true;
            this.textBoxCurrentGeneration.Size = new System.Drawing.Size(220, 26);
            this.textBoxCurrentGeneration.TabIndex = 3;
            this.textBoxCurrentGeneration.TextChanged += new System.EventHandler(this.textBoxCurrentGeneration_TextChanged);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.Location = new System.Drawing.Point(15, 125);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(56, 18);
            this.labelProgress.TabIndex = 4;
            this.labelProgress.Text = "tiến độ:";
            // 
            // progressBarEvolution
            // 
            this.progressBarEvolution.Location = new System.Drawing.Point(75, 122);
            this.progressBarEvolution.Name = "progressBarEvolution";
            this.progressBarEvolution.Size = new System.Drawing.Size(160, 20);
            this.progressBarEvolution.TabIndex = 5;
            // 
            // timerEvolution
            // 
            this.timerEvolution.Interval = 50;
            this.timerEvolution.Tick += new System.EventHandler(this.timerEvolution_Tick);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(630, 210);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 40);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Bắt đầu GA";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // BasicTSPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 530);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.btnGenerateCities);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBoxParameters);
            this.Controls.Add(this.panelMap);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BasicTSPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo Thuật tonas di truyền-bài TSP cơ bản";
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMutationRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGenerations)).EndInit();
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.Label labelPopulationSize;
        private System.Windows.Forms.NumericUpDown numericPopulationSize;
        private System.Windows.Forms.Label labelMutationRate;
        private System.Windows.Forms.NumericUpDown numericMutationRate;
        private System.Windows.Forms.Label labelGenerations;
        private System.Windows.Forms.NumericUpDown numericGenerations;
        private System.Windows.Forms.Label labelCities;
        private System.Windows.Forms.NumericUpDown numericCities;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGenerateCities;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.Label labelBestDistance;
        private System.Windows.Forms.Label labelCurrentGeneration;
        private System.Windows.Forms.TextBox textBoxBestDistance;
        private System.Windows.Forms.TextBox textBoxCurrentGeneration;
        private System.Windows.Forms.ProgressBar progressBarEvolution;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Timer timerEvolution;
        private System.Windows.Forms.Button btnStart;
    }
}