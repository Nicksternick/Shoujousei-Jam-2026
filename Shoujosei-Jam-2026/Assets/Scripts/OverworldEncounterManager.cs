using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class OverworldEncounterManager : MonoBehaviour
{
    [SerializeField]
    private float encounterChance;
    [SerializeField]
    private EnemyData enemyData;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(SceneChangeDataManager.Instance.PreviousEncounterTrigger != gameObject.name)
        {
            var player = collision.GetComponent<OverworldPlayerController>();
            if (player != null)
            {
                if (Random.Range(0, 1.0f) < encounterChance)
                {
                    SceneChangeDataManager.Instance.EnemyData = enemyData;
                    SceneChangeDataManager.Instance.OverWorldPlayerPosition = player.transform.position;
                    SceneChangeDataManager.Instance.FirstEncounterComplete = true;
                    SceneChangeDataManager.Instance.FirstEncounterDialogueComplete = false;
                    SceneChangeDataManager.Instance.PreviousEncounterTrigger = gameObject.name;
                    SceneManager.LoadScene("BattleScene");
                }
            }
        }
    }
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
