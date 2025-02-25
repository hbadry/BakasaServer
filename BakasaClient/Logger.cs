namespace BakasaClient
{
    public static class Logger
    {
        private static readonly string LogFilePath = "error_log.txt"; // Log file location
        private static readonly string LoggingFilePath = "logging.txt";

        public static void LogException(Exception ex, string customMessage = "حدث خطا")
        {
            try
            {
                // Format error message with timestamp
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {customMessage}\n" +
                                    $"Exception: {ex.Message}\n" +
                                    $"Stack Trace: {ex.StackTrace}\n" +
                                    "-----------------------------------------------------\n";

                // Write to file (append)
                File.AppendAllText(LogFilePath, logMessage);

                // Show a user-friendly message box
                MessageBox.Show($"{customMessage}\n\nDetails: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception logEx)
            {
                MessageBox.Show($"Failed to write log: {logEx.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void Log(string message)
        {
            try
            {
                // Format error message with timestamp
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n";

                File.AppendAllText(LoggingFilePath, logMessage);

            }
            catch (Exception logEx)
            {

            }
        }
    }

}
