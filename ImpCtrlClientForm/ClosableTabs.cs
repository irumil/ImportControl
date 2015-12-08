using System;
using System.Windows.Forms;
using System.Drawing;

namespace PL.TabControl
{
    public delegate bool OnBeforeCloseTab(int indx);

    public class ClosableTab : System.Windows.Forms.TabControl
    {
        public event OnBeforeCloseTab BeforeCloseATabPage;

        private Image _img;
        private Point _imageLocation = new Point(15, 5);
        private Point _imgHitArea = new Point(13, 2);
        
        private bool _imgExist;
        private int _tabWidth;

        public ClosableTab()
        {
            BeforeCloseATabPage = null;
            DrawMode = TabDrawMode.OwnerDrawFixed;
            Padding = new Point(12, 3);
        }

        public Image SetImage
        {
            set 
            { 
                _img = value;
                if (_img != null)
                {
                    _imgExist = true;
                }
            }
            get { return _img; }
        }

        public Point ImageLocation
        {
            get { return _imageLocation; }
            set { _imageLocation = value; }
        }

        public Point ImageHitArea
        {
            get { return _imgHitArea; }
            set { _imgHitArea = value; }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Rectangle _rectangle = e.Bounds;
            _rectangle = GetTabRect(e.Index);
            _rectangle.Offset(2, 2);
            
            Brush titleBrush = new SolidBrush(Color.Black);
            var f = Font;
            
            string title = this.TabPages[e.Index].Text;
            int stringLength = Convert.ToInt32(e.Graphics.MeasureString(title, f).Width);
            
            e.Graphics.DrawString(title, f, titleBrush, new PointF(_rectangle.X, _rectangle.Y));

            try
            {
                e.Graphics.DrawImage(_img, new Point(_rectangle.X + (GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
            }
            catch (Exception)
            {
                
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (_imgExist)
            {
                Point p = e.Location;
                for (int i = 0; i < TabCount; i++)
                {
                    _tabWidth = GetTabRect(i).Width - (_imgHitArea.X);

                    Rectangle r = GetTabRect(i);
                    r.Offset(_tabWidth, _imgHitArea.Y);
                    r.Width = _img.Width;
                    r.Height = _img.Height;
                    if (r.Contains(p))
                    {
                        CloseTab(i);
                    }
                }
            }
        }

        private void CloseTab(int i)
        {
            if (BeforeCloseATabPage != null)
            {
                var canClose = BeforeCloseATabPage(i);
                if (!canClose)
                    return;
            }
            TabPages.Remove(TabPages[i]);
        }
    }
}
