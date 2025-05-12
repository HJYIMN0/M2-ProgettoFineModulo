using UnityEngine;
public class Attack
{
    public void AttackScene(HERO a, HERO b)
    {
        while (a.IsAlive() == true && b.IsAlive() == true)
        {
            int turno;
            if ((a.GetTotalStats().spd + a.GetWeapon().GetBonusStats().spd) > (b.GetTotalStats().spd + b.GetWeapon().GetBonusStats().spd))
            {
                Debug.Log($"{a.GetName()} attaccerà per primo!");
                if (GameFormulas.HasHit(a.GetTotalStats(), b.GetTotalStats()) == true)
                {
                    GameFormulas.CalculateDamage(a, b);
                }
                turno = 0;
            }
            else
            {
                Debug.Log($"{b.GetName()} attaccerà per primo!");
                if (GameFormulas.HasHit(b.GetTotalStats(), a.GetTotalStats()) == true)
                {
                    GameFormulas.CalculateDamage(b, a);
                }
                turno = 1;
            }
            if (turno == 0)
            {
                Debug.Log($"{b.GetName()} sta per attaccare!");
                if (GameFormulas.HasHit(b.GetTotalStats(), a.GetTotalStats()) == true)
                {
                    GameFormulas.CalculateDamage(b, a);
                }
                turno++;
            }
            if (turno == 1)
            {
                Debug.Log($"{a.GetName()} Sta per attaccare!");
                if (GameFormulas.HasHit(a.GetTotalStats(), b.GetTotalStats()) == true)
                {
                    GameFormulas.CalculateDamage(a, b);
                }
                turno++;
            }
            if (turno > 1)
            {
                turno = 0;
            }
        }
    }
}
