using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class FilterMenu : MonoBehaviour
{

    public Button DRButt, MacularButt, CataractButt, GlaucomaButt;
    public Color selectColor;
    public GameObject PlayerManager;
    

    void awake()
    {
        if (MainMenu.DRTog){
            DRButt.image.color = selectColor;
        }
        else{
            DRButt.image.color = Color.white;
        }
        if (MainMenu.MacularTog){
        MacularButt.image.color = selectColor;
        }
        else{
        MacularButt.image.color = Color.white;
        }
        if (MainMenu.CataractTog){
        CataractButt.image.color = selectColor;
        }
        else{
        CataractButt.image.color = Color.white;
        }
        if (MainMenu.GlaucomaTog){
        GlaucomaButt.image.color = selectColor;
        }
        if (MainMenu.GlaucomaTog){
        GlaucomaButt.image.color = Color.white;
        }
    }

    public void EnableDR(){
        MainMenu.DRTog = true;
        MainMenu.MacularTog = false;
        MainMenu.CataractTog = false;
        MainMenu.GlaucomaTog = false;
        DRButt.image.color = selectColor;
        MacularButt.image.color = Color.white;
        CataractButt.image.color = Color.white;
        GlaucomaButt.image.color = Color.white;
        PlayerManager.GetComponent<Filter>().applyFilter();
    }

    public void EnableMacular(){
        MainMenu.DRTog = false;
        MainMenu.MacularTog = true;
        MainMenu.CataractTog = false;
        MainMenu.GlaucomaTog = false;
        DRButt.image.color = Color.white;
        MacularButt.image.color = selectColor;
        CataractButt.image.color = Color.white;
        GlaucomaButt.image.color = Color.white;
        PlayerManager.GetComponent<Filter>().applyFilter();
    }

    public void EnableCataract(){
        MainMenu.DRTog = false;
        MainMenu.MacularTog = false;
        MainMenu.CataractTog = true;
        MainMenu.GlaucomaTog = false;
        DRButt.image.color = Color.white;
        MacularButt.image.color = Color.white;
        CataractButt.image.color = selectColor;
        GlaucomaButt.image.color = Color.white;
        PlayerManager.GetComponent<Filter>().applyFilter();
    }

    public void EnableGlaucoma(){
        MainMenu.DRTog = false;
        MainMenu.MacularTog = false;
        MainMenu.CataractTog = false;
        MainMenu.GlaucomaTog = true;
        DRButt.image.color = Color.white;
        MacularButt.image.color = Color.white;
        CataractButt.image.color = Color.white;
        GlaucomaButt.image.color = selectColor;
        PlayerManager.GetComponent<Filter>().applyFilter();
    }

    
    // Start is called before the first frame update

    
    public void OpenSettingMenu(){
        PlayerManager.GetComponent<ControlManager>().OpenSettingMenu();
    }

    public void ReturnButton()
    {
        PlayerManager.GetComponent<ControlManager>().CloseMenu();
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main menu");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
