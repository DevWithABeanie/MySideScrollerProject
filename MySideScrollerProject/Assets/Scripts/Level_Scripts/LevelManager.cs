using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    [Header("Components")] 
    public GameObject currentCheckPoint;
    private PlayerController playerController;

    [Header("Particle Systems")]
    public GameObject deathParticle;
    public GameObject respawnParticle;

    [Header("Level Manager Varibles")]
    public float respawnDelay; 

    void Start () {
        playerController = FindObjectOfType<PlayerController>(); 
	}
	
	
	void Update () {
		
	}

    public void RespawnCharacter()
    {
        StartCoroutine("RespawnPlayerCo"); 
    }

    public IEnumerator RespawnPlayerCo()
    {
        Debug.Log("Character has Respawned");
        Instantiate(deathParticle, playerController.transform.position, playerController.transform.rotation);
        playerController.enabled = false;
        playerController.GetComponent<Renderer>().enabled = false; 
        yield return new WaitForSeconds(respawnDelay); 
        playerController.transform.position = currentCheckPoint.transform.position;
        playerController.enabled = true;
        playerController.GetComponent<Renderer>().enabled = true;
        Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
    }
}
