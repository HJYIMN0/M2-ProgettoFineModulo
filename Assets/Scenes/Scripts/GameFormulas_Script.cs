using System;
using Unity.VisualScripting;
using UnityEngine;

static class GameFormulas
{
    public static bool HasElementAdvantage(ELEMENT attackElement, HERO defender)
    {
        if (attackElement == defender.GetWeakness())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool HasElementDisadvantage(ELEMENT attackElement, HERO defender)
    {
        if (attackElement == defender.GetResistance())
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

    public static float EvaluateElementalModifier(ELEMENT attackElement, HERO defender)
    {
        if (HasElementAdvantage(attackElement, defender) == true)
        {
            Debug.Log("È superefficace!");
            return 1.5f;            
        }
        else if (HasElementDisadvantage(attackElement, defender) == true)
        {
            Debug.Log("Non è molto efficace...");
            return 0.5f;          

        }
        else 
        {
            return 1f;
        }
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int x = attacker.aim - defender.eva;        
        int y = UnityEngine.Random.Range(0, 99);       

        if (x > y)
        {
            return true;
        }
        else
        {
            Debug.Log("Miss!");
            return false;            
        }
    }

    public static bool IsCrit(int critValue)
    {
        if (critValue < UnityEngine.Random.Range(0, 99))
        {
            return false;
        }
        else
        {
            Debug.Log("CRIT");
            return true;
        }        
    }

    public static int CalculateDamage(HERO attacker, HERO defender)
    {

        Stats attackerStats = Stats.Sum(attacker.GetTotalStats(), attacker.GetWeapon().GetBonusStats());
        
        Stats defenderStats = Stats.Sum(defender.GetTotalStats(), defender.GetWeapon().GetBonusStats());

        int defenderDefense;

        if (attacker.GetWeapon().GetDamageType() == WEAPON.DAMAGE_TYPE.PHYSICAL)
        {
            defenderDefense = defenderStats.def;

        }
        else
        {
            defenderDefense = defenderStats.res;
        }
        int dannoInflitto = attackerStats.atk - defenderDefense;

        dannoInflitto *= Mathf.RoundToInt(GameFormulas.EvaluateElementalModifier(attacker.GetWeapon().GetElement(), defender));

        if (GameFormulas.IsCrit(attackerStats.crt) == true)
        {
            dannoInflitto += 2;

        }


        if (dannoInflitto >= 0)
        {
            return dannoInflitto;
        }
        else
        {
            dannoInflitto = 0;
            return dannoInflitto;
            
        }

        
    }


}
