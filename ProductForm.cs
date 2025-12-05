using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHMIP
{
    public partial class ProductForm : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable productsTable;
        private AutorizationForm autorizationForm;
        public Label labelCount;

        public ProductForm(AutorizationForm autorizationForm)
        {
            InitializeComponent();

            this.autorizationForm = autorizationForm;

            
            InitializeDatabase();
            LoadProducts();

            FillManufacturersList();

            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;

            textBox1.TextChanged += OnSearchTextChanged;

            comboBox1.SelectedIndexChanged += OnManufacturerSelected;

            labelCount = new Label();
            labelCount.Location = new Point(10, 10); 
            labelCount.AutoSize = true;
            Controls.Add(labelCount);

            UpdateRecordsCount();
        }

        private void InitializeDatabase()
        {
            string connectionString = "Server=VANDAL; Database=posuda; Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("SELECT * FROM Products", connection);
            productsTable = new DataTable();
            adapter.Fill(productsTable);
        }

        public void LoadProducts(string searchQuery = "", string selectedManufacturer = "", string sortOrder = "ASC")
        {
            flowLayoutPanel1.Controls.Clear(); 

            DataView dataView = new DataView(productsTable);
            if (!string.IsNullOrEmpty(searchQuery))
            {
                dataView.RowFilter = $"Наименование LIKE '%{searchQuery}%' OR Описание LIKE '%{searchQuery}%' OR Производитель LIKE '%{searchQuery}%'";
            }
            if (!string.IsNullOrEmpty(selectedManufacturer) && !selectedManufacturer.Equals("Все производители"))
            {
                if (!string.IsNullOrEmpty(dataView.RowFilter))
                {
                    dataView.RowFilter += $" AND Производитель='{selectedManufacturer}'";
                }
                else
                {
                    dataView.RowFilter = $"Производитель='{selectedManufacturer}'";
                }
            }
            dataView.Sort = $"Стоимость {sortOrder}";

            foreach (DataRowView rowView in dataView)
            {
                DataRow row = rowView.Row;
                string productName = row["Наименование"].ToString();
                string description = row["Описание"].ToString();
                string manufacturer = row["Производитель"].ToString();
                decimal price = Convert.ToDecimal(row["Стоимость"]);
                int stock = Convert.ToInt32(row["Кол_во_на_складе"]);
                string imagePath = row["Изображение"].ToString();

                string fullImagePath = Path.Combine(@"C:\Users\User\Desktop\SHMIP\Товар", imagePath);

                Panel productPanel = new Panel();
                productPanel.Size = new Size(600, 150);
                productPanel.BorderStyle = BorderStyle.FixedSingle;

                if (stock == 0)
                {
                    productPanel.BackColor = Color.LightGray;
                }
                else
                {
                    productPanel.BackColor = Color.White;
                }

                PictureBox productImage = new PictureBox();
                productImage.Location = new Point(10, 10);
                productImage.Size = new Size(100, 100);
                productImage.BorderStyle = BorderStyle.FixedSingle;
                productImage.SizeMode = PictureBoxSizeMode.Zoom;
                if (!string.IsNullOrEmpty(imagePath))
                {
                    productImage.Load(fullImagePath);
                }
                productPanel.Controls.Add(productImage);

                string productInfo = $"Название: {productName}\nОписание: {description}\nПроизводитель: {manufacturer}\nЦена: {price:C}";

                Label productInfoLabel = new Label();
                productInfoLabel.Location = new Point(120, 10);
                productInfoLabel.Size = new Size(400, 100);
                productInfoLabel.AutoSize = false;
                productInfoLabel.Text = productInfo;
                productInfoLabel.Font = new Font("Comic Sans MS", 8);
                productInfoLabel.ForeColor = Color.Black;
                productInfoLabel.BackColor = Color.Transparent;
                productInfoLabel.BorderStyle = BorderStyle.None;
                productPanel.Controls.Add(productInfoLabel);

                Label stockLabel = new Label();
                stockLabel.Location = new Point(500, 10);
                stockLabel.Size = new Size(100, 20);
                stockLabel.AutoSize = false;
                stockLabel.TextAlign = ContentAlignment.MiddleRight;
                if (stock == 0)
                {
                    stockLabel.Text = "Нет в наличии";
                }
                else
                {
                    stockLabel.Text = $"В наличии: {stock}";
                }
                stockLabel.Font = new Font("Comic Sans MS", 8);
                productPanel.Controls.Add(stockLabel);

                flowLayoutPanel1.Controls.Add(productPanel);
            }
            UpdateRecordsCount();
        }

        
        private void FillManufacturersList()
        {
            List<string> manufacturers = new List<string>();
            manufacturers.Add("Все производители");

            
            var uniqueManufacturers = productsTable.AsEnumerable().Select(r => r.Field<string>("Производитель")).Distinct();
            manufacturers.AddRange(uniqueManufacturers.OrderBy(m => m));

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(manufacturers.ToArray());
            comboBox1.SelectedIndex = 0; 
        }

        public void OnSearchTextChanged(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text.Trim();
            string currentSortOrder = GetCurrentSortOrder();
            string selectedManufacturer = comboBox1.SelectedItem?.ToString() ?? "";
            LoadProducts(searchQuery, selectedManufacturer, currentSortOrder);
            UpdateRecordsCount();
        }

        
        public void OnManufacturerSelected(object sender, EventArgs e)
        {
            string selectedManufacturer = comboBox1.SelectedItem?.ToString() ?? "";
            string currentSearchQuery = textBox1.Text.Trim();
            string currentSortOrder = GetCurrentSortOrder();
            LoadProducts(currentSearchQuery, selectedManufacturer, currentSortOrder);
            UpdateRecordsCount();
        }

        public void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                string sortOrder = rb.Name == "radioButton1" ? "ASC" : "DESC";
                string currentSearchQuery = textBox1.Text.Trim();
                string selectedManufacturer = comboBox1.SelectedItem?.ToString() ?? "";
                LoadProducts(currentSearchQuery, selectedManufacturer, sortOrder);
                UpdateRecordsCount();
            }
        }

        
        public string GetCurrentSortOrder()
        {
            return radioButton1.Checked ? "ASC" : "DESC";
        }

        public void UpdateRecordsCount()
        {
            if (productsTable != null && flowLayoutPanel1 != null && labelCount != null)
            {
                int totalRecords = productsTable.Rows.Count;
                int displayedRecords = flowLayoutPanel1.Controls.Count;

                labelCount.Text = $"{displayedRecords} из {totalRecords}";
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var redacdAtForm = new AutorizationForm();
            redacdAtForm.Show();
            Hide();
        }
    }
}