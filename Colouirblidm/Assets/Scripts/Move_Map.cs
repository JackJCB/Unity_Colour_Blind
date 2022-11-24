using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Map : MonoBehaviour
{
    private Vector3 selected;
    public GameObject Placeholder;
    public Camera topCamera;
    private Ray ray;
    private bool canMove = false;
    private Vector3 distanceDifference;
    public Landscape_controller landscapeScript;
    private bool playerOn;
    void Start()
    {
        
    }
    void Update()
    {
        //mouse click to slide puzzle
        if(Input.GetMouseButtonDown(0))
        {
            //ray cast stuff that i dont really get
            RaycastHit raycastHit;
            ray = topCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out raycastHit, 100f))
            {
                if(raycastHit.transform != null)
                {
                    //gets refence to object clicked on
                    if(raycastHit.collider.gameObject.CompareTag("Moveable"))
                    {
                        Placeholder = raycastHit.collider.gameObject;
                        landscapeScript = Placeholder.GetComponent<Landscape_controller>();
                        playerOn = landscapeScript.isTouchingPlayer;
                        canMove = true;  
                    }
                    //allows you to move the object that was clicked
                    if(canMove == true && playerOn == false)
                    {
                        selected = raycastHit.transform.position;
                        distanceDifference = Placeholder.transform.position - selected;
                        
                        if ((distanceDifference.x == 20 || distanceDifference.x == -20) && distanceDifference.z == 0)
                        {
                           Placeholder.transform.position = selected;
                        }
                        else if((distanceDifference.z == 20 || distanceDifference.z == -20) && distanceDifference.x == 0)
                        {
                            Placeholder.transform.position = selected;
                        }
                        
                    }
                }
            }
        }
    }
}
