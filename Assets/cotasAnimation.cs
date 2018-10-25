using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class cotasAnimation : MonoBehaviour {

    Camera myCamera;
    public float diferenciaCota;
    public float pasoCota;
	private float pasoCota2;
    public float maxCota;
    public float minCota;
	public int animationType; //0 parado  1 arriba a abajo llena   2 arriba a abajo vacia 3 ababjo a arriba llena 4 ababjo a arriba llena  5 de enmedio a los lados llena 6 de enmedio a los lados vacia
    float cota;
	float cota2;
    // Use this for initialization

    void Start () {
        //Camera myCamera;
        myCamera = gameObject.GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
		if(animationType!=0) updateAnimation ();
    }

	public void startAnimation(int type){
		animationType = type;

		if(animationType==1){
			myCamera.nearClipPlane = minCota;
			myCamera.farClipPlane = minCota;
			cota = minCota;
		}
		if(animationType==4){
			myCamera.nearClipPlane = minCota;
			myCamera.farClipPlane = maxCota;
			cota = maxCota;
		}
		if(animationType==2){
			myCamera.nearClipPlane = maxCota;
			myCamera.farClipPlane = maxCota;
			cota = maxCota;
		}
		if(animationType==5){
			myCamera.nearClipPlane = minCota;
			myCamera.farClipPlane = maxCota;
			cota = minCota;
		}
		if(animationType==3){
			myCamera.nearClipPlane = 450;
			myCamera.farClipPlane = 450;
			cota = 450;
			cota2 = 450;
			/*
			cota = (maxCota-minCota)/2+minCota;
			cota2 = (maxCota-minCota)/2+minCota;
			*/
		}
		if(animationType==6){
			myCamera.nearClipPlane = minCota;
			myCamera.farClipPlane = maxCota;
			cota = minCota;
			cota2 = maxCota;
		}
			
	}

	void updateAnimation(){ //  <  >

		if(animationType==1){
			myCamera.farClipPlane = cota;
			cota=cota+ pasoCota;
			if(cota>=maxCota){
				animationType = 0;
			}
		}
		if(animationType==2){
			myCamera.farClipPlane = cota;
			cota=cota- pasoCota*2;
			if(cota<=minCota){
				animationType = 0;
			}
		}
		if(animationType==3){
			myCamera.nearClipPlane = cota;
			cota=cota- pasoCota;
			if(cota<=minCota){
				animationType = 0;
			}
		}
		if(animationType==4){
			myCamera.nearClipPlane = cota;
			cota=cota+ pasoCota*2;
			if(cota>=maxCota){
				animationType = 0;
			}
		}
		if(animationType==5){
			myCamera.nearClipPlane = cota;
			cota=cota- pasoCota;
			myCamera.farClipPlane = cota2;
			cota2=cota2+ pasoCota;
			if(cota<=minCota && cota2>=maxCota){
				animationType = 0;
			}

		}
		if(animationType==6){
			myCamera.nearClipPlane = cota;
			cota=cota+ pasoCota*2;
			myCamera.farClipPlane = cota2;
			cota2=cota2- pasoCota*2;
			if(cota>=maxCota && cota2<=maxCota){
				animationType = 0;
			}
		}
	}

	
}
