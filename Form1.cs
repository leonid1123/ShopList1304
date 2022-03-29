using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ShopList1304
{
    public partial class Form1 : Form
    {
        class Food
        {
            private string name;
            private int price;
            private int quantity;

            public Food(string name, int price, int quantity)
            {
                this.name = name;
                this.price = price;
                this.quantity = quantity;
            }

            public string Name { get => name; set => name = value; }
            public int Price { get => price; set => price = value; }
            public int Quantity { get => quantity; set => quantity = value; }


        }

        List<Food> foodList = new List<Food>();

        Food bread = new Food("хлеб", 12, 10);


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Добавить
        {
            int tmpPrice;
            bool priceOK = int.TryParse(maskedTextBox1.Text.Trim(), out tmpPrice);
            int tmpQuantity;
            bool quantityOK = int.TryParse(maskedTextBox2.Text.Trim(), out tmpQuantity);

            if (textBox1.Text.Length > 0 && priceOK && quantityOK)
            {
                Food newFood = new Food(textBox1.Text, tmpPrice, tmpQuantity);
                foodList.Add(newFood);
                ListPrint(foodList);
                textBox1.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                SumCount(foodList);
            }
        }
        int ListPrint(List<Food> listToPrint)
        {
            listBox1.Items.Clear();
            foreach (Food food in listToPrint)
            {
                listBox1.Items.Add(food.Name + " " + food.Price.ToString() + " руб." + food.Quantity.ToString() + "шт.");
            }
            return listToPrint.Count;
        }

        private void button2_Click(object sender, EventArgs e)//Удалить
        {
            if (listBox1.SelectedIndex > -1)
            {
                foodList.RemoveAt(listBox1.SelectedIndex);
                ListPrint(foodList);
                SumCount(foodList);
            }
        }
        void SumCount(List<Food> foodToSum)
        {
            int sum = 0;
            foreach (Food food in foodToSum)
            {
                sum += food.Price * food.Quantity;
            }
            label5.Text = "Итоговая стоимость: " + sum.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = foodList[listBox1.SelectedIndex].Name;
            maskedTextBox1.Text = foodList[listBox1.SelectedIndex].Price.ToString();
            maskedTextBox2.Text = foodList[listBox1.SelectedIndex].Quantity.ToString();
        }

        private void button3_Click(object sender, EventArgs e)//изменить позицию
        {
            if (listBox1.SelectedIndex > -1)
            {
                foodList[listBox1.SelectedIndex].Name = textBox1.Text;
                foodList[listBox1.SelectedIndex].Price = int.Parse(maskedTextBox1.Text);
                foodList[listBox1.SelectedIndex].Quantity = int.Parse(maskedTextBox2.Text);
                ListPrint(foodList);
                SumCount(foodList);
            }
        }

        private void maskedTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox1.SelectAll();
        }

        private void maskedTextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            maskedTextBox2.SelectAll();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach(Food food in foodList)
            {
                String tmp = food.Name+food.Price.ToString()+food.Quantity.ToString();
                File.WriteAllText("WriteLines.txt",tmp);

            }



        }
    }
}