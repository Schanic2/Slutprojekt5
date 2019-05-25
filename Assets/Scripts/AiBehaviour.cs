using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBehaviour : MonoBehaviour
{
    public float lookRadius = 15f; // Hur långt fienden kan se och börjar gå mot en.

    Transform target;
    NavMeshAgent agent; // Nav mesh bannan

     void Start()
    {
        target = Player.instance.player.transform; // Refera till vår spelare.
        agent = GetComponent<NavMeshAgent>(); // Kod för vägledning till vår spelare.
    }

    void OnDrawGizmosSelected() // Skapa en röd boll area.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius); 
    }
     void Update() // Gör så att enemy går mot vår spelare om de är inne i enemy lookRadius.
    {
        float distance = Vector3.Distance(target.position, transform.position); // Hämta information för hur långt spelaren är från enemies.

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position); // Börja gå mot spelaren.

            if (distance <= agent.stoppingDistance)
            {
                // Kåd för att enemy attackera spelaren.
            }
        }
    }

}
