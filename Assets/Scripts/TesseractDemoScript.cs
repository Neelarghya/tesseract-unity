using UnityEngine;
using UnityEngine.UI;

public class TesseractDemoScript : MonoBehaviour
{
    [SerializeField] private Text display;
    private TesseractDriver _tesseractDriver;

    private void Start()
    {
        _tesseractDriver = new TesseractDriver();
        display.text = _tesseractDriver.CheckTessVersion();
    }
}