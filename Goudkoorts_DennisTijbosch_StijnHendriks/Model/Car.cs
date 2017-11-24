using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Car
    {
        public bool isFull { get; set; }
        public char DisplayChar { get; set; }
        public Car()
        {
            isFull = true;
            DisplayChar = '0';
        }

        public void Empty()
        {
            DisplayChar = 'O';
        }
    }

