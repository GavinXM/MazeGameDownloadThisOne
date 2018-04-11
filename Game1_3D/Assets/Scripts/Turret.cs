using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject rotatable;
    public GameObject SpawnPt;
    public GameObject cannonball;
	
    private void Start()
    {
        StartCoroutine(shootCannonball());
    }

    void Update () {
        float a = 70 * Time.time;
        rotatable.transform.localRotation = Quaternion.Euler(0, a, 0);
	}
    IEnumerator shootCannonball()
    {
        while (true)
        {
            GameObject go = Instantiate(cannonball);
            go.transform.localPosition = SpawnPt.transform.position;
            go.transform.localRotation = SpawnPt.transform.rotation;
            go.GetComponent<Rigidbody>().velocity = 2 * SpawnPt.transform.forward;
            Destroy(go, 5f);

            yield return new WaitForSeconds(3f);

        }
    }
}
