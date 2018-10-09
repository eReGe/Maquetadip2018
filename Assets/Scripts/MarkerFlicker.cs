using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerFlicker : MonoBehaviour {

	public Color c;
	public float speedChange=0.05f;
	public float limitChange=0.08f;
	// Use this for initialization
	void Start () {
		c = gameObject.GetComponent<Renderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		flickering ();
		//Debug.Log ("Flicker");
	}

	void flickering(){
		Color colorToChange =gameObject.GetComponent<Renderer> ().material.color ;
		float r=Random.Range (-speedChange, speedChange);
		colorToChange.r = colorToChange.r + r;
		colorToChange.g = colorToChange.g + r;
		colorToChange.b = colorToChange.b + r;
		if(colorToChange.r<c.r-limitChange){
			colorToChange.r = c.r - limitChange;
		}
		if(colorToChange.r>c.r+limitChange){
			colorToChange.r = c.r + limitChange;
		}
		if(colorToChange.g<c.g-limitChange){
			colorToChange.g = c.g - limitChange;
		}
		if(colorToChange.g>c.g+limitChange){
			colorToChange.g = c.g +limitChange;
		}
		if(colorToChange.b<c.b-limitChange){
			colorToChange.b = c.b - limitChange;
		}
		if(colorToChange.b>c.b+limitChange){
			colorToChange.b = c.b + limitChange;
		}


		gameObject.GetComponent<Renderer> ().material.color = colorToChange;

	}

}
