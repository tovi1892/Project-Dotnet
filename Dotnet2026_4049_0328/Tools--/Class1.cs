using System;
using System.IO;

namespace Tools__;

public static class LogManager
{
    private const string LogDir = "Log";

    private static string GetCurrentDirectoryPath()
    {
        string mainLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LogDir);
        string monthFolderName = DateTime.Now.ToString("yyyy-MM");

        return Path.Combine(mainLogPath, monthFolderName);
    }

    private static string GetFilePath()
    {
        string directoryPath = GetCurrentDirectoryPath();
        string fileName = $"{DateTime.Now:dd}.txt";
        return Path.Combine(directoryPath, fileName);
    }

    public static void WriteLog(string project, string funcName, string message)
    {
        string directoryPath = GetCurrentDirectoryPath();
        string filePath = GetFilePath();

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        string logLine = $"{DateTime.Now}\t{project}.{funcName}:\t{message}";

        File.AppendAllText(filePath, logLine + Environment.NewLine);
    }
    public static void cleanLogs()
    {
        string mainLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");

        if (Directory.Exists(mainLogPath))
        {
            string[] monthDirectories = Directory.GetDirectories(mainLogPath);
            foreach (string monthPath in monthDirectories)
            {
                string folderName = Path.GetFileName(monthPath); 

                if (DateTime.TryParse(folderName, out DateTime folderDate))
                {
                    DateTime twoMonthsAgo = DateTime.Now.AddMonths(-2);

                    if (folderDate < new DateTime(twoMonthsAgo.Year, twoMonthsAgo.Month, 1))
                    {
                        Directory.Delete(monthPath, true);
                    }
                }
            }
        }
    }
}