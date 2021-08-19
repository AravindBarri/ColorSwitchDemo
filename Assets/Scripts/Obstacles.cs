using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    Rigidbody2D tempRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        tempRigidbody = GetComponent<Rigidbody2D>();
        //StartCoroutine(StartSpawn());
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine(StartSpawn());
            //Debug.Log("Spawn TILE");
        }
        if(other.tag == "DestroyPoint")
        {
            StartCoroutine(PushToStack());
        }
    }
    IEnumerator PushToStack()
    {
        yield return new WaitForSeconds(2);
        ObstacleManager.Instance.AddToPool(this.gameObject);
    }
    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(1);
        ObstacleManager.Instance.SpawnObstacle();
    }
}
