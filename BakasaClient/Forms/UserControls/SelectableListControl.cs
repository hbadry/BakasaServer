using System.Drawing.Drawing2D;


namespace BakasaClient.Forms.UserControls
{
    public class SelectableListControl : UserControl
    {
        private ListBox listBox;
        private Color _selectedColor = Color.DodgerBlue;
        private Color _hoverColor = Color.LightSkyBlue;
        private Color _borderColor = Color.MidnightBlue;
        private Color _textColor = Color.White;
        private int _borderRadius = 10;
        private int _hoveredIndex = -1;

        // Event to notify parent about selection change
        public event EventHandler<string> SelectionChanged;

        public SelectableListControl()
        {
            InitializeListBox();
            this.DoubleBuffered = true;
            this.Padding = new Padding(5);
        }

        private void InitializeListBox()
        {
            listBox = new ListBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                Font = new Font("Tahoma", 12, FontStyle.Bold), // Arabic-friendly font
                ForeColor = _textColor,
                BackColor = Color.FromArgb(30, 30, 30), // Dark mode background
                SelectionMode = SelectionMode.One,
                ItemHeight = 35,
                RightToLeft = RightToLeft.Yes // Enable RTL
            };

            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.DrawItem += ListBox_DrawItem;
            listBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            listBox.MouseMove += (s, e) =>
            {
                int index = listBox.IndexFromPoint(e.Location);
                if (index != _hoveredIndex)
                {
                    _hoveredIndex = index;
                    listBox.Invalidate(); // Redraw list to show hover effect
                }
            };

            listBox.MouseLeave += (s, e) =>
            {
                _hoveredIndex = -1;
                listBox.Invalidate(); // Remove hover effect when mouse leaves
            };
            Controls.Add(listBox);
        }

        // Method to set list of items
        public void SetItems(List<string> items)
        {
            listBox.Items.Clear();
            if (items != null)
            {
                listBox.Items.AddRange(items.ToArray());
            }
        }

        // Get selected item
        public string SelectedItem => listBox.SelectedItem?.ToString();

        // Notify parent when selection changes
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, SelectedItem);
        }

        // Custom item drawing with RTL support
        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            string text = listBox.Items[e.Index].ToString();
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            bool isHovered = (e.Index == _hoveredIndex);

            Color hoverColor = Color.FromArgb(80, 80, 80); // Hover effect color
            Color bgColor = isSelected ? _selectedColor : (isHovered ? hoverColor : Color.FromArgb(50, 50, 50));
            Color textColor = isSelected ? Color.White : Color.LightGray;

            using (SolidBrush brush = new SolidBrush(bgColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (GraphicsPath path = RoundedRect(rect, _borderRadius))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillPath(brush, path);

                // Align text to the right (RTL Support)
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Far, // Right-align text
                    LineAlignment = StringAlignment.Center,
                    FormatFlags = StringFormatFlags.DirectionRightToLeft // Force RTL
                };

                g.DrawString(text, listBox.Font, textBrush, rect, format);
            }
        }


        // Rounded rectangle method
        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // Top-left
            path.AddArc(arc, 180, 90);
            // Top-right
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            // Bottom-right
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // Bottom-left
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }


}
