using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combatant : MonoBehaviour
{
    public string name;
    public int maxHP;
    public int currentHP;
    public int maxPP;
    public int currentPP;
    public int offense;
    public int defense;
    public int speed;
    public int iq;
    public int vitality;
    public int guts;
    public int luck;
    public bool isPartyMember = false;

    public void TakeDamage(int amount)
    {
        if (isPartyMember){
            StartCoroutine(RollingHPChange(amount));
        }
        
    }
    private IEnumerator RollingHPChange(int amount)
    {
        int targetAmount = amount; // Save the original amount to track
        bool isHealing = targetAmount > 0; // If it's healing, the amount will be positive

        while (targetAmount != 0 && currentHP > 0)
        {
            // If healing, increase health; if damaging, decrease health
            if (isHealing)
            {
                currentHP += 1;  // Heal 1 HP at a time
                targetAmount--;
            }
            else
            {
                currentHP -= 1;  // Damage 1 HP at a time
                targetAmount++;
            }

            // Ensure the HP doesn't go out of bounds
            currentHP = Mathf.Clamp(currentHP, 0, maxHP);

            yield return new WaitForSeconds(0.05f); // Adjust speed of change as needed
        }
    }
}