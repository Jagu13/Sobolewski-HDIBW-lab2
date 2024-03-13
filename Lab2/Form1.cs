using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
            label1.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdczytajPlik();
        }

        void OdczytajPlik()
        {
            string fileName = @"C:\Users\Jagoda\Desktop\Jagodka\Sobolewski\db\ZALog2003.10.01.txt";
            try
            {
                // Create a StreamReader
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    // Read line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        listBox1.Items.Add(line);
                        if (line.Contains(",") && !(line.Contains("date")))
                        {
                            int countPrzecinki = line.Count(f => f == ',');
                            if (countPrzecinki == 5) 
                            {
                                OdczytajElement(ref line);
                                counter++;
                            }
                        }
                    }
                    label1.Text = "ilość linii: " + counter;
                    label1.Refresh();
                    Console.WriteLine(counter);
                }
            }
            catch (Exception exp)
            {
                //Console.WriteLine(exp.Message);
            }

        }

        void OdczytajElement(ref string line)
        {
            string[] splitData = line.Split(',');
            String typ = splitData[0];
            String data = splitData[1];
            String czas = splitData[2];
            String adresWe = splitData[3];
            String adresWy = splitData[4];
            String protokol = splitData[5];

            listBox2.Items.Add(typ);
            listBox3.Items.Add(data);
            listBox4.Items.Add(czas);
            listBox5.Items.Add(adresWe);
            listBox6.Items.Add(adresWy);
            listBox7.Items.Add(protokol);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}