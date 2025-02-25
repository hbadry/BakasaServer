using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BakasaClient.Forms.CustomComponents
{

    public class CustomButton : Button
    {
        private Color _baseColor = Color.DodgerBlue;
        private Color _hoverColor = Color.DeepSkyBlue;
        private Color _disabledColor = Color.Gray;  // Disabled background color
        private Color _borderColor = Color.MidnightBlue;
        private Color _disabledTextColor = Color.DarkGray; // Disabled text color
        private int _borderSize = 2;
        private int _cornerRadius = 15;
        private bool _isHovered = false;

        public CustomButton()
        {
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10, FontStyle.Bold);
            FlatAppearance.BorderSize = 0;
            Size = new Size(120, 40);
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (Enabled) // Only highlight if enabled
            {
                _isHovered = true;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color fillColor = Enabled ? (_isHovered ? _hoverColor : _baseColor) : _disabledColor;
            Color textColor = Enabled ? ForeColor : _disabledTextColor;

            using (GraphicsPath path = RoundedRect(ClientRectangle, _cornerRadius))
            using (SolidBrush brush = new SolidBrush(fillColor))
            using (Pen borderPen = new Pen(_borderColor, _borderSize))
            {
                g.FillPath(brush, path);
                g.DrawPath(borderPen, path);
            }

            // Draw Text
            TextRenderer.DrawText(g, Text, Font, ClientRectangle, textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

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
