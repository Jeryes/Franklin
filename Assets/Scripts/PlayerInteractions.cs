using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    //[SerializeField] Camera _camera;
    public bool InInteractZone;
    public InputAction interact;

    void Awake()
    {
        InInteractZone = false;
        interact = InputSystem.actions.FindAction("Interact");
    }

    void Onable()
    {
        interact.performed += _ => Interactions();
    }
    void OnTriggerEnter(Collider InteractionVolume)
    {
        if (InteractionVolume.GetType() == typeof(BoxCollider))
            InInteractZone = true;
            Debug.Log("In Door Zone");
    }

    void OnTriggerExit(Collider InteractionVolume)
    {
        if (InteractionVolume.GetType() == typeof(BoxCollider))
            InInteractZone = false;
            Debug.Log("Left Door Zone");
    }

    // Update is called once per frame
    void Update()
    {
        // if (InInteractZone == true)
        // {
        //     if (Input.GetKeyDown(KeyCode.E))
        //     Debug.Log("Interaction success");
        // }
        
    }

    public void Interactions()
    {
        if (InInteractZone)
        {
            Debug.Log("Interaction success");
        }
    }
}
