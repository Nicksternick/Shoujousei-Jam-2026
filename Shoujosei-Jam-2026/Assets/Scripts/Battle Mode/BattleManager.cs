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

    [SerializeField] private SpriteRenderer deathBG;
    [SerializeField] private SpriteRenderer playerPotrait;
    [SerializeField] private SpriteRenderer enemyPotrait;
    [SerializeField] private SpriteRenderer playerDeathSquare;
    [SerializeField] private SpriteRenderer enemyDeathSquare;



    private bool prepareBattle = false;

    private bool battleStarted = false;

    private bool killPlayer = false;
    private bool killEnemy = false;

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
        if (killPlayer)
        {
            if (playerDeathSquare.color.a < 2f)
            {
                Color color = playerDeathSquare.color;
                color.a += 0.05f;
                playerDeathSquare.color = color;
                Vector3 transform = playerPotrait.transform.position;
                transform.x -= 0.1f;
                playerPotrait.transform.position = transform;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        if (killEnemy)
        {
            if (enemyDeathSquare.color.a < 2f)
            {
                Color color = enemyDeathSquare.color;
                color.a += 0.05f;
                enemyDeathSquare.color = color;
                Vector3 transform = enemyPotrait.transform.position;
                transform.x += 0.1f;
                enemyPotrait.transform.position = transform;
            }
            else
            {
                SceneManager.LoadScene("OverWorld");
            }
        }

        if ( killPlayer || killEnemy) { return; }

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
        if (health != enemySlider.maxValue)
        {
            AudioManager.Instance.PlaySound(SoundType.EnemyHit);
        }

        if (health <= 0)
        {
            AudioManager.Instance.StopMusic();
            EndBattle(true);
        }
        enemySlider.value = health;
    }

    private void EndBattle(bool enemyDied)
    {
        battleStarted = false;
        deathBG.gameObject.SetActive(true);
        if (enemyDied)
        {
            if (SceneChangeDataManager.Instance.EnemyData.enemySprite == EnemyType.Basic)
            {
                AudioManager.Instance.PlaySound(SoundType.PlayerDeath);
            }
            else
            {
                AudioManager.Instance.PlaySound(SoundType.BossDeath);
            }
            killEnemy = true;
        }
        else
        {
            AudioManager.Instance.PlaySound(SoundType.PlayerDeath);
            killPlayer = true;
        }
    }

    [YarnCommand("StartBattle")]
    public void StartBattle()
    {
        prepareBattle = true;
    }
}
