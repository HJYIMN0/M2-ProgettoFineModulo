
using UnityEngine;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class HERO
{
    private string name;
    private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private WEAPON weapon;
    public HERO(string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, WEAPON weapon)
    {

        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapon = weapon;

    }

    public string GetName()
    {
        return this.name;
    }

    public string SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("ERRORE! Il nome selezionato non è valido!");
            return this.name;
        }
        else
        {
            this.name = name;
            return name;
        }
    }

    public int GetHp()
    { 
     return hp;
    }

    public int SetHp(int hp)
    {
        if (hp < 0)
        {
            Debug.LogError("ERRORE! Il valore inserito non è valido!");
            return this.hp;
        }
        else
        {
            this.hp = hp;
            return hp;
        }
    }

    public ELEMENT GetWeakness()
    { 
        return weakness;
    
    }

    public ELEMENT GetResistance()
    { 
        return resistance;

    }

    public Stats GetTotalStats()
    {
        Stats totalStats = new Stats();

        totalStats.atk = baseStats.atk + weapon.GetBonusStats().atk;
        totalStats.def = baseStats.def + weapon.GetBonusStats().def;
        totalStats.res = baseStats.res + weapon.GetBonusStats().res;
        totalStats.spd = baseStats.spd + weapon.GetBonusStats().spd;
        totalStats.crt = baseStats.crt + weapon.GetBonusStats().crt;
        totalStats.aim = baseStats.aim + weapon.GetBonusStats().aim;
        totalStats.eva = baseStats.eva + weapon.GetBonusStats().eva;

        return totalStats;
    }

    public WEAPON GetWeapon()
    {
        return weapon;
    }

    public int AddHp(int amount)
    {
        this.hp += amount;
        return hp;
    }

    public int TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            Debug.Log("Non mi hai fatto niente!");
            return 0;
        }
        else
        {
            AddHp(-damage);
            return hp;
        }

    }

    public bool IsAlive()
    {
        if (GetHp() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
