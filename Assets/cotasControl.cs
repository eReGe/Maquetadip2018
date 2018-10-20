using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cotasControl : MonoBehaviour {

    Camera myCamera;
    public float diferenciaCota;
    public float pasoCota;
    public float maxCota;
    public float minCota;
    float cota;
    // Use this for initialization

    void Start () {
        //Camera myCamera;
        myCamera = gameObject.GetComponent<Camera>();

       

        // now you have a reference pointer to the camera, modify properties :
        myCamera.nearClipPlane = 0.05f;
        myCamera.farClipPlane = 100f;
        cota = 390;
    }
	
	// Update is called once per frame
	void Update () {
        myCamera.nearClipPlane = cota-diferenciaCota;
        myCamera.farClipPlane = cota;
        cota=cota+ pasoCota;
        //if (cota < minCota) cota = minCota;
        if (cota > maxCota) cota = minCota;
    }
}
