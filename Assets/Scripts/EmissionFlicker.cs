using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionFlicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material[] m = GetComponent<Renderer>().materials;
        Material mat = m[2];

        float emission = Mathf.PingPong(Time.time, 2);
        Color baseColor = m[2].color; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }
}
