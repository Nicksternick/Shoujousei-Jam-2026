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
}
