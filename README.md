# Standalone OCR for Unity using Tesseract 

This is a sample project that sets up API and Dependencies to use Tesseract for different platforms.
To read more about how this project was made visit [this Article](https://medium.com/@neelarghyamandal/offline-ocr-using-tesseract-in-unity-part-1-b9a717ac7bcb) 

## Requires
- Unity


## Usage
The Demo Scene (Main) portrays how one can use the classes via TesseractDemoScript

### 1. Create and Setup a new Driver
```
TesseractDriver tesseractDriver = new TesseractDriver();
tesseractDrriver.Setup(OnSetupComplete)
```
#### Parameter:
UnityAction onSetupComplete -- Action called when Tesseract is successfully set up

### 2. Recognize from a Texture
```
string recognizedText = tesseractDriver.Recognize(texture)
```
#### Parameter: 
Texture2D texture -- The texture that the driver will look for characters in

### 3. Get Highlighted Texture
```
Texture2D highlightedTexture = tesseractDriver.GetHighlightedTexture()
```


## How it looks
![How it looks](Preview.jpg)


## License
[Apache-2.0 License](LICENSE)
