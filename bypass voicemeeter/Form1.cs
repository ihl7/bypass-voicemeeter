using System;
using System.ComponentModel;
using System.Windows.Forms;
using Memory;
using System.Threading;
namespace bypass_voicemeeter
{
    public partial class Form1 : Form
    {
        Mem meme = new Mem();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            Width = 0;
            Height = 0;

            backgroundWorker1.RunWorkerAsync();

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    int PID = meme.GetProcIdFromName("voicemeeter8x64.exe");
                    if (PID > 0)
                    {
                        meme.OpenProcess(PID);
                        meme.WriteMemory("base+0x135708", "int", "0");
                    }
                    Thread.Sleep(5);
                }
                catch
                {

                }

            }
        }


    }
}
