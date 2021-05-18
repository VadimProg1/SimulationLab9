using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation9Lab
{
    public partial class Form1 : Form
    {
        private decimal prob5 = 0;
        private BasicSensor rnd = new BasicSensor();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsProbsOk())
            {
                label_validation.Text = "";
                chart1.Series[0].Points.Clear();
                int[] statistics = new int[5] { 0, 0, 0, 0, 0 };
                decimal[] probs = new decimal[5] { 
                    numericUpDown_prob1.Value,
                    numericUpDown_prob2.Value,
                    numericUpDown_prob3.Value,
                    numericUpDown_prob4.Value,
                    prob5 };

                for (int i = 0; i < numericUpDown_experiments.Value; i++)
                {
                    double randNum = rnd.GetRandomNumber();
                    double a = 0;
                    for (int j = 0; j < probs.Length; j++)
                    {
                        a += Convert.ToDouble(probs[j]);
                        if(a > randNum)
                        {
                            statistics[j]++;
                            break;
                        }
                    }
                }
                for(int i = 0; i < statistics.Length; i++)
                {
                    chart1.Series[0].Points.AddXY(i + 1, statistics[i] / numericUpDown_experiments.Value);
                }
            }
            else
            {
                label_validation.Text = "You entered incorrect probs";
            }
        }
        
        private bool IsProbsOk()
        {
            decimal p = numericUpDown_prob1.Value + numericUpDown_prob2.Value
                + numericUpDown_prob3.Value + numericUpDown_prob4.Value;
            if(p < 1)
            {
                prob5 = 1 - p;
                return true;
            }
            return false;
        }
    }
}
