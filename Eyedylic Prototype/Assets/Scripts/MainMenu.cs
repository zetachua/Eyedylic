using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button DRButt, MacularButt, CataractButt, GlaucomaButt;
    public static bool DRTog, MacularTog, CataractTog, GlaucomaTog;

    // Start is called before the first frame update
    void Start()
    {
        DRTog = false;
        MacularTog = false;
        CataractTog = false;
        GlaucomaTog = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableDR(){
        DRTog = true;
        MacularTog = false;
        CataractTog = false;
        GlaucomaTog = false;
        DRButt.image.color = Color.red;
        MacularButt.image.color = Color.white;
        CataractButt.image.color = Color.white;
        GlaucomaButt.image.color = Color.white;
    }

    public void EnableMacular(){
        DRTog = false;
        MacularTog = true;
        CataractTog = false;
        GlaucomaTog = false;
        DRButt.image.color = Color.white;
        MacularButt.image.color = Color.red;
        CataractButt.image.color = Color.white;
        GlaucomaButt.image.color = Color.white;
    }

    public void EnableCataract(){
        DRTog = false;
        MacularTog = false;
        CataractTog = true;
        GlaucomaTog = false;
        DRButt.image.color = Color.white;
        MacularButt.image.color = Color.white;
        CataractButt.image.color = Color.red;
        GlaucomaButt.image.color = Color.white;
    }

    public void EnableGlaucoma(){
        DRTog = false;
        MacularTog = false;
        CataractTog = false;
        GlaucomaTog = true;
        DRButt.image.color = Color.white;
        MacularButt.image.color = Color.white;
        CataractButt.image.color = Color.white;
        GlaucomaButt.image.color = Color.red;
    }



    public void StartScene()
    {
        SceneManager.LoadScene("Sensory Audio 1Bath");
    }
}