using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S04c_inputKbdMovRot : MonoBehaviour {

  public float movSpeed = 4.0f;
  public float rotSpeed = 70f;
  private float localRot = 0; // degrees

  void Update() {
    if(Input.GetKeyDown(KeyCode.Space)) {
      transform.position = new Vector3(0, 0, 0);
      localRot = 0;
    } else {
      float dt = Time.deltaTime;
      float da = Input.GetAxis("Horizontal"); // left/right arrow keys (AD keys)
      float ds = Input.GetAxis("Vertical");   // up/down arrow keys (WS keys)
      // The values of ds and da are between -1.0 and 1.0
      // Debug.Log(string.Format("ds={0,4}  da={1,4}", ds, da));
      localRot += rotSpeed * dt * da;
      transform.position = transform.position + movSpeed * dt * ds * transform.forward;
    }
    transform.localRotation = Quaternion.Euler(0, localRot, 0);
  }


}
