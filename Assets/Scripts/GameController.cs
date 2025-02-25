using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    //private PlayerControls playerControls;
    public GameObject UICanvas;
    private bool IsMenuOpen;
    public InputAction openMenu;
    public InputAction cancelMenu;
    
    // Start is called before the first frame update
    void Awake()
    {
        //playerControls = new PlayerControls();

        // Hides the UI when the game starts
        UICanvas = GameObject.Find("Canvas");
        UICanvas.GetComponent<Canvas>().enabled = false;
        IsMenuOpen = false;

        openMenu = InputSystem.actions.FindAction("OpenMenu");
        //Debug.Log(openMenu);
        cancelMenu = InputSystem.actions.FindAction("Cancel");
        //Debug.Log(cancelMenu);

        //Debug.Log(IsMenuOpen);
    }

    // Update is called once per frame
    void Update()
    {
        OpenCloseMenu();
    }

    void OpenCloseMenu()
    {
        if (IsMenuOpen == false && openMenu.IsPressed()) 
            {
                UICanvas.GetComponent<Canvas>().enabled = true;
                IsMenuOpen = true;
            }

        if (IsMenuOpen == true && cancelMenu.IsPressed())
            {
                UICanvas.GetComponent<Canvas>().enabled = false;
                IsMenuOpen = false;
            }
    }
}
