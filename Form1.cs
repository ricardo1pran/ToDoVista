﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            var x = MessageBox.Show("All incomplete ToDos will be lost!\nAre you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            if (todo.Equals(""))
            {
                MessageBox.Show(this, "Type something to add first!", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            listBox1.Items.Add(todo);
            textBox1.Text = "";
            textBox1.Focus();
            //MessageBox.Show("To-Do added successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show(this,"Select a Todo first!","Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (listBox1.Items[listBox1.SelectedIndex].ToString().Contains("Completed!"))
            {
                MessageBox.Show(this, "Oops! To-Do is already completed!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
                return;
            }
            var selectedTodo = listBox1.Items[listBox1.SelectedIndex].ToString();
            var completedTodo = "(" + selectedTodo + ") --Completed!";
            listBox1.Items[listBox1.SelectedIndex] = completedTodo;
            MessageBox.Show(this, "To-Do Completed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information
            );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show(this, "Select a Todo first!", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var ask = MessageBox.Show("Are you sure want to delete this todo?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if( ask.Equals(DialogResult.Yes))
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                MessageBox.Show(this,"To-Do Deleted!","Success",
                    MessageBoxButtons.OK,MessageBoxIcon.Information
                );
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,"ToDoVista v.1.2.0\nMade by Ricardo1pran\n2023",
                "About ToDoVista",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,e);
            }
        }

        private void saveListAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show(this, "The ToDo List is Empty!\nNothing to save!", "Oops!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Header file
                var enter = Environment.NewLine;
                File.WriteAllText(saveFileDialog1.FileName, "----- ToDoVista Saved ToDo List -----" + enter + enter);
                foreach (var item in listBox1.Items)
               {
                   File.AppendAllText(saveFileDialog1.FileName, "o " + item.ToString() + enter);
               }

                
                MessageBox.Show(this,"ToDo List saved succesfully!","Done!",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void remCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show("All completed ToDos will be removed!\nAre you sure?", "Clear Completed Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x.Equals(DialogResult.Yes))
            {
                // iterate backwards to prevent messing with existing items' index
                for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                {
                    if (listBox1.Items[i].ToString().Contains(") --Completed!"))
                    {
                        listBox1.Items.RemoveAt(i);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void clearAllToDosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show("All ToDos will be removed!\nAre you sure?", "Clear All Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (x.Equals(DialogResult.Yes))
            {
                listBox1.Items.Clear();
            }
            else
            {
                return;
            }
        }
    }
}
