using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Health
{
    public static Player instance; // För att hitta vår spelare och koppla det till andra klasser.

    public GameObject player; // Refera till vår spelare object hela tiden.

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }


}
