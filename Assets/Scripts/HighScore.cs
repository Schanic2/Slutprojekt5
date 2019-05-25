using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    
    public Text highscoretext;

    public static int highScore;


    // Start is called before the first frame update
    void Start()
    {
        highscoretext = GetComponent<Text>(); // För att komma åt texten

        highScore = PlayerPrefs.GetInt("Highscore", highScore); // Spara det som fil.

        highscoretext.text = "" + highScore; // Skriver ut din highscore.
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreSkript.scoreValue > highScore) // Om din highscore är högre än vanlig score i spelet så blir highscore till vanlig score.
        {
            highScore = ScoreSkript.scoreValue;
            PlayerPrefs.SetInt("Highscore", highScore);
            highscoretext.text = highScore.ToString(); // Gör så att det uppdateras direkt och man behöver inte stänga av spelet för det ska updateras.
            
        }

    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Highscore", highScore); 
        PlayerPrefs.Save(); // Sparar Highscore när spelet avslutas.
    }

}
