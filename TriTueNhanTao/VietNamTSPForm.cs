using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriTueNhanTao
{
    public partial class VietNamTSPForm : Form
    {
        private List<Province> provinces;
        private int[] bestRoute;
        private double bestDistance;
        private Random random;
        private GeneticAlgorithmVN ga;
        private bool isRunning;
        private int currentGeneration;
        private List<Province> selectedProvinces;

        public VietNamTSPForm()
        {
            InitializeComponent();
            
            // Đảm bảo form sử dụng font Unicode cho tiếng Việt
            try
            {
                this.Font = new Font("Arial Unicode MS", 9F, FontStyle.Regular, GraphicsUnit.Point);
            }
            catch
            {
                this.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            }
            
            // Đảm bảo form handle được tạo trước khi khởi tạo
            this.CreateHandle();
            InitializeVietNamDemo();
        }

        private void InitializeVietNamDemo()
        {
            provinces = new List<Province>();
            selectedProvinces = new List<Province>();
            random = new Random();
            bestRoute = null;
            bestDistance = double.MaxValue;
            isRunning = false;
            currentGeneration = 0;
            
            // Đảm bảo tất cả controls sử dụng font Unicode
            SetUnicodeFont(this);
            
            LoadVietNamProvinces();
            PopulateProvinceList();
        }

        private void SetUnicodeFont(Control parent)
        {
            try
            {
                Font unicodeFont = new Font("Arial Unicode MS", parent.Font.Size, parent.Font.Style, GraphicsUnit.Point);
                parent.Font = unicodeFont;
                
                foreach (Control control in parent.Controls)
                {
                    if (control.HasChildren)
                    {
                        SetUnicodeFont(control);
                    }
                    else
                    {
                        Font controlFont = new Font("Arial Unicode MS", control.Font.Size, control.Font.Style, GraphicsUnit.Point);
                        control.Font = controlFont;
                    }
                }
            }
            catch
            {
                // Nếu không có Arial Unicode MS, sử dụng Microsoft Sans Serif
                Font fallbackFont = new Font("Microsoft Sans Serif", parent.Font.Size, parent.Font.Style, GraphicsUnit.Point);
                parent.Font = fallbackFont;
            }
        }

        private void LoadVietNamProvinces()
        {
            // Tọa độ đầy đủ 63 tỉnh thành của Việt Nam (điều chỉnh cho panel 600x550)
            provinces.AddRange(new List<Province>
            {
                // Miền Bắc (8 tỉnh)
                new Province("Hà Nội", 290, 140),
                new Province("Hải Phòng", 330, 125),
                new Province("Quảng Ninh", 370, 110),
                new Province("Bắc Giang", 310, 110),
                new Province("Bắc Ninh", 300, 130),
                new Province("Hải Dương", 315, 135),
                new Province("Hưng Yên", 295, 145),
                new Province("Vĩnh Phúc", 275, 125),
                
                // Tây Bắc (4 tỉnh)
                new Province("Lai Châu", 160, 65),
                new Province("Điện Biên", 130, 85),
                new Province("Sơn La", 180, 105),
                new Province("Hòa Bình", 240, 130),
                
                // Đông Bắc (11 tỉnh)
                new Province("Hà Giang", 240, 40),
                new Province("Cao Bằng", 300, 50),
                new Province("Bắc Kạn", 280, 70),
                new Province("Tuyên Quang", 250, 80),
                new Province("Lào Cai", 200, 70),
                new Province("Yên Bái", 220, 95),
                new Province("Thái Nguyên", 270, 115),
                new Province("Lạng Sơn", 335, 85),
                new Province("Phú Thọ", 255, 105),
                
                // Đồng bằng sông Hồng (còn lại - 2 tỉnh)
                new Province("Nam Định", 285, 150),
                new Province("Thái Bình", 310, 145),
                new Province("Ninh Bình", 275, 160),
                new Province("Hà Nam", 280, 155),
                
                // Bắc Trung Bộ (6 tỉnh)
                new Province("Thanh Hóa", 255, 180),
                new Province("Nghệ An", 240, 210),
                new Province("Hà Tĩnh", 250, 230),
                new Province("Quảng Bình", 260, 250),
                new Province("Quảng Trị", 270, 270),
                new Province("Thừa Thiên Huế", 280, 290),
                
                // Duyên hải Nam Trung Bộ (8 tỉnh)
                new Province("Đà Nẵng", 295, 310),
                new Province("Quảng Nam", 285, 330),
                new Province("Quảng Ngãi", 300, 350),
                new Province("Bình Định", 315, 370),
                new Province("Phú Yên", 325, 390),
                new Province("Khánh Hòa", 340, 410),
                new Province("Ninh Thuận", 330, 430),
                new Province("Bình Thuận", 320, 450),
                
                // Tây Nguyên (5 tỉnh)
                new Province("Kon Tum", 270, 345),
                new Province("Gia Lai", 280, 370),
                new Province("Đắk Lắk", 300, 390),
                new Province("Đắk Nông", 290, 410),
                new Province("Lâm Đồng", 280, 430),
                
                // Đông Nam Bộ (6 tỉnh)
                new Province("TP.HCM", 270, 470),
                new Province("Đồng Nai", 290, 460),
                new Province("Bà Rịa-Vũng Tàu", 300, 480),
                new Province("Bình Dương", 260, 460),
                new Province("Bình Phước", 250, 440),
                new Province("Tây Ninh", 230, 450),
                
                // Đồng Bằng Sông Cửu Long (13 tỉnh)
                new Province("Long An", 240, 480),
                new Province("Tiền Giang", 250, 490),
                new Province("Bến Tre", 260, 500),
                new Province("Trà Vinh", 270, 510),
                new Province("Vĩnh Long", 250, 510),
                new Province("Đồng Tháp", 230, 500),
                new Province("An Giang", 210, 490),
                new Province("Kiên Giang", 190, 510),
                new Province("Cần Thơ", 240, 520),
                new Province("Hậu Giang", 230, 530),
                new Province("Sóc Trăng", 250, 540),
                new Province("Bạc Liêu", 230, 550),
                new Province("Cà Mau", 220, 570),
                
                // Quần đảo (2 đảo - không tính vào TSP vì ở xa)
                new Province("Hoàng Sa", 480, 280),
                new Province("Trường Sa", 520, 450)
            });
        }

        private void PopulateProvinceList()
        {
            checkedListBoxProvinces.Items.Clear();
            
            // Sử dụng font hỗ trợ Unicode đầy đủ cho tiếng Việt
            try
            {
                checkedListBoxProvinces.Font = new Font("Arial Unicode MS", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            }
            catch
            {
                // Fallback nếu không có Arial Unicode MS
                checkedListBoxProvinces.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
            }
            
            foreach (var province in provinces)
            {
                checkedListBoxProvinces.Items.Add(province.Name);
            }
            
            // Chọn mặc định một số tỉnh chính (không bao gồm Hoàng Sa, Trường Sa)
            var defaultProvinces = new[] { "Hà Nội", "TP.HCM", "Đà Nẵng", "Hải Phòng", "Cần Thơ", "Thừa Thiên Huế", "Khánh Hòa" };
            for (int i = 0; i < checkedListBoxProvinces.Items.Count; i++)
            {
                if (defaultProvinces.Contains(checkedListBoxProvinces.Items[i].ToString()))
                {
                    checkedListBoxProvinces.SetItemChecked(i, true);
                }
            }
            
            // Gọi UpdateSelectedProvinces trực tiếp khi khởi tạo (không qua event)
            UpdateSelectedProvinces();
        }

        private void UpdateSelectedProvinces()
        {
            selectedProvinces.Clear();
            for (int i = 0; i < checkedListBoxProvinces.Items.Count; i++)
            {
                if (checkedListBoxProvinces.GetItemChecked(i))
                {
                    string provinceName = checkedListBoxProvinces.Items[i].ToString();
                    var province = provinces.First(p => p.Name == provinceName);
                    selectedProvinces.Add(province);
                }
            }
            
            labelSelectedCount.Text = $"Đã chọn: {selectedProvinces.Count} tỉnh thành";
            panelMap.Invalidate();
            ResetResults();
        }

        private void ResetResults()
        {
            bestRoute = null;
            bestDistance = double.MaxValue;
            currentGeneration = 0;
            textBoxBestDistance.Text = "";
            textBoxCurrentGeneration.Text = "0";
            progressBarEvolution.Value = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (selectedProvinces.Count < 3)
            {
                MessageBox.Show("Cần chọn ít nhất 3 tỉnh thành để chạy thuật toán!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isRunning)
            {
                StartGeneticAlgorithm();
                btnStart.Text = "Dừng";
                isRunning = true;
                timerEvolution.Start();
            }
            else
            {
                StopGeneticAlgorithm();
                btnStart.Text = "Bắt đầu GA";
                isRunning = false;
                timerEvolution.Stop();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            StopGeneticAlgorithm();
            ResetResults();
            panelMap.Invalidate();
        }

        private void StartGeneticAlgorithm()
        {
            try
            {
                int populationSize = (int)numericPopulationSize.Value;
                double mutationRate = (double)numericMutationRate.Value / 100.0;
                int maxGenerations = (int)numericGenerations.Value;

                ga = new GeneticAlgorithmVN(selectedProvinces, populationSize, mutationRate, maxGenerations);
                currentGeneration = 0;
                progressBarEvolution.Maximum = maxGenerations;
                progressBarEvolution.Value = 0;
                
                // Reset kết quả trước khi bắt đầu
                bestRoute = null;
                bestDistance = double.MaxValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo thuật toán: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                StopGeneticAlgorithm();
            }
        }

        private void StopGeneticAlgorithm()
        {
            isRunning = false;
            timerEvolution.Stop();
            btnStart.Text = "Bắt đầu GA";
        }

        private void timerEvolution_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ga != null && currentGeneration < ga.MaxGenerations && isRunning)
                {
                    ga.NextGeneration();
                    currentGeneration++;
                    
                    var currentBest = ga.GetBestRoute();
                    if (currentBest.Distance < bestDistance)
                    {
                        bestDistance = currentBest.Distance;
                        bestRoute = currentBest.Route;
                    }

                    // Cập nhật UI
                    textBoxBestDistance.Text = $"{bestDistance:F2} km";
                    textBoxCurrentGeneration.Text = $"{currentGeneration}/{ga.MaxGenerations}";
                    progressBarEvolution.Value = Math.Min(currentGeneration, progressBarEvolution.Maximum);
                    
                    panelMap.Invalidate();

                    // Dừng khi đã đủ số thế hệ
                    if (currentGeneration >= ga.MaxGenerations)
                    {
                        StopGeneticAlgorithm();
                        MessageBox.Show($"Hoàn thành!\nKhoảng cách tốt nhất: {bestDistance:F2} km\nĐường đi: {GetRouteDescription()}", 
                            "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi trong quá trình chạy thuật toán: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                StopGeneticAlgorithm();
            }
        }

        private string GetRouteDescription()
        {
            if (bestRoute == null || bestRoute.Length == 0) return "";
            
            var routeNames = new List<string>();
            foreach (int index in bestRoute)
            {
                routeNames.Add(selectedProvinces[index].Name);
            }
            routeNames.Add(selectedProvinces[bestRoute[0]].Name); // Quay về điểm đầu
            
            return string.Join(" → ", routeNames);
        }

        private void DrawVietNamOutline(Graphics g)
        {
            // Vẽ vùng biển (màu xanh nhạt)
            using (var seaBrush = new SolidBrush(Color.FromArgb(180, 173, 216, 230)))
            {
                g.FillRectangle(seaBrush, panelMap.ClientRectangle);
            }
            
            // Vẽ đường viền chính xác hơn của Việt Nam
            using (var outlinePen = new Pen(Color.FromArgb(34, 139, 34), 2))
            using (var fillBrush = new SolidBrush(Color.FromArgb(245, 245, 220))) // Màu be nhạt cho đất liền
            {
                // Đường viền Việt Nam chính xác hơn theo hình dạng thực tế
                Point[] vietnamOutline = new Point[]
                {
                    // Biên giới phía Bắc (từ Tây sang Đông) - chi tiết hơn
                    new Point(130, 85), new Point(145, 75), new Point(160, 65), new Point(180, 55),
                    new Point(200, 50), new Point(220, 42), new Point(240, 40), new Point(265, 45),
                    new Point(285, 50), new Point(305, 52), new Point(325, 58), new Point(345, 68),
                    new Point(365, 78), new Point(380, 90), new Point(390, 105),
                    
                    // Bờ biển phía Đông Bắc
                    new Point(395, 115), new Point(390, 125), new Point(380, 135), new Point(375, 145),
                    new Point(372, 155), new Point(370, 165),
                    
                    // Bờ biển miền Trung (đường cong đặc trưng)
                    new Point(372, 175), new Point(375, 190), new Point(378, 205), new Point(380, 220),
                    new Point(383, 235), new Point(386, 250), new Point(388, 265), new Point(390, 280),
                    new Point(393, 295), new Point(396, 310), new Point(400, 325), new Point(405, 340),
                    new Point(410, 355), new Point(415, 370), new Point(420, 385), new Point(425, 400),
                    new Point(428, 415), new Point(430, 430), new Point(428, 445), new Point(424, 460),
                    new Point(418, 473), new Point(410, 485), new Point(400, 493),
                    
                    // Bờ biển miền Nam
                    new Point(385, 497), new Point(370, 498), new Point(355, 496), new Point(340, 492),
                    new Point(325, 488), new Point(310, 485), new Point(295, 486), new Point(280, 490),
                    new Point(265, 495), new Point(250, 500), new Point(235, 506), new Point(220, 513),
                    new Point(205, 520), new Point(190, 528), new Point(175, 537), new Point(160, 546),
                    new Point(145, 555), new Point(130, 564), new Point(115, 570),
                    
                    // Biên giới phía Tây Nam và Tây (từ Nam lên Bắc)
                    new Point(105, 565), new Point(100, 555), new Point(98, 540), new Point(100, 525),
                    new Point(105, 510), new Point(112, 495), new Point(120, 480), new Point(130, 465),
                    new Point(142, 450), new Point(155, 435), new Point(168, 420), new Point(180, 405),
                    new Point(190, 390), new Point(198, 375), new Point(204, 360), new Point(208, 345),
                    new Point(210, 330), new Point(210, 315), new Point(208, 300), new Point(204, 285),
                    new Point(198, 270), new Point(192, 255), new Point(186, 240), new Point(180, 225),
                    new Point(174, 210), new Point(168, 195), new Point(162, 180), new Point(156, 165),
                    new Point(150, 150), new Point(144, 135), new Point(138, 120), new Point(133, 105),
                    new Point(130, 90)
                };
                
                g.FillPolygon(fillBrush, vietnamOutline);
                g.DrawPolygon(outlinePen, vietnamOutline);
            }
            
            // Vẽ Hoàng Sa
            using (var islandBrush = new SolidBrush(Color.SandyBrown))
            using (var islandPen = new Pen(Color.DarkGreen, 1))
            using (var font = new Font("Arial Unicode MS", 7F, FontStyle.Bold))
            {
                // Hoàng Sa
                g.FillEllipse(islandBrush, 475, 275, 15, 10);
                g.DrawEllipse(islandPen, 475, 275, 15, 10);
                g.DrawString("Hoàng Sa", font, Brushes.DarkRed, 470, 260);
                
                // Trường Sa
                g.FillEllipse(islandBrush, 515, 445, 15, 10);
                g.DrawEllipse(islandPen, 515, 445, 15, 10);
                g.DrawString("Trường Sa", font, Brushes.DarkRed, 508, 430);
                
                // Vẽ đường nét đứt nối từ đất liền đến quần đảo
                using (var dashPen = new Pen(Color.Red, 1))
                {
                    dashPen.DashStyle = DashStyle.Dash;
                    g.DrawLine(dashPen, 395, 310, 482, 280); // Nối Đà Nẵng - Hoàng Sa
                    g.DrawLine(dashPen, 340, 410, 522, 450); // Nối Khánh Hòa - Trường Sa
                }
            }
        }

        private void panelMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Vẽ nền bản đồ Việt Nam
            using (var backgroundBrush = new LinearGradientBrush(
                panelMap.ClientRectangle,
                Color.LightCyan,
                Color.PaleTurquoise,
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(backgroundBrush, panelMap.ClientRectangle);
            }
            
            // Vẽ đường viền đại khái của Việt Nam
            DrawVietNamOutline(g);

            // Vẽ tất cả các tỉnh thành (không được chọn)
            using (var unselectedBrush = new SolidBrush(Color.Gray))
            using (var smallFont = new Font("Arial Unicode MS", 7.5F, FontStyle.Regular, GraphicsUnit.Point))
            {
                foreach (var province in provinces)
                {
                    if (!selectedProvinces.Contains(province))
                    {
                        g.FillEllipse(unselectedBrush, province.X - 3, province.Y - 3, 6, 6);
                        g.DrawEllipse(Pens.DarkGray, province.X - 3, province.Y - 3, 6, 6);
                        
                        // Vẽ tên tỉnh với shadow effect - sử dụng font hỗ trợ Unicode đầy đủ
                        using (var shadowBrush = new SolidBrush(Color.FromArgb(80, Color.Black)))
                        {
                            g.DrawString(province.Name, smallFont, shadowBrush, province.X + 6, province.Y - 6);
                        }
                        g.DrawString(province.Name, smallFont, Brushes.DarkSlateGray, province.X + 5, province.Y - 7);
                    }
                }
            }

            // Vẽ các tỉnh thành được chọn
            using (var selectedBrush = new SolidBrush(Color.Crimson))
            using (var textBrush = new SolidBrush(Color.White))
            using (var font = new Font("Arial Unicode MS", 8F, FontStyle.Bold, GraphicsUnit.Point))
            using (var nameFont = new Font("Arial Unicode MS", 9F, FontStyle.Bold, GraphicsUnit.Point))
            {
                for (int i = 0; i < selectedProvinces.Count; i++)
                {
                    Province province = selectedProvinces[i];
                    
                    // Vẽ halo effect
                    using (var haloBrush = new SolidBrush(Color.FromArgb(100, Color.Red)))
                    {
                        g.FillEllipse(haloBrush, province.X - 12, province.Y - 12, 24, 24);
                    }
                    
                    g.FillEllipse(selectedBrush, province.X - 9, province.Y - 9, 18, 18);
                    g.DrawEllipse(new Pen(Color.DarkRed, 2), province.X - 9, province.Y - 9, 18, 18);
                    
                    string cityNumber = i.ToString();
                    SizeF textSize = g.MeasureString(cityNumber, font);
                    g.DrawString(cityNumber, font, textBrush, 
                        province.X - textSize.Width/2, province.Y - textSize.Height/2);
                    
                    // Vẽ tên tỉnh với nền và viền - sử dụng font Unicode
                    using (var nameBg = new SolidBrush(Color.FromArgb(220, Color.White)))
                    using (var nameBorder = new Pen(Color.DarkBlue, 1))
                    {
                        SizeF nameSize = g.MeasureString(province.Name, nameFont);
                        RectangleF nameRect = new RectangleF(province.X + 12, province.Y - 10, 
                            nameSize.Width + 6, nameSize.Height + 4);
                        g.FillRectangle(nameBg, nameRect);
                        g.DrawRectangle(nameBorder, Rectangle.Round(nameRect));
                        g.DrawString(province.Name, nameFont, Brushes.DarkBlue, 
                            province.X + 15, province.Y - 8);
                    }
                }
            }

            // Vẽ đường đi tốt nhất
            if (bestRoute != null && bestRoute.Length > 1)
            {
                using (var routePen = new Pen(Color.Blue, 4))
                using (var shadowPen = new Pen(Color.FromArgb(100, Color.Black), 6))
                {
                    routePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    
                    for (int i = 0; i < bestRoute.Length; i++)
                    {
                        int currentCity = bestRoute[i];
                        int nextCity = bestRoute[(i + 1) % bestRoute.Length];
            
                        Province current = selectedProvinces[currentCity];
                        Province next = selectedProvinces[nextCity];
            
                        // Vẽ shadow trước
                        g.DrawLine(shadowPen, current.X + 1, current.Y + 1, next.X + 1, next.Y + 1);
                        // Vẽ đường chính
                        g.DrawLine(routePen, current.X, current.Y, next.X, next.Y);
            
                        // Vẽ mũi tên chỉ hướng
                        DrawArrow(g, routePen, current.X, current.Y, next.X, next.Y);
                    }
                }
            }
        }

        private void DrawArrow(Graphics g, Pen pen, float x1, float y1, float x2, float y2)
        {
            // Tính toán hướng và vẽ mũi tên nhỏ
            double angle = Math.Atan2(y2 - y1, x2 - x1);
            float arrowLength = 8;
            float arrowAngle = 0.5f;
            
            float midX = (x1 + x2) / 2;
            float midY = (y1 + y2) / 2;
            
            float ax1 = midX - arrowLength * (float)Math.Cos(angle - arrowAngle);
            float ay1 = midY - arrowLength * (float)Math.Sin(angle - arrowAngle);
            float ax2 = midX - arrowLength * (float)Math.Cos(angle + arrowAngle);
            float ay2 = midY - arrowLength * (float)Math.Sin(angle + arrowAngle);
            
            g.DrawLine(pen, midX, midY, ax1, ay1);
            g.DrawLine(pen, midX, midY, ax2, ay2);
        }

        private void checkedListBoxProvinces_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Kiểm tra xem form đã được tạo handle chưa trước khi gọi BeginInvoke
            if (this.IsHandleCreated)
            {
                // Sử dụng BeginInvoke để đảm bảo trạng thái được cập nhật sau khi event hoàn thành
                this.BeginInvoke(new MethodInvoker(() => UpdateSelectedProvinces()));
            }
            else
            {
                // Nếu handle chưa được tạo, dùng cách khác
                System.Windows.Forms.Application.DoEvents();
                UpdateSelectedProvinces();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxProvinces.Items.Count; i++)
            {
                checkedListBoxProvinces.SetItemChecked(i, true);
            }
            UpdateSelectedProvinces();
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxProvinces.Items.Count; i++)
            {
                checkedListBoxProvinces.SetItemChecked(i, false);
            }
            UpdateSelectedProvinces();
        }

        private void btnSelectMajor_Click(object sender, EventArgs e)
        {
            var majorProvinces = new[] { "Hà Nội", "TP.HCM", "Đà Nẵng", "Hải Phòng", "Cần Thơ", "Huế" };
            
            for (int i = 0; i < checkedListBoxProvinces.Items.Count; i++)
            {
                bool shouldCheck = majorProvinces.Contains(checkedListBoxProvinces.Items[i].ToString());
                checkedListBoxProvinces.SetItemChecked(i, shouldCheck);
            }
            UpdateSelectedProvinces();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxParameters_Enter(object sender, EventArgs e)
        {

        }
    }

    // Lớp đại diện cho tỉnh thành
    public class Province
    {
        public string Name { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public double Latitude { get; set; }  // Có thể mở rộng để tính khoảng cách thực
        public double Longitude { get; set; }

        public Province(string name, float x, float y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public double GetDistance(Province other)
        {
            // Tính khoảng cách Euclidean được điều chỉnh theo tỷ lệ thực tế
            double dx = this.X - other.X;
            double dy = this.Y - other.Y;
            double pixelDistance = Math.Sqrt(dx * dx + dy * dy);
            
            // Chuyển đổi sang km (1 pixel ≈ 3 km - tỷ lệ gần đúng)
            return pixelDistance * 3.0;
        }
    }

    // Thuật toán di truyền cho bản đồ Việt Nam
    public class GeneticAlgorithmVN
    {
        private List<Province> provinces;
        private List<IndividualVN> population;
        private Random random;
        
        public int PopulationSize { get; private set; }
        public double MutationRate { get; private set; }
        public int MaxGenerations { get; private set; }

        public GeneticAlgorithmVN(List<Province> provinces, int populationSize, double mutationRate, int maxGenerations)
        {
            this.provinces = provinces;
            this.PopulationSize = populationSize;
            this.MutationRate = mutationRate;
            this.MaxGenerations = maxGenerations;
            this.random = new Random();
            
            InitializePopulation();
        }

        private void InitializePopulation()
        {
            population = new List<IndividualVN>();
            
            for (int i = 0; i < PopulationSize; i++)
            {
                int[] route = GenerateRandomRoute();
                IndividualVN individual = new IndividualVN(route);
                individual.CalculateDistance(provinces);
                population.Add(individual);
            }
        }

        private int[] GenerateRandomRoute()
        {
            int[] route = new int[provinces.Count];
            for (int i = 0; i < provinces.Count; i++)
            {
                route[i] = i;
            }
            
            // Shuffle Fisher-Yates
            for (int i = route.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = route[i];
                route[i] = route[j];
                route[j] = temp;
            }
            
            return route;
        }

        public void NextGeneration()
        {
            List<IndividualVN> newPopulation = new List<IndividualVN>();
            
            // Elitism - giữ lại cá thể tốt nhất
            IndividualVN best = GetBestIndividual();
            newPopulation.Add(new IndividualVN(best.Route));
            newPopulation[0].CalculateDistance(provinces);

            // Tạo thế hệ mới
            while (newPopulation.Count < PopulationSize)
            {
                IndividualVN parent1 = TournamentSelection();
                IndividualVN parent2 = TournamentSelection();
                
                IndividualVN child = Crossover(parent1, parent2);
                Mutate(child);
                child.CalculateDistance(provinces);
                
                newPopulation.Add(child);
            }

            population = newPopulation;
        }

        private IndividualVN TournamentSelection()
        {
            int tournamentSize = Math.Min(5, PopulationSize); // Đảm bảo không vượt quá kích thước quần thể
            IndividualVN best = null;
            
            for (int i = 0; i < tournamentSize; i++)
            {
                IndividualVN contestant = population[random.Next(population.Count)];
                if (best == null || contestant.Fitness > best.Fitness)
                {
                    best = contestant;
                }
            }
            
            return best;
        }

        private IndividualVN Crossover(IndividualVN parent1, IndividualVN parent2)
        {
            // Order Crossover (OX) - cải thiện để tránh lỗi
            int[] child = new int[provinces.Count];
            bool[] used = new bool[provinces.Count];
            
            if (provinces.Count <= 2)
            {
                // Với ít tỉnh thành, chỉ copy từ parent1
                return new IndividualVN((int[])parent1.Route.Clone());
            }
            
            int start = random.Next(provinces.Count);
            int end = random.Next(start + 1, provinces.Count + 1);
            if (end >= provinces.Count) end = provinces.Count - 1;
            
            // Copy segment from parent1
            for (int i = start; i <= end; i++)
            {
                child[i] = parent1.Route[i];
                used[parent1.Route[i]] = true;
            }
            
            // Fill remaining positions with genes from parent2
            int childIndex = (end + 1) % provinces.Count;
            int parent2Index = (end + 1) % provinces.Count;
            
            while (childIndex != start)
            {
                if (!used[parent2.Route[parent2Index]])
                {
                    child[childIndex] = parent2.Route[parent2Index];
                    used[parent2.Route[parent2Index]] = true;
                    childIndex = (childIndex + 1) % provinces.Count;
                }
                parent2Index = (parent2Index + 1) % provinces.Count;
            }
            
            return new IndividualVN(child);
        }

        private void Mutate(IndividualVN individual)
        {
            if (random.NextDouble() < MutationRate)
            {
                // Swap mutation
                int index1 = random.Next(individual.Route.Length);
                int index2 = random.Next(individual.Route.Length);
                
                int temp = individual.Route[index1];
                individual.Route[index1] = individual.Route[index2];
                individual.Route[index2] = temp;
            }
        }

        public IndividualVN GetBestIndividual()
        {
            IndividualVN best = population[0];
            for (int i = 1; i < population.Count; i++)
            {
                if (population[i].Fitness > best.Fitness)
                {
                    best = population[i];
                }
            }
            return best;
        }

        public (int[] Route, double Distance) GetBestRoute()
        {
            IndividualVN best = GetBestIndividual();
            return (best.Route, best.Distance);
        }
    }

    // Lớp cá thể cho thuật toán GA với bản đồ Việt Nam
    public class IndividualVN
    {
        public int[] Route { get; set; }
        public double Distance { get; set; }
        public double Fitness { get; set; }

        public IndividualVN(int[] route)
        {
            Route = (int[])route.Clone();
            Distance = 0;
            Fitness = 0;
        }

        public void CalculateDistance(List<Province> provinces)
        {
            Distance = 0;
            for (int i = 0; i < Route.Length; i++)
            {
                int currentProvince = Route[i];
                int nextProvince = Route[(i + 1) % Route.Length];
                Distance += provinces[currentProvince].GetDistance(provinces[nextProvince]);
            }
            Fitness = 1.0 / (Distance + 1); // +1 để tránh chia cho 0
        }
    }
}