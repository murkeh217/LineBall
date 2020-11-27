using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public PlayerController ball;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name + " triggered deathzone");

        ball.Death();

        GameManager.lives--;

        col.enabled = false;

        if (GameManager.lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

}
