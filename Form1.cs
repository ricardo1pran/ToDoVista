using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToDoVista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var x = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x.Equals(DialogResult.Yes))
            {
                return;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var todo = textBox1.Text;
            listBox1.Items.Add(todo);
            textBox1.Text = "";
            //MessageBox.Show("To-Do added successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a Todo first!");
                return;
            }
            var selectedTodo = listBox1.SelectedValue;
            var completedTodo = "(" + selectedTodo + ") --Completed!";
            listBox1.SelectedValue = completedTodo;
            MessageBox.Show("To-Do Completed!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a Todo first!");
                return;
            }
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            MessageBox.Show("To-Do Deleted!");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ToDoVista v.1.0.0");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Equals(Keys.Enter))
            {
                button1_Click(sender,e);
            }
        }
    }
}
