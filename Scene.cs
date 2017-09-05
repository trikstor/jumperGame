using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;
using GlukGame;

namespace WindowsFormsApplication1
{
    public static class Scene
    {
        private static int _step = 500;
        public enum actionNow
        {
            None,
            Jump,
            Attack
        }

        public static void DoWorkScene()
        {
            Timer tmrShow = new Timer { Interval = 100 };
            tmrShow.Tick += MoveObj;
            tmrShow.Enabled = true;
        }

        private static void MoveObj(object sender, EventArgs e)
        {
            _step -= 10;

            if (_step == 100)
            {
                CommandsCore NC = new CommandsCore();
                bool inTime = NC.CompareTimes();

                if (!inTime)
                    Events.EventGameOver();
            }

            if (_step >= 8)
                ChangePosition(_step, 15, false);
            else
            {
                _step = 500;
                NewLandObj();
            }
        }

        public static void NewLandObj()
        {
            var landObjects = new List<Bitmap> { Resources.cactus };
            var len = landObjects.Count;

            Random rand = new Random();
            var tempRand = rand.Next(0, len - 1);

            HeroAction.PrintImage(landObjects[tempRand], false);
        }

        private static List<int> Parabola()
        {
            var x = -7;
            List<int> y = new List<int>();

            while (x <= 7)
            {
                y.Add((int)Math.Pow(x * 0.5, 2));
                x++;
            }

            y.Add(8);
            return y;
        }

        public static void JumpAnimation()
        {
            List<int> y = Parabola();
            int i = 0;

            Timer tmrShow = new Timer { Interval = 5 };
            tmrShow.Enabled = true;
            tmrShow.Tick += delegate
            {
                ChangePosition(100, y[i], true);
                i++;

                if (i >= y.Count)
                    tmrShow.Enabled = false;
            };
        }

        public static void ChangePosition(int X, int Y, bool typeOfElem)
        {
            if (typeOfElem)
                Data.Box1.Location = new Point(X, Y);
            else
                Data.Box2.Location = new Point(X, Y);
        }
    }
}
