using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FilterTest : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle DRTog, MacularTog, CataractTog, GlaucomaTog;
    public GameObject Canvas;
    public GameObject MacularDegenerationCanvas;
    public GameObject MainCamera;
    private MobilePostProcessing MobilePostProcessingScript;
    private MobileBlur MobileBlurScript;
    void Start()
    {
        DRTog.isOn = false;
        MacularTog.isOn = false;
        CataractTog.isOn = false;
        GlaucomaTog.isOn = false;
        

        

    }

    void Awake()
    {
        MobilePostProcessingScript = MainCamera.GetComponent<MobilePostProcessing>();
        MobileBlurScript = MainCamera.GetComponent<MobileBlur>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void DR()
    {
        Canvas.SetActive(true);
    }*/

    public void applyFilter()
    {
        if(DRTog.isOn == true)
        {
            Canvas.SetActive(true);
        }
        else
        {
            Canvas.SetActive(false);
        }


        if (MacularTog.isOn == true)
        {
            MacularDegenerationCanvas.SetActive(true);
        }
        else
        {
            MacularDegenerationCanvas.SetActive(false);
        }


        if(CataractTog.isOn == true)
        {
            MobilePostProcessingScript.Contrast = 0.1f;
            MobilePostProcessingScript.Brightness = -0.3f;
            MobilePostProcessingScript.Saturation = -0.1f;
            MobilePostProcessingScript.Sharpness = 0;

            MainCamera.GetComponent<MobileBlur>().enabled = true;
            MobileBlurScript.BlurAmount = 0.8f;
        }
        else
        {
            MobilePostProcessingScript.Vignette = false;
            MobilePostProcessingScript.Contrast = 0.6f;
            MobilePostProcessingScript.Sharpness = 0.5f;
            MobilePostProcessingScript.Brightness = 0f;
            MobilePostProcessingScript.Saturation = 0f;
            MainCamera.GetComponent<MobileBlur>().enabled = false;
        }


        if (GlaucomaTog.isOn == true)
        {
            MainCamera.GetComponent<MobileBlur>().enabled = true;
            MobileBlurScript.BlurAmount = 0.1f;
            MobilePostProcessingScript.Contrast = 0.5f;
            MobilePostProcessingScript.Saturation = -0.1f;
            MobilePostProcessingScript.Sharpness = 0.5f;
            MobilePostProcessingScript.Vignette = true;
            MobilePostProcessingScript.VignetteAmount = 0.53f;
            MobilePostProcessingScript.VignetteSoftness = 0.4f;
        }
        /*else
        {
            MobilePostProcessingScript.Vignette = false;
            MobilePostProcessingScript.Contrast = 0.6f;
            MobilePostProcessingScript.Sharpness = 0.5f;
            MobilePostProcessingScript.Brightness = 0f;
            MobilePostProcessingScript.Saturation = 0f;
            MainCamera.GetComponent<MobileBlur>().enabled = false;
        }*/
    }
}
