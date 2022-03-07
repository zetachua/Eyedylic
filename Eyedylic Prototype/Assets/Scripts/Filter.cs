using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Filter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DRCanvas;
    public GameObject MacularDegenerationCanvas;
    public GameObject MainCamera;
    private MobilePostProcessing MobilePostProcessingScript;
    private MobileBlur MobileBlurScript;
    void Start()
    {
        applyFilter();

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
        MobilePostProcessingScript.Vignette = false;
        MobilePostProcessingScript.Bloom = false;
        MobilePostProcessingScript.BloomAmount = 0f;
            MobilePostProcessingScript.Contrast = 0f;
            MobilePostProcessingScript.Sharpness = 0f;
            MobilePostProcessingScript.Brightness = 0f;
            MobilePostProcessingScript.Saturation = 0f;
            MainCamera.GetComponent<MobileBlur>().enabled = false;
            DRCanvas.SetActive(false);
            MacularDegenerationCanvas.SetActive(false);

        if(MainMenu.DRTog == true)
        {
            DRCanvas.SetActive(true);
            MainCamera.GetComponent<MobileBlur>().enabled = true;
            MobileBlurScript.BlurAmount = 0.2f;
        }


        else if (MainMenu.MacularTog == true)
        {
            MacularDegenerationCanvas.SetActive(true);
        }


        else if(MainMenu.CataractTog == true)
        {
            MainCamera.GetComponent<MobileBlur>().enabled = true;
            MobileBlurScript.BlurAmount = 0.6f;
            MobilePostProcessingScript.Bloom = true;
            MobilePostProcessingScript.BloomAmount = 1.75f;
            MobilePostProcessingScript.Contrast = 0.1f;
            MobilePostProcessingScript.Saturation = -0.4f;
            MobilePostProcessingScript.Sharpness = 0.25f;


            
        }

   
        else if (MainMenu.GlaucomaTog == true)
        {
            MainCamera.GetComponent<MobileBlur>().enabled = true;
            MobileBlurScript.BlurAmount = 0.1f;
            MobilePostProcessingScript.ImageFiltering = true;
            MobilePostProcessingScript.Contrast = 0.5f;
            MobilePostProcessingScript.Saturation = -0.1f;
            MobilePostProcessingScript.Sharpness = 0.5f;
            MobilePostProcessingScript.Vignette = true;
            MobilePostProcessingScript.VignetteAmount = 0.7f;
            MobilePostProcessingScript.VignetteSoftness = 0.4f;
        }
    }
}
