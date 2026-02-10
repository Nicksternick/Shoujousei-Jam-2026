using UnityEngine;

public class BattleAttack : BattleAbility
{
    [SerializeField] private int damageAmount;
    public override void OnChargeComplete()
    {
        BattleManager.Instance.DealDamageToEnemy(damageAmount);
        isDestroy = true;
        Destroy(gameObject);
    }
}
