using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TesseractWrapper
{
#if UNITY_EDITOR
    private const string TesseractDllName = "tesseract";
    private const string LeptonicaDllName = "tesseract";
#elif UNITY_ANDROID
    private const string TesseractDllName = "libtesseract.so";
    private const string LeptonicaDllName = "liblept.so";
#else
    private const string TesseractDllName = "tesseract";
    private const string LeptonicaDllName = "tesseract";
#endif
    [DllImport(TesseractDllName)]
    private static extern IntPtr TessVersion();

    [DllImport(TesseractDllName)]
    private static extern IntPtr TessBaseAPICreate();

    [DllImport(TesseractDllName)]
    private static extern int TessBaseAPIInit3(IntPtr handle, string dataPath, string language);

    IntPtr tessHandle;

    public TesseractWrapper()
    {
        tessHandle = IntPtr.Zero;
    }

    public string Version()
    {
        IntPtr strPtr = TessVersion();
        string tessVersion = Marshal.PtrToStringAnsi(strPtr);
        return tessVersion;
    }

    public bool Init(string lang, string dataPath)
    {
        try
        {
            tessHandle = TessBaseAPICreate();

            int init = TessBaseAPIInit3(tessHandle, dataPath, lang);
            if (init != 0)
            {
                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return false;
        }
    }
}