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
    public partial class BasicTSPForm : Form
    {
        private List<PointF> cities;
        private int[] bestRoute;
        private double bestDistance;
        private Random random;
        private GeneticAlgorithm ga;
        private bool isRunning;
        private int currentGeneration;

        public BasicTSPForm()
        {
            InitializeComponent();
            // Đảm bảo form handle được tạo trước khi khởi tạo
            this.CreateHandle();
            InitializeDemo();
        }

        private void InitializeDemo()
        {
            cities = new List<PointF>();
            random = new Random();
            bestRoute = null;
            bestDistance = double.MaxValue;
            isRunning = false;
            currentGeneration = 0;
            
            // Tạo một số thành phố mẫu
            GenerateRandomCities();
        }

        private void GenerateRandomCities()
        {
            cities.Clear();
            int numCities = (int)numericCities.Value;
            
            for (int i = 0; i < numCities; i++)
            {
                float x = random.Next(50, panelMap.Width - 50);
                float y = random.Next(50, panelMap.Height - 50);
                cities.Add(new PointF(x, y));
            }
            
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

        private void btnGenerateCities_Click(object sender, EventArgs e)
        {
            GenerateRandomCities();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cities.Count < 4)
            {
                MessageBox.Show("Cần ít nhất 4 thành phố để chạy thuật toán!", "Thông báo", 
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
            int populationSize = (int)numericPopulationSize.Value;
            double mutationRate = (double)numericMutationRate.Value / 100.0;
            int maxGenerations = (int)numericGenerations.Value;

            ga = new GeneticAlgorithm(cities, populationSize, mutationRate, maxGenerations);
            currentGeneration = 0;
            progressBarEvolution.Maximum = maxGenerations;
            progressBarEvolution.Value = 0;
        }

        private void StopGeneticAlgorithm()
        {
            isRunning = false;
            timerEvolution.Stop();
            btnStart.Text = "Bắt đầu GA";
        }

        private void timerEvolution_Tick(object sender, EventArgs e)
        {
            if (ga != null && currentGeneration < ga.MaxGenerations)
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
                textBoxBestDistance.Text = bestDistance.ToString("F2");
                textBoxCurrentGeneration.Text = currentGeneration.ToString();
                progressBarEvolution.Value = currentGeneration;
                
                panelMap.Invalidate();

                // Dừng khi đã đủ số thế hệ
                if (currentGeneration >= ga.MaxGenerations)
                {
                    StopGeneticAlgorithm();
                    MessageBox.Show($"Hoàn thành! Khoảng cách tốt nhất: {bestDistance:F2}", 
                        "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void panelMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Vẽ các thành phố
            Brush cityBrush = new SolidBrush(Color.Red);
            Brush cityNumberBrush = new SolidBrush(Color.White);
            Font font = new Font("Arial", 8, FontStyle.Bold);
            
            for (int i = 0; i < cities.Count; i++)
            {
                PointF city = cities[i];
                g.FillEllipse(cityBrush, city.X - 8, city.Y - 8, 16, 16);
                g.DrawEllipse(Pens.Black, city.X - 8, city.Y - 8, 16, 16);
                
                string cityNumber = i.ToString();
                SizeF textSize = g.MeasureString(cityNumber, font);
                g.DrawString(cityNumber, font, cityNumberBrush, 
                    city.X - textSize.Width/2, city.Y - textSize.Height/2);
            }

            // Vẽ đường đi tốt nhất
            if (bestRoute != null && bestRoute.Length > 1)
            {
                Pen routePen = new Pen(Color.Blue, 2);
                
                for (int i = 0; i < bestRoute.Length; i++)
                {
                    int currentCity = bestRoute[i];
                    int nextCity = bestRoute[(i + 1) % bestRoute.Length];
                    
                    g.DrawLine(routePen, cities[currentCity], cities[nextCity]);
                }
                
                routePen.Dispose();
            }

            cityBrush.Dispose();
            cityNumberBrush.Dispose();
            font.Dispose();
        }

        private void panelMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isRunning && e.Button == MouseButtons.Left)
            {
                // Thêm thành phố mới bằng cách click chuột
                cities.Add(new PointF(e.X, e.Y));
                numericCities.Value = cities.Count;
                panelMap.Invalidate();
                ResetResults();
            }
        }

        private void labelBestDistance_Click(object sender, EventArgs e)
        {

        }

        private void labelCities_Click(object sender, EventArgs e)
        {

        }

        private void labelGenerations_Click(object sender, EventArgs e)
        {

        }

        private void numericGenerations_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCurrentGeneration_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelCurrentGeneration_Click(object sender, EventArgs e)
        {

        }
    }

    // Lớp đại diện cho một cá thể (route)
    public class Individual
    {
        public int[] Route { get; set; }
        public double Distance { get; set; }
        public double Fitness { get; set; }

        public Individual(int[] route)
        {
            Route = (int[])route.Clone();
            Distance = 0;
            Fitness = 0;
        }

        public void CalculateDistance(List<PointF> cities)
        {
            Distance = 0;
            for (int i = 0; i < Route.Length; i++)
            {
                int currentCity = Route[i];
                int nextCity = Route[(i + 1) % Route.Length];
                Distance += GetDistance(cities[currentCity], cities[nextCity]);
            }
            Fitness = 1.0 / (Distance + 1); // +1 để tránh chia cho 0
        }

        private double GetDistance(PointF city1, PointF city2)
        {
            double dx = city1.X - city2.X;
            double dy = city1.Y - city2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }

    // Lớp thuật toán di truyền
    public class GeneticAlgorithm
    {
        private List<PointF> cities;
        private List<Individual> population;
        private Random random;
        
        public int PopulationSize { get; private set; }
        public double MutationRate { get; private set; }
        public int MaxGenerations { get; private set; }

        public GeneticAlgorithm(List<PointF> cities, int populationSize, double mutationRate, int maxGenerations)
        {
            this.cities = cities;
            this.PopulationSize = populationSize;
            this.MutationRate = mutationRate;
            this.MaxGenerations = maxGenerations;
            this.random = new Random();
            
            InitializePopulation();
        }

        private void InitializePopulation()
        {
            population = new List<Individual>();
            
            for (int i = 0; i < PopulationSize; i++)
            {
                int[] route = GenerateRandomRoute();
                Individual individual = new Individual(route);
                individual.CalculateDistance(cities);
                population.Add(individual);
            }
        }

        private int[] GenerateRandomRoute()
        {
            int[] route = new int[cities.Count];
            for (int i = 0; i < cities.Count; i++)
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
            List<Individual> newPopulation = new List<Individual>();
            
            // Elitism - giữ lại cá thể tốt nhất
            Individual best = GetBestIndividual();
            newPopulation.Add(new Individual(best.Route));
            newPopulation[0].CalculateDistance(cities);

            // Tạo thế hệ mới
            while (newPopulation.Count < PopulationSize)
            {
                Individual parent1 = TournamentSelection();
                Individual parent2 = TournamentSelection();
                
                Individual child = Crossover(parent1, parent2);
                Mutate(child);
                child.CalculateDistance(cities);
                
                newPopulation.Add(child);
            }

            population = newPopulation;
        }

        private Individual TournamentSelection()
        {
            int tournamentSize = 5;
            Individual best = null;
            
            for (int i = 0; i < tournamentSize; i++)
            {
                Individual contestant = population[random.Next(population.Count)];
                if (best == null || contestant.Fitness > best.Fitness)
                {
                    best = contestant;
                }
            }
            
            return best;
        }

        private Individual Crossover(Individual parent1, Individual parent2)
        {
            // Order Crossover (OX)
            int[] child = new int[cities.Count];
            bool[] used = new bool[cities.Count];
            
            int start = random.Next(cities.Count);
            int end = random.Next(start, cities.Count);
            
            // Copy segment from parent1
            for (int i = start; i <= end; i++)
            {
                child[i] = parent1.Route[i];
                used[parent1.Route[i]] = true;
            }
            
            // Fill remaining positions with genes from parent2
            int childIndex = (end + 1) % cities.Count;
            int parent2Index = (end + 1) % cities.Count;
            
            while (childIndex != start)
            {
                if (!used[parent2.Route[parent2Index]])
                {
                    child[childIndex] = parent2.Route[parent2Index];
                    used[parent2.Route[parent2Index]] = true;
                    childIndex = (childIndex + 1) % cities.Count;
                }
                parent2Index = (parent2Index + 1) % cities.Count;
            }
            
            return new Individual(child);
        }

        private void Mutate(Individual individual)
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

        public Individual GetBestIndividual()
        {
            Individual best = population[0];
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
            Individual best = GetBestIndividual();
            return (best.Route, best.Distance);
        }
    }
}