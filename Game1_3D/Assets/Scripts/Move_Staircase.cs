using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Staircase : MonoBehaviour
{

    public GameMgr gameMgr;
    public float speed;
    public float jumpSpeed;

    private float distToGround;

    private Rigidbody rb;
    private int count;
    public ParticleSystem __particleSystem;

    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        count = 0;
        __particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + .6));
    }

    public bool IsMoving()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            return true;
        }
        return false;
    }

    void FixedUpdate()
    {

        if (gameMgr.currentPlayer != GameMgr.Player_Staircase)
        {
            return;
        }

        float dt = Time.deltaTime;
        float dx = Input.GetAxis("Horizontal"); // left/right arrow keys (AD keys)
        float dz = Input.GetAxis("Vertical");   // up/down arrow keys (WS keys)
                                                // The values of x and z are between -1.0 and 1.0
                                                // Debug.Log(string.Format("x={0,4}  z={1,4}", x, z));
        float x = transform.position.x;
        float z = transform.position.z;
        x += speed * dt * dx;
        z += speed * dt * dz;
        transform.position = new Vector3(x, 0.5f, z);

    }
}
