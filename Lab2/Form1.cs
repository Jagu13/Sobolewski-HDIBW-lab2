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
using static System.Net.WebRequestMethods;

namespace Lab2
{
    public partial class Form1 : Form
    {
        int counter = 0;
        string fileName;


        public Form1()
        {
            InitializeComponent();
            label1.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        void OdczytajPlik()
        {

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
                        if (line.Contains(",") && !line.StartsWith("type"))
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
                    counter = 0;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

        }

        void OdczytajKatalog(string[] listaPlikow)
        {
            try
            {
                for (int i = 0; i < listaPlikow.Length; i++)
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
                            if (line.Contains(",") && !line.StartsWith("type"))
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
                        counter = 0;
                    }

                }
                 
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        //przycisk CZYTAJ PLIK
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            OdczytajPlik();
        }

        //przycisk PLIK
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\Users\Jagoda\Desktop\Jagodka\Sobolewski";
            openFileDialog1.ShowDialog();

            fileName = openFileDialog1.FileName;
            textBox2.Text = fileName;
        }


        // przycisk KATALOG
        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = @"C:\Users\Jagoda\Desktop";
            folderBrowserDialog.ShowDialog();

            fileName = folderBrowserDialog.SelectedPath;
            textBox3.Text = fileName;

        }


        // przycisk CZYTAJ KATALOG
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();

            int fCount = Directory.GetFiles(textBox3.Text, "*.txt", SearchOption.AllDirectories).Length;
            Console.WriteLine(fCount);
            string[] files = Directory.GetFiles(textBox3.Text, "*.txt", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i]);
            }
            OdczytajKatalog(files);
        }

        void WyszukajPliki(ref string sciezka)
        {
            
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}