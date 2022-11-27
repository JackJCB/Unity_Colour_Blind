using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Controller : MonoBehaviour
{
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FinishIsActive()
    {
        var cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.blue);
        active = true;
    }

    public void FinishIsntActive()
    {
        var cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.grey);
        active = false;
    }
}
