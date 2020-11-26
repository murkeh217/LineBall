using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public Text finalScoreText;

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (Input.GetKey("space") && scene.name == "Lobby")
        {
            SceneManager.LoadScene(1);
        }

        if (scene.name == "GameOver")
        {
            finalScoreText.text = "Final Score: " + GameManager.score;
        }

        if (Input.GetMouseButton(0) && scene.name == "GameOver") 
        {
            GameManager.lives = 3;
            GameManager.score = 0;
            SceneManager.LoadScene(1);
        }

       
    }
}
