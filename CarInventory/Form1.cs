using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CarInventory
{
    public partial class Form1 : Form
    {
        List<Car> inventory = new List<Car>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string year, make, colour, mileage;

            year = yearInput.Text;
            make = makeInput.Text;
            colour = colourInput.Text;
            mileage = mileageInput.Text;

            Car c = new Car(year, make, colour, mileage);
            inventory.Add(c);

            outputLabel.Text = yearInput.Text = makeInput.Text = colourInput.Text = mileageInput.Text = "";
            yearInput.Focus();
            displayItems();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {

            #region remove with for loop

            //for (int i = 0; i < inventory.Count; i++)
            //{
            //    if (inventory[i].make == makeInput.Text)
            //    {
            //        inventory.RemoveAt(i);
            //        break;
            //    }
            //}

            #endregion


            #region remove by finding index of car with lambda expression

            //int index = inventory.FindIndex(car => car.make == makeInput.Text);

            //if (index > -1)
            //{
            //    inventory.RemoveAt(index);
            //}
            //else
            //{
            //    outputLabel.Text = "car not found in database";
            //    return;
            //}

            #endregion

            #region remove by finding object with lambda expression
            //

            Car c = inventory.Find(car => car.make == makeInput.Text);
            
            if (c != null)
            {
                inventory.Remove(c);
            }
            else
            {
                outputLabel.Text = "car does not exist in db";
                return;             
            }

            //
            #endregion

            #region remove all instances of a make using lambda expression

            //inventory.RemoveAll(car => car.make == makeInput.Text);
           
            #endregion

            displayItems();
        }

        public void displayItems()
        {
            outputLabel.Text = "";
            
            foreach (Car c in inventory)
            {
                outputLabel.Text += c.year + " "
                     + c.make + " "
                     + c.colour + " "
                     + c.mileage + "\n";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            //- using lamda expressions to sort an object list based on a property
            //- result goes back into the same list
            inventory = inventory.OrderBy(x => x.make).ToList();

            // same as above but now can sort by two properties
            //inventory = inventory.OrderBy(a => a.make).ThenBy(a => a.year).ToList();

            // same as above but second property is in descending order
            //inventory = inventory.OrderBy(a => a.make).ThenByDescending(a => a.year).ToList();

            displayItems();
        }
    }
}