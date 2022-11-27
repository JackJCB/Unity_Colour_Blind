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
    public bool win;
    private int positionsCorrect = 0;
    public GameObject[] currentPositions;
    public Vector3[] EndPositions;
    Win_Controller Win_Controller;
    void Start()
    {
        currentPositions = GameObject.FindGameObjectsWithTag("Moveable");
        Win_Controller = FindObjectOfType<Win_Controller>();
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
                        
                        if (((distanceDifference.x == 20 || distanceDifference.x == -20) && distanceDifference.z == 0) || (distanceDifference.z == 20 || distanceDifference.z == -20) && distanceDifference.x == 0)
                        {
                            Placeholder.transform.position = selected;
                            currentPositions = GameObject.FindGameObjectsWithTag("Moveable");
                            //checks to see if current tile positions are the same as win condition
                            if (currentPositions.Length == EndPositions.Length)
                            {

                                AreAllCorrect();
                                CanFinishLevel();
                                
                            }
                        }
                    }
                }
            }
        }
    }
    //checks to see if all the landscape pieces are in the correct position to finish the level
    private bool AreAllCorrect()
    {
        for (int i = 0; i<currentPositions.Length; i++)
        {
            if (currentPositions[i].transform.position == EndPositions[i])
            {
                positionsCorrect++;
                
                if(positionsCorrect == 8)
                {   
                    positionsCorrect = 0;
                    return true;
                }        
            }   
        }
        positionsCorrect = 0;
        return false;      
    }
    public void CanFinishLevel()
    {
        if (AreAllCorrect() == true)
        {
            Win_Controller.FinishIsActive();
        }
        if (AreAllCorrect() == false)
        {
            Win_Controller.FinishIsntActive();
        }
        
    }
    
}
      
