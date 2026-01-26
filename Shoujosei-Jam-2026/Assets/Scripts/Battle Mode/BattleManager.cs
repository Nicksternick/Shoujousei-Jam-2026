using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    [SerializeField] private BattleArena arena;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        instance = this;
    }

    public void UpdatePlayerHealthUI(int health)
    {
        text.text = $"Player Health: {health}";
    }

    public Vector3 CenterOnState()
    {
        return arena.Center;
    }

    public Vector3 ClampToStageX(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, arena.MinX, arena.MaxX);
        return position;
    }

    public Vector3 ClampToStageX(Vector3 position, out bool hasClamped)
    {
        float originalX = position.x;

        position = ClampToStageX(position);

        hasClamped = originalX != position.x;

        return position;
    }

    public Vector3 ClampToStageY(Vector3 position)
    {
        position.y = Mathf.Clamp(position.y, arena.MinY, arena.MaxY);
        return position;
    }

    public Vector3 ClampToStageY(Vector3 position, out bool hasClamped)
    {
        float originalY = position.y;

        position = ClampToStageY(position);

        hasClamped = originalY != position.y;

        return position;
    }

    public Vector3 ClampToStage(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, arena.MinX, arena.MaxX);
        position.y = Mathf.Clamp(position.y, arena.MinY, arena.MaxY);

        return position;
    }

    public Vector3 ClampToStage(Vector3 position, out bool hasClamped)
    {
        float originalX = position.x;
        float originalY = position.y;

        position = ClampToStage(position);

        hasClamped = originalX != position.x || originalY != position.y;

        return position;
    }
}
