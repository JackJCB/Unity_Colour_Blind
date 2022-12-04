using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Controller : MonoBehaviour
{
    public bool active;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FinishIsActive()
    {
        gameObject.SetActive(true);
        active = true;
    }

    public void FinishIsntActive()
    {
        gameObject.SetActive(false);
        active = false;
    }
}
