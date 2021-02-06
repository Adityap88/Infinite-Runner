using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using UnityEngine;

public class ObjectPooler : MonoBehaviour

{
    public GameObject poolObject;
    public int numOfObj;
    private List<GameObject> objectList;

    // Start is called before the first frame update
    void Start()
    {
        objectList = new List<GameObject>();
        for (int i = 0; i < numOfObj; i++)
          
        {
            GameObject gameobject = Instantiate(poolObject);
            gameobject.SetActive(false);
            objectList.Add(gameobject);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject game in objectList)
        {
            if (!game.activeInHierarchy)
            {
                return game;
            }
        }
        GameObject obj = Instantiate(poolObject);
        obj.SetActive(false);
        objectList.Add(obj);
        return obj;
    }
}
