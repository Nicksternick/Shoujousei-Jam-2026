using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;
    [SerializeField] private BattlePlayerController player;
    [SerializeField] private BattleArena arena;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private Slider slider;
    [SerializeField] private EnemyHandler enemy;

    [SerializeField] private SpriteRenderer fadeSprite;

    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioSource music;

    private bool battleStarted = false;

    public BattleArena Arena => arena;
    public Vector3 PlayerPosition => player.transform.position;
    public bool BattleStarted => battleStarted;

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
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
            music.Play();
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
            hit.Play();
        }
        
        if (health <= 0)
        {
            GetComponent<Debug_Scene>().ChangeScene("ALPHA_START");
        }
        slider.value = health;
    }

    public void UpdateEnemyHealthUI(int health)
    {
        if (health <= 0)
        {
            GetComponent<Debug_Scene>().ChangeScene("ALPHA_START");
        }
    }


}
