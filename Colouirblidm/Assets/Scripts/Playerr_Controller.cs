using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerr_Controller : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    Game_Manager manager;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        manager = GameObject.FindObjectOfType<Game_Manager>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }

    public void RestartLevel()
    {
        manager.RestartLevel();
    }
    public void FinishLevel()
    {
        manager.FinishLevel();
    }
    private void OnCollisionEnter(Collision otr)
    {
        if (otr.gameObject.CompareTag("Respawn"))
        {
            RestartLevel();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            bool canFinish = other.gameObject.GetComponent<Win_Controller>().active;
            if (canFinish == true)
            {
                FinishLevel();
            }
            
        }
    }
}
