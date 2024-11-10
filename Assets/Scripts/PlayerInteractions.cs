using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    //[SerializeField] Camera _camera;
    public bool InInteractZone;

    void Start()
    {
        InInteractZone = false;
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
        if (InInteractZone == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            Debug.Log("Interaction success");
        }
        
    }
}
