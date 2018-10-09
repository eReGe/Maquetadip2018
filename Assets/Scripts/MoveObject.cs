using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Move the object forward along its z axis 1 unit/second.
		transform.Translate(Vector3.forward * Time.deltaTime*speed);
		//transform.Rotate(Vector3.down * Time.deltaTime*speed/2);
		float zRot = transform.eulerAngles.z;
		if(zRot>=15){
			zRot = 15;
		}
		if(zRot<=-15){
			zRot = -15;
		}
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x,transform.eulerAngles.y,zRot);
	}
}
