using System.Collections;
using UnityEngine;

public class PooledObjectBehaviour : MonoBehaviour
{
    // Holds the info about its object pool
    public ObjectPool Pool { get; set; }
    public float speed = 9f;


    // Provides funtionaoity to the instantiated objects
    private void OnEnable()
    {
        StartCoroutine(DestroyPooledObject());
    }
    private void Update()
    {
        ApplyMovement();
    }
    IEnumerator DestroyPooledObject()
    {
        yield return new WaitForSeconds(4f);
        // returns the object to its pool instead of destroy
        ObjectPoolManager.ReturnObjectToPool(Pool.Name, this.gameObject);
    }

    // Apply movement towards left side
    public void ApplyMovement()
    {
        transform.position += ((Vector3.left * speed) * Time.deltaTime);
        
    }
}