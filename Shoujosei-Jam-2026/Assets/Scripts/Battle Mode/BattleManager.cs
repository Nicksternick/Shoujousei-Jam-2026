using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;
    [SerializeField] private BattlePlayerController player;
    [SerializeField] private BattleArena arena;
    [SerializeField] private TextMeshProUGUI text;

    public BattleArena Arena => arena;
    public Vector3 PlayerPosition => player.transform.position;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdatePlayerHealthUI(int health)
    {
        text.text = $"Player Health: {health}";
    }
}
