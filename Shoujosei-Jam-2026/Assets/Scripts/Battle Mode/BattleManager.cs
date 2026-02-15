using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;
    [SerializeField] private BattlePlayerController player;
    [SerializeField] private BattleArena arena;
    [SerializeField] private Slider playerSlider;
    [SerializeField] private Slider enemySlider;
    [SerializeField] private EnemyHandler enemy;

    [SerializeField] private SpriteRenderer fadeSprite;

    [SerializeField] private DialogueRunner dialogueRunner;

    private bool prepareBattle = false;

    private bool battleStarted = false;

    public BattleArena Arena => arena;
    public Vector3 PlayerPosition => player.transform.position;
    public bool BattleStarted => battleStarted;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AudioManager.Instance.StopMusic();
        if (SceneChangeDataManager.Instance.PreviousEncounterTrigger == "FirstEncounterTrigger")
        {
            dialogueRunner.StartDialogue("FirstBattleDialogue");
        }
        else
        {
            prepareBattle = true;
        }
    }

    private void FixedUpdate()
    {
        if (prepareBattle)
        {
            if (fadeSprite.color.a >= 0)
            {
                Color color = fadeSprite.color;
                color.a -= 0.02f;
                fadeSprite.color = color;
            }
            else if (!battleStarted)
            {
                enemy.SetupEnemy(SceneChangeDataManager.Instance.EnemyData);
                battleStarted = true;
                AudioManager.Instance.PlayMusic(MusicTrack.Combat);
            }
        }
    }

    public void DealDamageToEnemy(int damage)
    {
        enemy.TakeDamage(damage);
    }

    public void UpdatePlayerHealthUI(int health)
    {
        if (health != 100)
        {
            AudioManager.Instance.PlaySound(SoundType.Hit);
        }
        
        if (health <= 0)
        {
            
        }
        playerSlider.value = health;
    }

    public void UpdateEnemyHealthUI(int health)
    {
        if (health <= 0)
        {
            AudioManager.Instance.StopMusic();
            GetComponent<Debug_Scene>().ChangeScene("OverWorld");
        }
        enemySlider.value = health;
    }

    [YarnCommand("StartBattle")]
    public void StartBattle()
    {
        prepareBattle = true;
    }
}
