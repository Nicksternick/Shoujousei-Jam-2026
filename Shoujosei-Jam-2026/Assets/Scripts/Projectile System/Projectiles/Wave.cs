using UnityEngine;

public class Wave : Projectile
{
    [SerializeField] private float waveTurnAmplitudeDegPerSec = 180f; // max turn rate
    [SerializeField] private float waveFrequencyHz = 1.5f;            // cycles per second
    [SerializeField] private float wavePhase = 0f;                    // radians
    private float startTime;

    public float StartTime
    {
        get { return startTime; }
        set { startTime = value; }
    }

    public override ProjectileType Type => ProjectileType.Wave;
    public override Vector3 Move(Transform transform)
    {
        Vector3 position = transform.position;

        bool clamped;
        BattleManager.Instance.Arena.ClampToStage(position, out clamped);
        if (clamped) { ProjectileManager.Instance.ReturnProjectileToPool(this); ; }

        position += direction * speed;

        // sine-based turning
        if (waveTurnAmplitudeDegPerSec != 0f && waveFrequencyHz != 0f)
        {
            float t = Time.time - startTime;

            // sine in [-1, 1]
            float s = Mathf.Sin((t * waveFrequencyHz * Mathf.PI * 2f) + wavePhase);

            // turn this frame in degrees (rate * dt)
            float turnDeg = s * waveTurnAmplitudeDegPerSec * Time.deltaTime;

            direction = Quaternion.AngleAxis(turnDeg, Vector3.forward) * direction;

            // keep in XY plane (if you're using 2D-in-3D)
            direction.z = 0f;
            direction.Normalize();
        }

        return position;
    }

    public override void OnPlayerHit(BattlePlayerController player)
    {
        player.TakeDamage(damage);
        ProjectileManager.Instance.ReturnProjectileToPool(this);
    }
}
