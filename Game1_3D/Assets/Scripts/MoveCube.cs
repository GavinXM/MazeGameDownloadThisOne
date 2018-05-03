using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//HUD, Sound, Particle effect, Score
public class MoveCube : MonoBehaviour
{   // get rotaiton for correct camera positoin
    public GameMgr gameMgr;

    private float distToGround;
    public float speed;
    public float jumpSpeed;

    //float yRotation = cameraParent.transform.eulerAngles.y;

    private Rigidbody rb;
    // private int count;
    // private int countUp;
    public ParticleSystem _particleSystem;
    public float rotationSpeed = 100.0f;
    private float yCube;

    // public Text StarText;
    // public Text UpText;



    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        gameMgr.count = 0;
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        yCube = rb.position.y;
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
                gameMgr.audioSource.Play();
            }
            else if (!IsMoving() && !IsGrounded())
            {
                rb.velocity = Vector3.up * jumpSpeed;
                gameMgr.audioSource.Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            gameMgr.count = gameMgr.count + 1;
            //  Debug.Log("Star: " + count);
            gameMgr.SetCountText();
            gameMgr.pick.Play();

        }

        if (other.gameObject.CompareTag("1Up"))
        {
            other.gameObject.SetActive(false);
            gameMgr.countUp = gameMgr.countUp + 1;
            //  Debug.Log("1Up: " + countUp);
            gameMgr.SetCountTextUp();
            gameMgr.pick.Play();

        }

        if (other.gameObject.CompareTag("Ending"))
        {
            gameMgr.SetCountWinText();
            gameMgr.winB.enabled = true;
            gameMgr.winB2.enabled = true;
            gameMgr.finish.Play();
        }

    }


}
