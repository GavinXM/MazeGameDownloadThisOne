using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer3 : MonoBehaviour
{

    public GameMgr gamemgr;
    public static MeshRenderer mesh;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }

    private void Update()
    {
        if (gamemgr.currentPlayer == GameMgr.Player_Staircase)
        {
            mesh.enabled = true;
        }
        else
        {
            mesh.enabled = false;
        }
    }
   
}



