using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalBus : MonoBehaviour {
	public GameObject fishPrefab;
	public static int tankSize=25;
	public int fishNumber;
	static int numFish=2 ;
	public static GameObject[] allFish = new GameObject[numFish];

	public static Vector3 goalPos = Vector3.zero;
	// Use this for initialization
	void Start () {
		//numFish = fishNumber;
		for(int i=0; i<numFish;i++){
			Vector3 pos = new Vector3 (Random.Range (-tankSize, tankSize),
				             0,
				              Random.Range (-tankSize, tankSize));
				allFish[i]= (GameObject) Instantiate(fishPrefab,pos,Quaternion.identity);
		}

		goalPos=new Vector3 (Random.Range (transform.position.x-tankSize,transform.position.x+ tankSize),
			transform.position.y+40,
			Random.Range (transform.position.z-tankSize,transform.position.z+ tankSize));
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range (0,10000)<50){
			goalPos=new Vector3 (Random.Range (transform.position.x-tankSize,transform.position.x+ tankSize),
				transform.position.y+40,
				Random.Range (transform.position.z-tankSize,transform.position.z+ tankSize));
		}
	}
}
