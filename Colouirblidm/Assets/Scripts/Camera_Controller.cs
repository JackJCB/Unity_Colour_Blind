using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    
    void Start()
    {
        //enbables close camera and disables far camera at start of game
        cam1.enabled = true;
        cam2.enabled = false;
    }

    
    void Update()
    {
        //switches between cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }
}
