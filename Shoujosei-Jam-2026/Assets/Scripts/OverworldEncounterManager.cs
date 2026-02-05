using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OverworldEncounterManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap collisionMap;
    [SerializeField]
    private float encounterChance;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
       if(Random.Range(0, 1.0f) < encounterChance)
       {
            Debug.Log("Trigger Encounter");
       }
    }
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!collisionMap)
        {
            collisionMap = GetComponent<Tilemap>();
        }
        collisionMap.color = new Color(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
