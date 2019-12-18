using UnityEngine;
using UnityEngine.UI;

public class TesseractDemoScript : MonoBehaviour
{
    [SerializeField] private Texture2D imageToRecognize;
    [SerializeField] private Text display;
    private TesseractDriver _tesseractDriver;

    private void Start()
    {
        _tesseractDriver = new TesseractDriver();
        display.text = _tesseractDriver.CheckTessVersion();
        _tesseractDriver.Setup();
        Recoginze();
        display.text += "\n" + _tesseractDriver.GetErrorMessage();
    }

    private void Recoginze()
    {
        display.text += "\n" + _tesseractDriver.Recognize(imageToRecognize);
    }
}