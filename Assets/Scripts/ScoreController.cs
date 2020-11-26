using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public PlayerController ball;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.name + " triggered scorezone");
        GameManager.score++;  
    }
}