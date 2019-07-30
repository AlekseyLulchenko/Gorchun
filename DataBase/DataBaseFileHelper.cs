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
    }
}
