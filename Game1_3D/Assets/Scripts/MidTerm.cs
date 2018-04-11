using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidTerm : MonoBehaviour
{

    public GameObject parent13;
    public GameObject prefab13;

   /* void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "P0yi")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.name == "P0er")
        {
            Destroy(col.gameObject);
        }
    }*/





    private float rand(float min, float max)
    {
        return Random.Range(min, max);
    }

    private void gen(GameObject prefab, string name,
                    float px, float py, float pz,
                    float rx, float ry, float rz,
                    float sx, float sy, float sz)
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = new Vector3(px, py, pz);
        go.transform.localRotation = Quaternion.Euler(rx, ry, rz);
        go.transform.localScale = new Vector3(sx, sy, sz);
        go.transform.parent = parent13.transform;
        go.name = name;
    }

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            if (i%2 == 0)
            {
                gen(prefab13, "P0yi", rand(-20, 20), 1, rand(-20, 20), 0, 0, 0, 1, 1, 1);
            }
            else
            {
                gen(prefab13, "P0er", rand(-20, 20), 1, rand(-20, 20), 0, 90, 0, 1, 1, 1);
            }
        }
       /* gen(prefab13, "P0yi", rand(-20,20), 1, rand(-20,20), 0, 0, 0, 1, 1, 1);
        gen(prefab13, "P0er", rand(-20,20), 1, rand(-20,20), 0, 90, 0, 1, 1, 1);
        gen(prefab13, "P0er", rand(-20, 20), 1, rand(-20, 20), 0, 90, 0, 1, 1, 1);
        gen(prefab13, "P0er", rand(-20, 20), 1, rand(-20, 20), 0, 0, 0, 1, 1, 1);
        gen(prefab13, "P0er", rand(-20, 20), 1, rand(-20, 20), 0, 90, 0, 1, 1, 1);
        gen(prefab13, "P0er", rand(-20, 20), 1, rand(-20, 20), 0, 0, 0, 1, 1, 1);
        gen(prefab13, "P0er", rand(-20, 20), 1, rand(-20, 20), 0, 0, 0, 1, 1, 1);*/

        // I need to add a way to detect collision.

       
    }

}
