namespace Logger
{
   
    public  class FileLogger
    {
       
        static string filePath = @"./Log.txt";
        static public string UserName { get; set; } = null!;

        static void Log(string message)
        {
            File.AppendAllText(filePath, $"\r\n{message}");
        }
        static public void LogError(string message)
        {
            Log($"{message}\tError");
        }
        static public void LogUser(string message)
        {
            Log($"{message}\t UserName:{FileLogger.UserName}\t{DateTime.Now}");
        }
        static public void LogUser(string message, int BookId)
        {
            Log($"{message}\tBookId:{BookId}\t\tUserName:{FileLogger.UserName}\t{ DateTime.Now}");
        }
    }

}