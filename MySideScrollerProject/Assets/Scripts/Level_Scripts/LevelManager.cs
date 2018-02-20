using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [Header("Components")] 
    public GameObject currentCheckPoint;
    private PlayerController playerController; 

    void Start () {
        playerController = FindObjectOfType<PlayerController>(); 
	}
	
	
	void Update () {
		
	}

    public void RespawnCharacter()
    {
        Debug.Log("Character has Respawned");
        playerController.transform.position = currentCheckPoint.transform.position; 
    }
}
