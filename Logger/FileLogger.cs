namespace Logger
{
   
     public class FileLogger :ILog
    {
       
        static public string FilePath = @".\Log.txt";
        public void Log(string message , string messageType)
        {
            File.AppendAllText(FilePath, message);
        }
         public void LogError(string message)
        {
            Log(message, "Error");
        }
        public void LogWaring(string message)
        {
            Log(message, "Waring");
        }
        public void LogInformation(string message)
        {
            Log(message, "Error");
        }
        public void LogUser(string message , string userName , int id)
        {
            Log($"{message}\tuserName:{userName}\t BookId:{id}", "Error");
        }
    }

}