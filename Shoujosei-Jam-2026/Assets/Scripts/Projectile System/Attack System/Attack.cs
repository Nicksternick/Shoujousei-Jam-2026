using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private AttackPattern pattern;

    private AttackData attackData;

    private int attackCounter = 0;
    private List<ArenaPoints> spawnPoints = new List<ArenaPoints>();
    private bool attacking = false;

    public bool Attacking => attacking;

    private int headsUpCounter;

    public void SetupAttack(AttackData data)
    {
        attackData = data;
        pattern = data.Pattern;
        pattern.SetDamage(attackData.Damage);
        pattern.SetSpeed(attackData.Speed);
        spawnPoints.Clear();
        attackCounter = 0;
        attacking = true;

        if (data.TriggerAtAllPoints)
        {
            spawnPoints = attackData.AttackPoints.ToList();
        }
        else
        {
            spawnPoints = new List<ArenaPoints>();

            List<ArenaPoints> controlList = attackData.AttackPoints.ToList();
            int numberToSelect = 0;
            if (attackData.MinPoints == attackData.MaxPoints)
            {
                numberToSelect = attackData.MaxPoints;
            }
            else
            {
                numberToSelect = Random.Range(attackData.MinPoints, attackData.MaxPoints + 1);
            }

            for (int i = 0; i < numberToSelect; i++)
            {
                ArenaPoints point = controlList[Random.Range(0, controlList.Count())];
                controlList.Remove(point);
                spawnPoints.Add(point);
            }
        }

        foreach (ArenaPoints point in spawnPoints)
        {
            ProjectileManager.Instance.SpawnHeadsUpWarning(BattleManager.Instance.Arena.GetArenaPoint(point, attackData.Offset), () => { headsUpCounter--; });
        }

        headsUpCounter = spawnPoints.Count;
    }

    public void UpdateAttack()
    {
        if (headsUpCounter > 0) return;

        if (attackCounter >= attackData.AttackLength)
        {
            attacking = false;
        }
        else if (attackCounter % attackData.AttackRate == 0)
        {
            pattern.TickPattern();
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                ArenaPoints point = spawnPoints[i];
                TickAttack(BattleManager.Instance.Arena.GetArenaPoint(point, attackData.Offset));
            }
        }

        attackCounter++;
    }

    private void TickAttack(Vector3 spawnPosition)
    {
        pattern.UpdatePattern(spawnPosition);
    }
}
