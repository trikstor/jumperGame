using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Actions
    {
    }
    public static class Events
    {
        public static void EventGameOver()
        {
            MessageBox.Show("Game Over");
            Score.AddScore(200);
        }
    }
}
