using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            if (index + loadingProcessSize > dataGridView1.Rows.Count)
                return false;
            else
            {
                for (int i = index; i < index + loadingProcessSize; i++)
                {
                    if (dataGridView1.Columns[i].Name == "0")
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
            setSegmentSize();
        }

        //load button
        private void button2_Click(object sender, EventArgs e)
        {
            loadProcessInMemory();
        }

        //unload button
        private void button3_Click(object sender, EventArgs e)
        {
            unloadProcessFromMemory();
        }

        //compress button
        private void button4_Click(object sender, EventArgs e)
        {
            compressProcess();
        }

        private void setSegmentSize()
        {
            if (textBox1.Text == String.Empty)
                MessageBox.Show("Введите размер сегмента памяти.");
            else if (Convert.ToInt32(textBox1.Text) < 1 || Convert.ToInt32(textBox1.Text) > 4)
            {
                MessageBox.Show("Минимальный размер сегмента: 1 Кб\nМаксимальный размер сегмента 4 Кб");
            }
            else
            {
                dataGridView1.Rows.Clear();
                //if (correctDataField(textBox1.Text))
                //{
                    memorySize = Convert.ToInt32(textBox1.Text);
                segmentQuantity = Convert.ToInt32(textBox3.Text);
                dataGridView1.RowCount = memorySize / segmentQuantity;
                dataGridView1.ColumnCount = segmentQuantity;
                    for (int i = 0; i < memorySize / segmentQuantity; i++) {
                    {
                        for (int j = 0; j < segmentQuantity; j++)
                        {
                            //string[] elements = { i.ToString(), "0", (i * 4).ToString(), String.Empty };
                            dataGridView1.Rows[i].Cells[j].Value = "0";
                        }
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

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (check(i, loadingProcessSize))
                    {
                        success = true;
                        for (int j = i; j < (i + loadingProcessSize); j++)
                        {
                            dataGridView1.Columns[0].Name = j.ToString();
                            dataGridView1.Columns[1].Name = processName.Text;
                            //listView1.Items[j].SubItems[2].Text = (j * 4).ToString();
                            //listView1.Items[j].SubItems[3].Text = (j - i).ToString();
                        }
                        i = dataGridView1.Rows.Count - 1;
                    }
                }
            }
            if (!success)
                MessageBox.Show("Для процесса нет места.");
        }

        private void unloadProcessFromMemory()
        {
            //if (textBox2.Text == String.Empty)
            //    MessageBox.Show("Введите название процесса.");
            //else
            //{
            //    for (int i = 0; i < listView1.Items.Count; i++)
            //    {
            //        if (listView1.Items[i].SubItems[1].Text == textBox2.Text)
            //        {
            //            listView1.Items[i].SubItems[0].Text = i.ToString();
            //            listView1.Items[i].SubItems[1].Text = "0";
            //            //listView1.Items[i].SubItems[2].Text = (i * 4).ToString();
            //            //listView1.Items[i].SubItems[3].Text = String.Empty;
            //        }
            //    }
            //}
        }

        private void compressProcess()
        {
            //int i = 0;
            //while (i < listView1.Items.Count)
            //{
            //    if (listView1.Items[i].SubItems[1].Text == "0")
            //    {
            //        // Сдвигаем все строки после i на одну вверх
            //        for (int j = i; j < listView1.Items.Count - 1; j++)
            //        {
            //            listView1.Items[j].SubItems[1].Text = listView1.Items[j + 1].SubItems[1].Text;
            //            listView1.Items[j].SubItems[2].Text = listView1.Items[j + 1].SubItems[2].Text;
            //            listView1.Items[j].SubItems[3].Text = listView1.Items[j + 1].SubItems[3].Text;
            //        }
            //        // Очищаем освободившуюся строку
            //        int last = listView1.Items.Count - 1;
            //        listView1.Items[last].SubItems[1].Text = "0";
            //        listView1.Items[last].SubItems[2].Text = "";
            //        listView1.Items[last].SubItems[3].Text = "";
            //    }
            //    i++;
            //}
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
