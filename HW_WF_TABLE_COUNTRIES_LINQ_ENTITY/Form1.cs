using HW_WF_TABLE_COUNTRIES_LINQ_ENTITY.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_WF_TABLE_COUNTRIES_LINQ_ENTITY
{
    public partial class Form1 : Form
    {
        Controller controller;
        Controller_Linq controller_Linq;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
            controller_Linq = new Controller_Linq();
            LoadData();

        }


        void LoadData()
        {
            listBox1.Items.Clear();
            foreach (var el in controller.GetCountriesAsObj())
                listBox1.Items.Add(el);
            btnDelete.Enabled = false;
        }
        
        void DelCountry(int ID)
        {
            controller.DelCountry(ID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Countries bk = (Countries)listBox1.SelectedItem;
            
            DelCountry(bk.id);
            LoadData();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (textBoxName.Text != "" && textBoxArea.Text != "" &&
                textBoxAmountHumans.Text != "" && textBoxCapital.Text != ""
                && textBoxContinent.Text != "")
            {
                Countries bk = new Countries()
                { 
                Name = textBoxName.Text,
                Capital = textBoxCapital.Text,
                AmountHumans = int.Parse(textBoxAmountHumans.Text),
                Area = int.Parse(textBoxArea.Text),
                Continent = textBoxContinent.Text
                };

                controller.AddCountry(bk);
                LoadData();

            }
            else MessageBox.Show("Введите все данные");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(controller_Linq.Top1_ByArea().First());
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(controller_Linq.Top1_ByHumans().First());
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in controller_Linq.Top5_ByArea()) 
            { 
                 listBox1.Items.Add(item);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in controller_Linq.Top5_ByHumans())
            {
                listBox1.Items.Add(item);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            foreach (var item in controller_Linq.Smallest_ByArea())
            {
                listBox1.Items.Add(item);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
                listBox1.Items.Add(controller_Linq.AmountByCountries());
            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var el in controller_Linq.ContinentWithMaxAmountCountries())
                listBox1.Items.Add(el);


        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var el in   controller_Linq.AmountCountriesInEveryContinent())
                listBox1.Items.Add(el);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();

            foreach (var el in controller_Linq.MidAreaaCountriesInEurope())
                listBox1.Items.Add(el);

           
        }
    }
}
