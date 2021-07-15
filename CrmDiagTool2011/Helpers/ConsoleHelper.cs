using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CrmDiagTool2011.Helpers
{
    /// <summary>
    /// This class is used to retrieve output of a console command execution
    /// </summary>
    class ConsoleHelper
    {
        /// <summary>
        /// Retrieve output of a console command execution
        /// </summary>
        /// <param name="exePath">Application to execute</param>
        /// <param name="args">Command arguments</param>
        /// <returns>Console output</returns>
        public static string GetConsoleOutPut(string exePath, string args)
        {
            string line, output = String.Empty;

            ProcessStartInfo processStartInfo = new ProcessStartInfo()
                {
                    FileName = exePath,
                    Arguments = args,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    StandardOutputEncoding = Encoding.Default
                };

            try
            {
                using (Process process = Process.Start(processStartInfo))
                {
                    using (StreamReader myStreamReader = process.StandardOutput)
                    {
                        while ((line = myStreamReader.ReadLine()) != null)
                        {
                            output += line.Trim() + "\r\n";
                        }
                    }
                }

                return output;
            }
            catch (Exception e)
            {
                return String.Format("Unable to retrieve information from [{0}] application. Error:{1}", exePath, e.Message);
            }
        }
    }
}
