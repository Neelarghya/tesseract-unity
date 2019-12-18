using System;
using UnityEngine;

public class TesseractDriver
{
    private TesseractWrapper _tesseract;

    public string CheckTessVersion()
    {
        _tesseract = new TesseractWrapper();

        try
        {
            string version = "Tesseract version: " + _tesseract.Version();
            Debug.Log(version);
            return version;
        }
        catch (Exception e)
        {
            string errorMessage = e.GetType() + " - " + e.Message;
            Debug.LogError(errorMessage);
            return errorMessage;
        }
    }

    public void Setup()
    {
        _tesseract = new TesseractWrapper();

        string datapath = Application.streamingAssetsPath + "/tessdata/";

        if (_tesseract.Init("eng", datapath))
        {
            Debug.Log("Init Successful");
        }
    }

    public string GetErrorMessage()
    {
        return _tesseract?.GetErrorMessage();
    }

    public string Recognize(Texture2D imageToRecognize)
    {
        return _tesseract.Recognize(imageToRecognize);
    }

    public Texture2D GetHighlightedTexture()
    {
        return _tesseract.GetHighlightedTexture();
    }
}