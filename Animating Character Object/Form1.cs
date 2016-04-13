

//Name :Jess Nguyen
//Date Started : April 4, 2016
//Date Finished : April 8, 2016 
//Summary : A Game engine that uses classes, object animation and multi screens.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animating_Character_Object
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Form f = this.FindForm();
            f.Controls.Remove(this);

            MainScreen ms = new MainScreen();
            f.Controls.Add(ms);
        }
    }
}
