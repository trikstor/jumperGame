using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using WindowsFormsApplication1;
using WindowsFormsApplication1.Properties;

namespace GlukGame
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = new Pen(Color.DarkSlateGray, 3);
            e.Graphics.DrawRectangle(p, 5, 5, 300, 65);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer Audio;
            //Audio = new System.Media.SoundPlayer(Resources.flush);
            //Audio.Load(); Audio.PlayLooping();

            Data.Box1.Width = 65;
            Data.Box1.Height = 65;

            var rectangle = new Rectangle
            (5, //Положение по горизонтали
                5, //Положение по вертикали
                65, //Ширина
                65);

            panel1.Controls.Add(Data.Box1);
            Data.Box1.Location = new Point(100, 8);

            Data.Box2.Width = 30;
            Data.Box2.Height = 50;

            var rectangle1 = new Rectangle
            (5, //Положение по горизонтали
                5, //Положение по вертикали
                65, //Ширина
                65);

            panel1.Controls.Add(Data.Box2);
            Data.Box2.Location = new Point(8, 15);

            var bw = new BackgroundWorker();
            bw.DoWork += HeroAction.bw_DoWork;
            bw.RunWorkerAsync(); //собственно запускаем фоновый поток

            HeroAction.DrawHero();

            Scene.DoWorkScene();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B)
            {
                Data.CurrAction = Data.HeroAct.Attack;
                HeroAction.DrawHero();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.CurrAction = Data.HeroAct.Attack;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.CurrAction = Data.HeroAct.Jump;

            CommandsCore NC = new CommandsCore();
            NC.FixTime();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Tab = new Form2();
            Tab.Show();
        }
    }
}
