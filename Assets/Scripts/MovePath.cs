using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePath : MonoBehaviour {
	public Transform[] target;
	public float speed;

	private int current;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position != target[current].position){
			Vector3 pos = Vector3.MoveTowards (transform.position,target[current].position, speed *Time.deltaTime);
			GetComponent<Rigidbody>().MovePosition(pos);
			Debug.Log("move"+current);
		}
		else{
			Debug.Log("entered1");
			current= (current+1)%target.Length;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
        Debug.Log("Collider:"+other);
        if (other.tag == "Waypoint")
        {
            current = (current + 1) % target.Length;
            if (current==0)
            {
                transform.position = target[0].position;
            }
        }
        
		Debug.Log("entered");

	}
}
