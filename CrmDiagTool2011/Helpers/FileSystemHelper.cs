using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace CrmDiagTool2011.Helpers
{
    /// <summary>
    /// This class is used to retrieve information about files and directories
    /// </summary>
    class FileSystemHelper
    {
        /// <summary>
        /// Returns a list of files in a specified folder
        /// </summary>
        /// <param name="directoryPath">Directory to scan</param>
        /// <param name="table">Table containing files information (can be null)</param>
        /// <param name="includeChildDirectories">Specifies if files from child directories should be retrieved</param>
        /// <param name="includeFilter">A term that should be contained in Gac files name</param>
        /// <returns>Table of files contained in the specified directory</returns>
        internal static DataTable GetDirectoryInformation(string directoryPath, DataTable table, bool includeChildDirectories, string includeFilter = null, bool includePath = false)
        {
            try
            {
                if (table == null)
                {
                    table = new DataTable();
                    table.Columns.Add("File");
                    table.Columns.Add("Version");
                    table.Columns.Add("Length");
                    table.Columns.Add("Modified");
                    table.Columns.Add("Patched");
                    table.Columns.Add("Language");
                }

                DirectoryInfo di = new DirectoryInfo(directoryPath);

                foreach (FileInfo fileInfo in di.GetFiles())
                {
                    if (includeFilter == null || fileInfo.Name.Contains(includeFilter))
                    {
                        string path = fileInfo.FullName;
                        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(path);

                        DataRow row = table.NewRow();
                        row["File"] = includePath ? fileInfo.FullName : fileInfo.Name;
                        row["Version"] = fvi.FileVersion;
                        row["Length"] = fileInfo.Length;
                        row["Modified"] = fileInfo.LastWriteTime;
                        row["Patched"] = fvi.IsPatched;
                        row["Language"] = fvi.Language;

                        table.Rows.Add(row);
                    }
                }

                if (includeChildDirectories)
                {
                    foreach (DirectoryInfo subDi in di.GetDirectories())
                    {
                        table = GetDirectoryInformation(subDi.FullName, table, includeChildDirectories, includeFilter, includePath);
                    }
                }

                return table;
            }
            catch (Exception error)
            {
                throw new Exception("Error while retrieving files form directory: " + error.Message, error);
            }
        }
    
    }
}
