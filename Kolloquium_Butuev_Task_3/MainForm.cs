using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CarFleetApp
{
    public partial class MainForm : Form
    {
        private List<CarFleet> carFleets = new List<CarFleet>();

        public MainForm()
        {
            InitializeComponent();
            LoadData();
            SetupEventHandlers();
            ShowCars();
        }

        private void LoadData()
        {
            var fleet1 = new CarFleet("Автопарк 1");
            fleet1.AddCar(new Car("A", 180, 120, BodyType.Sedan));
            fleet1.AddCar(new Car("Toyota", 200, 150, BodyType.SUV));
            fleet1.AddCar(new Car("BMW", 250, 200, BodyType.Limousine));

            var fleet2 = new CarFleet("Автопарк 2");
            fleet2.AddCar(new Car("Audi", 220, 180, BodyType.Hatchback));
            fleet2.AddCar(new Car("Mercedes", 230, 190, BodyType.StationWagon));
            fleet2.AddCar(new Car("Toyota", 190, 140, BodyType.Sedan));

            carFleets.Add(fleet1);
            carFleets.Add(fleet2);
        }

        private void SetupEventHandlers()
        {
            btnFilterByBrand.Click += BtnFilterByBrand_Click;
            btnSortByPower.Click += BtnSortByPower_Click;
            btnGroupByBodyType.Click += BtnGroupByBodyType_Click;
        }

        private void ShowCars()
        {
            dgvCars.Rows.Clear();

            foreach (var fleet in carFleets)
            {
                foreach (var car in fleet.Cars)
                {
                    dgvCars.Rows.Add(
                        fleet.Name,
                        car.Brand,
                        car.MaxSpeed,
                        car.EnginePower,
                        car.BodyType.ToString()
                    );
                }
            }
        }

        private void BtnFilterByBrand_Click(object sender, EventArgs e)
        {
            using (var inputForm = new Form())
            {
                inputForm.Text = "Введите марку";
                inputForm.Size = new System.Drawing.Size(300, 150);
                inputForm.StartPosition = FormStartPosition.CenterParent;

                var label = new Label();
                label.Text = "Введите марку автомобиля:";
                label.Location = new System.Drawing.Point(20, 20);
                label.AutoSize = true;

                var textBox = new TextBox();
                textBox.Location = new System.Drawing.Point(20, 50);
                textBox.Width = 240;

                var okButton = new Button();
                okButton.Text = "OK";
                okButton.Location = new System.Drawing.Point(100, 80);
                okButton.DialogResult = DialogResult.OK;

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(okButton);

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string brand = textBox.Text.Trim();
                    if (!string.IsNullOrEmpty(brand))
                    {
                        dgvCars.Rows.Clear();

                        var cars = carFleets
                            .SelectMany(f => f.Cars)
                            .Where(c => c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
                            .ToList();

                        if (cars.Count == 0)
                        {
                            MessageBox.Show("Автомобилей такой марки не найдено");
                            ShowCars();
                        }
                        else
                        {
                            foreach (var car in cars)
                            {
                                dgvCars.Rows.Add(
                                    "Все автопарки",
                                    car.Brand,
                                    car.MaxSpeed,
                                    car.EnginePower,
                                    car.BodyType.ToString()
                                );
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите марку");
                    }
                }
            }
        }

        private void BtnSortByPower_Click(object sender, EventArgs e)
        {
            dgvCars.Rows.Clear();

            var sortedCars = carFleets
                .SelectMany(f => f.Cars)
                .OrderByDescending(c => c.EnginePower)
                .ToList();

            foreach (var car in sortedCars)
            {
                dgvCars.Rows.Add(
                    "Все автопарки",
                    car.Brand,
                    car.MaxSpeed,
                    car.EnginePower,
                    car.BodyType.ToString()
                );
            }
        }

        private void BtnGroupByBodyType_Click(object sender, EventArgs e)
        {
            string result = "Количество автомобилей по типам кузова:\n\n";

            foreach (var fleet in carFleets)
            {
                result += $"{fleet.Name}:\n";

                var groups = fleet.Cars
                    .GroupBy(c => c.BodyType)
                    .Select(g => new
                    {
                        BodyType = g.Key,
                        Count = g.Count()
                    })
                    .ToList();

                foreach (var group in groups)
                {
                    result += $"  {group.BodyType}: {group.Count} автомобилей\n";
                }
                result += "\n";
            }

            MessageBox.Show(result);
        }
    }
}