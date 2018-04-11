using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveCube : MonoBehaviour
{
    public GameMgr gameMgr;

    private float distToGround;
    public float speed;
    public float jumpSpeed;
    

    private Rigidbody rb;
    private int count;
    public ParticleSystem _particleSystem;
    public float rotationSpeed = 100.0f;




    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        count = 0;
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + .2));
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

        if (gameMgr.currentPlayer != GameMgr.Player_Box)
        {
            return;
        }
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        // FIX and DECIDE on MOVEMENT

        //float moveHorizontal = Input.GetAxis("Horizontal");
        /////float moveVertical = Input.GetAxis("Vertical");
        if (!IsGrounded())
        {
            float translation = Input.GetAxis("Vertical") * speed;
            translation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            Vector3 movement = new Vector3(0.0f, 0.0f, translation);
        }


       // rb.AddForce(translation * speed);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb.velocity = Vector3.up * jumpSpeed;
            }
            else if (!IsMoving() && !IsGrounded())
            {
                rb.velocity = Vector3.up * jumpSpeed;
            }
        }
    }

}