/*
 * Very basic wrapper for ADB commands
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BSPlaylistEditor.ADB
{
    public class ADBcontroller
    {
        private static string adbPath = "";

        //ADBcontoller object properties
        public string command { get; set; } //Command to send to ADB as a string
        public bool output { get; set; } = false; //Whether or not to return the output of the command
        
        //Checks if adb.exe exists, and will extract the bundled one if it doesn't
        public static void extractADB()
        {
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "resources");
            string outputFile = Path.Combine(outputFolder, "adb.exe");
            if (File.Exists(outputFile))
            {
                Trace.WriteLine("adb.exe found. Will use existing copy.");
                adbPath = outputFile;
                return;
            }
            Trace.WriteLine("adb.exe not found. Extracting included copy.");
            Assembly assembly = Assembly.GetExecutingAssembly();
            string adbResourcePath = assembly.GetManifestResourceNames().Where(x => x.EndsWith("adb.exe")).FirstOrDefault();
            Stream adbData = assembly.GetManifestResourceStream(adbResourcePath);
            try
            {
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);
                using (FileStream outputFileStream = new FileStream(outputFile, FileMode.Create))
                {
                    adbData.CopyTo(outputFileStream);
                }
                adbPath = outputFile;
                return;
            }
            catch(Exception e)
            {
                Trace.WriteLine(e);
            }
        }

        public string runCommand()
        {
            //Make sure adb.exe exists before running commands
            if(adbPath == "")
                extractADB();
            string output = "";
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo();
            process.StartInfo.FileName = adbPath;
            process.StartInfo.Arguments = this.command;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            if (this.output)
            {
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                process.Start();
                while (!process.StandardOutput.EndOfStream)
                {
                    output += "\n" + process.StandardOutput.ReadLine();
                }
                process.WaitForExit();
                return output;
            }
            else
            {
                process.StartInfo.RedirectStandardOutput = false;
                process.Start();
                process.WaitForExit();
                return null;
            }
        }
    }
}
