using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var scoreEx = new Score();
            var scoreRange = scoreEx.PrintScores(Score.sortType.byScore);

            foreach (var scoreElem in scoreRange)
            {
                if(scoreElem != null)
                    listBox1.Items.Add(scoreElem);
            }
        }
    }
}