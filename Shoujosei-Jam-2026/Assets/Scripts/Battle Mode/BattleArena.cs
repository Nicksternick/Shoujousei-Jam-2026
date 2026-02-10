using UnityEngine;

public enum ArenaPoints
{
    Random,
    Center,
    TopLeft,
    Top,
    TopRight,
    BottomLeft,
    Bottom,
    BottomRight,
    Left,
    Right,
}

public class BattleArena : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collider;

    public float MinX => collider.bounds.min.x;

    public float MinY => collider.bounds.min.y;

    public float MaxX => collider.bounds.max.x;

    public float MaxY => collider.bounds.max.y;

    public Vector3 Center => collider.bounds.center;

    public Vector3 GetNormal(ArenaPoints pointType)
    {
        switch (pointType)
        {
            case ArenaPoints.Random:
                return Random.rotation.eulerAngles.normalized;

            case ArenaPoints.Center:
                return Random.rotation.eulerAngles.normalized;

            case ArenaPoints.Left:
                return Vector3.right;

            case ArenaPoints.Right:
                return Vector3.left;

            case ArenaPoints.Top:
                return Vector3.down;

            case ArenaPoints.Bottom:
                return Vector3.up;

            case ArenaPoints.TopLeft:
                return new Vector3(1, -1, 0).normalized;

            case ArenaPoints.TopRight:
                return new Vector3(-1, -1, 0).normalized;

            case ArenaPoints.BottomLeft:
                return new Vector3(1, 1, 0).normalized;

            case ArenaPoints.BottomRight:
                return new Vector3(-1, 1, 0);

            default:
                Debug.LogError("No Arena Point Chosen");
                return Center;
        }
    }

    public Vector3 GetArenaPoint(ArenaPoints pointType, float offset = 0)
    {
        float x;
        float y;
        switch (pointType)
        {
            case ArenaPoints.Random:
                x = Random.Range(MinX + offset, MaxX - offset);
                y = Random.Range(MinY + offset, MaxY - offset);
                return new Vector3(x, y, 0);

            case ArenaPoints.Center:
                return Center;

            case ArenaPoints.Left:
                x = MinX + offset;
                y = Center.y;
                return new Vector3(x, y, 0);

            case ArenaPoints.Right:
                x = MaxX - offset;
                y = Center.y;
                return new Vector3(x, y, 0);

            case ArenaPoints.Top:
                x = Center.x;
                y = MaxY - offset;
                return new Vector3(x, y, 0);

            case ArenaPoints.Bottom:
                x = Center.x;
                y = MinY + offset;
                return new Vector3(x, y, 0);

            case ArenaPoints.TopLeft:
                x = MinX + offset;
                y = MaxY - offset;
                return new Vector3(x, y, 0);

            case ArenaPoints.TopRight:
                x = MaxX - offset;
                y = MaxY - offset;
                return new Vector3(x, y, 0);

            case ArenaPoints.BottomLeft:
                x = MinX + offset;
                y = MinY + offset;
                return new Vector3(x, y, 0);

            case ArenaPoints.BottomRight:
                x = MaxX - offset;
                y = MinY + offset;
                return new Vector3(x, y, 0);

            default:
                Debug.LogError("No Arena Point Chosen");
                return Center;
        }
    }

    #region Clamping Functions
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
    #endregion
}
