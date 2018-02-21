using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectbleManager : MonoBehaviour {

    [Header ("Collectable Manager Varibles")]
    public static int points;
    [Header("Collectable Manager Components")]
    Text text; 

    void Start()
    {
        text = GetComponent<Text>();

        points = 000; 
    }

    void Update()
    {
        if(points < 000)
        {
            points = 000; 
        }

        text.text = "" + points; 
    }

    public static void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd; 
    }

    public static void Reset()
    {
        points = 000; 
    }

}
