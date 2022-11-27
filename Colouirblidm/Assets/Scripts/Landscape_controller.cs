using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landscape_controller : MonoBehaviour
{
    public bool isTouchingPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isTouchingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
