using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EyeXFramework;
using Tobii.EyeX.Framework;

namespace ImplicitTest
{
    public partial class Task0 : Form
    {
        public Task0()
        {
            InitializeComponent();

            Program.EyeXHost.Connect(behaviorMap1);
            behaviorMap1.Add(panel1, new GazeAwareBehavior(OnGaze));

            var lightlyFilteredGazeDataStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);
            lightlyFilteredGazeDataStream.Next += (s, e) => Console.WriteLine("Gaze point at ({0:0.0}, {1:0.0}) @{2:0}", e.X, e.Y, e.Timestamp);
        }

        private void OnGaze(object sender, GazeAwareEventArgs e)
        {
            var panel = sender as Panel;
            if (panel != null)
            {
                panel.BorderStyle = (e.HasGaze) ? BorderStyle.FixedSingle : BorderStyle.None;
            }
        }
    }
}
