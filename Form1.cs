using System.Diagnostics;

namespace iCUE_Watchdog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string processName = "iCUE"; // Replace with the name of your specific process

            // Check if the process is running
            if (Process.GetProcessesByName(processName).Length == 0)
            {
                notifyIcon1.BalloonTipText = "iCUE is not running... restarting it!";
                notifyIcon1.ShowBalloonTip(2500);

                // Start the process
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = @"C:\Program Files\Corsair\Corsair iCUE5 Software\iCUE Launcher.exe";
                    startInfo.Arguments = "--autorun";
                    startInfo.WorkingDirectory = @"C:\Program Files\Corsair\Corsair iCUE5 Software\";
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions if the process couldn't be started
                    MessageBox.Show($"Error starting the process: {ex.Message}");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}