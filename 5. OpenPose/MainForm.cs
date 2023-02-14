using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace WebCameraKinematics2
{
    public partial class MainForm : Form
    {
        private static MainForm mainForm;
        private static KinematicsControl kc = new KinematicsControl();

        public MainForm()
        {
            mainForm = this;
            InitializeComponent();
            Init_MenuStrip();
            EnableCalculate(true);

            kc.f = mainForm;
        }


        // Init
        private void Init_MenuStrip()
        {
            ToolStripMenuItem MnuStripFile = new ToolStripMenuItem("File", null);
            menuStrip.Items.Add(MnuStripFile);

            ToolStripMenuItem MnuStripFile_Location = new ToolStripMenuItem("Location", null, Location_Click);
            MnuStripFile.DropDownItems.Add(MnuStripFile_Location);
        }


        // History
        public void event_logBox(string str, bool line = true)
        {
            string nowTime = DateTime.Now.ToString("HH:mm:ss >>> ");
            string text1 = "\r\n" + nowTime + str;
            string text2 = "\r\n---------------------------------------------------------------------------------------------------------------------";
            if (logBox.InvokeRequired)
            {
                this.logBox.Invoke(new Action(() => this.logBox.AppendText(text1)));
                if (line) this.logBox.Invoke(new Action(() => this.logBox.AppendText(text2)));
            }
            else
            {
                this.logBox.AppendText(text1);
                if (line) this.logBox.AppendText(text2);
            }
        }


        // Label
        public void LabelsForProcess(bool load, bool calculate, bool save)
        {
            if (load)
            {
                if (label_Load.InvokeRequired) label_Load.Invoke(new Action(() => label_Load.BackColor = Color.Aqua));
                else label_Load.BackColor = Color.Aqua;
            }
            if (!load)
            {
                if (label_Load.InvokeRequired) label_Load.Invoke(new Action(() => label_Load.BackColor = Color.Silver));
                else label_Load.BackColor = Color.Silver;
            }
            if (calculate)
            {
                if (label_Calculate.InvokeRequired) label_Calculate.Invoke(new Action(() => label_Calculate.BackColor = Color.Aqua));
                else label_Calculate.BackColor = Color.Aqua;
            }
            if (!calculate)
            {
                if (label_Calculate.InvokeRequired) label_Calculate.Invoke(new Action(() => label_Calculate.BackColor = Color.Silver));
                else label_Calculate.BackColor = Color.Silver;
            }
            if (save)
            {
                if (label_Save.InvokeRequired) label_Save.Invoke(new Action(() => label_Save.BackColor = Color.Aqua));
                else label_Save.BackColor = Color.Aqua;
            }
            if (!save)
            {
                if (label_Save.InvokeRequired) label_Save.Invoke(new Action(() => label_Save.BackColor = Color.Silver));
                else label_Save.BackColor = Color.Silver;
            }
        }
        public void LabelLocation(string folderPath)
        {
            if (label_LocationW.InvokeRequired) label_LocationW.Invoke(new Action(() => label_LocationW.Text = folderPath));
            else label_LocationW.Text = folderPath;
        }
        public void LabelTotalFiles(int numFile)
        {
            if (label_TotalFilesV.InvokeRequired) label_TotalFilesV.Invoke(new Action(() => label_TotalFilesV.Text = numFile.ToString()));
            else label_TotalFilesV.Text = numFile.ToString();
        }
        public void LabelCurFile(int numFile)
        {
            if (label_CurrentFileV.InvokeRequired) label_CurrentFileV.Invoke(new Action(() => label_CurrentFileV.Text = numFile.ToString()));
            else label_CurrentFileV.Text = numFile.ToString();
        }
        public void LabelTotalFrames(int numFrame)
        {
            if (label_TotalFramesV.InvokeRequired) label_TotalFramesV.Invoke(new Action(() => label_TotalFramesV.Text = numFrame.ToString()));
            else label_TotalFramesV.Text = numFrame.ToString();
        }
        public void LabelCurFrame(int numFrame)
        {
            if (label_CurrentFrameV.InvokeRequired) label_CurrentFrameV.Invoke(new Action(() => label_CurrentFrameV.Text = numFrame.ToString()));
            else label_CurrentFrameV.Text = numFrame.ToString();
        }
        public void LabelFPS(int numFrame)
        {
            if (label_FPSV.InvokeRequired) label_FPSV.Invoke(new Action(() => label_FPSV.Text = numFrame.ToString()));
            else label_FPSV.Text = numFrame.ToString();
        }


        // PictureBox
        public void PictureImage(Bitmap image)
        {
            if (video.InvokeRequired) video.Invoke(new Action(() => video.Image = image));
            else video.Image = image;
        }


        // Button events
        private void Calculate_Click(object sender, EventArgs e)
        {
            var thread = new Thread(kc.Process);
            thread.Start();
        }


        // Button on/off
        public void EnableCalculate(bool s) { if (calculate.InvokeRequired) calculate.Invoke(new Action(() => calculate.Enabled = s)); else calculate.Enabled = s; }


        // MenuStrip events
        private void Location_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string aviPath = folderBrowserDialog.SelectedPath + "\\";
                LabelLocation(aviPath);
                kc.SetFilesInDir(aviPath, "*.avi");
            }
        }
    }
}
