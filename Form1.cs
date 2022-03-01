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
            Food newFood = new Food(textBox1.Text,int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            foodList.Add(newFood);
            ListPrint(foodList);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

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
            
        }
        public void SumCount()
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(bread.Name + " " + bread.Price.ToString() + "руб. " + bread.Quantity.ToString() + "шт.");
        }
    }
}
//TODO пересчитывать цену после удаления элемента