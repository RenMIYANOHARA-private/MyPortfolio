using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

using OpenCvSharp;
using OpenCvSharp.Extensions;       // for translating to BitMapusing System;
using Newtonsoft.Json.Linq;


namespace WebCameraKinematics2
{
    // How to get paths of all files in directory
    // https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=netframework-4.8

    // How to read video file
    // https://qiita.com/visyeii/items/b36172011e2394c27e26

    // How to write mat image file to png
    // https://qiita.com/satorimon/items/72d89b6dbc60e34bc195

    // How to make video file from image
    // https://github.com/shimat/opencvsharp/issues/507
    // https://csharp.hotexamples.com/examples/Emgu.CV/VideoWriter/-/php-videowriter-class-examples.html
    // http://sourcechord.hatenablog.com/entry/2016/08/15/235654

    // YML
    // YML lib URL https://www.nuget.org/packages/YamlDotNet/
    // How to use in C# program https://dotnetfiddle.net/rrR2Bb
    // How to load yml file https://stackoverflow.com/questions/46896848/read-a-yaml-file-into-c

    // Json ####### Json is better than YML to read  the file in C#
    // The reason is here https://stackoverflow.com/questions/46896848/read-a-yaml-file-into-c

    // How to output Json file in bat file from openposedemo.exe
    // https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/demo_overview.md

    // Json
    // How to install and import into the project https://dotnetfiddle.net/d02Shh
    // How to load json file (step 1) https://social.msdn.microsoft.com/Forums/en-US/525ff8f2-13f5-4602-bce3-78b909cadedb/how-to-read-and-write-a-json-file-in-c?forum=csharpgeneral
    // How to load json file (step 2) https://stackoverflow.com/questions/16459155/how-to-access-json-object-in-c-sharp

    // Openpose
    // Command option https://qiita.com/wada-n/items/e9e6653effc1e3d0c566
    // The shape of output values https://github.com/CMU-Perceptual-Computing-Lab/openpose/blob/master/doc/output.md
    // The shape of output values https://qiita.com/kilometer/items/060c32f2f3d5b6a59e66


    class KinematicsControl
    {
        public MainForm f{ get; set; }
        public Process proc = new Process();

        private string processor = "gpu";

        private string aviForderPath = null;
        private string[] aviFilePaths = null;
        private string imageNormalPath = null;
        private string imageKinemaPath = null;
        private string valueKinemaPath = null;
        private string resultPath = null;

        private string currentAviPath = null;
        private int currentFrame = 0;
        private int totalFrames = 0;

        private bool switchWait = false;

        private string openposeBat = "openpose.bat";


        // Button event
        public void Process()
        {
            if (aviFilePaths != null && aviFilePaths.Length > 0)
            {
                f.EnableCalculate(false);

                // Set the information for directories
                resultPath = aviForderPath + "\\result\\";
                imageNormalPath = "..\\..\\lib\\" + processor + "\\image_kinema\\";
                imageKinemaPath = "..\\..\\lib\\" + processor + "\\image_normal\\";
                valueKinemaPath = "..\\..\\lib\\" + processor + "\\value_kinema\\";
                SetPath(aviForderPath + "\\result\\");


                // Main Calculation
                int numFile = 1;
                foreach (string aviFilePath in aviFilePaths)
                {
                    f.LabelCurFile(numFile); ++numFile;
                    currentAviPath = aviFilePath;
                    f.event_logBox(currentAviPath, false);
                    SetPath(imageNormalPath);
                    SetPath(imageKinemaPath);
                    SetPath(valueKinemaPath);

                    // Output frames from original video file
                    switchWait = true;
                    var thread1_1 = new Thread(PlayAviPath);
                    thread1_1.Start();
                    var thread1_2 = new Thread(CheckCondition);
                    thread1_2.Start();

                    // Waiting until finishing thread1 
                    while (true && switchWait) { Thread.Sleep(1000); }

                    // Start to analize kinematics data
                    switchWait = true;
                    var thread2 = new Thread(MakeData);
                    thread2.Start();

                    // Waiting until finishing thread2 
                    while (true && switchWait) { Thread.Sleep(1000); }
                }
                Thread.Sleep(1000);
                RemovePath(imageNormalPath);
                RemovePath(imageKinemaPath);
                RemovePath(valueKinemaPath);

                f.event_logBox("Finished all process. ");
                f.LabelsForProcess(false, false, false);
                f.EnableCalculate(true);
            }

            else f.event_logBox("There is no avi files. ");
        }


        // Sub process function
        private void SetPath(string path)
        {
            if (Directory.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path);
                foreach (string filePath in filePaths) File.Delete(filePath);
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
        private void RemovePath(string path)
        {
            if (Directory.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path);
                foreach (string filePath in filePaths) File.Delete(filePath);
                Directory.Delete(path);
            }
        }
        private void PlayAviPath()
        {
            VideoCapture vcap = new VideoCapture(currentAviPath);

            f.LabelsForProcess(true, false, false);
            currentFrame = 0;
            while (vcap.IsOpened())
            {
                Mat mat = new Mat();

                if (vcap.Read(mat))
                {
                    if (mat.IsContinuous())
                    {
                        ++currentFrame;
                        f.PictureImage(BitmapConverter.ToBitmap(mat));
                        f.LabelTotalFrames(currentFrame);
                        mat.ImWrite(imageNormalPath + currentFrame.ToString() + ".png");
                    }
                    else break;
                }
                else break;
                mat.Dispose(); //Memory release
            }

            totalFrames = currentFrame;

            f.LabelsForProcess(false, true, false);
            StartOpenPose();
            CheckKinemaVideo();
            switchWait = false;
        }
        private void CheckCondition()
        {
            int fromF = 0;
            while (true && switchWait)
            {
                Thread.Sleep(1000);
                int toF = Directory.GetFiles(imageKinemaPath).Length;
                if (toF < fromF) fromF = 0;
                f.LabelCurFrame(toF);
                f.LabelFPS(toF - fromF);
                fromF = toF;
            }
        }
        private void MakeData()
        {
            // You have to put FourCC.MJPG not FourCC.Default on this computer
            string fileName = Path.GetFileName(currentAviPath);
            string kinemaAviPath = resultPath + fileName.Replace(".avi", "_kinema.avi");
            VideoWriter vwri = new VideoWriter(kinemaAviPath, FourCC.MJPG, 30, new Size(320, 240), isColor: true);

            string kinemaCsvPath = resultPath + fileName.Replace(".avi", "_kinema.csv");
            List<string> data = new List<string>();
            data = AddKeyPointsHeader(data);

            f.LabelsForProcess(false, false, true);
            currentFrame = 1;
            while (true && currentFrame <= totalFrames)
            {
                // video
                Mat mat = new Mat(imageKinemaPath + currentFrame.ToString() + "_rendered.png");
                vwri.Write(mat);
                mat.Dispose();


                // data
                using (StreamReader r = new StreamReader(valueKinemaPath + currentFrame.ToString() + "_keypoints.json"))
                {
                    var json = r.ReadToEnd();
                    var jobj = JObject.Parse(json);
                    string id = jobj["people"][0]["pose_keypoints_2d"].ToString();
                    id = id.Replace("\r", String.Empty);
                    id = id.Replace("\n", String.Empty);
                    id = id.Replace("]", String.Empty);
                    id = id.Replace("[", String.Empty);
                    data.Add(id);
                }

                ++currentFrame;
            }
            File.WriteAllLines(kinemaCsvPath, data);

            switchWait = false;
        }


        // Sub sub process function
        private void CheckKinemaVideo()
        {
            currentFrame = 1;
            while (true && currentFrame <= totalFrames)
            {
                Thread.Sleep(10);
                bool switchContinue = true;
                while (true && switchContinue)
                {
                    try
                    {
                        Mat mat = new Mat(imageKinemaPath + currentFrame.ToString() + "_rendered.png");
                        f.PictureImage(BitmapConverter.ToBitmap(mat));
                        ++currentFrame;
                    }
                    catch
                    {
                        switchContinue = false;
                    }
                    Thread.Sleep(10);
                }
            }

        }
        private void StartOpenPose()
        {
            CreateOpenPoseBat();

            try
            {
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.WorkingDirectory = string.Format("..\\..\\lib\\{0}\\", processor);
                proc.StartInfo.FileName = openposeBat;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
            }
            catch (Exception ex)
            {
                f.event_logBox(ex.StackTrace.ToString(), false);
            }
        }
        private void CreateOpenPoseBat()
        {
            StreamWriter w = new StreamWriter(string.Format("..\\..\\lib\\{0}\\", processor) + openposeBat);
            w.Write(".\\bin\\OpenPoseDemo.exe ");
            w.Write(string.Format("--display 0 "));
            w.Write(string.Format("--image_dir {0}\\ ", imageNormalPath));
            w.Write(string.Format("--write_images {0}\\ ", imageKinemaPath));
            w.Write(string.Format("--write_json {0}\\ ", valueKinemaPath));
            w.Write("--number_people_max 1");
            w.Close();
        }
        private List<string> AddKeyPointsHeader(List<string> data)
        {
            string header = null;
            string[] keyPoints = new string[] { "Nose", "Neck", "RShoulder", "RElbow", "RWrist", 
                                                "LShoulder", "LElbow", "LWrist", "MidHip", "RHip", 
                                                "RKnee", "RAnkle", "LHip", "LKnee","LAnkle", 
                                                "REye", "LEye", "REar", "LEar", "LBigToe", 
                                                "LSmallToe", "LHeel", "RBigToe", "RSmallToe", "RHeel"};

            for (int i = 0; i < keyPoints.Length; i++) header = header + string.Format("{0}_X, {0}_Y, {0}_C, ", keyPoints[i]);
            header = header + string.Format("{0}_X, {0}_Y, {0}_C, ", keyPoints.Length - 1);
            data.Clear();
            data.Add(header);
            return data;
        }
        public void SetFilesInDir(string path, string extension)
        {
            aviForderPath = path;
            aviFilePaths = Directory.GetFiles(path, extension);
            f.LabelTotalFiles(aviFilePaths.Length);
            foreach (string filePath in aviFilePaths) f.event_logBox(Path.GetFileName(filePath), false);
            f.event_logBox(path);
        }
    }
}
