using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour {
	public float speed = 0.05f;
	public float minRadius = 5;
	public float maxRadius = 80;
	public string contenido="";
	public bool isGrowing=false;
	public bool finish=false;
	CapsuleCollider myCollider;
	// Use this for initialization
	void Start () {
	 	myCollider = transform.GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isGrowing) {
			myCollider.radius += speed; // or whatever radius you want.
			if (myCollider.radius > maxRadius) {
				//speed = 0;
				myCollider.radius = minRadius;
				isGrowing = false;
				finish = true;
			}
		} 

	}
}
