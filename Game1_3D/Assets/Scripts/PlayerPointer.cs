using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour
{

    public GameMgr gamemgr;
    public static MeshRenderer mesh;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = true;
    }

    private void Update()
    {
        if (gamemgr.currentPlayer == GameMgr.Player_Box)
        {
            mesh.enabled = true;
        }
        else
        {
            mesh.enabled = false;
        }
    }
}
    
	

