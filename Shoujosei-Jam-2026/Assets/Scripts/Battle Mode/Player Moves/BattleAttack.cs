using UnityEngine;

public class BattleAttack : BattleAbility
{
    [SerializeField] private int damageAmount;
    public override void OnChargeComplete()
    {
        AudioManager.Instance.PlaySound(SoundType.PlayerAttack);
        BattleManager.Instance.DealDamageToEnemy(damageAmount);
        isDestroy = true;
        Destroy(gameObject);
    }
}
