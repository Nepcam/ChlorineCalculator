using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChlorineCalculator
{
    public partial class FormChlorineCalculator : Form
    {
        public FormChlorineCalculator()
        {
            InitializeComponent();
        }
        //const = READ ONLY Variables
        //Amount of chlorine per cubic metre of water
        const double CHLORINE_RATE = 0.1;
        //Amount of chlorine in one bag in kg's
        const int BAG_WEIGHT = 2;
        //Cost of a bag of chlorine
        const decimal BAG_COST = 5.5m;

        private void buttonCalculateChlorineCost_Click(object sender, EventArgs e)
        {
            try
            {
                //GET the width of the swimming pool
                double poolWidth = 0;
                poolWidth = double.Parse(textBoxWidth.Text);

                //GET the length of the swimming pool
                double poolLength = 0;
                poolLength = double.Parse(textBoxLength.Text);

                //GET the depth of the swimming pool
                double poolDepth = 0;
                poolDepth = double.Parse(textBoxDepth.Text);


                //CALCULATE the volume of water in the swimming pool ( = length * width * depth)
                double waterVolume = 0;
                waterVolume = poolLength * poolWidth * poolDepth;
                //Console.WriteLine(waterVolume);

                //CALCULATE the amount of chlorine required ( = water volume * chlorine required per cubic metre
                double chlorineRequired = 0;
                chlorineRequired = waterVolume * CHLORINE_RATE;
                //Console.WriteLine(chlorineRequired);

                //CALCULATE the bags of chlorine required, rounded up ( = chlorine amount / bag weight)
                int bagsOfChlorine = 0;
                bagsOfChlorine = (int)Math.Ceiling(chlorineRequired) / BAG_WEIGHT;
                Console.WriteLine(bagsOfChlorine);

                //CALCULATE the total cost of the chlorine ( = number of bags * bag cost)
                decimal totalCost = 0;
                totalCost = bagsOfChlorine * BAG_COST;
                //Console.WriteLine(totalCost);

                //DISPLAY the volume of water(to 3dp)
                textBoxVolumeTotal.Text = totalCost.ToString("N3");
                //DISPLAY the number of kg of chlorine required(to 3dp)
                textBoxKGS.Text = chlorineRequired.ToString("N3");
                //DISPLAY the number of bags of chlorine required
                textBoxBags.Text = bagsOfChlorine.ToString();
                //DISPLAY the cost of the bags formatted as currency
                textBoxTotalCosts.Text = totalCost.ToString("c");
            }
            catch
            {
                //Display error message
                MessageBox.Show("Error");
                //Clear all textboxes
                textBoxWidth.Clear();
                textBoxLength.Clear();
                textBoxDepth.Clear();
                //Set focus to the first input textbox
                textBoxWidth.Focus();
            }
        }//End of Calculate Chlorine button

        private void buttonClearAllFields_Click(object sender, EventArgs e)
        {
            //Clear all textboxes
            //Input text boxes
            textBoxWidth.Clear();
            textBoxLength.Clear();
            textBoxDepth.Clear();

            //Read only text boxes
            textBoxVolumeTotal.Clear();
            textBoxKGS.Clear();
            textBoxBags.Clear();
            textBoxTotalCosts.Clear();
        }

        private void buttonCloseApp_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
