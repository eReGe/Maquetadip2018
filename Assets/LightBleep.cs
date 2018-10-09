﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBleep : MonoBehaviour {
	public float maxIntensity;
	public float minIntensity;
	public float duration = 1.0F;
	public Color color;
	Light lt;
	// Use this for initialization
	void Start () {
		lt= GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		float phi = Time.time / duration * 2 * Mathf.PI;
		float amplitude = Mathf.Cos(phi) *maxIntensity + minIntensity;
		lt.intensity = amplitude;
	}
}
