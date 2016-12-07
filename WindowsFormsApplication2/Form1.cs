using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int rozmiar = 150;
        double[,] matrix = new double[150,6];
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < rozmiar; i++)
            {
                double suma = 0;
                double min = -1;
                double minj = 0;
                int j = 0;
                while (j < rozmiar - 1)
                {
                    if (j != i)
                    {
                        suma = Math.Pow(matrix[i, 0] - matrix[j, 0], 2.0) + Math.Pow(matrix[i, 1] - matrix[j, 1], 2.0) + Math.Pow(matrix[i, 2] - matrix[j, 2], 2.0) + Math.Pow(matrix[i, 3] - matrix[j, 3], 2.0);
                        if (min == -1)
                        {
                            min = suma;
                            minj = j;
                        }
                        else
                            if (min > suma)
                        {
                            min = suma;
                            minj = j;
                        }
                    }
                    j++;
                }
                dataGridView1.Rows.Add(i + 1, minj + 1, Math.Round(min, 2));
                dataGridView1.Refresh();
            }
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            double[] knnSuma = new double[150];
            double[] knnId = new double[150];
            for (int i = 0; i < rozmiar; i++)
            {
                double suma = 0;
                int j = 0;
                while (j < rozmiar - 1)
                {
                    if (j != i)
                    {
                        suma = 0;
                        for (int z = 0; z < 4; z++)
                        {
                            suma += (Math.Pow(matrix[i, z] - matrix[j, z], 2));
                        }
                        knnSuma[j] = suma;
                        knnId[j] = j+ 1.0;
                    }
                    else
                    {
                        knnSuma[j] = 100;
                        knnId[j] = j + 1.0;
                    }
                    j++;
                    
                }
                for (int x = 0; x < 150; x++)
                {
                    for (int y = 0; y < 150; y++)
                    {
                        if (x != y)
                        {
                            if (knnSuma[x]< knnSuma[y])
                            {
                                double tmp = knnSuma[y];
                                knnSuma[y] = knnSuma[x];
                                knnSuma[x] = tmp;
                                double tp = knnId[y];
                                knnId[y] = knnId[x];
                                knnId[x] = tp;
                            }
                        }
                    }
                }
                for (int z = 0; z < int.Parse(textBox1.Text); z++)
                {
                    dataGridView2.Rows.Add(i + 1, knnId[z], knnSuma[z]);
                }
                dataGridView2.Rows.Add();
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] plik = File.ReadAllLines(@"Dane.txt");

            DataGridViewCell cell = new DataGridViewTextBoxCell();
            cell.ValueType = typeof(Double);


            DataGridViewColumn dgvc6 = new DataGridViewColumn();
            dgvc6.HeaderText = "ID";
            dgvc6.CellTemplate = cell;
            DataGridViewColumn dgvc7 = new DataGridViewColumn();
            dgvc7.HeaderText = "ID NN";
            dgvc7.CellTemplate = cell;
            DataGridViewColumn dgvc8 = new DataGridViewColumn();
            dgvc8.HeaderText = "Length";
            dgvc8.CellTemplate = cell;
       
            dataGridView1.Columns.Add(dgvc6);
            dataGridView1.Columns.Add(dgvc7);
            dataGridView1.Columns.Add(dgvc8);

            DataGridViewColumn dgvc9 = new DataGridViewColumn();
            dgvc9.HeaderText = "ID";
            dgvc9.CellTemplate = cell;
            DataGridViewColumn dgvc10 = new DataGridViewColumn();
            dgvc10.HeaderText = "ID NN";
            dgvc10.CellTemplate = cell;
            DataGridViewColumn dgvc11 = new DataGridViewColumn();
            dgvc11.HeaderText = "Length";
            dgvc11.CellTemplate = cell;

            dataGridView2.Columns.Add(dgvc9);
            dataGridView2.Columns.Add(dgvc10);
            dataGridView2.Columns.Add(dgvc11);

            DataGridViewColumn dgvc1 = new DataGridViewColumn();
            dgvc1.HeaderText = "Iris-setosa";
            dgvc1.CellTemplate = cell;
            DataGridViewColumn dgvc2 = new DataGridViewColumn();
            dgvc2.HeaderText = "Iris-vesicolor";
            dgvc2.CellTemplate = cell;
            DataGridViewColumn dgvc3 = new DataGridViewColumn();
            dgvc3.HeaderText = "Iris-virginica";
            dgvc3.CellTemplate = cell;

            dataGridView3.Columns.Add(dgvc1);
            dataGridView3.Columns.Add(dgvc2);
            dataGridView3.Columns.Add(dgvc3);


            int i = 0;
            foreach (String s in plik)
            {
                string[] temp = s.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                matrix[i, 0] = Double.Parse(temp[0]);
                matrix[i, 1] = Double.Parse(temp[1]);
                matrix[i, 2] = Double.Parse(temp[2]);
                matrix[i, 3] = Double.Parse(temp[3]);
                matrix[i, 4] = Double.Parse(temp[4]);
                matrix[i, 5] = Double.Parse(temp[5]);
                i++;
            }
            

        }
    }
}
