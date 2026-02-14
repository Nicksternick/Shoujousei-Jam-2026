using System.Collections.Generic;
using UnityEngine;

public class BattleAbilitySpawner : MonoBehaviour
{
    [SerializeField] private BattleAbilityData abilities;
    [SerializeField] private int abilityCooldown = 0;
    [SerializeField] private int cooldownTimer;
    [SerializeField] private List<BattleAbility> activeAbilities = new  List<BattleAbility>();
    private void Start()
    {
        cooldownTimer = abilityCooldown;
    }

    private void FixedUpdate()
    {
        if (!BattleManager.Instance.BattleStarted) return;
        if (cooldownTimer > 0 && activeAbilities.Count == 0)
        {
            cooldownTimer -= 1;
        }
        else if (cooldownTimer <= 0 && activeAbilities.Count == 0)
        {
            foreach (BattleAbility ability in abilities.abilities)
            {
                Vector3 position = BattleManager.Instance.Arena.GetArenaPoint(ArenaPoints.Random, 3);

                BattleAbility abl = Instantiate(ability);

                abl.transform.position = position;

                activeAbilities.Add(abl);
            }

            cooldownTimer = abilityCooldown;
        }

        if (activeAbilities.Count > 0)
        {
            for (int i = 0; i < activeAbilities.Count; i++)
            {
                if (activeAbilities[i] == null)
                {
                    activeAbilities.Remove(activeAbilities[i]);
                }
            }
        }
    }
}
