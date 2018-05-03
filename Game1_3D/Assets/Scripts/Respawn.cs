using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
    public GameMgr gameMgr;
    public float num1_x;
    public float num2_y;
    public float num3_z;
    

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spawn")
        {

            transform.position = new Vector3(num1_x, num2_y, num3_z);
            gameMgr.res.Play();
        }
    }
    

}