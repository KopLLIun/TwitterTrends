using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ОС.Лаба4
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        private int memorySize;
        private int segmentQuantity;
        private string loadingProcessName;
        private int loadingProcessSize;

        public bool check(int index, int loadingProcessSize)
        {
            if (index + loadingProcessSize > listView1.Items.Count)
                return false;
            else
            {
                for (int i = index; i < index + loadingProcessSize; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text != "0")
                        return false;
                }
            }
            return true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        //create button
        private void button1_Click(object sender, EventArgs e)
        {
            setMemorySize();
        }

        //load button
        private void button2_Click(object sender, EventArgs e)
        {
            loadProcessInMemory();
        }

        //unload buttno
        private void Button3_Click(object sender, EventArgs e)
        {
            unloadProcessFromMemory();
        }

        //compress button
        private void button4_Click(object sender, EventArgs e)
        {
            compressProcess();
        }

        private void setMemorySize()
        {
            if (textBox1.Text == String.Empty)
                MessageBox.Show("Введите размер оперативной памяти.");
            else if (Convert.ToInt32(textBox1.Text) < 16 || Convert.ToInt32(textBox1.Text) > 512)
            {
                MessageBox.Show("Минимальный объем памяти: 16 Кб\nМаксимальный объем паяти 512 Кб");
            }
            else
            {
                listView1.Items.Clear();
                if (correctDataField(textBox1.Text))
                {
                    memorySize = Convert.ToInt32(textBox1.Text);
                    segmentQuantity = memorySize / 4;
                    for (int i = 0; i < segmentQuantity; i++)
                    {
                        string[] elements = { i.ToString(), "0", (i * 4).ToString(), String.Empty };
                        listView1.Items.Add(new ListViewItem(elements));
                    }
                }
            }
        }

        private void loadProcessInMemory()
        {
            bool success = false;
            loadingProcessName = processName.Text;
            if (correctDataField(processSize.Text))
            {
                int convertProcessSize = Convert.ToInt32(processSize.Text);
                loadingProcessSize = convertProcessSize % 4 == 0 ? convertProcessSize / 4 : convertProcessSize / 4 + 1;

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (check(i, loadingProcessSize))
                    {
                        success = true;
                        for (int j = i; j < (i + loadingProcessSize); j++)
                        {
                            listView1.Items[j].SubItems[0].Text = j.ToString();
                            listView1.Items[j].SubItems[1].Text = processName.Text;
                            //listView1.Items[j].SubItems[2].Text = (j * 4).ToString();
                            //listView1.Items[j].SubItems[3].Text = (j - i).ToString();
                        }
                        i = listView1.Items.Count - 1;
                    }
                }
            }
            if (!success)
                MessageBox.Show("Для процесса нет места.");
        }

        private void unloadProcessFromMemory()
        {
            if (textBox2.Text == String.Empty)
                MessageBox.Show("Введите название процесса.");
            else
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].SubItems[1].Text == textBox2.Text)
                    {
                        listView1.Items[i].SubItems[0].Text = i.ToString();
                        listView1.Items[i].SubItems[1].Text = "0";
                        //listView1.Items[i].SubItems[2].Text = (i * 4).ToString();
                        //listView1.Items[i].SubItems[3].Text = String.Empty;
                    }
                }
            }
        }

        private void compressProcess()
        {
            int i = 0;
            while (i < listView1.Items.Count)
            {
                if (listView1.Items[i].SubItems[1].Text == "0")
                {
                    // Сдвигаем все строки после i на одну вверх
                    for (int j = i; j < listView1.Items.Count - 1; j++)
                    {
                        listView1.Items[j].SubItems[1].Text = listView1.Items[j + 1].SubItems[1].Text;
                        listView1.Items[j].SubItems[2].Text = listView1.Items[j + 1].SubItems[2].Text;
                        listView1.Items[j].SubItems[3].Text = listView1.Items[j + 1].SubItems[3].Text;
                    }
                    // Очищаем освободившуюся строку
                    int last = listView1.Items.Count - 1;
                    listView1.Items[last].SubItems[1].Text = "0";
                    listView1.Items[last].SubItems[2].Text = "";
                    listView1.Items[last].SubItems[3].Text = "";
                }
                i++;
            }
        }

        private bool correctDataField(string data)
        {
            if (String.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("Ошибка ввода данных");
                return false;
            }
            return true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void processSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
