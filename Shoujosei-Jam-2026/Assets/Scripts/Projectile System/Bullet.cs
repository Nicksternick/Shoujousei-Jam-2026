using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;

    private void Start()
    {
        direction = Random.rotation.eulerAngles.normalized; 
    }

    public override Vector3 Move(Transform transform)
    {
        Vector3 position = transform.position;

        position += direction * speed;

        bool clampedX ;
        bool clampedY;
        BattleManager.instance.ClampToStageX(position, out clampedX);
        BattleManager.instance.ClampToStageY(position, out clampedY);

        direction.x *= clampedX ? -1 : 1;
        direction.y *= clampedY ? -1 : 1;

        return position;
    }

    public override void OnPlayerHit(BattlePlayerController player)
    {
        player.TakeDamage(10);
    }
}
