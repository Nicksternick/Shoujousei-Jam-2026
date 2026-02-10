using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private AttackHandler attackHandler;
    [SerializeField] private AttackSelectionData attackSelection;

    public int Health => health;

    private void Start()
    {
        BattleManager.Instance.UpdateEnemyHealthUI(health);
    }

    private void FixedUpdate()
    {
        if (!attackHandler.AttackInProgress)
        {
            AttackData attack = GetAttack();

            if (attack != null)
            {
                attackHandler.SetupAttack(attack);
            }
            else
            {
                Debug.LogAssertion("Attack is Null");
            }
        }
    } 

    public void TakeDamage(int damage)
    {
        health -= damage;
        BattleManager.Instance.UpdateEnemyHealthUI(health);
    }

    private AttackData GetAttack()
    {
        if (attackSelection.AttackSelection.Length == 1)
        {
            return attackSelection.AttackSelection[0].AttackData;
        }

        List<int> weightChart = new List<int>();
        int weightRange = 0;
        foreach (AttackSelection selection in attackSelection.AttackSelection)
        {
            weightRange += selection.ActivationWeight;
            if (weightChart.Count == 0)
            {
                weightChart.Add(selection.ActivationWeight);
            }
            else
            {
                weightChart.Add(selection.ActivationWeight + weightChart[weightChart.Count - 1]);
            }
        }

        int selectedValue = Random.Range(0, weightRange);
        for (int i = 0; i < weightChart.Count; i++)
        {
            if (selectedValue <= weightChart[i])
            {
                return attackSelection.AttackSelection[i].AttackData;
            }
        }

        return null;
    }
}
