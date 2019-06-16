using System;
using System.IO;

namespace Gorchun.DataBase
{
    public static class DataBaseFileHelper
    {
        private const string DATABASE_FILENAME = "DataBase.db";
        private const string DATABASE_FILE_PARENT_FOLDER = "Data";
        private const string APPLICATION_FOLDER = "Gorchun";

        //private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public static string GetConnectionString()
            => $"Data Source={BuildFullDbFilePath()};Flags=NoVerifyTextAffinity";


        private static string BuildFullDbFilePath()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DATABASE_FILE_PARENT_FOLDER, DATABASE_FILENAME);
            return filePath;
        }

        //private static void CreateClientDatabase(string destinationFileName)
        //{
        //    string sourceDbFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DATABASE_FILE_PARENT_FOLDER, DATABASE_FILENAME);
        //    if (File.Exists(sourceDbFile) == false)
        //    {
        //        throw new FileNotFoundException($"Source database file '{sourceDbFile}' doesn't exist.");
        //    }

        //    CreateDirectoryIfNotExists(Path.GetDirectoryName(destinationFileName));
        //    FileInfo fileInfo = new FileInfo(sourceDbFile);
        //    //_logger.Info("Creating a new database file...");
        //    fileInfo.CopyTo(destinationFileName, overwrite: true);

        //    if (File.Exists(destinationFileName) == false)
        //    {
        //        //_logger.Info($"Can't create database file '{destinationFileName}'.");
        //        throw new FileNotFoundException($"An error occured while creating the database file {destinationFileName}");
        //    }
        //}

        //private static void CreateDirectoryIfNotExists(string path)
        //{
        //    if (Directory.Exists(path) == false)
        //    {
        //        //_logger.Info($"Creating directory for client database: '{path}'");
        //        Directory.CreateDirectory(path);
        //    }
        //}
    }
}
