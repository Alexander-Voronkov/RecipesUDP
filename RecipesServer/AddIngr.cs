using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DllClass;
namespace RecipesServer
{
    public partial class AddIngr : Form
    {
        List<Ingredient> ingrs;
        public Ingredient res;
        public AddIngr(List<Ingredient>qq)
        {
            InitializeComponent();
            this.ingrs = qq;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength==0)
            {
                MessageBox.Show("Ingredient name can't be empty!");
                return;
            }

            if(textBox2.TextLength==0)
            {
                MessageBox.Show("Ingredient weight can't be empty!");
                return;
            }

            float weight;

            if(!float.TryParse(textBox2.Text,out weight)||weight==0)
            {
                MessageBox.Show("Wrong weight!");
                return;
            }

            if(ingrs.Where(x=>x.IngredientName==textBox1.Text).Count()>0)
            {
                MessageBox.Show("Recipe already contains this ingredient!");
                return;
            }

            res = new Ingredient(textBox1.Text, weight);
            this.Close();
        }
    }
}
