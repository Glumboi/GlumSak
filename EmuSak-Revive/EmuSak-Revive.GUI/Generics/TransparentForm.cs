using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace EmuSak_Revive.GUI.Generics
{
    public class TransparentForm
    {
        [DllImport("gdi32")]
        private static extern IntPtr CreateEllipticRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("dwmapi")]
        private static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DwmBlurbehind pBlurBehind);

        public struct DwmBlurbehind
        {
            public int DwFlags;
            public bool FEnable;
            public IntPtr HRgnBlur;
            public bool FTransitionOnMaximized;
        }

        public static void MakeFormTransparent(Form frm)
        {
            var hr = CreateEllipticRgn(0, 0, frm.Width, frm.Height);
            var dbb = new DwmBlurbehind { FEnable = true, DwFlags = 1, HRgnBlur = hr, FTransitionOnMaximized = false };
            DwmEnableBlurBehindWindow(frm.Handle, ref dbb);
        }
    }
}