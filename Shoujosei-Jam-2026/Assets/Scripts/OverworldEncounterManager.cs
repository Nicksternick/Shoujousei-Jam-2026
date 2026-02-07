using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using static Unity.Burst.Intrinsics.X86;

public class OverworldEncounterManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap collisionMap;
    [SerializeField]
    private float encounterChance;
    [SerializeField]
    private EnemyData enemyData;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<OverworldPlayerController>();
        if(player != null)
        {
            if (Random.Range(0, 1.0f) < encounterChance)
            {
                SceneChangeDataManager.Instance.EnemyData = enemyData;
                SceneChangeDataManager.Instance.OverWorldPlayerPosition = player.transform.position;
                SceneManager.LoadScene("SampleScene");
            }
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
