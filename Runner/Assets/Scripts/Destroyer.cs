using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject destroy;
    void Start()
    {
        destroy = GameObject.Find("GroundEndPoint");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x< destroy.transform.position.x )
        {
            gameObject.SetActive(false);
        }
    }
}
