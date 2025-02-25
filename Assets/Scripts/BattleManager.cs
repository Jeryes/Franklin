using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<Combatant> players;
    public List<Combatant> enemies;
    private List<Combatant> turnOrder;

    void Start()
    {
        DetermineTurnOrder();
    }

    public void DetermineTurnOrder()
    {
        turnOrder = players.Concat(enemies)
            .OrderByDescending(c => c.speed)
            .ToList();
    }

    public void PerformTurn(Combatant attacker, Combatant target)
    {
        int damage = CalculateDamage(attacker, target);
        target.TakeDamage(damage);
    }

    private int CalculateDamage(Combatant attacker, Combatant defender)
    {
        float randomMultiplier = UnityEngine.Random.Range(0.9f, 1.1f);
        int baseDamage = Mathf.Max(1, attacker.offense - defender.defense);
        return Mathf.RoundToInt(baseDamage * randomMultiplier);
    }
}