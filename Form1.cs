using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            bool priceOK = int.TryParse(textBox2.Text, out tmpPrice);
            int tmpQuantity;
            bool quantityOK = int.TryParse(textBox3.Text, out tmpQuantity);

            if (textBox1.Text.Length > 0 && priceOK && quantityOK)
            {
                Food newFood = new Food(textBox1.Text, tmpPrice, tmpQuantity);
                foodList.Add(newFood);
                ListPrint(foodList);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
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
                sum+=food.Price*food.Quantity;
            }
            label5.Text = "Итоговая стоимость: "+sum.ToString();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = foodList[listBox1.SelectedIndex].Name;
            textBox2.Text = foodList[listBox1.SelectedIndex].Price.ToString();
            textBox3.Text = foodList[listBox1.SelectedIndex].Quantity.ToString();
        }

        private void button3_Click(object sender, EventArgs e)//изменить позицию
        {
            if (listBox1.SelectedIndex > -1)
            {
                foodList[listBox1.SelectedIndex].Name = textBox1.Text;
                foodList[listBox1.SelectedIndex].Price = textBox2.Text;
                foodList[listBox1.SelectedIndex].Quantity = textBox3.Text;
            }
        }
    }
}