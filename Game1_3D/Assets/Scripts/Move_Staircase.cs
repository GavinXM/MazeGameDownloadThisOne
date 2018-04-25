using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Staircase : MonoBehaviour
{     // Get rotation for correct camera position

    public GameMgr gameMgr;
    public float speed;
    public float jumpSpeed;

    private float distToGround;
    //public Text text;
    private Rigidbody rb;
    private int count;
    private int countUp;
    public ParticleSystem __particleSystem;
    public float rotationSpeed = 100.0f;
    private float yStair;

    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        count = 0;
        __particleSystem = GetComponentInChildren<ParticleSystem>();
        yStair = rb.position.y;
       // SetCountText();
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
        
        if (Input.GetKeyDown(KeyCode.Space)) /// maybe add while not moving to stop clipping issue.
        {
            float rotation = Input.GetAxis("Horizontal");
            //rotation *= Time.deltaTime;
            rotation += 90;
            transform.Rotate(0, rotation, 0);
        }
        float translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        Vector3 movement = new Vector3(0.0f, 0.0f, translation);

        float translation2 = Input.GetAxis("Horizontal") * speed;
        translation2 *= Time.deltaTime;
        transform.Translate(translation2, 0, 0);
        Vector3 movement2 = new Vector3(translation2, 0.0f, 0.0f);


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
    /*
    void SetCountText()
    {
       // countText.text = "Count: " + count.ToString();
    }

    void SetCountText()
    {
       // countText.text = "Count: " + count.ToString();
    }*/
}
