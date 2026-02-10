using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;
    [SerializeField] private BattlePlayerController player;
    [SerializeField] private BattleArena arena;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private EnemyHandler enemy;

    public BattleArena Arena => arena;
    public Vector3 PlayerPosition => player.transform.position;

    private void Awake()
    {
        Instance = this;
    }

    public void DealDamageToEnemy(int damage)
    {
        enemy.TakeDamage(damage);
    }

    public void UpdatePlayerHealthUI(int health)
    {
        if (health <= 0)
        {
            GetComponent<Debug_Scene>().ChangeScene("ALPHA_LOSE");
        }
        text.text = $"Player Health: {health}";
    }

    public void UpdateEnemyHealthUI(int health)
    {
        if (health <= 0)
        {
            GetComponent<Debug_Scene>().ChangeScene("ALPHA_START");
        }
        text2.text = $"Enemy Health: {health}";
    }


}
