using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    [SerializeField] private GameObject theEnemy;
     private int xPos;
     private int zPos;
     public List<int> fiender = new List<int>();
     int enemiesLeft;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(EnemySpawn());

    }

    // Update is called once per frame
    void Update()
    {
        
       

        
    }

   
    IEnumerator EnemySpawn()
    {
         while (fiender.Count < 30)
        {
            fiender.Add(enemiesLeft);
            xPos = Random.Range(1, 51);
            zPos = Random.Range(1, 31);
            Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }
}

