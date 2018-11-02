using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;

public class TapaBehaviour : MonoBehaviour {
	public float translationSpeed=1.8f;
	public Color colorMesura1;
	public Color colorMesura2;
	public Color colorPlataforma1;
	public Color colorPlataforma2;
	public Color colorPlataforma3;
	public bool StartState=false;
	public bool EndState=false;
	public bool ColorState=false;
	public bool isAlarm=false;
	public bool isNeuronal=false;
	public GameObject sceneControl;
	public Transform sceneControl1;
	//public ReadMunicipiData rmd;
	//public SceneControl sc;
	public int codigo;
	public Vector3 pos;
	public List<Vector3> destinos;
	public bool isPlataforma=false;

	public float timeLeftNeuronal;
	public float timeLapseNeuronalset;
	private float timeLapseNeuronal;
	int r=0;

	//Lineas neuronales
	public GameObject lineEndobj;

	public int state=0;  // 0 Desactivado  //1 Activado
	public float yPos;
	//CIRCULO
	public int segments;
	public float xradius;
	public float yradius;
	LineRenderer line;
	public float speedAlarm;
	public float maxRadius;
	public bool isDrawAlarm=false;
	public float probabilidadRadar;

	public List<int> m1;
	public List<int> m2;
	public List<int> m3;
	// Use this for initialization
	void Start () {
		//yPos = transform.parent.position.y;
		m1=new List<int>();
		m2=new List<int>();
		m3=new List<int>();
		sceneControl = GameObject.Find ("SceneControl");
		timeLapseNeuronal = timeLapseNeuronalset + Random.Range (-1,1);
	}
	public void setYpos(float _y){
		yPos = _y;
	}

	// Update is called once per frame
	void Update () {
		/*
		if (isAlarm) {
			line = gameObject.GetComponent<LineRenderer>();
			line.enabled = true;
			alarma ();
		}*/
		if (isNeuronal) {
			line = gameObject.GetComponent<LineRenderer>();
			line.enabled = true;
			neuronalGrid ();

		}
		if(!isNeuronal ){
			line = gameObject.GetComponent<LineRenderer>();
			line.enabled = false;
		}
	}

	public void animationDecision(string tipo,string tabletName){
		SceneControl sc2 = sceneControl.GetComponent<SceneControl> ();
		isAlarm = false;
		isNeuronal = false;
		isPlataforma = false;
		destinos = sceneControl.GetComponent<SceneControl> ().PlataformaUrbanaV;
		//m2 = m2.Clear;
		switch (tipo) {
		//PERSONAS


			//SOSTENIBILIDAD

		case "Mesura":
			Debug.Log ("Case mesura");
			//m1 = sceneControl.GetComponent<SceneControl>().MesuraM; //NOCOMPLETO
			m1 = sceneControl.GetComponent<SceneControl>().SoporteTecnicoM; //NOCOMPLETO
			m2 = sceneControl.GetComponent<SceneControl>().AparatosPrestadosM; //NOCOMPLETO
			break;
		case "SoporteTecnico":
			m1 = sceneControl.GetComponent<SceneControl>().SoporteTecnicoM; //NOCOMPLETO
			break;
		case "AparatosPrestados":
			m1 = sceneControl.GetComponent<SceneControl>().AparatosPrestadosM; //NOCOMPLETO
			break;




			//TECNOLOGIA
		
		
		case "Plataforma":
			//Debug.Log ("Case Plataforma");
			m1 = sceneControl.GetComponent<SceneControl> ().PlataformaUrbana1M;  //NOCOMPLETO
			m2 = sceneControl.GetComponent<SceneControl>().PlataformaUrbana2M; //NOCOMPLETO
			m3 = sceneControl.GetComponent<SceneControl>().HibridM; //NOCOMPLETO
			isPlataforma = true;
			//List<Vector3> m2 = sceneControl.GetComponent<SceneControl> ().PlataformaUrbanaV;
			//destinos = sceneControl.GetComponent<SceneControl> ().PlataformaUrbanaV;
			break;
		case "Plataforma1":
			m1 = sceneControl.GetComponent<SceneControl>().PlataformaUrbana1M;  //NOCOMPLETO
			break;
		case "Plataforma2":
			m1 = sceneControl.GetComponent<SceneControl>().PlataformaUrbana2M;  //NOCOMPLETO
			break;
		case "Plataforma3":
			m1 = sceneControl.GetComponent<SceneControl>().HibridM;  //NOCOMPLETO
			break;

		
		}

		if (state == 0) { //Inactivo
			//Debug.Log ("State:0 TAPA");
			if (tabletName == "Tablet1" || tabletName == "Tablet2" || tabletName == "Tablet3"||tabletName =="Tablet2Mesura1"||tabletName =="Tablet2Mesura2") {
				//Debug.Log ("DentroIF");
				for (int i = 0; i < m1.Count; i++) {
					//Debug.Log ("State:0 m1[i]:"+m1[i]+" Codigo:"+codigo);
					if (tipo == "Mesura") {
						//Debug.Log ("Tipo Mesura1 tapa 1");
						if (codigo == m1 [i]) {
							Debug.Log ("Tipo Mesura1 tapa 2");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c = colorMesura1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							MarkerFlicker mf = gameObject.GetComponent <MarkerFlicker> ();
							mf.c = colorMesura1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							//line = gameObject.GetComponent<LineRenderer> ();
							/*if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}*/
							break;
						} else {
							/*line = gameObject.GetComponent<LineRenderer> ();
							line.enabled = false;
							isNeuronal = false;*/
						}
					} else if (tipo == "Plataforma") {
						if (codigo == m1 [i]) {
							Debug.Log ("Tipo Plataforma tapa 1");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c = colorPlataforma1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							MarkerFlicker mf = gameObject.GetComponent <MarkerFlicker> ();
							mf.c = colorPlataforma1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							line = gameObject.GetComponent<LineRenderer> ();
							if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;

							} else {
								line.enabled = false;
								isNeuronal = false;
							}
							break;
						} 
					}
					else {

						isNeuronal = false;
						if (codigo == m1 [i]) {

							this.StartState = true;

							/*line = gameObject.GetComponent<LineRenderer> ();
							if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}*/
							break;
						} else {
							/*line = gameObject.GetComponent<LineRenderer> ();
							line.enabled = false;
							isNeuronal = false;*/
						}
					}
				}
				for (int i = 0; i < m2.Count; i++) {
					//Debug.Log ("State:0 m1[i]:"+m1[i]+" Codigo:"+codigo);
					if (tipo == "Mesura") {

						if (codigo == m2 [i]) {
							Debug.Log ("Tipo Mesura2 tapa");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c= colorMesura2;
							gameObject.GetComponent<Renderer> ().material.color = c;
							//line = gameObject.GetComponent<LineRenderer> ();
							/*if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}*/
							break;
						} else {
							/*line = gameObject.GetComponent<LineRenderer> ();
							line.enabled = false;
							isNeuronal = false;*/
						}
					}
					else if (tipo == "Plataforma") {
						if (codigo == m2 [i]) {
							Debug.Log ("Tipo Plataforma tapa 2");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c = colorPlataforma2;
							gameObject.GetComponent<Renderer> ().material.color = c;
							MarkerFlicker mf = gameObject.GetComponent <MarkerFlicker> ();
							mf.c = colorPlataforma2;
							gameObject.GetComponent<Renderer> ().material.color = c;
							//line = gameObject.GetComponent<LineRenderer> ();
							if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}
							break;
						} 
					}
				}
				for (int i = 0; i < m3.Count; i++) {
					//Debug.Log ("State:0 m1[i]:"+m1[i]+" Codigo:"+codigo);
					if (tipo == "Plataforma") {
						if (codigo == m3 [i]) {
							Debug.Log ("Tipo Plataforma tapa 3");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c = colorPlataforma3;
							gameObject.GetComponent<Renderer> ().material.color = c;
							MarkerFlicker mf = gameObject.GetComponent <MarkerFlicker> ();
							mf.c = colorPlataforma3;
							gameObject.GetComponent<Renderer> ().material.color = c;
							line = gameObject.GetComponent<LineRenderer> ();
							if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}
							break;
						} 
					}
				}

			} else {
				/*for (int i = 0; i < m1.Count; i++) {
					//Debug.Log ("State:0 m1[i]:"+m1[i]+" Codigo:"+codigo);
					if (codigo == m1 [i]) {

						this.EndState = true;
						break;
					}
				}*/
			}
			//Debug.Log ("Activated markers:"+m1.Count);
			//this.StartState = true;
		} /*else if (state == 1) { //Activo
			if (tabletName == "Tablet1" || tabletName == "Tablet2" || tabletName == "Tablet3"||tabletName =="Tablet2Mesura1"||tabletName =="Tablet2Mesura2") {
				line = gameObject.GetComponent<LineRenderer>();
				if (isPlataforma) {
					line.enabled = true;
					isNeuronal = true;
				} else {
					line.enabled = false;
					isNeuronal = false;
				}
				bool check = false;
				for (int i = 0; i < m1.Count; i++) {
					if (codigo == m1 [i]) {
						check = true;
						//this.EndState = true;
						break;
					}
				}
				if (!check) {//No esta en el nuevo contenido
					this.EndState = true;
				}
			} else {
				for (int i = 0; i < m1.Count; i++) {
					if (codigo == m1 [i]) {
						this.EndState = true;
						break;
					}
				}
			}
			//Debug.Log ("Activated markers:"+m1.Count);
			//this.EndState = true;
		}*/

	}//END ANIMATION DECISION


	public void neuronalGrid(){
		line = gameObject.GetComponent<LineRenderer>();
		line.SetVertexCount (2);
		line.useWorldSpace = true;
		line.startWidth = 3;
		line.endWidth = 3;
		float xini =transform.parent.position.x;
		float zini =transform.parent.position.z;
		float yini=150;
		//Debug.Log ("destinos:"+destinos.Count);


		timeLeftNeuronal -= Time.deltaTime;

		if (timeLeftNeuronal <= 0) {
			timeLeftNeuronal = timeLapseNeuronal;
			r = (int)Random.Range (0,destinos.Count);

		}
		//Debug.Log ("r:"+r);
		float xend =destinos[r].x;
		float zend =destinos[r].z;
		//Debug.Log ("x:"+xend);
		float yend=150;
		line.SetPosition (0,new Vector3(xini,yini,zini) );
		line.SetPosition (1,new Vector3(xend,yend,zend) );

	}

}
