using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public static int score = 0;
    public static int lives = 3;

    void Update()
    {
        scoreText.text = "Score: " + GameManager.score;
        livesText.text = "Lives: " + GameManager.lives;
    }
}
