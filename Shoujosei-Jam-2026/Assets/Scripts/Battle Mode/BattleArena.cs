using UnityEngine;

public class BattleArena : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collider;
    private float xOffset;
    private float yOffset;
    private Vector3 xyOffset;

    private void Awake()
    {
        xOffset = transform.position.x;
        yOffset = transform.position.y;
        xyOffset = new Vector3(xOffset, yOffset);
    }

    public float MinX
    {
        get { return collider.bounds.min.x; }
    }

    public float MinY
    {
        get { return collider.bounds.min.y; }
    }

    public float MaxX
    {
        get { return collider.bounds.max.x; }
    }

    public float MaxY
    {
        get { return collider.bounds.max.y; }
    }

    public Vector3 Center
    {
        get { return collider.bounds.center; }
    }

    public Vector3 CenterOnState()
    {
        return Center;
    }

    public Vector3 ClampToStageX(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, MinX, MaxX);
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
        position.y = Mathf.Clamp(position.y, MinY, MaxY);
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
        position.x = Mathf.Clamp(position.x, MinX, MaxX);
        position.y = Mathf.Clamp(position.y, MinY, MaxY);

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
