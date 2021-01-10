using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


class PInvoke
{
    [StructLayout(LayoutKind.Sequential)]
    private struct DLLVERSIONINFO
    {
        public int cbSize;
        public int dwMajorVersion;
        public int dwMinorVersion;
        public int dwBuildNumber;
        public int dwPlatformID;
    }

    [DllImport("winmm.dll", EntryPoint = "timeGetTime")]
    public static extern uint TimeGetTime();

    [DllImport("shell32.dll", CharSet = CharSet.Auto)]
    static extern uint ExtractIconEx(string szFileName, int nIconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons);

    [DllImport("user32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
    private static unsafe extern int DestroyIcon(IntPtr hIcon);

    public static void Main()
    {
        PInvoke.TimeGetTime();
        PInvoke.ExtractIconFromExe(@"C:\Windows\system32\imageres.dll", true);
        Marshal.GetLastWin32Error();
    }
    public static Icon ExtractIconFromExe(string file, bool large)
    {
        unsafe
        {
            uint readIconCount = 0;
            IntPtr[] hDummy = new IntPtr[1] { IntPtr.Zero };
            IntPtr[] hIconEx = new IntPtr[1] { IntPtr.Zero };

            try
            {
                if (large)
                    readIconCount = ExtractIconEx(file, 0, hIconEx, hDummy, 1);
                else
                    readIconCount = ExtractIconEx(file, 0, hDummy, hIconEx, 1);

                if (readIconCount > 0 && hIconEx[0] != IntPtr.Zero)
                {
                    // GET FIRST EXTRACTED ICON
                    Icon extractedIcon = (Icon)Icon.FromHandle(hIconEx[0]).Clone();

                    return extractedIcon;
                }
                else // NO ICONS READ
                    return null;
            }
            catch (Exception ex)
            {
                /* EXTRACT ICON ERROR */

                // BUBBLE UP
                throw new ApplicationException("Could not extract icon", ex);
            }
            finally
            {
                // RELEASE RESOURCES
                foreach (IntPtr ptr in hIconEx)
                    if (ptr != IntPtr.Zero)
                        DestroyIcon(ptr);

                foreach (IntPtr ptr in hDummy)
                    if (ptr != IntPtr.Zero)
                        DestroyIcon(ptr);
            }
        }
    }
}
