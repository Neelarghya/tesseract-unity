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

    private IntPtr _tessHandle;
    private string _errorMsg;

    [DllImport(TesseractDllName)]
    private static extern IntPtr TessVersion();

    [DllImport(TesseractDllName)]
    private static extern IntPtr TessBaseAPICreate();

    [DllImport(TesseractDllName)]
    private static extern int TessBaseAPIInit3(IntPtr handle, string dataPath, string language);

    [DllImport(TesseractDllName)]
    private static extern void TessBaseAPIDelete(IntPtr handle);

    [DllImport(TesseractDllName)]
    private static extern void TessBaseAPISetImage(IntPtr handle, IntPtr imagedata, int width, int height,
        int bytes_per_pixel, int bytes_per_line);

    [DllImport(TesseractDllName)]
    private static extern void TessBaseAPISetImage2(IntPtr handle, IntPtr pix);
    
    [DllImport(TesseractDllName)]
    private static extern int TessBaseAPIRecognize(IntPtr handle, IntPtr monitor);

    [DllImport(TesseractDllName)]
    private static extern IntPtr TessBaseAPIGetUTF8Text(IntPtr handle);

    [DllImport(TesseractDllName)]
    private static extern void TessDeleteText(IntPtr text);

    [DllImport(TesseractDllName)]
    private static extern void TessBaseAPIEnd(IntPtr handle);

    [DllImport(TesseractDllName)]
    private static extern void TessBaseAPIClear(IntPtr handle);


    public TesseractWrapper()
    {
        _tessHandle = IntPtr.Zero;
    }

    public string Version()
    {
        IntPtr strPtr = TessVersion();
        string tessVersion = Marshal.PtrToStringAnsi(strPtr);
        return tessVersion;
    }

    public string GetErrorMessage()
    {
        return _errorMsg;
    }

    public bool Init(string lang, string dataPath)
    {
        if (!_tessHandle.Equals(IntPtr.Zero))
            Close();

        try
        {
            _tessHandle = TessBaseAPICreate();
            if (_tessHandle.Equals(IntPtr.Zero))
            {
                _errorMsg = "TessAPICreate failed";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dataPath))
            {
                _errorMsg = "Invalid DataPath";
                return false;
            }

            int init = TessBaseAPIInit3(_tessHandle, dataPath, lang);
            if (init != 0)
            {
                Close();
                _errorMsg = "TessAPIInit failed. Output: " + init;
                return false;
            }
        }
        catch (Exception ex)
        {
            _errorMsg = ex + " -- " + ex.Message;
            return false;
        }

        return true;
    }

    public void Close()
    {
        if (_tessHandle.Equals(IntPtr.Zero))
            return;
        TessBaseAPIEnd(_tessHandle);
        TessBaseAPIDelete(_tessHandle);
        _tessHandle = IntPtr.Zero;
    }
}