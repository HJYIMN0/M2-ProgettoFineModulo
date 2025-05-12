
using UnityEngine;
using System.Diagnostics;
using System;
[Serializable]

public class WEAPON 
{
    public enum DAMAGE_TYPE
    {
        PHYSICAL = 0,        
        MAGICAL = 1,        

    }

    private string name;
    [SerializeField] private DAMAGE_TYPE dmgtype;
    [SerializeField] private ELEMENT elem;
    [SerializeField] private Stats bonusStats;

    public WEAPON ()
    {


    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            UnityEngine.Debug.LogWarning("ERRORE! Il nome non è valido!");
        }
        else
        {
            this.name = name;
        }

        }

    public string GetName()
    {
        return name;    
    }

    public DAMAGE_TYPE GetDamageType()
    {
        return this.dmgtype;
    }

    public DAMAGE_TYPE SetDamageType(DAMAGE_TYPE dmgtype)
    {           
       this.dmgtype = dmgtype;
        return dmgtype;
    }
    public ELEMENT GetElement()
    {
        return this.elem;
    }

    public ELEMENT SetElement(ELEMENT elem)
    {
        this.elem = elem;
        return elem;        
    }

    public Stats GetBonusStats()
    {
        return this.bonusStats;    
    }

    public Stats SetBonusStats(Stats bonusStats)
    {
        this.bonusStats = bonusStats;
        return bonusStats;
    }

    



}