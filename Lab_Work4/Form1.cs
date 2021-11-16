using System;
using System.Windows.Forms;

namespace Diagramm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = 10;
            numericUpDown1.Minimum = 1;
            dataGridView1.RowCount = (int)numericUpDown1.Value;
            dataGridView1.ColumnCount = 4;

            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns[0].HeaderCell.Value = "Название товара";
                dataGridView1.Columns[1].HeaderCell.Value = "Цена товара";
                dataGridView1.Columns[2].HeaderCell.Value = "Количество";
                dataGridView1.Columns[3].HeaderCell.Value = "Стоимость";
            }

            dataGridView1.RowHeadersWidth = 50;

            for (int i = 0; i < (int)numericUpDown1.Value; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0");
                dataGridView1.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }




        private void deal()
        {
            double count, price, priceForOne, l, sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = "";
                        dataGridView1.Rows[i].Cells[1].Value = 0;
                        dataGridView1.Rows[i].Cells[2].Value = 0;
                        dataGridView1.Rows[i].Cells[3].Value = 0;
                    }

                }
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                dataGridView1.Columns[i].Width = 150;

                if (double.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out l) && double.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out l) && chart1.Series["S1"].ChartType == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie)
                {

                    string name = dataGridView1.Rows[i].Cells[0].Value.ToString();

                    count = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    price = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    priceForOne = count * price;

                    sum += priceForOne;
                    string Percent = ((priceForOne / sum) * 100).ToString("0.00") + "%";

                    dataGridView1.Rows[i].Cells[3].Value = Convert.ToString(priceForOne);
                    chart1.Series["S1"].Label = "#PERCENT{P}";
                    chart1.Series["S1"].LegendText = "#VALX";
                    chart1.Series["S1"].Points.AddXY(priceForOne + " " + name, priceForOne);
                }
                if (double.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out l) && double.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out l) && chart1.Series["S1"].ChartType == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column)
                {

                    string name = dataGridView1.Rows[i].Cells[0].Value.ToString();

                    count = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    price = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    priceForOne = count * price;

                    sum += priceForOne;
                    string Percent = ((priceForOne / sum) * 100).ToString("0.00") + "%";

                    dataGridView1.Rows[i].Cells[3].Value = Convert.ToString(priceForOne);
                    chart1.Series["S1"].Label = "#PERCENT{P}";


                    chart1.Series["S1"].LegendText = "Стоимость";
                    chart1.Series["S1"].Points.AddXY(priceForOne + " " + name, priceForOne);
                }
                if (double.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString(), out l) == false || double.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out l) == false)
                {
                    ShowMessageBox("Введены некорректные данные", "Сообщение");
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chart1.Series["S1"].ChartType == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie)
            {
                chart1.Series.Clear();
                chart1.Series.Add("S1");
                deal();
                chart1.Series["S1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            }
            else if (chart1.Series["S1"].ChartType == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column)
            {
                chart1.Series.Clear();
                chart1.Series.Add("S1");
                deal();
                chart1.Series["S1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chart1.Series["S1"].ChartType == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie)
            {
                chart1.Series.Clear();
                chart1.Series.Add("S1");
                chart1.Series["S1"].LegendText = "#VALX";
                deal();
                chart1.Series["S1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            }
            else if (chart1.Series["S1"].ChartType == System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column)
            {
                chart1.Series.Clear();
                chart1.Series.Add("S1");
                deal();
                chart1.Series["S1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void ShowMessageBox(string message, string text)
        {
            bool showed = false;
            if (!showed)
                MessageBox.Show(message, text);
            showed = true;
        }
    }
}
