using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S03g_main : MonoBehaviour {

  private int count = 0;

  void Update() {
    GameObject go = null;
    float px = Random.Range(-5f, 5f);
    float py = Random.Range(-5f, 5f);
    float pz = Random.Range(-5f, 5f);
    float rx = Random.Range(0f, 360f);
    float ry = Random.Range(0f, 360f);
    float rz = Random.Range(0f, 360f);
    float sx = 1;
    float sy = 1;
    float sz = 1;
    if(Input.GetKeyDown(KeyCode.B)) {
      go = GameObject.CreatePrimitive(PrimitiveType.Cube);
      sx = Random.Range(0.3f, 1.5f);
      sy = Random.Range(0.3f, 1.5f);
      sz = Random.Range(0.3f, 1.5f);
    } else if(Input.GetKeyDown(KeyCode.S)) {
      go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      sx = sy = sz = Random.Range(0.3f, 1.5f);
    } else if(Input.GetKeyDown(KeyCode.C)) {
      go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
      sx = sz = Random.Range(0.3f, 1.5f);
      sy = Random.Range(0.3f, 1.5f);
    } else {
      return;
    }
    go.transform.position = new Vector3(px, py, pz);
    go.transform.localRotation = Quaternion.Euler(rx, ry, rz);
    go.transform.localScale = new Vector3(sx, sy, sz);
    count++;
    go.name = "P" + count;
  }


}
