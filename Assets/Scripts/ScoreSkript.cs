using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSkript : MonoBehaviour
{
    public static int scoreValue; // Enkel score system.

    public Text score;


    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue; // Lägger till text "Score " plus hur mycket scorevalue för varje fiende dödat.
    }

}
