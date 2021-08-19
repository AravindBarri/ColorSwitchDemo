using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpawnPoint;
    public GameObject[] obstacles;
    public Stack<GameObject> ObstacleStack;
    private static ObstacleManager instance;

    public static ObstacleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ObstacleManager>();
            }
            return instance;
        }

    }
    void Start()
    {
        ObstacleStack = new Stack<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObstacle()
    {
        if (ObstacleStack.Count == 0)
        {
            CreateObstacles(3);
        }

        int index = Random.Range(0, obstacles.Length);


        GameObject temp = ObstacleStack.Pop();
        temp.SetActive(true);
        temp.transform.position = SpawnPoint.transform.position;
    }
    void CreateObstacles(int value)
    {
        for (int i = 0; i < value; i++)
        {
            int maxrange = obstacles.Length;
            int r = Random.Range(0, maxrange);
            ObstacleStack.Push(Instantiate(obstacles[r]));
            ObstacleStack.Peek().SetActive(false);
        }
    }
    public void AddToPool(GameObject tempObj)
    {
        ObstacleStack.Push(tempObj);
        ObstacleStack.Peek().SetActive(false);
    }
}
