using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MID_TERM
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[100];
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void populateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopulateNumbers(ref numbers);
        }

        private void PopulateNumbers(ref int[] abc)
        {
            Random rnd = new Random();
            float sum = 0;
            float avg;

            for (int i = 0; i < abc.Length; i++)
            {
                abc[i] = rnd.Next(100);
                sum += abc[i];
                listBox1.Items.Add(i.ToString() + " => " + abc[i].ToString());

            }
            avg = sum / 100;
            label3.Text = "Average : " + avg;
            int vOut = Convert.ToInt32(avg);

            for (int i = 0; i < abc.Length; i++)
            {
                if (abc[i] < vOut)
                {
                    listBox2.Items.Add(abc[i].ToString());
                }
                else
                {
                    listBox3.Items.Add(abc[i].ToString());
                }


                var _items = this.listBox2.Items.Cast<string>().Distinct().ToArray();
                this.listBox2.Items.Clear();
                foreach (var item in _items)
                {
                    this.listBox2.Items.Add(item);
                }

                var _items2 = this.listBox3.Items.Cast<string>().Distinct().ToArray();
                this.listBox3.Items.Clear();
                foreach (var item in _items2)
                {
                    this.listBox3.Items.Add(item);
                }
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchNumbers(ref numbers);

        }

        private void SearchNumbers(ref int[] num)
        {
            try
            {
                int search = int.Parse(textBox1.Text);
                int count = 0;
                string index = "";

                for (int i = 0; i < num.Length; i++)
                {
                    if (search == num[i])
                    {
                        count++;
                        index = i + " Index: " + index;
                    }
                }
                label7.Text = "Count: " + count;
                if (count >= 1)
                {
                    label8.Text = "Index: " + index;
                }
                else
                {
                    label8.Text = "The number is not in array";
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Please enter any number in the search box");
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                if (MessageBox.Show("Are you want to exit?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;

            }
            else
            {
                if (MessageBox.Show("Are you want to exit?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        }
    }
}  
