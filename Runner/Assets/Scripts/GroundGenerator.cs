using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform GroundPoint;
    public Transform minHeight;
    public Transform maxHeight;

    private float minY;
    private float maxY;

    public float minGap;
    public float maxGap;

    public ObjectPooler[] pooler;
    private float[] groundWidth;

    private CoindGenerator coinGenerator;

    void Start()
    {
        groundWidth = new float[pooler.Length];
        for( int i = 0; i < pooler.Length; i++)
        {
             groundWidth[i] = pooler[i].poolObject.GetComponent<BoxCollider2D>().size.x;
            minY = minHeight.position.y;
            maxY = maxHeight.position.y;

        }
        coinGenerator = FindObjectOfType<CoindGenerator>();

    }

    
    void Update()
    {
        if (transform.position.x < GroundPoint.position.x)
        {
            int rand = UnityEngine.Random.Range(0, pooler.Length);
            float distance = groundWidth[rand]/4;
            float Y = UnityEngine.Random.Range(minY, maxY);
            float gap = UnityEngine.Random.Range(minGap, maxGap);

            transform.position=new Vector3(transform.position.x+distance+ gap , Y, transform.position.z);
            GameObject ground = pooler[rand].GetPooledObject();
            ground.transform.position = transform.position;
            ground.SetActive(true);

            coinGenerator.SpawnCoins(transform.position, groundWidth[rand]);
           transform.position = new Vector3(transform.position.x+distance+gap , transform.position.y, transform.position.z);



        }
    }
}
