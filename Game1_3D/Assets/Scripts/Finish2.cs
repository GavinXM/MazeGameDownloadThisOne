using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish2 : MonoBehaviour {

    public ParticleSystem _2particleSystem;


    private void Start()
    {
        _2particleSystem = GetComponentInChildren<ParticleSystem>();

        _2particleSystem.Stop();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Entered, Staring Particle System.");
            _2particleSystem.Play();
        }
    }




    /* private bool stopPS = true;
     private void Start()
     {
        _1particleSystem.Stop();
        _2particleSystem.Stop();{
            }


     private void Update()
     {

         if (_1particleSystem==null)
         {
             Debug.Log("== strange ==");
         }
         if (stopPS)
         {
             stopPS = false;
             _1particleSystem.Stop();
             _2particleSystem.Stop();
         }
     }


     void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Player")
         {
             Debug.Log("Entered, Staring Particle System.");
             _1particleSystem.Play();
             _2particleSystem.Play();
         }
     }*/
}
