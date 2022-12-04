using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    Game_Manager manager;
    private void Start()
    {
        manager = GameObject.FindObjectOfType<Game_Manager>();
    }
    public void LoadNextLevel()
    {
        manager.NextLevel();
    }
}
