using UnityEngine;
using System.Collections.Generic;

public class EnemyEncounter : MonoBehaviour
{
    public List<Combatant> possibleEnemies;

    public List<Combatant> GetEnemyParty()
    {
        int enemyCount = Random.Range(1, 3); // 1-2 enemies for now
        List<Combatant> enemyParty = new List<Combatant>();

        for (int i = 0; i < enemyCount; i++)
        {
            enemyParty.Add(Instantiate(possibleEnemies[Random.Range(0, possibleEnemies.Count)]));
        }

        return enemyParty;
    }
}