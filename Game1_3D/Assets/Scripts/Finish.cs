using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {
    
    public ParticleSystem _1particleSystem;
    

    private void Start()
    {
        _1particleSystem = GetComponentInChildren<ParticleSystem>();
        
        _1particleSystem.Stop();
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           // Debug.Log("Entered, Staring Particle System.");
            _1particleSystem.Play();
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
