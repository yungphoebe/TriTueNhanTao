namespace TriTueNhanTao
{
    partial class VietNamTSPForm
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
            this.groupBoxProvinceSelection = new System.Windows.Forms.GroupBox();
            this.checkedListBoxProvinces = new System.Windows.Forms.CheckedListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btnSelectMajor = new System.Windows.Forms.Button();
            this.labelSelectedCount = new System.Windows.Forms.Label();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.labelPopulationSize = new System.Windows.Forms.Label();
            this.numericPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.labelMutationRate = new System.Windows.Forms.Label();
            this.numericMutationRate = new System.Windows.Forms.NumericUpDown();
            this.labelGenerations = new System.Windows.Forms.Label();
            this.numericGenerations = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBoxResults = new System.Windows.Forms.GroupBox();
            this.labelBestDistance = new System.Windows.Forms.Label();
            this.textBoxBestDistance = new System.Windows.Forms.TextBox();
            this.labelCurrentGeneration = new System.Windows.Forms.Label();
            this.textBoxCurrentGeneration = new System.Windows.Forms.TextBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBarEvolution = new System.Windows.Forms.ProgressBar();
            this.timerEvolution = new System.Windows.Forms.Timer(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBoxProvinceSelection.SuspendLayout();
            this.groupBoxParameters.SuspendLayout();
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
            this.panelMap.Location = new System.Drawing.Point(12, 50);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(600, 550);
            this.panelMap.TabIndex = 0;
            this.panelMap.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMap_Paint);
            // 
            // groupBoxProvinceSelection
            // 
            this.groupBoxProvinceSelection.Controls.Add(this.checkedListBoxProvinces);
            this.groupBoxProvinceSelection.Controls.Add(this.btnSelectAll);
            this.groupBoxProvinceSelection.Controls.Add(this.btnSelectNone);
            this.groupBoxProvinceSelection.Controls.Add(this.btnSelectMajor);
            this.groupBoxProvinceSelection.Controls.Add(this.labelSelectedCount);
            this.groupBoxProvinceSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProvinceSelection.Location = new System.Drawing.Point(630, 50);
            this.groupBoxProvinceSelection.Name = "groupBoxProvinceSelection";
            this.groupBoxProvinceSelection.Size = new System.Drawing.Size(280, 300);
            this.groupBoxProvinceSelection.TabIndex = 1;
            this.groupBoxProvinceSelection.TabStop = false;
            this.groupBoxProvinceSelection.Text = "Ch?n T?nh Thành";
            // 
            // checkedListBoxProvinces
            // 
            this.checkedListBoxProvinces.CheckOnClick = true;
            this.checkedListBoxProvinces.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxProvinces.Location = new System.Drawing.Point(15, 25);
            this.checkedListBoxProvinces.Name = "checkedListBoxProvinces";
            this.checkedListBoxProvinces.Size = new System.Drawing.Size(250, 175);
            this.checkedListBoxProvinces.TabIndex = 0;
            this.checkedListBoxProvinces.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxProvinces_ItemCheck);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(15, 220);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 25);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "chọn hết";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectNone.Location = new System.Drawing.Point(100, 220);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(75, 25);
            this.btnSelectNone.TabIndex = 2;
            this.btnSelectNone.Text = "bỏ chọn";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectMajor
            // 
            this.btnSelectMajor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectMajor.Location = new System.Drawing.Point(185, 220);
            this.btnSelectMajor.Name = "btnSelectMajor";
            this.btnSelectMajor.Size = new System.Drawing.Size(80, 25);
            this.btnSelectMajor.TabIndex = 3;
            this.btnSelectMajor.Text = "Tỉnh chính";
            this.btnSelectMajor.UseVisualStyleBackColor = true;
            this.btnSelectMajor.Click += new System.EventHandler(this.btnSelectMajor_Click);
            // 
            // labelSelectedCount
            // 
            this.labelSelectedCount.AutoSize = true;
            this.labelSelectedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedCount.ForeColor = System.Drawing.Color.Blue;
            this.labelSelectedCount.Location = new System.Drawing.Point(15, 255);
            this.labelSelectedCount.Name = "labelSelectedCount";
            this.labelSelectedCount.Size = new System.Drawing.Size(168, 18);
            this.labelSelectedCount.TabIndex = 4;
            this.labelSelectedCount.Text = "Đã chọn: 0 tỉnh thành";
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.labelPopulationSize);
            this.groupBoxParameters.Controls.Add(this.numericPopulationSize);
            this.groupBoxParameters.Controls.Add(this.labelMutationRate);
            this.groupBoxParameters.Controls.Add(this.numericMutationRate);
            this.groupBoxParameters.Controls.Add(this.labelGenerations);
            this.groupBoxParameters.Controls.Add(this.numericGenerations);
            this.groupBoxParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxParameters.Location = new System.Drawing.Point(630, 356);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(280, 124);
            this.groupBoxParameters.TabIndex = 2;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Tham Số Thuật Toán Di Truyền";
            this.groupBoxParameters.Enter += new System.EventHandler(this.groupBoxParameters_Enter);
            // 
            // labelPopulationSize
            // 
            this.labelPopulationSize.AutoSize = true;
            this.labelPopulationSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPopulationSize.Location = new System.Drawing.Point(15, 25);
            this.labelPopulationSize.Name = "labelPopulationSize";
            this.labelPopulationSize.Size = new System.Drawing.Size(138, 18);
            this.labelPopulationSize.TabIndex = 0;
            this.labelPopulationSize.Text = "Kích thước quần thể";
            // 
            // numericPopulationSize
            // 
            this.numericPopulationSize.Location = new System.Drawing.Point(180, 23);
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
            this.numericPopulationSize.Size = new System.Drawing.Size(80, 22);
            this.numericPopulationSize.TabIndex = 1;
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
            this.labelMutationRate.Location = new System.Drawing.Point(15, 55);
            this.labelMutationRate.Name = "labelMutationRate";
            this.labelMutationRate.Size = new System.Drawing.Size(121, 18);
            this.labelMutationRate.TabIndex = 2;
            this.labelMutationRate.Text = "tỷ lệ đột biến (%):";
            // 
            // numericMutationRate
            // 
            this.numericMutationRate.DecimalPlaces = 1;
            this.numericMutationRate.Location = new System.Drawing.Point(180, 53);
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
            this.numericMutationRate.Size = new System.Drawing.Size(80, 22);
            this.numericMutationRate.TabIndex = 3;
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
            this.labelGenerations.Location = new System.Drawing.Point(15, 85);
            this.labelGenerations.Name = "labelGenerations";
            this.labelGenerations.Size = new System.Drawing.Size(115, 18);
            this.labelGenerations.TabIndex = 4;
            this.labelGenerations.Text = "Số thế hệ tối đa:";
            // 
            // numericGenerations
            // 
            this.numericGenerations.Location = new System.Drawing.Point(180, 83);
            this.numericGenerations.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericGenerations.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericGenerations.Name = "numericGenerations";
            this.numericGenerations.Size = new System.Drawing.Size(80, 22);
            this.numericGenerations.TabIndex = 5;
            this.numericGenerations.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(630, 490);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(130, 40);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Bắt đầu GA";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.LightCoral;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnReset.Location = new System.Drawing.Point(780, 490);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 40);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Đặt Lại";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.groupBoxResults.Location = new System.Drawing.Point(630, 540);
            this.groupBoxResults.Name = "groupBoxResults";
            this.groupBoxResults.Size = new System.Drawing.Size(280, 100);
            this.groupBoxResults.TabIndex = 5;
            this.groupBoxResults.TabStop = false;
            this.groupBoxResults.Text = "K?t Qu?";
            // 
            // labelBestDistance
            // 
            this.labelBestDistance.AutoSize = true;
            this.labelBestDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBestDistance.Location = new System.Drawing.Point(-3, 26);
            this.labelBestDistance.Name = "labelBestDistance";
            this.labelBestDistance.Size = new System.Drawing.Size(152, 18);
            this.labelBestDistance.TabIndex = 0;
            this.labelBestDistance.Text = "Khoảng cách tốt nhất:";
            // 
            // textBoxBestDistance
            // 
            this.textBoxBestDistance.Location = new System.Drawing.Point(150, 22);
            this.textBoxBestDistance.Name = "textBoxBestDistance";
            this.textBoxBestDistance.ReadOnly = true;
            this.textBoxBestDistance.Size = new System.Drawing.Size(115, 26);
            this.textBoxBestDistance.TabIndex = 1;
            // 
            // labelCurrentGeneration
            // 
            this.labelCurrentGeneration.AutoSize = true;
            this.labelCurrentGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentGeneration.Location = new System.Drawing.Point(15, 50);
            this.labelCurrentGeneration.Name = "labelCurrentGeneration";
            this.labelCurrentGeneration.Size = new System.Drawing.Size(103, 18);
            this.labelCurrentGeneration.TabIndex = 2;
            this.labelCurrentGeneration.Text = "Thế hệ hiện tại";
            // 
            // textBoxCurrentGeneration
            // 
            this.textBoxCurrentGeneration.Location = new System.Drawing.Point(150, 47);
            this.textBoxCurrentGeneration.Name = "textBoxCurrentGeneration";
            this.textBoxCurrentGeneration.ReadOnly = true;
            this.textBoxCurrentGeneration.Size = new System.Drawing.Size(115, 26);
            this.textBoxCurrentGeneration.TabIndex = 3;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.Location = new System.Drawing.Point(15, 75);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(61, 18);
            this.labelProgress.TabIndex = 4;
            this.labelProgress.Text = "Tiến độ:";
            // 
            // progressBarEvolution
            // 
            this.progressBarEvolution.Location = new System.Drawing.Point(80, 72);
            this.progressBarEvolution.Name = "progressBarEvolution";
            this.progressBarEvolution.Size = new System.Drawing.Size(185, 20);
            this.progressBarEvolution.TabIndex = 5;
            // 
            // timerEvolution
            // 
            this.timerEvolution.Tick += new System.EventHandler(this.timerEvolution_Tick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelTitle.Location = new System.Drawing.Point(12, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(631, 31);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Thuật Toán Di Truyền - Bài Toán TSP Việt Nam";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // VietNamTSPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 650);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.groupBoxResults);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBoxParameters);
            this.Controls.Add(this.groupBoxProvinceSelection);
            this.Controls.Add(this.panelMap);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VietNamTSPForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Demo GA-TSP B?n ?? Vi?t Nam";
            this.groupBoxProvinceSelection.ResumeLayout(false);
            this.groupBoxProvinceSelection.PerformLayout();
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMutationRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGenerations)).EndInit();
            this.groupBoxResults.ResumeLayout(false);
            this.groupBoxResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.GroupBox groupBoxProvinceSelection;
        private System.Windows.Forms.CheckedListBox checkedListBoxProvinces;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btnSelectMajor;
        private System.Windows.Forms.Label labelSelectedCount;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.Label labelPopulationSize;
        private System.Windows.Forms.NumericUpDown numericPopulationSize;
        private System.Windows.Forms.Label labelMutationRate;
        private System.Windows.Forms.NumericUpDown numericMutationRate;
        private System.Windows.Forms.Label labelGenerations;
        private System.Windows.Forms.NumericUpDown numericGenerations;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBoxResults;
        private System.Windows.Forms.Label labelBestDistance;
        private System.Windows.Forms.TextBox textBoxBestDistance;
        private System.Windows.Forms.Label labelCurrentGeneration;
        private System.Windows.Forms.TextBox textBoxCurrentGeneration;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ProgressBar progressBarEvolution;
        private System.Windows.Forms.Timer timerEvolution;
        private System.Windows.Forms.Label labelTitle;
    }
}