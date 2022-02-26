using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

using fuzzyLogicFindPotential;


namespace FuzzyLogicApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            findPotential potential = new findPotential();
            MWArray result = potential.FindPotential((MWArray)15, (MWArray)15, (MWArray)50, (MWArray)15, (MWArray)180);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //calculate 
            textBox1.Text = textBox1.Text.Replace(".", ",");
            textBox2.Text = textBox2.Text.Replace(".", ",");
            textBox3.Text = textBox3.Text.Replace(".", ",");
            textBox4.Text = textBox4.Text.Replace(".", ",");
            textBox5.Text = textBox5.Text.Replace(".", ",");

            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                label9.Text = "Insert all data";
                label9.ForeColor = System.Drawing.Color.White;
                return;
            }

            label9.Text = "";

            double test1 = double.Parse(textBox1.Text);
            double test2 = double.Parse(textBox2.Text);
            double test3 = double.Parse(textBox3.Text);
            double test4 = double.Parse(textBox4.Text);
            double test5 = double.Parse(textBox5.Text);

            findPotential potential = new findPotential();
            MWArray result =  potential.FindPotential((MWArray)test1, (MWArray)test2, (MWArray)test3, (MWArray)test4, (MWArray)test5);
            double[,] arr = (double[,])((MWNumericArray)result).ToArray(MWArrayComponent.Real);


            string result_s = result.ToString();
            string potential_result = "";

            Color color = Color.White;

            if (arr[0,0] > 0 && arr[0, 0] <= 1.5)
            {
                potential_result = "NISKI";
                color = Color.Red;
            }

            if (arr[0, 0] > 1.5 && arr[0, 0] < 2.5)
            {
                potential_result = "PRZECIĘTNY";
                color = Color.Yellow;
            }

            if (arr[0, 0] >= 2.5)
            {
                potential_result = "WYSOKI";
                color = Color.LimeGreen;
            }

            
            label9.Text = potential_result + "(" + result_s + ")";
            label9.ForeColor = color; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //open file
            string line = "";
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
           // theDialog.Filter = "XLSX files|*.xlsx";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                //try
                //{
                    StreamReader sr = new StreamReader(theDialog.FileName);
                        while(line !=null)
                    {
                        line = sr.ReadLine();
                        if(line != null)
                        {
                            string[] data = line.Split();

                            string firstName = data[0];
                            string lastName = data[1];
                            for(int i = 2; i < 7; i++){
                                data[i] = data[i].Replace(".", ",");
                            }

                            double test1 = double.Parse(data[2]);
                            double test2 = double.Parse(data[3]);
                            double test3 = double.Parse(data[4]);
                            double test4 = double.Parse(data[5]);
                            double test5 = double.Parse(data[6]);

                            findPotential potential = new findPotential();
                            MWArray result = potential.FindPotential((MWArray)test1, (MWArray)test2, (MWArray)test3, (MWArray)test4, (MWArray)test5);
                            string result_s = result.ToString();

                            double[,] arr = (double[,])((MWNumericArray)result).ToArray(MWArrayComponent.Real);
                       
                            string potential_result = "";

                            

                            if (arr[0, 0] > 0 && arr[0, 0] <= 1.5)
                            {
                                potential_result = "NISKI";
                            }

                            if (arr[0, 0] > 1.5 && arr[0, 0] < 2.5)
                            {
                                potential_result = "PRZECIĘTNY"; 
                            }

                            if (arr[0, 0] > 2.5)
                            {
                                potential_result = "WYSOKI";
                            }


                            string strToSave = firstName + " " + lastName + " " + result + " " + potential_result;

                            using (StreamWriter writer = new StreamWriter("potential.txt", true)) //// true to append data to the file
                            {
                                writer.WriteLine(strToSave);
                            }
                        
                        }
                    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                //}
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            // tu będzie wynik
            
            ForeColor = System.Drawing.Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
