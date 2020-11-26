using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{ 
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (Input.GetKey("space"))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetMouseButton(0) && scene.name == "GameOver") 
        {
            SceneManager.LoadScene(1);
        }
    }
}
