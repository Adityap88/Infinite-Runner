using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoindGenerator : MonoBehaviour
{
    public ObjectPooler pooler;



    public void SpawnCoins( Vector3 position,float groundwidth)

    {
        int random = UnityEngine.Random.Range(0, 100);
        if (random < 60)
        {
            return;
        }
        int Y = (int)UnityEngine.Random.Range(2f, 4f);
        int X = (int)UnityEngine.Random.Range(3f, 6f);

   
        int rand = (int)UnityEngine.Random.Range(2f, groundwidth/4);
        for (int i= 0; i < rand; i++)
        {
            GameObject coin = pooler.GetPooledObject();
            float x = position.x - (groundwidth / 4);
            coin.transform.position = new Vector3(x + i + X,
                position.y + Y,
                0);

            coin.SetActive(true);

        }
      
    }
}
