using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public static class Data
    {
        public enum HeroAct
        {
            Walk,
            Attack,
            Jump
        }

        public static PictureBox Box1 { get; set; }
        public static PictureBox Box2 { get; set; }

        public static HeroAct CurrAction { get; set; }

        static Data()
        {
            Box1 = new PictureBox();
            Box2 = new PictureBox();

            CurrAction = HeroAct.Walk;
        }
    }


    public class HeroAction
    {
        private static int I = 0;

        public static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (;;)
            {
                if (Data.CurrAction != Data.HeroAct.Walk)
                {
                    Data.CurrAction = Data.HeroAct.Walk;
                }
                System.Threading.Thread.Sleep(700);
            }
        }

        public static void DrawHero()
        {
            Timer tmrShow = new Timer {Interval = 100};
            tmrShow.Tick += PrintHero;
            tmrShow.Enabled = true;
        }

        private static void PrintHero(object sender, EventArgs e)
        {
            var heroAn = new List<Bitmap> { Resources.hero1, Resources.hero2, Resources.hero3};
            var heroJp = new List<Bitmap> { Resources.hero_Jump1, Resources.hero_Jump2, Resources.hero_Jump3 };
            switch (Data.CurrAction)
            {
                case Data.HeroAct.Walk:
                    if (I > 2)
                        I = 0;

                    PrintImage(heroAn[I], true);
                    I++;
                    break;
                case Data.HeroAct.Attack:
                    PrintImage(Resources.hero_attack, true);
                    break;
                case Data.HeroAct.Jump:
                    if (I > 2)
                        I = 0;
                    PrintImage(heroJp[I], true);
                    I++;

                    Scene.JumpAnimation();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void PrintImage(Bitmap img, bool typeOfBox)
        {
            if (typeOfBox)
                Data.Box1.Image = img;
            else
            {
                Data.Box2.Image = img;
            }
        }
    }
}
