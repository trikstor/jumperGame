using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    // Check the jump event at the right time
    class CommandsCore
    {
        private int? FixedTime { get; set; }

        private double NowTimeInUNIX()
        {
            return (DateTime.Now - new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }
        public void FixTime()
        {
            FixedTime = (int)NowTimeInUNIX();
            MessageBox.Show(FixedTime + " ");
        }

        public bool CompareTimes()
        {
            int currTime = (int)NowTimeInUNIX();
            if (currTime - 100 < FixedTime && FixedTime < currTime + 100)
                return true;
            return false;
        }
    }
}
