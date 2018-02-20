using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    [Header("Components")]
    public LevelManager levelManager;


    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

  
    void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            levelManager.currentCheckPoint = gameObject;
            Debug.Log("Activated Checkpoint " + transform.position); 
        }
    }
}
