using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePickUp : MonoBehaviour {

    [Header("Collectable Pick Up Varibles")]
    public int pointsToAdd; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>() == null)
        return;

        CollectbleManager.AddPoints(pointsToAdd);
        Destroy(gameObject); 
    }

}
