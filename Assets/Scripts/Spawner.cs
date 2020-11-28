using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float queueTime = 0f;
    private Coroutine _coroutine;
    public float _spawnDistance = 0f;

    void Start()
    {
        _coroutine = StartCoroutine(Spawnner());
    }

    public IEnumerator Spawnner()
    {
        Camera camera = Camera.main;
        var x = camera.transform.position.x + camera.orthographicSize * camera.aspect + _spawnDistance;

        while (true)
        {
            yield return new WaitForSeconds(queueTime);

            switch (Random.Range(0,4))
            {
                case 0:
                    //works
                    ObjectPoolManager.GetObjectFromPool("Pipes", new Vector2(x, 4), 180);
                    break;

                case 1:
                    //doesnt work
                    ObjectPoolManager.GetObjectFromPool("Pipes", new Vector2(x, -4), 0);
                    break;

                case 2:
                    //doesnt work
                    ObjectPoolManager.GetObjectFromPool("Pipes", new Vector2(x, 2), 180);
                    break;

                case 3:
                    //works
                    ObjectPoolManager.GetObjectFromPool("Pipes", new Vector2(x, -2), 0);
                    break;

                default:
                    Debug.Log("Empty");
                    break;
            }


        }
    }
}
