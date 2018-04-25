using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Letter_L : MonoBehaviour
{

    public GameMgr gameMgr;
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed = 100.0f;
    private float distToGround;

    private Rigidbody rb;
    private int count;
    private int countUp;
    public ParticleSystem ___particleSystem;
    private float yL;
    private float xL;
    private float zL;

    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        count = 0;
        ___particleSystem = GetComponentInChildren<ParticleSystem>();
        yL = rb.position.y;
        xL = rb.position.x;
        zL = rb.position.z;
        
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

        if (gameMgr.currentPlayer != GameMgr.Player_LetterL)
        {
            return;
        }
        
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        float translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        Vector3 movement = new Vector3(0.0f, 0.0f, translation);

        // float dt = Time.deltaTime;
        // float dx = Input.GetAxis("Horizontal"); // left/right arrow keys (AD keys)
        // float dz = Input.GetAxis("Vertical");   // up/down arrow keys (WS keys)
        // The values of x and z are between -1.0 and 1.0
        // Debug.Log(string.Format("x={0,4}  z={1,4}", x, z));
        //   float x = transform.position.x;
        //   float z = transform.position.z;
        //   x += speed * dt * dx;
        //   z += speed * dt * dz;
        //  transform.position = new Vector3(x, 0, z);


    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            gameMgr.count = gameMgr.count + 1;
            //  Debug.Log("Star: " + count);
            gameMgr.SetCountText();

        }

        if (other.gameObject.CompareTag("1Up"))
        {
            other.gameObject.SetActive(false);
            gameMgr.countUp = gameMgr.countUp + 1;
            //  Debug.Log("1Up: " + countUp);
            gameMgr.SetCountTextUp();

        }

    }


}
