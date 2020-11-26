using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public float speed;

    public float queueTime = 0f;

    public GameObject obstaclePrefab = null;

    private Coroutine _coroutine;

    public PlayerController ball;

    public float _spawnDistance = 0f;

    Queue<GameObject> _activeObstacles = new Queue<GameObject>();
    Queue<GameObject> _pooledObstacles = new Queue<GameObject>();

    GameObject SpawnObstacle(Vector2 position, float rotation)
    {
        GameObject obstacle;
        if (_pooledObstacles.Count == 0)
        {
            obstacle = Instantiate(obstaclePrefab);
        }
        else
        {
            obstacle = _pooledObstacles.Dequeue();
            obstacle.SetActive(true);
        }
        obstacle.transform.position = position;
        obstacle.transform.rotation = Quaternion.Euler(0, 0, rotation);
        //Debug.Log("Rotation is: " + rotation + " Position is: " + position, obstacle);
        //Debug.Break();
        _activeObstacles.Enqueue(obstacle);

        return obstacle;
    }

    void Repool(GameObject obstacle)
    {
        obstacle.SetActive(false);
        _pooledObstacles.Enqueue(obstacle);
    }

    private IEnumerator Spawner()
    {
        Camera camera = Camera.main;
        var x = camera.transform.position.x + camera.orthographicSize * camera.aspect + _spawnDistance;

        while (true)
        {
            yield return new WaitForSeconds(queueTime);

            switch (Random.Range(0, 4))
            {
                case 0:
                    SpawnObstacle(new Vector2(x, 4), 180);
                    break;

                case 1:
                    SpawnObstacle(new Vector2(x, -4), 0);
                    break;

                case 2:
                    SpawnObstacle(new Vector2(x, 2), 180);
                    break;

                case 3:
                    SpawnObstacle(new Vector2(x, -2), 0);
                    break;

                default:
                    Debug.Log("Empty");
                    break;
            }

            if (_activeObstacles.Count > 0)
            {
                var leftMost = _activeObstacles.Peek();

                Debug.Log("Active Obstacles: " + _activeObstacles + " Position of x: " + leftMost.transform.position.x + " Camera position: " + Camera.main.transform.position.x + " t/f: " + leftMost.GetComponentInChildren<Renderer>().isVisible);

                if (leftMost.transform.position.x < camera.transform.position.x)
                {
                    Repool(_activeObstacles.Dequeue());
                }
            }


        }
    }

    void Update()
    {
        transform.position += ((Vector3.left * speed) * Time.deltaTime);
    }

    void Start()
    {
        _coroutine = StartCoroutine(Spawner());
    }
}
