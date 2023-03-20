using System;
using System.IO;
using System.Diagnostics;

namespace Form1
{
    public partial class Form1 : Form
    {

        private double xGeo1;
        private double yGeo1;
        private double xGeo2;
        private double yGeo2;
        private double height;
        private double fov;
        private string mess = "( ";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            label3.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button3.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            label9.Visible = false;
            button5.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;

            button3.Visible = true;
            label12.Visible = true;
            label11.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label10.Visible = true;
            label13.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (isDoubleS(textBox1.Text))
            {
                label3.Visible = false;
                xGeo1 = Convert.ToDouble(textBox1.Text);
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (isDoubleS(textBox2.Text))
            {
                label3.Visible = false;
                yGeo1 = Convert.ToDouble(textBox2.Text);
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (isDoubleS(textBox4.Text))
            {
                label3.Visible = false;
                xGeo2 = Convert.ToDouble(textBox4.Text);
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (isDoubleS(textBox3.Text))
            {
                label3.Visible = false;
                yGeo2 = Convert.ToDouble(textBox3.Text);
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (xGeo1 != 0 & xGeo2 != 0 & yGeo1 != 0 & yGeo2 != 0)
            {
                label13.Visible = false;
                label12.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                button3.Visible = false;

                label6.Visible = true;
                button4.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;

            }
            else {
                label3.Visible = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (isDoubleS(textBox6.Text))
            {
                label3.Visible = false;
                height = Convert.ToDouble(textBox6.Text);
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (isDoubleS(textBox5.Text))
            {
                label3.Visible = false;
                fov = Convert.ToDouble(textBox5.Text);
            }
            else
            {
                label3.Visible = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (isDoubleS(textBox5.Text) == true & isDoubleS(textBox6.Text) == true)
            {
                double lengthX;
                double lengthY;
                if (xGeo1 > xGeo2)
                {
                    lengthX = (xGeo1 - xGeo2) * 111 * 1000;
                }
                else
                {
                    lengthX = (xGeo2 - xGeo1) * 111 * 1000;
                }
                if (yGeo1 > yGeo2)
                {
                    lengthY = (yGeo1 - yGeo2) * 111 * 1000;
                }
                else
                {
                    lengthY = (yGeo2 - yGeo1) * 111 * 1000;
                }

                Algoritm algoritm = new Algoritm(Convert.ToSingle(lengthX), Convert.ToSingle(lengthY), Convert.ToSingle(height), Convert.ToByte(fov), new byte[] { 16, 9 });
                float[,] route = algoritm.RouteCreate();

                for (int y = 0; y < route.Length / 2; y++)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        if (y == (route.Length / 2) - 1)
                        {
                            if (x == 1)
                            {
                                mess += ((route[y, x] / 1000 / 111) + ") )");
                                break;
                            }
                            mess += ("(" + (route[y, x] / 1000 / 111) + ", ");
                        }
                        else
                        {
                            if (x == 1)
                            {
                                mess += ((route[y, x] / 1000 / 111) + "), ");
                                break;
                            }
                            mess += ("(" + (route[y, x] / 1000 / 111) + ", ");
                        }
                    }
                }

                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                button4.Visible = false;
                button5.Visible = true;
                label9.Visible = true;
            }
            else
            {
                label3.Visible = true;
            }

        }
        private bool isDoubleS(string i)
        {
            try
            {
                Convert.ToDouble(i);
                return true;
            }
            catch
            {
                return false;
            }
        }


        private bool isByte(byte i)
        {
            try 
            {
                Convert.ToByte(i);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            string folderName;
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
            }
            using (FileStream fs = File.Create(folderBrowserDialog1.SelectedPath + "/Text.txt"))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(mess);

                fs.Write(array, 0, array.Length);
            }
            MessageBox.Show("Маршрут успешно сохранен!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}