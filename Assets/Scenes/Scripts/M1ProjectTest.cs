using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class M1ProjectTest : MonoBehaviour
{
    HERO a;
    HERO b;
    WEAPON arma1 = new WEAPON();
    WEAPON arma2 = new WEAPON();
    public Stats statsGiocatore1 = new Stats();
    public Stats statsGiocatore2 = new Stats();
    
  

     public string nomeGiocatore1 = "Pino";
     public string nomeGiocatore2 = "Piero";
     public int hpGiocatore1 = 10;
     public int hpGiocatore2 = 10;


    public ELEMENT giocatore1Weakness = ELEMENT.FIRE;
    public ELEMENT giocatore2Weakness = ELEMENT.LIGHTNING;
    public ELEMENT giocatore1ElementResistance = ELEMENT.FIRE;
    public ELEMENT giocatore2ElementResistance = ELEMENT.LIGHTNING;
    public string nomeArma1 = "Totino";
    public string nomeArma2 = "Tino";
    public WEAPON.DAMAGE_TYPE dmgTypeArma1;
    public WEAPON.DAMAGE_TYPE dmgTypeArma2;
    public Stats StatsArma1 = new Stats();
    public Stats StatsArma2 = new Stats();
    public ELEMENT Weapon1Element = ELEMENT.FIRE;
    public ELEMENT Weapon2Element = ELEMENT.LIGHTNING;


    int turno = 0;






    // Start is called before the first frame update
    void Start()
    {
        //Stats statsA = new Stats(StatsGiocatore1);
        //a = new HERO(nomeGiocatore1, hpGiocatore1, statsA, giocatore1ElementResistance, giocatore1Weakness, arma1);
        //Stats statsB = new Stats(atkGiocatore2, defGiocatore2, resGiocatore2, spdGiocatore2, crtGiocatore2, aimGiocatore2, evaGiocatore2);
        //b = new HERO(nomeGiocatore2, hpGiocatore2, statsB, giocatore2ElementResistance,giocatore2Weakness, arma2);

        a = new HERO(nomeGiocatore1, hpGiocatore1, statsGiocatore1, giocatore1ElementResistance, giocatore1Weakness, arma1);
        b = new HERO(nomeGiocatore2, hpGiocatore2, statsGiocatore2, giocatore2ElementResistance, giocatore2Weakness, arma2);
        arma1.SetName(nomeArma1);
        arma2.SetName(nomeArma2);
        arma1.SetDamageType(dmgTypeArma1);
        arma2.SetDamageType(dmgTypeArma2);
        arma1.SetBonusStats(StatsArma1);
        arma2.SetBonusStats(StatsArma2);
        arma1.SetElement(Weapon1Element);
        arma2.SetElement(Weapon2Element);



        //Stats statsA = new Stats(atkGiocatore1, defGiocatore1, resGiocatore1, spdGiocatore1, crtGiocatore1, aimGiocatore1, evaGiocatore1);
        //Stats statsB = new Stats(atkGiocatore2, defGiocatore2, resGiocatore2, spdGiocatore2, crtGiocatore2, aimGiocatore2, evaGiocatore2);
        //a.Stats = statsA;
    }

    // Update is called once per frame
    void Update()
    {
        if (a.IsAlive() == true && b.IsAlive() == true)
        {
            
            while (turno == 0)
                {
                if (a.GetTotalStats().spd > b.GetTotalStats().spd)                              //Se giocatore a attacca per primo
                {
                    Debug.Log($"{a.GetName()} attaccerà per primo!");
                    if (GameFormulas.HasHit(a.GetTotalStats(), b.GetTotalStats()) == true)
                    {
                        b.TakeDamage(GameFormulas.CalculateDamage(a, b));
                    }
                    

                    turno = 1;
                }
                else if (a.GetTotalStats().spd < b.GetTotalStats().spd)                     //Se giocatore b attacca per primo
                {
                    Debug.Log($"{b.GetName()} attaccerà per primo!");
                    if (GameFormulas.HasHit(b.GetTotalStats(), a.GetTotalStats()) == true)
                    {
                        a.TakeDamage(GameFormulas.CalculateDamage(b, a));
                    }
                    turno = 2;
                }
                else
                {
                    turno = UnityEngine.Random.Range(1, 3);

                }                
            }
            if (turno == 1)
            {
                Debug.Log($"{b.GetName()} sta per attaccare!");
                if (GameFormulas.HasHit(b.GetTotalStats(), a.GetTotalStats()) == true)
                {
                    a.TakeDamage(GameFormulas.CalculateDamage(b, a));
                }
                turno = 2;
            }
            if (turno == 2)
            {
                Debug.Log($"{a.GetName()} sta per attaccare!");
                if (GameFormulas.HasHit(a.GetTotalStats(), b.GetTotalStats()) == true)
                {
                    b.TakeDamage(GameFormulas.CalculateDamage(a, b));
                }
                turno = 1;
            }
            if (turno > 2)
            {
                turno = 1;
            }

            Debug.Log($"Questi sono gli HP di{a.GetName()} {a.GetHp()}");
            Debug.Log($"Questi sono gli HP di{b.GetName()} {b.GetHp()}");

        }
        else if (a.IsAlive() == true && b.IsAlive() == false)
        {
            Debug.Log($"{a.GetName()} ha vinto!");
        }
        else if (a.IsAlive() == false && b.IsAlive() == true)
        {
            Debug.Log($"{b.GetName()} ha vinto!");
        }
        else
        {
            Debug.Log("Entrambi i soldati sono caduti...");        
        }
    }
}
