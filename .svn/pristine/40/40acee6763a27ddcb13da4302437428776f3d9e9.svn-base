using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

/*
 * Programming by GearIntellix
 */
namespace ISA.Showroom.Utility
{
    class InPopup
    {
        Control _panel;
        Form _frm;
        Timer _timer;
        bool onpopup = false,
            curonpopup = false,
            popres = false,
            popforce = false;
        List<Rectangle> popuparea = new List<Rectangle>();
        Action onLeavePopArea = null;

        public Control Panel
        {
            get { return _panel; }
        }
        public Form Mother
        {
            get { return _frm; }
        }
        public bool IsOpened
        {
            get { return onpopup; }
        }

        public InPopup(Form mother, Control panel)
        {
            _frm = mother;
            _panel = panel;
            _timer = new Timer();
            _timer.Tick += (a, b) =>
            {
                if (!onpopup) return;
                Point p = _frm.PointToClient(Cursor.Position);
                foreach (Rectangle cur in popuparea)
                {
                    curonpopup = p.X >= cur.X && p.X <= (cur.X + cur.Width) && p.Y >= cur.Y && p.Y <= (cur.Y + cur.Height);
                    if (curonpopup) break;
                }
                if (!curonpopup) onLeavePopArea();
            };
        }

        public bool isPanelFocused(Control elm)
        {
            if (elm.Focused) return true;
            foreach (Control cur in elm.Controls)
            {
                if (isPanelFocused(cur)) return true;
            }
            return false;
        }

        public void Close(bool res)
        {
            popres = res;
            popforce = true;
            onLeavePopArea();
        }

        public bool Open(Control invoker, Action<bool> onClose)
        {
            if (invoker == null) invoker = _frm;
            if (onpopup) return false;
            popforce = false;
            onpopup = true;
            popres = false;

            Point ip = invoker.Location;
            Point pp = _panel.Location;

            // 0: right top, 1: right bottom, 2: left top, 3: left bottom, 4: center
            int mode = -1;
            if (invoker == _frm)
            {
                mode = 4;
            }
            else if (ip.X + _panel.Width <= _frm.Width) // right
            {
                if (ip.Y - _panel.Height >= 0) // top
                {
                    mode = 0;
                }
                else if (ip.Y + invoker.Height + _panel.Height <= _frm.Height) // bottom 
                {
                    mode = 1;
                }
            }
            else if (ip.X + invoker.Width - _panel.Width >= 0)// left
            {
                if (ip.Y - _panel.Height >= 0) // top
                {
                    mode = 2;
                }
                else if (ip.Y + invoker.Height + _panel.Height <= _frm.Height) // bottom 
                {
                    mode = 3;
                }
            }

            onLeavePopArea = () =>
            {
                if ((!isPanelFocused(_panel) && _frm.ContainsFocus) || popforce)
                {
                    _timer.Stop();
                    _panel.Visible = false;
                    onpopup = false;
                    if (onClose != null) onClose(popres);
                }
            };

            switch (mode)
            {
                case 0:
                    _panel.Location = new Point(ip.X, ip.Y - _panel.Height);
                    break;
                case 1:
                    _panel.Location = new Point(ip.X, ip.Y + invoker.Height);
                    break;
                case 2:
                    _panel.Location = new Point(ip.X + invoker.Width - _panel.Width, ip.Y - _panel.Height);
                    break;
                case 3:
                    _panel.Location = new Point(ip.X + invoker.Width - _panel.Width, ip.Y + invoker.Height);
                    break;
                case 4:
                    _panel.Location = new Point((invoker.Width / 2) - (_panel.Width / 2), (invoker.Height / 2) - (_panel.Height / 2));
                    break;
            }
            _panel.BringToFront();
            _panel.Visible = true;
            _panel.Focus();

            popuparea.Clear();
            if (invoker != _frm) popuparea.Add(new Rectangle(invoker.Location, invoker.Size));
            popuparea.Add(new Rectangle(_panel.Location, _panel.Size));
            _timer.Start();

            return true;
        }

    }
}
