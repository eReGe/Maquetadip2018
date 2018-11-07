using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightRotation : MonoBehaviour {

	public float duration = 20f;
	public float speedYrot = 2f;
	public float speedXrot = 0.5f;
	public bool isStartNight=false;
	public bool isStartDay=true;
	public bool isChanging=false;
	public GameObject[] Maquetas;
	public GameObject Mar;
	public int layerLuces;

	private float durationDawn;
	private float speedXrot2;
	public Light light;
	public Color colorSunset = new Color(1f,0.6f,0.3f,1);
	public Color colorSunday = new Color(0.9f, 0.7f, 0.2f, 1);
	public Color colorNight = new Color(1,1,1,1);
	public Color colorMaquetaNight = new Color(0.4f,0.4f,0.4f,1);
	public Color colorMaquetaDay = new Color(1,1,1,1);
	public Color colorLightsNight = new Color(0.4f,0.4f,0.4f,0.5f);
	public Color colorLightsDay = new Color(1,1,1,0);
	private Color c=new Color(1,1,1,1);
	private Color cLights=new Color(1,1,1,1);

	private float t = 0;
	private float t2 = 0;
	//bool isReset = false;
	float xMin=5;
	float xMax=60;
	private float xRot;
	bool isUp=true;
	bool isDay=true;


	// Use this for initialization
	void Start () {
		xRot = xMin;
		speedYrot = 360 / duration;
		speedXrot = (xMax - xMin) / (duration / 2);
		speedXrot2 = speedXrot;
		/*gameObj.transform.eulerAngles = new Vector3(
			gameObj.transform.eulerAngles.x,
			gameObj.transform.eulerAngles.y + 90,
			gameObj.transform.eulerAngles.z
		);*/

		light.color = colorSunday;
		float duration1degree = duration / 360;
		durationDawn=duration/10;
	}

	// Update is called once per frame
	void Update()
	{
		// Rotate the object around its local Y axis at 1 degree per second
		//transform.Rotate(0,Time.deltaTime, 0);

		// ...also rotate around the World's Y axis
		SetTimeDay();
		//ColorChange(colorSunset,colorSunday,duration/4);
		RotationChange ();

		if(isChanging){
			isStartNight = false;
			isStartDay = false;

			if (isDay) {
				ColorChangeMaqueta (colorMaquetaDay,colorMaquetaNight,colorLightsDay,colorLightsNight,durationDawn);
				ColorChangeLight(colorSunday,colorNight,durationDawn);
			}
			else {
				ColorChangeMaqueta (colorMaquetaNight,colorMaquetaDay,colorLightsNight,colorLightsDay,durationDawn);
				ColorChangeLight(colorNight,colorSunday,durationDawn);
			}
		}
		if (!isDay && !isChanging) {
			flickering ();
		}
	}


	void SetTimeDay(){
		bool isDayAnt = isDay;
		float yRot = transform.eulerAngles.y;
		/*if (yRot > 90 && yRot < 270) {
			isDay = true;
		} else {
			isDay = false;
		}*/


		//Comenzar atardecer
		if (yRot > 290 && yRot < 300 && !isChanging) {
			isStartNight = true;
			isChanging = true;
			t2 = 0;
		} if (yRot > 50 && yRot < 60 && !isChanging) {
			isStartDay = true;
			isChanging = true;
			t2 = 0;
		}
		//Debug.Log ("IsDay"+isDay);

		//INTENSIDAD LUZ
		/*if(isDayAnt && !isDay){ //Changes from day to night
			light.intensity=0.5f;
		}
		if(!isDayAnt && isDay){ //Changes from night to day 
			light.intensity=1;
			t = 0;
		}*/
	}

	void ColorChangeLight(Color startColor, Color endColor, float durationChange)
	{

		light.color = Color.Lerp(startColor, endColor, t);
		//Debug.Log ("t="+t);
		if (t < 1) { 
			t += Time.deltaTime / (durationChange);
		} else {
			t = 0;

		}
	}
	void ColorChangeMaqueta(Color startColor, Color endColor,Color startColorL, Color endColorL, float durationChange)
	{

		for (int i = 0; i < Maquetas.Length; i++) {
			Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
			c = m [1].color;
			cLights = m [4].color;
			cLights = Color.Lerp (startColorL, endColorL, t2);
			c = Color.Lerp (startColor, endColor, t2);
			m [0].color = c;
			m [1].color = c;
			m [2].color = c;

			m [4].color = cLights;
			//Debug.Log ("t="+t);

			//m [5].color = c;
		}

		Material[] mMar =Mar.GetComponent<Renderer>().materials;
		c = mMar[0].color;
		c = Color.Lerp (startColor, endColor, t2);
		mMar[0].color = c;

		if (t2 < 1) { 
			t2 += Time.deltaTime / (durationChange);
		} else {
			isChanging = false;
			isDay = !isDay;
			//t2 = 0;
		}

	}
	void flickering(){
		for (int i = 0; i < Maquetas.Length; i++) {
			Material[] m =Maquetas [i].GetComponent<Renderer>().materials;

			cLights = m [4].color;
			float r=Random.Range (-0.07f, 0.071f);
			cLights.a = cLights.a + r;
			if(cLights.a<colorLightsNight.a-0.1f){
				cLights.a =colorLightsNight.a-0.1f;
			}
			else if(cLights.a>colorLightsNight.a){
				cLights.a = colorLightsNight.a;
			}
			//cLights = Color.Lerp (startColorL, endColorL, t2);


			m [4].color = cLights;
			//Debug.Log ("t="+t);

			//m [5].color = c;
		}
	}
	void RotationChange()
	{
		//Debug.Log(isUp);
		//Debug.Log(transform.eulerAngles.x);
		if (isUp) {
			//xRot = xRot + speedXrot;
			//Debug.Log(transform.rotation.x);
			//Debug.Log(transform.rotation.y);
			if(transform.eulerAngles.x>xMax ){
				//Debug.Log("CHANGES TO DOWN");

				isUp = false;
				speedXrot2 = -speedXrot;
			}
		} else {
			//xRot = xRot - speedXrot;
			if(transform.eulerAngles.x<xMin ){
				//Debug.Log("CHANGES TO UP");
				isUp = true;
				speedXrot2 = speedXrot;
			}
		}


		transform.Rotate(0, (Time.deltaTime)*speedYrot, 0, Space.World);
		//transform.Rotate(Time.deltaTime*speedXrot2, 0, 0, Space.Self);
		//transform.Rotate(xRot, 0, 0, Space.World);

	}

	void controlLuzMaqueta(){
		for (int i = 0; i < Maquetas.Length; i++) {
			Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
			//c = m [1].color;
			//c.a = c.a + parcSpeed;

			//m [5].color = c;
		}
	}
}
