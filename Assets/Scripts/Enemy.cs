using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Health
{   

    public void Hit(int dmgAmount)
    {
        HP -= dmgAmount;
        if (HP <= 0)
        {
            isDead = true;
            Death();
        }
    }

    public void Death()
   {
        if (isDead == true)
        {
            StartCoroutine(Die()); 
        }
    }
    public IEnumerator Die()
    {
        Destroy(gameObject);
        ScoreSkript.scoreValue += 10;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
