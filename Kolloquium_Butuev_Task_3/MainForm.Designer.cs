namespace CarFleetApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.FlowLayoutPanel panelButtons;
        private System.Windows.Forms.Button btnFilterByBrand;
        private System.Windows.Forms.Button btnSortByPower;
        private System.Windows.Forms.Button btnGroupByBodyType;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFilterByBrand = new System.Windows.Forms.Button();
            this.btnSortByPower = new System.Windows.Forms.Button();
            this.btnGroupByBodyType = new System.Windows.Forms.Button();

            this.panelButtons.Controls.Add(this.btnFilterByBrand);
            this.panelButtons.Controls.Add(this.btnSortByPower);
            this.panelButtons.Controls.Add(this.btnGroupByBodyType);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Height = 40;
            this.panelButtons.Padding = new System.Windows.Forms.Padding(5);

            this.btnFilterByBrand.Text = "Фильтр по марке";
            this.btnFilterByBrand.Width = 120;
            this.btnFilterByBrand.Height = 30;
            this.btnFilterByBrand.Margin = new System.Windows.Forms.Padding(5);

            this.btnSortByPower.Text = "Сортировка по мощности";
            this.btnSortByPower.Width = 120;
            this.btnSortByPower.Height = 30;
            this.btnSortByPower.Margin = new System.Windows.Forms.Padding(5);

            this.btnGroupByBodyType.Text = "Группировка по кузову";
            this.btnGroupByBodyType.Width = 120;
            this.btnGroupByBodyType.Height = 30;
            this.btnGroupByBodyType.Margin = new System.Windows.Forms.Padding(5);

            this.dgvCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCars.ReadOnly = true;
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvCars.Columns.Add("Автопарк", "Автопарк");
            this.dgvCars.Columns.Add("Марка", "Марка");
            this.dgvCars.Columns.Add("Макс. скорость", "Макс. скорость");
            this.dgvCars.Columns.Add("Мощность", "Мощность");
            this.dgvCars.Columns.Add("Тип кузова", "Тип кузова");

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dgvCars);
            this.Controls.Add(this.panelButtons);
            this.Text = "Управление автопарками";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
    }
}