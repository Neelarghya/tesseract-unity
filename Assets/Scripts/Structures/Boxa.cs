using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct Boxa
{
    public Int32 n;
    public Int32 nalloc;
    public Int32 refcount;
    public IntPtr box;
}