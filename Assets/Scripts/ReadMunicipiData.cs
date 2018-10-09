using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using LitJson;
using System.IO;
using SimpleJSON;

public class ReadMunicipiData : MonoBehaviour {
	public GameObject marcador;
	public GameObject AnimStarters;

	private string jsonString;
	private JSONString itemData;
	private bool isLoaded;
	private bool isFinsihWriting = false;
	public List<UnMunicipio> TodosMunicipios;

	public int codigo;
	public string nombre;
	public int bibliotecas;
	public float posX;
	public float posY;
	public float posZ;

	private UnMunicipio um;
	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (this);
		//fillData ();

	}
	
	// Update is called once per frame
	void Update () {
		AnimationTrigger atScript = AnimStarters.GetComponent<AnimationTrigger>();
		if (atScript.finish && !isFinsihWriting) {
			writeJsonFile2 ();
		}
	}

	public bool fillData(){
		Debug.Log ("Fill Config");
		jsonString = File.ReadAllText (Application.dataPath + "/Resources/Json/DatosMunicipios.Json");
		if(jsonString==null){
			return false;
		}
		//itemData = JsonMapper.ToObject (jsonString);
		TodosMunicipios = new List<UnMunicipio> ();
		var N = JSON.Parse(jsonString);
		int cont = 0;
		for(int i=0;i<N.Count;i++){
			um = new UnMunicipio ();
			//scenes = new List<Escena> ();
			um.codigo	= N [i] ["codigo"];
			um.nombre = N [i] ["nombre"];
			//Personas
			um.bibliotecas= N [i] ["bibliotecas"];
			um.bibliobuses= N [i] ["bibliobuses"];
			um.teleasistencia=N [i] ["teleasistencia"];
			um.hestia=N [i] ["hestia"];
			um.governobert=N [i] ["governobert"];
			um.xaloc=N [i] ["xaloc"];
			um.km2=N [i] ["km2"];
			//um.km22=N [i] ["KM22"];
			//Sostenibilidad
			um.CambioClimatico=N [i] ["CambioClimatico"];
			um.Sostenibilidad=N [i] ["Sostenibilidad"];
			um.EconomiaCircular=N [i] ["EconomiaCircular"];
			//um.emissions=N [i] ["emissions"];
			um.CalderesBiomassa=N [i] ["CalderesBiomassa"];
			um.FotovoltaiquesAuto=N [i] ["FotovoltaiquesAuto"];
			um.FotovoltaiquesVenta=N [i] ["FotovoltaiquesVenta"];
			um.AnalisisParticulas=N [i] ["AnalisisParticulas"];
			um.AguaFuentes=N [i] ["AguaFuentes"];
			um.MedidaSonido=N [i] ["MedidaSonido"];
			um.SoporteTecnico=N [i] ["SoporteTecnico"];
			um.AparatosPrestados=N [i] ["AparatosPrestados"];
			um.Turismo=N [i] ["Turismo"];
			//Tecnologia
			um.AsesoramientoJuridico=N [i] ["AsesoramientoJuridico"];
			um.GestionInformacion=N [i] ["GestionInformacion"];
			um.GestionFormacion=N [i] ["GestionFormacion"];
			um.HERMES=N [i] ["HERMES"];
			um.GestionContabilidad=N [i] ["GestionContabilidad"];
			um.GestionPadron=N [i] ["GestionPadron"];
			um.GestionWebs=N [i] ["GestionWebs"];
			um.Muniapps=N [i] ["Muniapps"];
			um.PlataformaUrbana1=N [i] ["PlataformaUrbana1"];
			um.PlataformaUrbana2=N [i] ["PlataformaUrbana2"];
			um.Hibrid=N[i]["Hibrid"];
			um.SITMUN=N [i] ["SITMUN"];
			um.InfraestructurasInformacion=N [i] ["InfraestructurasInformacion"];
			//Posicion
			um.posX = N [i] ["posX"];
			um.posY = N [i] ["posY"];
			um.posZ = N [i] ["posZ"];

			TodosMunicipios.Add (um);

			//Debug.Log ("Nombre: "+um.nombre);
			//Debug.Log ("x: "+um.posX+" y: "+um.posY+" z: "+um.posZ);
			//if (um.bibliobuses != 0) {
				//Debug.Log ("Hay biblio: " + um.bibliotecas);
				cont++;
			GameObject Marker=Instantiate (marcador, new Vector3 (um.posX, um.posY, um.posZ), Quaternion.identity);
			//GameObject Marker=Instantiate (marcador, new Vector3 (um.posX, um.posY, um.posZ), Quaternion.identity);
			Vector3 v = new Vector3 (um.posX, um.posY, um.posZ);
			//v.y = -27;
			//Marker.transform.position= v;
			//GameObject Marker=Instantiate (marcador, new Vector3 (um.posX, um.posY, um.posZ), Quaternion.identity);
			//GameObject Marker=Instantiate (marcador, new Vector3 (um.posX, 70, um.posZ), Quaternion.identity);

				MarkerBehaviour MB= Marker.GetComponentInChildren<MarkerBehaviour> ();

				MB.codigo = um.codigo;
				MB.setYpos (um.posY);
			TapaBehaviour TB= Marker.GetComponentInChildren<TapaBehaviour> ();
			TB.codigo=um.codigo;
				//MB.pos = new Vector3 (um.posX,um.posY,um.posZ);
				//MB.yPos = um.posY;
				//Marker.transform.position= new Vector3 (um.posX,um.posY,um.posZ);
				Marker.transform.position= new Vector3 (um.posX,um.posY-27,um.posZ);	
			//}

		}
		Debug.Log ("Datos recuperados. ");
		Debug.Log ("Pintados: "+cont);
		//Instantiate(marcador,new Vector3(TodosMunicipios[0].posX,TodosMunicipios[0].posY,TodosMunicipios[0].posZ),Quaternion.identity);
		AnimationTrigger atScript = AnimStarters.GetComponent<AnimationTrigger>();
		//atScript.isGrowing = true;
		return true;
	}

	public void writeJsonFile(List<UnMunicipio> listaNueva){


		/*JSONObject j = new JSONObject();
		j = listaNueva as JSONObject;*/
		//number
		//j.AddField("field1", 0.5);
		//string
		//j.AddField("field2", "sampletext");
		//array
		//JSONObject arr = new JSONObject(JSONObject.Type.ARRAY);
		AnimationTrigger atScript = AnimStarters.GetComponent<AnimationTrigger>();
		atScript.isGrowing = true;

		if (atScript.finish) {
			string str;
			string strAll;
			strAll = "[";
			for (int i = 0; i < TodosMunicipios.Count; i++) {
				str = JsonUtility.ToJson (TodosMunicipios [0]);
				if (i < TodosMunicipios.Count - 1) {
					strAll += str + ",";
				} else {
					strAll += str;
				}
			}
			strAll += "]";
			//var N = JSON.ToString(listaNueva);
			Debug.Log ("FICHERO1: " + TodosMunicipios);
			//JsonData jsd = JsonMapper.ToJson (listaNueva);
			//string s=listaNueva.ToString ();
			//Debug.Log ("FICHERO2: "+jsd);
			//Debug.Log ("FICHERO3: "+str);

			//File.WriteAllText (Application.dataPath + "/Resources/Json/DatosMunicipios2.Json", strAll);
		}
	}
	public void writeJsonFile2(){
		string str;
		string strAll;
		strAll = "[";
		for (int i = 0; i < TodosMunicipios.Count; i++) {
			str = JsonUtility.ToJson (TodosMunicipios [i]);
			if (i < TodosMunicipios.Count - 1) {
				strAll += str + ",";
			} else {
				strAll += str;
			}
		}
		strAll += "]";
		//var N = JSON.ToString(listaNueva);
		Debug.Log ("FICHERO1: " + TodosMunicipios);
		//JsonData jsd = JsonMapper.ToJson (listaNueva);
		//string s=listaNueva.ToString ();
		//Debug.Log ("FICHERO2: "+jsd);
		//Debug.Log ("FICHERO3: "+str);

		File.WriteAllText (Application.dataPath + "/Resources/Json/DatosMunicipios2.Json", strAll);
		isFinsihWriting = true;
	}





	public struct UnMunicipio {
		public int codigo;
		public string nombre;
		//Personas
		public int bibliotecas;
		public int bibliobuses;
		public int teleasistencia;
		public int hestia;
		public int governobert;
		public int xaloc;
		public int km2;
		//public int km22;
		//Sostenibilidad
		public int CambioClimatico;
		public int Sostenibilidad;
		public int EconomiaCircular;
		public List<int> emissions;
		public int CalderesBiomassa;
		public int FotovoltaiquesAuto;
		public int FotovoltaiquesVenta;
		public int AnalisisParticulas;
		public int AguaFuentes;
		public int MedidaSonido;
		public int SoporteTecnico;
		public int AparatosPrestados;
		public int Turismo;
		//Tecnologia
		public int AsesoramientoJuridico;
		public int GestionInformacion;
		public int GestionFormacion;
		public int HERMES;
		public int GestionContabilidad;
		public int GestionPadron;
		public int GestionWebs;
		public int Muniapps;
		public int PlataformaUrbana1;
		public int PlataformaUrbana2;
		public int Hibrid;
		public int SITMUN;
		public int InfraestructurasInformacion;
		//Posicion
		public float posX;
		public float posY;
		public float posZ;
		//public List<Escena> escenas;

	}
}
