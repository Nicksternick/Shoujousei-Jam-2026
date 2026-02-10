using UnityEngine;

public abstract class BattleAbility : MonoBehaviour
{
    [SerializeField] private BattleAbilitySprite sprite;
    [SerializeField] private int chargeTime;
    [SerializeField] private float counter = 0;
    [SerializeField] private bool isCharging;
    [SerializeField] private float decayFactor;
    protected bool isDestroy;

    public bool IsDestroy => isDestroy;

    private void FixedUpdate()
    {
        if (isCharging)
        {
            Charge();
        }
        else
        {
            Decay();
        }
    }

    private void Charge()
    {
        if (counter < chargeTime)
        {
            sprite.SetScale((float)counter / (float)chargeTime);
            counter++;
        }
        else
        {
            OnChargeComplete();
        }
    }

    private void Decay()
    {
        if (counter > 0)
        {
            sprite.SetScale((float)counter / (float)chargeTime);
            counter -= 1 * decayFactor;
        }
    }

    public abstract void OnChargeComplete();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BattlePlayerController player = collision.GetComponent<BattlePlayerController>();
        if (player)
        {
            isCharging = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        BattlePlayerController player = collision.GetComponent<BattlePlayerController>();
        if (player)
        {
            isCharging = false;
        }
    }
}
