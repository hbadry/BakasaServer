namespace BakasaClient.Forms.CustomComponents
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            this.RightToLeft = RightToLeft.Yes;
            this.TextAlign = ContentAlignment.MiddleRight;
            this.Font = new Font("Segoe Script", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            this.ForeColor = Color.Black;
        }
    }
}
