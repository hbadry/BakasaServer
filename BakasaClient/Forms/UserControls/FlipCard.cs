using System.Drawing.Imaging;
using Timer = System.Windows.Forms.Timer;

namespace BakasaClient.Forms.UserControls
{
    public partial class FlipCard : UserControl
    {
        private bool isFlipped = false; // Tracks front/back state
        private Timer flipTimer;
        private int fadeStep = 0;
        private int fadeMaxSteps = 10; // Total steps for fade effect

        private Image originalFrontImage;
        private Image originalBackImage;

        // Define the delegate (if necessary)
        private bool atLeastOneFlip = false;
        public delegate void CardFlipped(object sender, EventArgs e);

        // Declare the event
        public event CardFlipped CardFlippedEvent;

        protected virtual void OnFirstFlip()
        {
            CardFlippedEvent?.Invoke(this, EventArgs.Empty); // Fire the event if there are subscribers
        }

        public Image FrontImage
        {
            get => originalFrontImage;
            set
            {
                originalFrontImage = value;
                if (value != null)
                    pictureBoxFront.Image = (Image)originalFrontImage.Clone(); // Use a copy
            }
        }

        public Image BackImage
        {
            get => originalBackImage;
            set
            {
                originalBackImage = value;
                if (value != null)
                    pictureBoxBack.Image = (Image)originalBackImage.Clone(); // Use a copy
            }
        }

        public string BackText
        {
            get => labelBackText.Text;
            set => labelBackText.Text = value;
        }

        public FlipCard()
        {
            InitializeComponent();
            InitializeFlipCard();
        }

        private void InitializeFlipCard()
        {
            this.Size = new Size(150, 200);

            // PictureBox for Front Image
            pictureBoxFront = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(pictureBoxFront);

            // Panel for Back Side
            panelBack = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Visible = false
            };

            // PictureBox for Back Image
            pictureBoxBack = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            panelBack.Controls.Add(pictureBoxBack);

            // Label for Text
            labelBackText = new Label
            {
                Text = "Default",
                Font = new Font("Tahoma", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            labelBackText.Location = new Point(
            (panelBack.Width - labelBackText.Width) / 2, // Center horizontally
            (panelBack.Height - labelBackText.Height) / 2 // Center vertically
        );
            panelBack.Controls.Add(labelBackText);

            this.Controls.Add(panelBack);
            panelBack.Controls.SetChildIndex(labelBackText, 0);

            // Click Event to Toggle Flip
            this.Click += FlipCard_Click;
            pictureBoxFront.Click += FlipCard_Click;
            pictureBoxBack.Click += FlipCard_Click;
            panelBack.Click += FlipCard_Click;

            // Timer for Fade Animation
            flipTimer = new Timer();
            flipTimer.Interval = 50; // Controls animation speed
            flipTimer.Tick += FlipTimer_Tick;
            panelBack.Resize += (s, e) => CenterLabel();
        }
        private void CenterLabel()
        {
            if (labelBackText != null && panelBack != null)
            {
                labelBackText.Location = new Point(
                    (panelBack.Width - labelBackText.Width) / 2,
                    (panelBack.Height - labelBackText.Height) / 2
                );
            }
        }


        private void FlipCard_Click(object sender, EventArgs e)
        {
            if (!flipTimer.Enabled) // Prevent multiple clicks during animation
            {
                fadeStep = 0;
                flipTimer.Start();
            }
            if (!atLeastOneFlip)
            {
                atLeastOneFlip = true;
                OnFirstFlip();
            }
        }

        private void FlipTimer_Tick(object sender, EventArgs e)
        {
            if (fadeStep < fadeMaxSteps) // Fade Out Phase
            {
                SetImageOpacity(isFlipped ? pictureBoxBack : pictureBoxFront, 1.0f - (fadeStep / (float)fadeMaxSteps));
            }
            else if (fadeStep == fadeMaxSteps) // Switch Side
            {
                isFlipped = !isFlipped;
                pictureBoxFront.Visible = !isFlipped;
                panelBack.Visible = isFlipped;

                // Ensure the back panel and pictureBoxBack are properly sized
                panelBack.Size = this.Size;
                pictureBoxBack.Size = panelBack.Size;

                // Restore original images to prevent corruption
                pictureBoxFront.Image = (Image)originalFrontImage.Clone();
                pictureBoxBack.Image = (Image)originalBackImage.Clone();
            }
            else if (fadeStep < fadeMaxSteps * 2) // Fade In Phase
            {
                SetImageOpacity(isFlipped ? pictureBoxBack : pictureBoxFront, (fadeStep - fadeMaxSteps) / (float)fadeMaxSteps);
            }
            else // End Animation
            {
                flipTimer.Stop();
            }
            fadeStep++;
        }

        private void SetImageOpacity(PictureBox pictureBox, float opacity)
        {
            if (pictureBox.Image == null) return;

            Bitmap bmp = new Bitmap(pictureBox.Image.Width, pictureBox.Image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity; // Set opacity

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(isFlipped ? originalBackImage : originalFrontImage,
                            new Rectangle(0, 0, bmp.Width, bmp.Height),
                            0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attributes);
            }

            pictureBox.Image = bmp;
        }

        public void SetImages(Image front, Image back, string text)
        {
            FrontImage = front;
            BackImage = back;
            BackText = text;
        }

        private PictureBox pictureBoxFront;
        private Panel panelBack;
        private PictureBox pictureBoxBack;
        private Label labelBackText;
    }





}
