using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectionSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //the selection sort method accepts an int array as an argument 
        //it uses the selection sort algorithm to sort the array 
        private void SelectionSort(int[] iArray)
        {
            int minIndex;       //subscript of smallest value in scanned area 
            int minValue;       //Smallest value in the scanned area 

            //the outer loop steps through all of the array elements 
            //except the last one. The startScan variable marks the \
            //position where the scan should begin.
            for (int startScan = 0; startScan < iArray.Length - 1; startScan++)
            {
                //assume the first element in the scannable area 
                //is the smallest value
                minIndex = startScan;
                minValue = iArray[startScan];

                //scan the array starting at the second element in the
                //scannable area, looking for the smallest value 
                for (int index = startScan + 1; index < iArray.Length; index++)
                {
                    if (iArray[index] < minValue)
                    {
                        minValue = iArray[index];
                        minIndex = index;
                    }
                }

                //swap the value with the smallest value with the
                //first element in the scannable area 
                Swap(ref iArray[minIndex], ref iArray[startScan]);
            }
        }

        //the swap method accepts two integer arguments, by reference ,
        // and swaps their contents 
        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            //create an array of random integers 
            const int SIZE = 6;
            int[] numbers = new int[SIZE];
            Random rand = new Random();

            //put the random numbers in the array 
            //from 0 - 10
            for (int index = 0; index < numbers.Length; index++)
            {
                numbers[index] = rand.Next(10);
            }

            //display the array in the original list box
            foreach(int value in numbers)
            {
                originalListBox.Items.Add(value);
            }

            //sort the array 
            SelectionSort(numbers);

            //display the array in sorted order 
            foreach(int value in  numbers)
            {
                sortedListBox.Items.Add(value);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close this form
            this.Close();
        }
    }
}
