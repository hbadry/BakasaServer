namespace BakasaClient
{
    public static class MessageHelper
    {
        /// <summary>
        /// Shows an information message.
        /// </summary>
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a warning message.
        /// </summary>
        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Confirm(string message)
        {
            DialogResult result = MessageBox.Show(message, "تاكيد",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result;
        }
    }
}
