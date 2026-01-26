using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    //protected delegate void OnPlayerHit(BattlePlayerController player);

    //protected OnPlayerHit onPlayerHit;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //onPlayerHit += (BattlePlayerController player) => { Debug.Log($"{player.gameObject.name} entered projectile"); };
    }

    private void FixedUpdate()
    {
        transform.position = Move(transform);
    }

    public abstract Vector3 Move(Transform transform);
    public abstract void OnPlayerHit(BattlePlayerController player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BattlePlayerController player = collision.GetComponent<BattlePlayerController>();
        if (player)
        {
            OnPlayerHit(player);
        }
    }
}
