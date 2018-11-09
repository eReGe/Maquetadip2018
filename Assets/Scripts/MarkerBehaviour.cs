using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Control;

public class MarkerBehaviour : MonoBehaviour {
	public float translationSpeed=1.8f;
	public GameObject tapa;
	public Color colorMesura1;
	public Color colorMesura2;
	public Color colorPlataforma1;
	public Color colorPlataforma2;
	public Color colorPlataforma3;
	public bool StartState=false;
	public bool EndState=false;
	public bool ColorState=false;
	public bool isAlarm=false;
	public bool isWifi=false;
	public bool isNeuronal=false;
	public GameObject sceneControl;
	public Transform sceneControl1;
	//public ReadMunicipiData rmd;
	//public SceneControl sc;
	public int codigo;
	public Vector3 pos;
	public List<Vector3> destinos;
	public bool isPlataforma=false;
	public bool check;

	public float timeLeftNeuronal;
	public float timeLapseNeuronalset;
	private float timeLapseNeuronal;
	int r=0;

	//Lineas neuronales
	public GameObject lineEndobj;

	public int state=0;  // 0 Desactivado  //1 Activado
	public int tablet=0;
	public float yPos;
	//CIRCULO
	public int segments;
	public float xradius,xradius1,xradius2;
	public float yradius,yradius1,yradius2;
	LineRenderer line;
	LineRenderer line1;
	LineRenderer line2;
	LineRenderer line3;
	LineRenderer line4;
	public GameObject auxLine1,auxLine2,auxLine3,auxLine4;
	public float speedAlarm;
	public float speedWifi;
	public float maxRadius;
	public bool isDrawAlarm=false;
	public bool isDrawWifi=false;
	public float probabilidadRadar;
	public float probabilidadWifi;
	public bool isSuperposition = false;
	public bool superposed=false;

	private List<int> m1;
	private List<int> m2;
	private List<int> m3;

	//PATH RENDER
	private Transform startMarker, endMarker;
	public Transform[] waypoint;
	public float speed = 20f;
	private float startTime = 0f;
	private float journeyLength = 1f;
	private int currentStartPoint = 0;

	// Use this for initialization
	void Start () {
		//yPos = transform.parent.position.y;
		m1=new List<int>();
		m2=new List<int>();
		m3=new List<int>();
		sceneControl = GameObject.Find ("SceneControl");
		timeLapseNeuronal = timeLapseNeuronalset + Random.Range (-1,1);
        speedAlarm = speedAlarm + Random.Range(-8,8);


		xradius = maxRadius;
		xradius1 = maxRadius/3*2;
		xradius2 = maxRadius/3;
		yradius = maxRadius;
		yradius1 = maxRadius/3*2;
		yradius2 = maxRadius/3;

		line1=auxLine1.GetComponent<LineRenderer>();

		line2=auxLine2.GetComponent<LineRenderer>();
		line3=auxLine3.GetComponent<LineRenderer>();
		line4=auxLine4.GetComponent<LineRenderer>();
	}
	public void setYpos(float _y){
		yPos = _y;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.StartState) {
			startAnimation ();
		}
		if (this.EndState) {
			line = gameObject.GetComponent<LineRenderer>();
			line.enabled = false;
			line1=auxLine1.GetComponent<LineRenderer>();
			line1.enabled = false;
			line2=auxLine2.GetComponent<LineRenderer>();
			line2.enabled = false;
			line3=auxLine3.GetComponent<LineRenderer>();
			line3.enabled = false;
			line4=auxLine4.GetComponent<LineRenderer>();
			line4.enabled = false;
			endAnimation ();

		}
		if (isAlarm) {
			line = gameObject.GetComponent<LineRenderer>();
			line.enabled = true;


			alarma();
			//wifi();
		}
		if (isWifi) {
			line = gameObject.GetComponent<LineRenderer>();
			line.enabled = true;

			wifi();
		}
		if (isNeuronal) {
			line = gameObject.GetComponent<LineRenderer>();
			line.enabled = false;
			neuronalGrid ();

		}
		if(!isNeuronal && !isAlarm){
			line = gameObject.GetComponent<LineRenderer>();
			line.enabled = false;
		}
	}

	public void animationDecision(string tipo,string tabletName,Color colorToChange){
		SceneControl sc2 = sceneControl.GetComponent<SceneControl> ();
		isAlarm = false;
		isNeuronal = false;
		isPlataforma = false;
		isWifi = false;
		destinos = sceneControl.GetComponent<SceneControl> ().PlataformaUrbanaV;
		//m2 = new List<int>();
		switch (tipo) {
		//PERSONAS
		case "XarxaBiblio":
			m1 = sceneControl.GetComponent<SceneControl> ().xarxaBiblioM;
			tablet = 1;
			break;
		case "Bibliotecas":
			m1 = sceneControl.GetComponent<SceneControl>().bibliotecasM;
			tablet = 1;

				break;
		case "Bibliobuses":
			m1 = sceneControl.GetComponent<SceneControl>().bibliobusesM;
			tablet = 1;

			break;

		case "Atencio":
			m1 = sceneControl.GetComponent<SceneControl>().atencioM;
			tablet = 1;
			isAlarm = true;
			break;
		case "Teleasistencia":
			m1 = sceneControl.GetComponent<SceneControl>().teleasisM;
			tablet = 1;
			isAlarm = true;
			break;
		case "HESTIA":
			m1 = sceneControl.GetComponent<SceneControl>().hestiaM;
			tablet = 1;
			break;

		case "GovernOBERT":
			m1 = sceneControl.GetComponent<SceneControl>().governObertM;
			tablet = 1;
			break;
		case "Xaloc":
			m1 = sceneControl.GetComponent<SceneControl>().xalocM;
			tablet = 1;
			break;
		case "Km2":
			m1 = sceneControl.GetComponent<SceneControl>().km21M;
			tablet = 1;
			break;

		//SOSTENIBILIDAD
		case "Xarxa":
			m1 = sceneControl.GetComponent<SceneControl> ().xarxaCiutatsM;//NOCOMPLETA
			tablet = 2;
			break;
		case "CambioClimatico":
			m1 = sceneControl.GetComponent<SceneControl> ().CambioClimaticoM;
			tablet = 2;
			break;
		case "Sostenibilitat":
			m1 = sceneControl.GetComponent<SceneControl> ().SostenibilidadM;
			tablet = 2;
			break;
		case "EconomiaCircular":
			m1 = sceneControl.GetComponent<SceneControl> ().EconomiaCircularM;
			tablet = 2;
			break;

		case "Renovables":
			m1 = sceneControl.GetComponent<SceneControl>().RenovablesM; //NOCOMPLETO
			tablet = 2;
			break;
		case "CalderesBiomasa":
			m1 = sceneControl.GetComponent<SceneControl>().CalderesBiomassaM; //NOCOMPLETO
			tablet = 2;
			break;
		case "FotovoltaiquesAuto":
			m1 = sceneControl.GetComponent<SceneControl>().FotovoltaiquesAutoM; //NOCOMPLETO
			tablet = 2;
			break;
		case "FotovoltaiquesVenta":
			m1 = sceneControl.GetComponent<SceneControl>().FotovoltaiquesVentaM; //NOCOMPLETO
			tablet = 2;
			break;

		case "Mesura":
			//m1 = sceneControl.GetComponent<SceneControl>().MesuraM; //NOCOMPLETO
			m1 = sceneControl.GetComponent<SceneControl>().SoporteTecnicoM; //NOCOMPLETO
			m2 = sceneControl.GetComponent<SceneControl>().AparatosPrestadosM; //NOCOMPLETO
			tablet = 2;
			break;
		case "SoporteTecnico":
			m1 = sceneControl.GetComponent<SceneControl>().SoporteTecnicoM; //NOCOMPLETO
			tablet = 2;
			break;
		case "AparatosPrestados":
			m1 = sceneControl.GetComponent<SceneControl>().AparatosPrestadosM; //NOCOMPLETO
			tablet = 2;
			break;


		case "OTAGA":
			m1 = sceneControl.GetComponent<SceneControl>().OTAGAM; //NOCOMPLETO
			tablet = 2;
			break;
		case "AnalisisParticulas":
			m1 = sceneControl.GetComponent<SceneControl>().AnalisisParticulasM; //NOCOMPLETO
			tablet = 2;
			break;
		case "AguaFuentes":
			m1 = sceneControl.GetComponent<SceneControl>().AguaFuentesM; //NOCOMPLETO
			tablet = 2;
			break;
		case "MediaSonido":
			m1 = sceneControl.GetComponent<SceneControl>().MedidaSonidoM; //NOCOMPLETO
			tablet = 2;
			break;


		case "Turisme":
			m1 = sceneControl.GetComponent<SceneControl>().TurismoM;
			tablet = 2;
			break;
		

		//TECNOLOGIA
		case "ServeiGestio":
			m1 = sceneControl.GetComponent<SceneControl>().AsesoramientoJuridicoM; //NOCOMPLETO
			tablet = 3;
			break;
		case "AsesoramientoJuridico":
			m1 = sceneControl.GetComponent<SceneControl>().AsesoramientoJuridicoM; //NOCOMPLETO
			tablet = 3;
			break;
		case "GestionInformacion":
			m1 = sceneControl.GetComponent<SceneControl>().GestionInformacionM; //NOCOMPLETO
			tablet = 3;
			break;
		case "GestionFormacion":
			m1 = sceneControl.GetComponent<SceneControl>().GestionFormacionM; //NOCOMPLETO
			tablet = 3;
			break;
		case "GestionContabilidad":
			m1 = sceneControl.GetComponent<SceneControl>().GestionContabilidadM; //NOCOMPLETO
			tablet = 3;
			break;
		case "GestionPadron":
			m1 = sceneControl.GetComponent<SceneControl>().GestionPadronM; //NOCOMPLETO
			tablet = 3;
			break;
		case "GestionWebs":
			m1 = sceneControl.GetComponent<SceneControl>().GestionWebsM; //NOCOMPLETO
			tablet = 3;
			break;
		case "HERMES":
			m1 = sceneControl.GetComponent<SceneControl>().HERMESM; //NOCOMPLETO
			tablet = 3;
			break;
		case "MuniApps":
			m1 = sceneControl.GetComponent<SceneControl>().MuniappsM; //NOCOMPLETO
			tablet = 3;
			break;

		case "Plataforma":
			m1 = sceneControl.GetComponent<SceneControl> ().PlataformaUrbana1M;  //NOCOMPLETO
			m2 = sceneControl.GetComponent<SceneControl>().PlataformaUrbana2M; //NOCOMPLETO
			m3 = sceneControl.GetComponent<SceneControl>().HibridM; //NOCOMPLETO
			isPlataforma = true;
			tablet = 3;
			//List<Vector3> m2 = sceneControl.GetComponent<SceneControl> ().PlataformaUrbanaV;
			//destinos = sceneControl.GetComponent<SceneControl> ().PlataformaUrbanaV;
			break;
		case "Plataforma1":
			m1 = sceneControl.GetComponent<SceneControl>().PlataformaUrbana1M;  //NOCOMPLETO
			tablet = 3;
			isPlataforma = true;
			break;
		case "Plataforma2":
			m1 = sceneControl.GetComponent<SceneControl>().PlataformaUrbana2M;  //NOCOMPLETO
			tablet = 3;
			isPlataforma = true;
			break;
		case "Plataforma3":
			m1 = sceneControl.GetComponent<SceneControl>().HibridM;  //NOCOMPLETO
			tablet = 3;
			isPlataforma = true;
			break;

		case "Infraestructures":
			m1 = sceneControl.GetComponent<SceneControl>().InfraestructurasInformacionM;
			tablet = 3;
			break;
		case "SITMUN":
			m1 = sceneControl.GetComponent<SceneControl>().SITMUNM;
			tablet = 3;
			break;
		case "Cartografia":
			m1 = sceneControl.GetComponent<SceneControl>().InfraestructurasInformacionM;
			tablet = 3;
			break;
		/*case "Poligons":
			m1 = sceneControl.GetComponent<SceneControl>().governObertM;
			break;*/
		}

		if (state == 0) { //Inactivo
			//Debug.Log ("State:0 m1.copunt:"+m1.Count);
			if (tabletName == "Tablet1" || tabletName == "Tablet2" || tabletName == "Tablet3"||tabletName =="Tablet2Mesura1"||tabletName =="Tablet2Mesura2") {
				for (int i = 0; i < m1.Count; i++) {
					//Debug.Log ("State:0 m1[i]:"+m1[i]+" Codigo:"+codigo);
					if (tipo == "Mesura") {
						
						if (codigo == m1 [i]) {
							Debug.Log ("Tipo Mesura1 mb");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c = colorMesura1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							MarkerFlicker mf = gameObject.GetComponent <MarkerFlicker> ();
							mf.c = colorMesura1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							line = gameObject.GetComponent<LineRenderer> ();
							/*if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}*/
							break;
						} else {
							line = gameObject.GetComponent<LineRenderer> ();
							line.enabled = false;
							isNeuronal = false;
						}
					} else if (tipo == "Plataforma1" || tipo == "Plataforma2" || tipo == "Plataforma3" || tipo == "Plataforma") {
						if (codigo == m1 [i]) {
							Debug.Log ("Tipo Plataforma mb");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c = colorMesura1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							MarkerFlicker mf = gameObject.GetComponent <MarkerFlicker> ();
							mf.c = colorMesura1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							line = gameObject.GetComponent<LineRenderer> ();
							isWifi = true;
							/*if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}*/
							break;
						} else {
							line = gameObject.GetComponent<LineRenderer> ();
							line.enabled = false;
							isNeuronal = false;
							isWifi = false;
						}
					}

					else {


						if (codigo == m1 [i]) {
						
							this.StartState = true;
							GetComponent<Renderer> ().material.color = colorToChange;
							line = gameObject.GetComponent<LineRenderer> ();
							MarkerFlicker mf = tapa.gameObject.GetComponent <MarkerFlicker> ();
							mf.c = colorToChange;

							break;
						} else {
							line = gameObject.GetComponent<LineRenderer> ();
							line.enabled = false;
							isNeuronal = false;
							isWifi = false;
						}
					}
				}
				for (int i = 0; i < m2.Count; i++) {
					//Debug.Log ("State:0 m1[i]:"+m1[i]+" Codigo:"+codigo);
					if (tipo == "Mesura") {
						
						if (codigo == m2 [i]) {
							Debug.Log ("Tipo Mesura2 mb");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c= colorMesura1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							line = gameObject.GetComponent<LineRenderer> ();
							/*if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}*/
							break;
						} else {
							line = gameObject.GetComponent<LineRenderer> ();
							line.enabled = false;
							isNeuronal = false;
						}
					}
					else if(tipo == "Plataforma"){
						if (codigo == m2 [i]) {
							Debug.Log ("Tipo Plataforma2 mb");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c= colorMesura1;
							gameObject.GetComponent<Renderer> ().material.color = c;
							line = gameObject.GetComponent<LineRenderer> ();
							isWifi = true;
							/*if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}*/
							break;
						} else {
							line = gameObject.GetComponent<LineRenderer> ();
							line.enabled = false;
							isNeuronal = false;
						}
					}
				}
				for (int i = 0; i < m3.Count; i++) {
					//Debug.Log ("State:0 m1[i]:"+m1[i]+" Codigo:"+codigo);

					if(tipo == "Plataforma"){
						if (codigo == m3 [i]) {
							Debug.Log ("Tipo Plataforma3 mb");
							this.StartState = true;
							Color c = gameObject.GetComponent<Renderer> ().material.color;
							c= colorPlataforma3;
							gameObject.GetComponent<Renderer> ().material.color = c;
							line = gameObject.GetComponent<LineRenderer> ();
							isWifi = true;
							/*if (isPlataforma) {
								line.enabled = true;
								isNeuronal = true;
							} else {
								line.enabled = false;
								isNeuronal = false;
							}*/
							break;
						} else {
							line = gameObject.GetComponent<LineRenderer> ();
							line.enabled = false;
							isNeuronal = false;
						}
					}
				}

			} else { //Borrado?
				isWifi = false;
				line1.enabled=false;
				line2.enabled=false;
				line3.enabled=false;
				line4.enabled=false;
				/*for (int i = 0; i < m1.Count; i++) {
					//Debug.Log ("State:0 m1[i]:"+m1[i]+" Codigo:"+codigo);
					if (codigo == m1 [i]) {

						this.EndState = true;
						break;
					}
				}*/
			}
			//g ("Activated markers:"+m1.Count);
			//this.StartState = true;
		} else if (state == 1) { //Activo
			if (tabletName == "Tablet1" || tabletName == "Tablet2" || tabletName == "Tablet3"||tabletName =="Tablet2Mesura1"||tabletName =="Tablet2Mesura2") {
				line = gameObject.GetComponent<LineRenderer>();
				if (isPlataforma) {
					line.enabled = true;
					isNeuronal = true;
					currentStartPoint = 0;
					isWifi = true;
				} else {
					line.enabled = false;
					isNeuronal = false;
					isWifi = false;
				}
				check = false;
				for (int i = 0; i < m1.Count; i++) {
					if (codigo == m1 [i]) {
						if(isSuperposition){
							superposed = true;
							Material[] m = tapa.gameObject.GetComponent<Renderer>().materials;
							Color c = m [1].color;
							c.a = 1;
							m [1].color = c;
							//mf.c = colorToChange;
						}
						else{
							check = true;
						}
						//this.EndState = true;
						break;
					}
				}
				if (!check) {//No esta en el nuevo contenido
					if(isSuperposition)this.EndState = false;
					else this.EndState = true;
				}
			} else {
				for (int i = 0; i < m1.Count; i++) {
					if (codigo == m1 [i]) {

						if (tabletName == "Tablet1Apagado" && tablet==1) {
							this.EndState = true;
							break;
						}
						if (tabletName == "Tablet2Apagado" && tablet==2) {
							this.EndState = true;
							break;
						}
						if (tabletName == "Tablet3Apagado" && tablet==3) {
							this.EndState = true;
							break;
						}
						if (tabletName == "ApagaSuperpos") {
							if(isSuperposition){
								if(superposed)
								{ 
									superposed = false;
									Material[] m = tapa.gameObject.GetComponent<Renderer>().materials;
									Color c = m [1].color;
									c.a = 0;
									m [1].color = c;
									isSuperposition = false;
								}
								else{
									this.EndState = true;
									superposed = false;
								}
							}
							else{
								this.EndState = true;
							}

							break;
						}



					}
					else {
						if (tabletName == "Tablet1Apagado" && tablet==1) {
							this.EndState = true;
							superposed = false;
							Material[] m = tapa.gameObject.GetComponent<Renderer>().materials;
							Color c = m [1].color;
							c.a = 0;
							m [1].color = c;
							isSuperposition = false;
							break;
						}
					}

				}
				for (int i = 0; i < m2.Count; i++) {
					if (codigo == m2 [i]) {
						if (tabletName == "Tablet1Apagado" && tablet==1) {
							this.EndState = true;
							break;
						}
						if (tabletName == "Tablet2Apagado" && tablet==2) {
							this.EndState = true;
							break;
						}
						if (tabletName == "Tablet3Apagado" && tablet==3) {
							this.EndState = true;
							break;
						}
					}
				}
				for (int i = 0; i < m3.Count; i++) {
					if (codigo == m3 [i]) {
						if (tabletName == "Tablet1Apagado" && tablet==1) {
							this.EndState = true;
							break;
						}
						if (tabletName == "Tablet2Apagado" && tablet==2) {
							this.EndState = true;
							break;
						}
						if (tabletName == "Tablet3Apagado" && tablet==3) {
							this.EndState = true;
							break;
						}
					}
				}
			}
			//Debug.Log ("Activated markers:"+m1.Count);
			//this.EndState = true;
		}

	}

	void startAnimation(){
		transform.parent.Translate (0,translationSpeed,0,Space.World);
		if(this.transform.parent.position.y>=yPos){
			this.StartState = false;
			state = 1;
		}

	}
	void endAnimation(){
		transform.parent.Translate (0,-translationSpeed,0,Space.World);
		if(this.transform.parent.position.y<=yPos-27){
			this.EndState = false;
			state = 0;
		}

	}
	void colorAnimation(){
		/*transform.parent.Translate (0,-translationSpeed,0,Space.World);
		if(this.transform.parent.position.y<-30){
			this.EndState = false;
		}*/

	}

	public  float RemapVal ( float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
	public void alarma(){
		int prob=0;
		if (xradius == 0 || xradius>=maxRadius) {
			prob = Random.Range (0,100);
			if (prob < probabilidadRadar) {
				isDrawAlarm = true;
			}
			else{
				isDrawAlarm=false;
			}
		}
		xradius = xradius + speedAlarm;
		xradius = xradius % maxRadius;
		xradius1 = xradius1 + speedAlarm;
		xradius1 = xradius1 % maxRadius;
		xradius2 = xradius2 + speedAlarm;
		xradius2 = xradius2 % maxRadius;
		yradius = yradius + speedAlarm;
		yradius = yradius % maxRadius;
		float alphaMap = xradius;
		line = gameObject.GetComponent<LineRenderer>();
		if(isDrawAlarm){
			line.enabled=true;
			line4.enabled=true;
			alphaMap = RemapVal (alphaMap,0,maxRadius,1,0);
			Color c = line.material.color;
			c.a = alphaMap;
			//Debug.Log ("Alpharadar: " + alphaMap);
			line.material.color=c;

			line.SetVertexCount (segments + 1);
			line.useWorldSpace = false;
			line.startWidth = 4;
			line.endWidth = 4;

			line4.material.color=c;
			line4.SetVertexCount (segments + 1);
			line4.useWorldSpace = false;
			line4.startWidth = 4;
			line4.endWidth = 4;
			CreatePoints ();
		}
		else{
			line.enabled=false;
			line4.enabled=false;
		}

	}

	void CreatePoints ()
	{
		float x,x1;
		float y,y1;
		float z,z1 = 0f;

		float angle = 90f-30f;
		float angle2 = 270f-30f;

		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius;
			y = -400;
			x1 = Mathf.Sin (Mathf.Deg2Rad * angle2) * xradius;
			z1 = Mathf.Cos (Mathf.Deg2Rad * angle2) * yradius;
			y1 = -400;

			line.SetPosition (i,new Vector3(x,y,z) );
			line4.SetPosition (i,new Vector3(x1,y,z1) );

			angle += (60f / segments);
			angle2 += (60f / segments);
		}
	}
	public void wifi(){
		float prob=0;
		if (xradius == 0 || xradius>=maxRadius-1) {
			prob = Random.Range (0,100);
			if (prob < probabilidadWifi) {
				isDrawWifi = true;
			}
			else{
				isDrawWifi=false;
			}
		}
		xradius = xradius + speedWifi;
		xradius = xradius % maxRadius;
		xradius1 = xradius1 + speedWifi;
		xradius1 = xradius1 % maxRadius;
		xradius2 = xradius2 + speedWifi;
		xradius2 = xradius2 % maxRadius;
		yradius = yradius + speedWifi;
		yradius = yradius % maxRadius;
		yradius1 = yradius1 + speedWifi;
		yradius1 = yradius1 % maxRadius;
		yradius2 = yradius2 + speedWifi;
		yradius2 = yradius2 % maxRadius;
		float alphaMap = xradius;
		line = gameObject.GetComponent<LineRenderer>();
		if(isDrawWifi){
			line1.enabled=true;
			line2.enabled=true;
			line3.enabled=true;
			//alphaMap = RemapVal (alphaMap,0,maxRadius,1,0);
			Color c = line.material.color;
			//c.a = alphaMap;
			//Debug.Log ("Alpharadar: " + alphaMap);
			line1.material.color=c;
			line1.SetVertexCount (segments + 1);
			line1.useWorldSpace = false;
			line1.startWidth = 4;
			line1.endWidth = 4;

			line2.material.color=c;
			line2.SetVertexCount (segments + 1);
			line2.useWorldSpace = false;
			line2.startWidth = 4;
			line2.endWidth = 4;

			line3.material.color=c;
			line3.SetVertexCount (segments + 1);
			line3.useWorldSpace = false;
			line3.startWidth = 4;
			line3.endWidth = 4;
			CreatePoints2();
		}
		else{
			line1.enabled=false;
			line2.enabled=false;
			line3.enabled=false;
		}

	}
	void CreatePoints2 ()
	{
		float x,x1,x2;
		float y,y1,y2;
		float z,z1,z2 = 0f;

		float angle = 170f;
		float angle2 = angle +60f;

		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius;
			y = -400;
			x1 = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius1;
			z1 = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius1;
			y1 = -400;
			x2 = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius2;
			z2 = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius2;
			y2 = -400;

			line1.SetPosition (i,new Vector3(x,y,z) );
			line2.SetPosition (i,new Vector3(x1,y,z1) );
			line3.SetPosition (i,new Vector3(x2,y,z2) );

			angle += (90f / segments);

		}
	}
	void SetPoints()
	{
		startMarker = waypoint[currentStartPoint];
		//endMarker.position = waypoint[currentStartPoint + 1];
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	public void neuronalGrid(){
		line = gameObject.GetComponent<LineRenderer>();
		line.SetVertexCount (2);
		line.useWorldSpace = true;
		line.startWidth = 0.5f;
		line.endWidth = 0.5f;
		float xini =transform.parent.position.x;
		float zini =transform.parent.position.z;
		float yini=150;
		Debug.Log ("destinos:"+destinos.Count);


		timeLeftNeuronal -= Time.deltaTime;

		if (timeLeftNeuronal <= 0) {
			timeLeftNeuronal = timeLapseNeuronal;
			 r = (int)Random.Range (0,destinos.Count);
	
		}
		Debug.Log ("r:"+r);
		float xend =destinos[r].x;
		float zend =destinos[r].z;
		Debug.Log ("x:"+xend);
		float yend=150;
		//line.SetPosition (0,new Vector3(xini,yini,zini) );
		//line.SetPosition (1,new Vector3(xend,yend,zend) );
		endMarker.position=new Vector3(xend,yend,zend);
		//PATH RENDER
		float distCovered = (Time.time - startTime) * 50; //50=speed
		float fracJourney = distCovered / journeyLength;
		Vector3 startPosition = new Vector3 (xini, yini, zini);//startMarker.position;
		Vector3 endPosition = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
		line.SetPosition(0, startPosition);
		line.SetPosition(1, endPosition);
		if (fracJourney >= 1f)
		{
			if (currentStartPoint + 2 < waypoint.Length)
			{
				currentStartPoint++;
				SetPoints();
			}
			else
			{
				//if finished, disable lineRenderer and this script
				line.enabled = false;
				//this.enabled = false;
			}
		}

	}

}
