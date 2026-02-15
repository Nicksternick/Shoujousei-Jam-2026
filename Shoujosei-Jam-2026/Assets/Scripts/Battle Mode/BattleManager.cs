using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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

    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private SpriteRenderer miniBossSprite;
    [SerializeField] private SpriteRenderer finalBossSprite;

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
        if (prepareBattle && !battleStarted)
        {
            EnemyData enemyData = SceneChangeDataManager.Instance.EnemyData;

            switch (enemyData.enemySprite)
            {
                case EnemyType.Basic:
                    enemySprite.gameObject.SetActive(true);
                    break;
                case EnemyType.MiniBoss:
                    miniBossSprite.gameObject.SetActive(true);
                    break;
                case EnemyType.FinalBoss:
                    finalBossSprite.gameObject.SetActive(true);
                    break;
            }

            enemySlider.maxValue = enemyData.health;
            enemySlider.value = enemyData.health;

            if (fadeSprite.color.a >= 0)
            {
                Color color = fadeSprite.color;
                color.a -= 0.02f;
                fadeSprite.color = color;
            }
            else if (!battleStarted)
            {
                switch (enemyData.enemySprite)
                {
                    case EnemyType.Basic:
                        AudioManager.Instance.PlayMusic(MusicTrack.Combat);
                        break;
                    case EnemyType.MiniBoss:
                        AudioManager.Instance.PlayMusic(MusicTrack.Combat);
                        break;
                    case EnemyType.FinalBoss:
                        AudioManager.Instance.PlayMusic(MusicTrack.BossMusic);
                        break;
                }

                enemy.SetupEnemy(enemyData);
                battleStarted = true;
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
            AudioManager.Instance.StopMusic();
            EndBattle(false);
        }
        playerSlider.value = health;
    }

    public void UpdateEnemyHealthUI(int health)
    {
        if (health <= 0)
        {
            AudioManager.Instance.StopMusic();
            EndBattle(false);
            GetComponent<Debug_Scene>().ChangeScene("OverWorld");
        }
        enemySlider.value = health;
    }

    private void EndBattle(bool enemyDied)
    {

    }

    [YarnCommand("StartBattle")]
    public void StartBattle()
    {
        prepareBattle = true;
    }
}
