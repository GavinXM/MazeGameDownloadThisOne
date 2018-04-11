using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonThing : MonoBehaviour
{
    public string player;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == player)
        {
            Destroy(gameObject);
        }
    }
}
