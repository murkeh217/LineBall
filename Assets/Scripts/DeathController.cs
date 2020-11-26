using System;
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

        StopCoroutine(FindObjectOfType<ObstaclesController>().Spawner());

        StartCoroutine(FindObjectOfType<ObstaclesController>().Spawner());

        if (GameManager.lives <= 0)
        {
            SceneManager.LoadScene(2);
            GameManager.lives = 3;
            GameManager.score = 0;
            //this.enabled = false;
  
        }
    }

}
