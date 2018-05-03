using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
// CAMERA PORTION NOT WORKING
public class GameMgr : MonoBehaviour {
    public const int Player_Box = 0;
    public const int Player_LetterL = 1;
    public const int Player_Staircase = 2;
    public int currentPlayer = Player_Box;
    public MoveCube moveCube;
    public Move_Staircase moveStair;
    public Move_Letter_L moveL;
    public GameObject Box;
    public GameObject L;
    public GameObject Stair;
    // Change parent of camera   DO shift up down left right for camera thing
    // chnage orientation on botton press.
    public GameObject FPSCamera;

    public int count;
    public int countUp;
    public Text StarText;
    public Text WinText;
    public Text UpText;
    public RawImage winB;
    public RawImage winB2;
    public RawImage start;
    public Text startText;
    public AudioSource audioSource;
    public AudioSource res;
    public AudioSource pick;
    public AudioSource finish;
    public AudioSource switch22;



    private void Start()
    {
        startText.enabled = true;
        winB.enabled = false;
        winB2.enabled = false;
        start.enabled = true;
        currentPlayer = Player_Box;
        moveCube._particleSystem.Play();
        moveStair.__particleSystem.Stop();
        moveL.___particleSystem.Stop();
        FPSCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Box = GameObject.FindGameObjectWithTag("Player");
        L = GameObject.FindGameObjectWithTag("Player2");
        Stair = GameObject.FindGameObjectWithTag("Player3");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startText.enabled = false;
            start.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            switch22.Play();
            startText.enabled = false;
            start.enabled = false;
            currentPlayer = Player_Box;
            moveCube._particleSystem.Play();
            moveStair.__particleSystem.Stop();
            moveL.___particleSystem.Stop();
            FPSCamera.transform.parent = Box.transform;
            FPSCamera.transform.position = Box.transform.position;
            FPSCamera.transform.rotation = Box.transform.rotation;

            float a3 = FPSCamera.transform.position.x;
            float b3 = FPSCamera.transform.position.y;
            float c3 = FPSCamera.transform.position.z;

            FPSCamera.transform.position = new Vector3(a3 + 0, b3 + 2, c3 - 3);
            /*
            float yRotation = moveCube.transform.eulerAngles.y;
            float xRotation = moveCube.transform.eulerAngles.x;
            float zRotation = moveCube.transform.eulerAngles.z;
            FPSCamera.transform.rotation = new Quaternion(xRotation,yRotation,zRotation);*/

            /// this is where the parent of the FPS camera is changed.

            // Debug.Log("currentPlayer = " + currentPlayer);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            switch22.Play();
            startText.enabled = false;
            start.enabled = false;
            currentPlayer = Player_LetterL;
            moveCube._particleSystem.Stop();
            moveL.___particleSystem.Play();
            moveStair.__particleSystem.Stop();
            FPSCamera.transform.parent = L.transform;
            FPSCamera.transform.position = L.transform.position;
            FPSCamera.transform.rotation = L.transform.rotation;

            float a2 = FPSCamera.transform.position.x;
            float b2 = FPSCamera.transform.position.y;
            float c2 = FPSCamera.transform.position.z;

            FPSCamera.transform.position = new Vector3(a2 - 0, b2 + 2, c2 + 2);
            /*
            float yRotation = moveL.transform.eulerAngles.y;
            float xRotation = moveL.transform.eulerAngles.x;
            float zRotation = moveL.transform.eulerAngles.z;
            // Debug.Log("currentPlayer = " + currentPlayer);*/
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            switch22.Play();
            startText.enabled = false;
            start.enabled = false;
            currentPlayer = Player_Staircase;
            moveCube._particleSystem.Stop();
            moveStair.__particleSystem.Play();
            moveL.___particleSystem.Stop();
            FPSCamera.transform.parent = Stair.transform;
            FPSCamera.transform.position = Stair.transform.position;

            FPSCamera.transform.rotation = Stair.transform.rotation;
            float a = FPSCamera.transform.position.x; 
            float b = FPSCamera.transform.position.y;
            float c = FPSCamera.transform.position.z;

            FPSCamera.transform.position = new Vector3(a+0, b+3, c-3);
            
            /*
            float yRotation = moveStair.transform.eulerAngles.y;
            float xRotation = moveStair.transform.eulerAngles.x;
            float zRotation = moveStair.transform.eulerAngles.z;
            */
            // Debug.Log("currentPlayer = " + currentPlayer);
        }



    }
    public void SetCountText()
    {
        StarText.text = "         " + count.ToString();
    }

    public void SetCountTextUp()
    {
        UpText.text = "         " + countUp.ToString();
    }

    public void SetCountWinText()
    {
        WinText.text = "You Win!";
    }


    /*

    public int speed;
    private float distToGround;
    public float jumpSpeed;
    private Rigidbody rb;
    private int count;


    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        count = 0;
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


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            currentPlayer = Player_Box;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            currentPlayer = Player_LetterL;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            currentPlayer = Player_Staircase;
        }

        if (currentPlayer == Player_Box)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsGrounded())
                {
                    GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
                }
                else if (!IsMoving() && !IsGrounded())
                {
                    GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
                }
            }
        }

        else if (currentPlayer == Player_LetterL)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsGrounded())
                {
                    GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
                }
                else if (!IsMoving() && !IsGrounded())
                {
                    GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
                }
            }
        }

        else if (currentPlayer == Player_Staircase)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsGrounded())
                {
                    GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
                }
                else if (!IsMoving() && !IsGrounded())
                {
                    GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
                }
            }
        }


    }

    */

}





