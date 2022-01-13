using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppHomeSQL2
{
    public partial class Form1 : Form
    {
        CodeFirst code;
        public Form1()
        {
            InitializeComponent();

            //code = new CodeFirst();
            //code.Products.Load();
            //dataGridView1.DataSource = code.Products.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            code = new CodeFirst();
            code.Products.Load();
            NewProductFormcs newProduct = new NewProductFormcs();
            DialogResult dialog = newProduct.ShowDialog(this);
            if (dialog == DialogResult.Cancel)
                return;
            Product product = new Product();
            
            product.Name = newProduct.textBox2.Text;
            product.Price = Convert.ToDouble(newProduct.textBox3.Text);
            code.Products.Add(product);
            code.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Product product = code.Products.Find(id);
                code.Products.Remove(product);
                code.SaveChanges();

                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Product product = code.Products.Find(id);
                NewProductFormcs newProduct = new NewProductFormcs();
                newProduct.textBox2.Text = product.Name;
                newProduct.textBox3.Text = product.Price.ToString();

                DialogResult dialog = newProduct.ShowDialog(this);
                if (dialog == DialogResult.Cancel)
                    return;
                product.Name = newProduct.textBox2.Text;
                product.Price = Convert.ToDouble(newProduct.textBox3.Text);

                code.SaveChanges();
                dataGridView1.Refresh();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            code = new CodeFirst();
            code.Products.Load();
            dataGridView1.DataSource = code.Products.Local.ToBindingList();
        }
    }
}
