using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerControl : MonoBehaviour {
	public Color colorToChange;
	public ReadMunicipiData rmd;
	int cont=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("NO_HIT");
	}

	void OnTriggerEnter (Collider col)
	{
		
		if (col.gameObject.name == "Maqueta1" || col.gameObject.name == "Maqueta2" || col.gameObject.name == "Maqueta3") {
			//Debug.Log ("IGNORE");
		} else {

			if(this.gameObject.name=="Tablet1"||this.gameObject.name=="Tablet2"||this.gameObject.name=="Tablet3"){
				
				if(col.gameObject.name!="MarkerLeyenda1" &&  col.gameObject.name!="MarkerLeyenda2" && col.gameObject.name!="MarkerLeyenda3"){
					col.gameObject.GetComponent<Renderer> ().material.color = colorToChange;

					AnimationTrigger at = gameObject.GetComponent <AnimationTrigger>();
					if (at.contenido != "Mesura" && at.contenido != "Plataforma") {
						MarkerFlicker mf = col.gameObject.GetComponent <MarkerFlicker> ();
						mf.c = colorToChange;
					}
					//Debug.Log (mb);
					if (col.gameObject.name != "Tapa1") {
						MarkerBehaviour mb = col.gameObject.GetComponent <MarkerBehaviour>();
						mb.animationDecision (at.contenido, this.gameObject.name);
					}
					//mb.StartState = true;
						//Debug.Log ("HIT: "+col.gameObject.name);
				}
				if(col.gameObject.name=="Tapa1"){
					AnimationTrigger at = gameObject.GetComponent <AnimationTrigger>();
					if (at.contenido != "Mesura" && at.contenido !="Plataforma") {
						col.gameObject.GetComponent<Renderer> ().material.color = colorToChange;
						MarkerFlicker mf = col.gameObject.GetComponent <MarkerFlicker> ();
						mf.c = colorToChange;
						LineRenderer line = col.gameObject.GetComponent<LineRenderer> ();
						line.enabled = false;
						TapaBehaviour tb=col.gameObject.GetComponent <TapaBehaviour> ();
						tb.isNeuronal = false;
						tb.isPlataforma = false;
						//cont++;
						//Debug.Log ("HIT:NOT MESURA ");
					} else if(at.contenido == "Mesura" || at.contenido =="Plataforma") { //Mesura y Plataforma
						TapaBehaviour tb=col.gameObject.GetComponent <TapaBehaviour> ();
						LineRenderer line = col.gameObject.GetComponent<LineRenderer> ();
						line.enabled = false;

						tb.animationDecision(at.contenido, this.gameObject.name);
						//Debug.Log ("HIT:MESURA and PlAT "+at.contenido + "  "+this.gameObject.name);
					}
				}
			
			}
			/*if(this.gameObject.name=="Tablet2Mesura1"){
				col.gameObject.GetComponent<Renderer> ().material.color = colorToChange;
				MarkerBehaviour mb = col.gameObject.GetComponent <MarkerBehaviour>();
				AnimationTrigger at = gameObject.GetComponent <AnimationTrigger>();
				MarkerFlicker mf = col.gameObject.GetComponent <MarkerFlicker>();
				mf.c = colorToChange;
				//Debug.Log (mb);
				mb.animationDecision(at.contenido, this.gameObject.name);
			}
			if(this.gameObject.name=="Tablet2Mesura2"){
				col.gameObject.GetComponent<Renderer> ().material.color = colorToChange;
				MarkerBehaviour mb = col.gameObject.GetComponent <MarkerBehaviour>();
				AnimationTrigger at = gameObject.GetComponent <AnimationTrigger>();
				MarkerFlicker mf = col.gameObject.GetComponent <MarkerFlicker>();
				mf.c = colorToChange;
				//Debug.Log (mb);
				mb.animationDecision(at.contenido, this.gameObject.name);
			}*/
			 if(this.gameObject.name=="Tablet1Apagado"||this.gameObject.name=="Tablet2Apagado"||this.gameObject.name=="Tablet3Apagado"){

				if (col.gameObject.name != "Tapa1") {
					MarkerBehaviour mb = col.gameObject.GetComponent <MarkerBehaviour> ();
					AnimationTrigger at = gameObject.GetComponent <AnimationTrigger> ();
					//Debug.Log (col.gameObject.name);
					//Debug.Log (mb);
					mb.animationDecision (at.contenido, this.gameObject.name);
					//Debug.Log ("HIT");
				} else {
					TapaBehaviour tb =col.gameObject.GetComponent <TapaBehaviour> ();
					tb.isNeuronal = false;
				}

			}
			if(this.gameObject.name=="ControlJSonCollider"){
				GameObject sc = GameObject.Find ("SceneControl");
				rmd = sc.GetComponent<ReadMunicipiData> ();
				//Debug.Log ("HITJSON");

				int code=col.gameObject.GetComponent<MarkerBehaviour> ().codigo;
				for (int i = 0; i < rmd.TodosMunicipios.Count; i++) {
					//Debug.Log ("State:0 m1[i]:"+m1[i]+" Codigo:"+codigo);
					if (code == rmd.TodosMunicipios [i].codigo) {
						float f=col.transform.position.y;
						//float f=col.transform.parent.position.y;
						Debug.Log ("ParentPosy:"+f);
						var v = rmd.TodosMunicipios [i];
						v.posY = f;
						rmd.TodosMunicipios[i]=v;
						Debug.Log ("Y nueva:"+rmd.TodosMunicipios[i].posY);
						cont++;
						Debug.Log ("EscritosJson: "+cont);
						break;
					}
				}
			}


		}
	}
}
