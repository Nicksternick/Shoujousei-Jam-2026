using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private AttackPattern pattern;

    private AttackData attackData;

    private int attackCounter = 0;
    private List<Vector3> spawnPositions = new List<Vector3>();
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
        spawnPositions.Clear();
        spawnPoints.Clear();
        attackCounter = 0;
        attacking = true;

        if (data.TriggerAtAllPoints)
        {
            spawnPoints = attackData.AttackPoints.ToList();
            foreach (ArenaPoints point in attackData.AttackPoints)
            {
                spawnPositions.Add(BattleManager.Instance.Arena.GetArenaPoint(point, attackData.Offset));
            }
        }
        else
        {
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
                spawnPositions.Add(BattleManager.Instance.Arena.GetArenaPoint(point, attackData.Offset));
            }
        }

        foreach (Vector3 point in spawnPositions)
        {
            ProjectileManager.Instance.SpawnHeadsUpWarning(point, () => { headsUpCounter--; });
        }

        headsUpCounter = spawnPositions.Count;
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

            for (int i = 0; i < spawnPositions.Count; i++)
            {
                Vector3 spawnPoint = spawnPositions[i];
                Vector3 spawnNormal = BattleManager.Instance.Arena.GetNormal(spawnPoints[i]);
                TickAttack(spawnPoint, spawnNormal);
            }
        }

        attackCounter++;
    }

    private void TickAttack(Vector3 spawnPosition, Vector3 normal)
    {
        pattern.UpdatePattern(spawnPosition, normal);
    }
}
