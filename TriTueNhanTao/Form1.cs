using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriTueNhanTao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBasicDemo_Click(object sender, EventArgs e)
        {
            try
            {
                BasicTSPForm basicForm = new BasicTSPForm();
                basicForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở Demo Cơ Bản: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVietNamDemo_Click(object sender, EventArgs e)
        {
            try
            {
                VietNamTSPForm vietnamForm = new VietNamTSPForm();
                vietnamForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở Demo Việt Nam: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
