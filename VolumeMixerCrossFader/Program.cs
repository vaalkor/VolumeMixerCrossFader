using System;
using System.Windows.Forms;

namespace CrossMixer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VolumeMixerCrossFader());
        }
    }
}
