using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private Attack currentAttack;

    public bool AttackInProgress => currentAttack.Attacking;

    public void SetupAttack(AttackData data)
    {
        currentAttack.SetupAttack(data);
    }

    private void FixedUpdate()
    {
        if (AttackInProgress)
        {
            currentAttack.UpdateAttack();
        }
    }
}
