using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

namespace Control{
public class SceneControl : MonoBehaviour {

		public float timer=0;
	public GameObject[] AnimStarters; //1 personas  //2 sostenibilidad   //3 infraestructuras
	public GameObject[] AnimFinishers;
	public GameObject[] Maquetas;
    public GameObject[] ZonasLisas;
    public GameObject[] LeyendaMarcador;
	public GameObject[] LeyendaMarcadorb;
	public GameObject[] LeyendaMarcadorc;
		public GameObject[] SpriteTablet1;
		public GameObject[] SpriteTablet2;
		public GameObject[] SpriteTablet3;
		public Sprite[] IconosTablet1;
		public Sprite[] IconosTablet2;
		public Sprite[] IconosTablet3;
		public Text[] Titulos;
		public Text[] Subtitulos;
	private ReadMunicipiData rmd;
	public OscIn oscIn;

        //ANIMACIONES
        public GameObject[] BiblioBusAnim;
        //VIDEO PLAYER
        public VideoPlayer videoPlayerMaqueta;
        public VideoClip[] videosMaqueta;
        public VideoPlayer videoPlayerLiso;
        public VideoClip[] videosLiso;
        private bool isTransition = false;
        private bool isEndTransition = false;
        private bool isIntro = false;


        //CONTROL
        public float[] estadoActual;  //codigos del json que indican en que estado estamos [tema, subestado,datos]
        public float estadoSiguiente;
        public float estadoSuperposicion;
        public string superposicionActual;
		public bool[] activeTablets;
		public string[] lenguajeTablets;
        public string[] lenguajes;

        public int layerCotas = 0;
        public int layerSatelite = 1;
        public int layerFondoLiso = 2;
        public int layerVideoMaqueta = 3;
        public int layerExteriorMaqueta=4;
        public int layerLuces = 5;

        public int layerLisoExteriorMaqueta = 0;
        public int layerLisoFondo = 1;
        public int layerLisoVideoTransicion = 2;

        public bool writeJSON = false;
		public bool	isParcs = false;
		public bool isStartParcs = false;
		public bool isEndParcs = false;
		public float parcFlickerSpeed;
		public float parcSpeed;

		public bool	isEmisions = false;
		public bool isStartEmisions = false;
		public bool isEndEmisions = false;
		public int contEmisions=5;
		public float timeLapseEmisions;
		public float timeLeftEmisions;
		public string[] co2Anys;

		public bool	isPolig = false;
		public bool isStartPolig = false;
		public bool isEndPolig = false;
		public float poligFlickerSpeed;

		public bool	isFibra = false;
		public bool isStartFibra = false;
		public bool isEndFibra = false;

		public bool	isPlataforma = false;
		public bool isStartPlataforma = false;
		public bool isEndPlataforma = false;
		public int contPlataforma=5;
		public float timeLapsePlataforma;
		public float timeLeftPlataforma;

		//LEYENDAS
		public string[] subtitulos1;
		public string[] subtitulos2;
		public string[] subtitulos3;

	private bool alpha=true;
		//PERSONES
	public List<int> bibliotecasM;
	public List<int> bibliobusesM;
	public List<int> xarxaBiblioM;
	public List<int> teleasisM;
	public List<int> hestiaM;
	public List<int> atencioM;
	public List<int> governObertM;
	public List<int> xalocM;
	public List<int> km2M;
	public List<int> km21M;
	public List<int> km22M;

		//Sostenibilidad
	public List<int> CambioClimaticoM;
	public List<int> SostenibilidadM;
	public List<int> EconomiaCircularM;
	public List<int> xarxaCiutatsM;
	//public List<int> emissionsM;
	public List<int> CalderesBiomassaM;
	public List<int> FotovoltaiquesAutoM;
	public List<int> FotovoltaiquesVentaM;
		public List<int>	RenovablesM;

	public List<int> OTAGAM;
	public List<int> AnalisisParticulasM;
	public List<int> AguaFuentesM;
	public List<int> MedidaSonidoM;

	public List<int> SoporteTecnicoM;
	public List<int> AparatosPrestadosM;
		public List<int> MesuraM;
	

		public List<int> TurismoM;
		//Tecnologia
		public List<int> ServeisGestioM;
	public List<int> AsesoramientoJuridicoM;
	public List<int> GestionInformacionM;
	public List<int> GestionFormacionM;
	public List<int> HERMESM;
	public List<int> GestionContabilidadM;
	public List<int> GestionPadronM;
	public List<int> GestionWebsM;
	public List<int> MuniappsM;

	public List<int> PlataformaUrbanaM;
	public List<Vector3> PlataformaUrbanaV;
	public List<int> PlataformaUrbana1M;
	public List<int> PlataformaUrbana2M;
		public List<int> HibridM;
	public List<int> SITMUNM;
	public List<int> InfraestructurasInformacionM;



	//COLORES
    public Color colorPERSONAS;
	public Color colorSOSTENIBILIDAD;
	public Color colorTECNOLOGIA;
		//PERSONES
	public Color colorBibliotecas;
	public Color colorBibliobuses;
	public Color colorTeleasis;
	public Color colorGovernObert;
	public Color colorHestia;
	public Color colorXaloc;
	public Color colorKm21;
	public Color colorKm22;
		//SOSTENIBILIDAD
	public Color	colorXarxa;
		public Color	colorXarxa1;
		public Color	colorXarxa2;
		public Color	colorXarxa3;
	public Color	colorRenovables;
	public Color	colorMesura;
		public Color	colorMesura1;
		public Color	colorMesura2;
	public Color	colorOTAGA;
	public Color	colorTurisme;
		//TECNOLOGIA
	public Color colorServeiGestio;
	public Color	colorPlataforma;
		public Color	colorPlataforma1;
		public Color	colorPlataforma2;
		public Color	colorPlataforma3;
	public Color	colorInfraestructures;
		public Color	colorSitmun;
	 


	// START
	void Start () {
            // Ensure that we have a OscIn component.
            //if( !oscIn ) oscIn = gameObject.AddComponent<OscIn>();

            // Start receiving from unicast and broadcast sources on port 7000.
            //oscIn.Open( 8015 );

            /*GameObject canvasObject = GameObject.FindGameObjectWithTag("CanvasTablet1");
		Transform textTr = canvasObject.transform.Find("Titulo");
		Text text = textTr .GetComponent<Text>();*/
            //Text t=Titulos[0].GetComponent<Text>();
            //Inicializar lenguajes
            lenguajes = new string[3];
            lenguajes[0] = "cat";
            lenguajes[1] = "esp";
            lenguajes[2] = "eng";

            lenguajeTablets = new string[3];
        for (int i = 0; i < 3; i++)
        {
                lenguajeTablets[i] = "cat";
        }

        //Inizalizar estados
        estadoActual = new float[3];
        for (int i = 0; i < 3; i++)
        {
                estadoActual[i] = 0;
        }

        //Materiales apagados de inicio (municipios, lineas, contornos, material liso,etc)
        for (int i = 0; i < Maquetas.Length; i++)
        {
            Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
            Color cm = m[layerLuces].color;
                cm.a = 0;
                Color cv = m[layerFondoLiso].color;
                cv.a = 0;

            m[layerFondoLiso].color = cv; //colorLiso
            m[layerLuces].color = cm; //Municipios
        }
        //changeAlphaMaterialPlanos(1,0);

        //VIDEOS en off
        changeAlphaVideoMaqueta(layerVideoMaqueta,0);
        changeAlphaVideoLisas(layerLisoVideoTransicion,0);
        

		for(int i=0;i<LeyendaMarcador.Length;i++){
			LeyendaMarcador [i].GetComponent<MeshRenderer> ().enabled = false;
			//LeyendaMarcadorb [i].GetComponent<SpriteRenderer> ().enabled = false;
			//LeyendaMarcadorc [i].GetComponent<SpriteRenderer> ().enabled = false;
		}
			for(int i=0;i<LeyendaMarcadorb.Length;i++){
				LeyendaMarcadorb [i].GetComponent<SpriteRenderer> ().enabled = false;
			}
			for(int i=0;i<LeyendaMarcadorc.Length;i++){
				LeyendaMarcadorc [i].GetComponent<SpriteRenderer> ().enabled = false;
			}

		rmd=GetComponent<ReadMunicipiData>();
		bool b=rmd.fillData ();
		if(!b){
			Debug.Log ("No data filled");
		}

		bibliotecasM = new List<int> ();
		bibliobusesM= new List<int> ();
		fillArrays ();



	}// START
	
	//UPDATE
	void Update () {
            keyControl();
            
            if (isTransition) {//transicion de maqueta a contenido
                if (videoPlayerMaqueta.frame >= 20)//frame en el cual se cambia el fondo
                {
                    Debug.Log("enciende materialliso");
                    changeAlphaMaterialMaqueta(layerFondoLiso, 1);
                    changeAlphaMaterialPlanos(layerLisoFondo, 1);

                }
                Debug.Log("isPlaying"+ videoPlayerMaqueta.frame+" fc: "+ videoPlayerMaqueta.frameCount);
                if (videoPlayerMaqueta.frame == (long)videoPlayerMaqueta.frameCount)
                {
                    isTransition = false;
                    videoPlayerMaqueta.Stop();
                    changeAlphaVideoMaqueta(layerVideoMaqueta, 0);
                    changeAlphaVideoLisas(layerLisoVideoTransicion, 0);
                    //StartIntro(estadoActual[0]);
                }
            }
            if (isEndTransition)
            {//transicion de maqueta a contenido
                if (videoPlayerMaqueta.frame >= 20)//frame en el cual se cambia el fondo
                {
                    Debug.Log("Apaga materialliso");
                    changeAlphaMaterialMaqueta(layerFondoLiso, 0);
                    changeAlphaMaterialPlanos(layerLisoFondo, 0);

                }
                Debug.Log("isPlaying" + videoPlayerMaqueta.frame + " fc: " + videoPlayerMaqueta.frameCount);
                if (videoPlayerMaqueta.frame == (long)videoPlayerMaqueta.frameCount)
                {
                    isEndTransition = false;
                    videoPlayerMaqueta.Stop();
                    changeAlphaVideoMaqueta(layerVideoMaqueta, 0);
                    changeAlphaVideoLisas(layerLisoVideoTransicion, 0);
                    //StartIntro(estadoActual[0]);
                }
            }
            if (isIntro)//video introduccion tema
            {
                
                Debug.Log("isPlaying" + videoPlayerLiso.frame + " fc: " + videoPlayerLiso.frameCount);
                if (videoPlayerLiso.frame == (long)videoPlayerLiso.frameCount)
                {
               
                    videoPlayerLiso.Stop();
                    StartContent(estadoActual[0]);
                    changeAlphaVideoLisas(layerLisoVideoTransicion, 0);
                    StartContent(estadoActual[1]);
                }
            }


            /*AnimationTrigger atScript = AnimStarters[0].GetComponent<AnimationTrigger>();
            if(atScript.finish==true){
                AnimationTrigger atScript2 = AnimFinishers[0].GetComponent<AnimationTrigger>();
                atScript2.isGrowing = true;
            }*/

            timer = timer + Time.deltaTime;
			//timer = 0;
		//LIMPIAR SI ESTA 10 segundos sin actividad
			if (!activeTablets [0] && !activeTablets [1] && !activeTablets [2] && timer>60) {

				for (int i = 0; i < AnimFinishers.Length; i++) {
					AnimationTrigger at = AnimFinishers [i].GetComponent<AnimationTrigger> ();
					at.isGrowing = true;
				}
				timer = 0;
			}
			if (timer >= 60) {
				timer = 0;

			}

		//WRITE JSON
			if (writeJSON) {
				rmd.writeJsonFile (rmd.TodosMunicipios);
				writeJSON = false;
			}


		//LIMITES
        /*
			Color c0=new Color();
				int numLimites = 17;
			if (activeTablets [0] || activeTablets [1] || activeTablets [2]) {
				for (int i = 0; i < Maquetas.Length; i++) {
					Material[] m = Maquetas [i].GetComponent<Renderer> ().materials;
					c0 = m [numLimites].color;
					c0.a = c0.a+ parcSpeed;
					if (c0.a >= 1) {
						c0.a = 1;
					}
						
					m [numLimites].color = c0;
				}
			} else {
				for (int i = 0; i < Maquetas.Length; i++) {
					Material[] m = Maquetas [i].GetComponent<Renderer> ().materials;
					c0 = m [numLimites].color;
					c0.a = c0.a- parcSpeed;;
					if (c0.a <= 0) {
						c0.a = 0;
					}

					m [numLimites].color = c0;
				}
			}
			*/


		//PARCS
		Color c = new Color();
			int numTexturaParcs = 16;
			if(isParcs){
				if (isStartParcs) {
					
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c = m [numTexturaParcs].color;
						c.a = c.a + parcSpeed;

						m [numTexturaParcs].color = c;
					}
					if (c.a >= 0.75f) {
						c.a = 0.75f;
						isStartParcs = false;
					}

				}else if(!isEndParcs ){
					float spd = parcFlickerSpeed;
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c = m [numTexturaParcs].color;
						c.a = c.a + parcFlickerSpeed;
						if (c.a >= 0.75f) {
							c.a = 0.75f;
						}
						if (c.a <= 0.15f) {
							c.a = 0.15f;
						}
						m [numTexturaParcs].color = c;
					}

					if (c.a >= 0.75f) {
						c.a = 0.75f;
						//isStartParcs = false;
						parcFlickerSpeed = -parcFlickerSpeed;
					} 
					if(c.a<=0.15f){
						c.a = 0.15f;
						//isStartParcs = false;
						parcFlickerSpeed = -parcFlickerSpeed;
					}


				}

				if (isEndParcs) {
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c = m [numTexturaParcs].color;
						c.a = c.a - parcSpeed;

						m [numTexturaParcs].color = c;
					}
					if (c.a <= 0) {
						c.a = 0;
						isEndParcs = false;
						isParcs = false;
					}
				}

			}


		//EMISIONS
			Color c1 = new Color();
			if(isEmisions){
				
				for (int i = 0; i < Maquetas.Length; i++) {
					Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
					for (int j = 5; j <=14; j++) {  //5-14
						c1 = m [j].color;
						c1.a = 0;
						m [j].color = c1;
					}
					c1 = m [contEmisions].color;
					c1.a = 0.6f;

					//Titulos[2].text="Plataforma";
					string t=co2Anys[contEmisions-5];
					Subtitulos[1].text=t;

					m [contEmisions].color = c1;
				}
				timeLeftEmisions -= Time.deltaTime;

				if (timeLeftEmisions < 0) {
					timeLeftEmisions = timeLapseEmisions;
					contEmisions++;
					if (contEmisions > 14) {
						contEmisions = 5;
					}
				}

				/*if (isStartEmisions) { //5-14

					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c1 = m [5].color;
						c1.a = c1.a + parcSpeed;

						m [5].color = c1;
					}
					if (c1.a >= 0.55f) {
						c1.a = 0.55f;
						isStartEmisions = false;
					}

				}*/

				if (isEndEmisions) {
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m = Maquetas [i].GetComponent<Renderer> ().materials;
						for (int j = 5; j <= 14; j++) {
							c1 = m [j].color;
							c1.a = 0;
							m [j].color = c1;
							Subtitulos [1].text = "";
						}
					}
					isEndEmisions = false;
					isEmisions = false;
				/*	if (c1.a <= 0) {
						c1.a = 0;
						isEndEmisions = false;
						isEmisions = false;
					}*/
				}

			}//end emisions

			//Poligons
			Color c3 = new Color();
			int numTexturaPol = 15;
			if(isPolig){
				if (isStartPolig) {

					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c3 = m [numTexturaPol].color;
						c3.a = c3.a + parcSpeed;

						m [numTexturaPol].color = c3;
					}
					if (c3.a >= 0.85f) {
						c3.a = 0.85f;
						isStartPolig = false;
					}

				}else if(!isEndPolig ){
					float spd = poligFlickerSpeed;
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c3 = m [numTexturaPol].color;
						c3.a = c3.a + poligFlickerSpeed;
						if (c3.a >= 0.85f) {
							c3.a = 0.85f;
						}
						if (c3.a <= 0.35f) {
							c3.a = 0.35f;
						}
						m [numTexturaPol].color = c3;
					}

					if (c3.a >= 0.85f) {
						c3.a = 0.85f;
						poligFlickerSpeed = -poligFlickerSpeed;
					} 
					if(c3.a<=0.35f){
						c3.a = 0.35f;
						poligFlickerSpeed = -poligFlickerSpeed;
					}


				}

				if (isEndPolig) {
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c3 = m [numTexturaPol].color;
						c3.a = c3.a - parcSpeed;

						m [numTexturaPol].color = c3;
					}
					if (c3.a <= 0) {
						c3.a = 0;
						isEndPolig = false;
						isPolig = false;
					}
				}

			}//End poligons
			//Fibra
			Color c4 = new Color();
			int numTexturaFibra = 18;
			if(isFibra){
				if (isStartFibra) {

					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c4 = m [numTexturaFibra].color;
						c4.a = c4.a + parcSpeed;

						m [numTexturaFibra].color = c4;
					}
					if (c4.a >=1f) {
						c4.a = 1f;
						isStartFibra = false;
					}

				}

				if (isEndFibra) {
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c4 = m [numTexturaFibra].color;
						c4.a = c4.a - parcSpeed;

						m [numTexturaFibra].color = c4;
					}
					if (c4.a <= 0) {
						c4.a = 0;
						isEndFibra = false;
						isFibra = false;
					}
				}

			}//End fibra
				

	}//END UPDATE
    

    void changeAlphaMaterialMaqueta(int material, float a)
    {
            for (int i = 0; i < Maquetas.Length; i++)
            {
                Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
                Color cv = m[material].color;
                cv.a = a;

                m[material].color = cv; //colorLiso
            }

    }
    void changeAlphaMaterialPlanos( int material, float a)
    {
        for (int i = 0; i < ZonasLisas.Length; i++)
        {
            Material[] m = ZonasLisas[i].GetComponent<Renderer>().materials;
            Color cv = m[material].color;
            cv.a = a;

            m[material].color = cv; //colorLiso
        }

    }
    void changeAlphaVideoMaqueta(int material,float a)
    {
         for (int i = 0; i < Maquetas.Length; i++)
        {
            Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
            Color cv = m[material].color;
            cv.a = a;

            m[material].color = cv; //colorLiso
        }
    }
    void changeColorVideoMaqueta(int material,Color c)
    {
         for (int i = 0; i < Maquetas.Length; i++)
        {
            Material[] m = Maquetas[i].GetComponent<Renderer>().materials;

            m[material].color = c; //colorLiso
        }
    }
    void changeColorVideoLiso(int material,Color c)
    {
         for (int i = 0; i < ZonasLisas.Length; i++)
        {
            Material[] m = ZonasLisas[i].GetComponent<Renderer>().materials;

            m[material].color = c; //colorLiso
        }
    }
    void changeAlphaVideoLisas(int material,float a)
    {
         for (int i = 0; i < ZonasLisas.Length; i++)
        {
            Material[] m = ZonasLisas[i].GetComponent<Renderer>().materials;
            Color cv = m[material].color;
            cv.a = a;

            m[material].color = cv; //colorLiso
        }
    }

    //Control de teclado para testing
    void keyControl()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) //PERSONAS
        {
            Debug.Log("Personas");
            StartTransition(1);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //PERSONAS
        {
            Debug.Log("PersonasSale");
            EndTransition(1);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //SOSTENIBILIDAD
        {
            Debug.Log("Sostenibilidad");
            StartTransition(2);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) //SOSTENIBILIDAD
            {
            Debug.Log("SostenibilidadSale");
            EndTransition(2);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) //TECNOLOGIA
        {
            Debug.Log("Tecnologia");
            StartTransition(3);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) //TECNOLOGIA
            {
            Debug.Log("TecnologiaSale");
            EndTransition(3);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)) //PERSONAS
        {
            int r =Random.Range(0, 3);
            lenguajeTablets[0] = lenguajes[r];
            Debug.Log("Cambia idioma tablet1:"+r+" Estado:"+ (int)estadoActual[2]);
            writeTextLanguage(0,(int)estadoActual[2]);  
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("startbiblio");
            StartBiblio2(111);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("startbuses");
            StartBiblio2(112);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("startlabs");
            StartBiblio2(113);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("startteleasistencia");
            StartTeleasis(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("startHestia");
            StartTeleasis(2);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("startGovernObert");
            //StartGovernObert(1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("startXALOC");
            //StartTeleasis(2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("startPoligons");
            //StartGovernObert(1);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("startKM2");
            //StartTeleasis(2);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("startPatrimoni");
            //StartGovernObert(1);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Clean");
            Clean1();
        }

        }

	void fillArrays(){
		rmd=GetComponent<ReadMunicipiData>();
		for(int i=0;i<rmd.TodosMunicipios.Count;i++){
			///////////////////
			///TABLET PERSONAS
			//////////////////
			//Bibliotecas
			if(rmd.TodosMunicipios[i].bibliotecas != 0){
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				m.nombre=rmd.TodosMunicipios[i].nombre;
				m.numero=rmd.TodosMunicipios[i].bibliotecas;
				m.posX=rmd.TodosMunicipios[i].posX;
				m.posY=rmd.TodosMunicipios[i].posY;
				m.posZ=rmd.TodosMunicipios[i].posZ;
				m.colorM=colorBibliotecas;
				bibliotecasM.Add (m.codigo);
				xarxaBiblioM.Add (m.codigo);
			}
			//BiblioBuses
			if(rmd.TodosMunicipios[i].bibliobuses != 0){
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				m.nombre=rmd.TodosMunicipios[i].nombre;
				m.numero=rmd.TodosMunicipios[i].bibliobuses;
				m.posX=rmd.TodosMunicipios[i].posX;
				m.posY=rmd.TodosMunicipios[i].posY;
				m.posZ=rmd.TodosMunicipios[i].posZ;
				m.colorM=colorBibliobuses;
				bibliobusesM.Add (m.codigo);
				xarxaBiblioM.Add (m.codigo);
			}
			//Teleasistencia
			if (rmd.TodosMunicipios [i].teleasistencia != 0) {
					Marcador m=new Marcador();
					m.codigo=rmd.TodosMunicipios[i].codigo;
					teleasisM.Add (m.codigo);
					atencioM.Add (m.codigo);
			}
			//HESTIA
			if (rmd.TodosMunicipios [i].hestia != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				hestiaM.Add (m.codigo);
				atencioM.Add (m.codigo);
			}
			//GovernOBERT
			if (rmd.TodosMunicipios [i].governobert != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				governObertM.Add (m.codigo);
			}
			//XALOC
			if (rmd.TodosMunicipios [i].xaloc != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				xalocM.Add (m.codigo);
			}
			//KM21
			if (rmd.TodosMunicipios [i].km2 != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				km21M.Add (m.codigo);
				km2M.Add (m.codigo);
			}
			//KM22
			/*if (rmd.TodosMunicipios [i].km22 != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				km22M.Add (m.codigo);
				km2M.Add (m.codigo);

			}*/

			/////////////////////////
			///TABLET SOSTENIBILIDAD
			////////////////////////
			//CambioClimaticoM;
			if (rmd.TodosMunicipios [i].CambioClimatico != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
					CambioClimaticoM.Add (m.codigo); 
					xarxaCiutatsM.Add (m.codigo);
			}
			//SostenibilidadM;
			if (rmd.TodosMunicipios [i].Sostenibilidad != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				SostenibilidadM.Add (m.codigo);
					xarxaCiutatsM.Add (m.codigo);
			}
			//EconomiaCircularM;
			if (rmd.TodosMunicipios [i].EconomiaCircular != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				EconomiaCircularM.Add (m.codigo);
					xarxaCiutatsM.Add (m.codigo);
			}
			//emissionsM;
				/*if (rmd.TodosMunicipios [i].emissions != 0) {
					Marcador m=new Marcador();
					m.codigo=rmd.TodosMunicipios[i].codigo;
					emissionsM.Add (m.codigo);
				}*/
			// CalderesBiomassaM;
			if (rmd.TodosMunicipios [i].CalderesBiomassa != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				CalderesBiomassaM.Add (m.codigo);
					RenovablesM.Add (m.codigo);

			}
			//FotovoltaiquesAutoM;
			if (rmd.TodosMunicipios [i].FotovoltaiquesAuto != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				FotovoltaiquesAutoM.Add (m.codigo);
					RenovablesM.Add (m.codigo);

			}
			//FotovoltaiquesVentaM;
			if (rmd.TodosMunicipios [i].FotovoltaiquesVenta != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				FotovoltaiquesVentaM.Add (m.codigo);
					RenovablesM.Add (m.codigo);

			}

			//AnalisisParticulasM;
			if (rmd.TodosMunicipios [i].AnalisisParticulas != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				AnalisisParticulasM.Add (m.codigo);
					OTAGAM.Add (m.codigo);
			}
			//AguaFuentesM;
			if (rmd.TodosMunicipios [i].AguaFuentes != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				AguaFuentesM.Add (m.codigo);
					OTAGAM.Add (m.codigo);
			}
			//MedidaSonidoM;
			if (rmd.TodosMunicipios [i].MedidaSonido != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				MedidaSonidoM.Add (m.codigo);
					OTAGAM.Add (m.codigo);
			}

			//SoporteTecnicoM;
			if (rmd.TodosMunicipios [i].SoporteTecnico != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
					SoporteTecnicoM.Add (m.codigo);
					MesuraM.Add (m.codigo);
			}
			//AparatosPrestadosM;
			if (rmd.TodosMunicipios [i].AparatosPrestados != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				AparatosPrestadosM.Add (m.codigo);
					MesuraM.Add (m.codigo);
			}

			//TurismoM;
			if (rmd.TodosMunicipios [i].Turismo != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				TurismoM.Add (m.codigo);
			}


			/////////////////////
			///TABLET TECNOLOGIA
			///////////////////
			// AsesoramientoJuridicoM;
			if (rmd.TodosMunicipios [i].AsesoramientoJuridico != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
					AsesoramientoJuridicoM.Add (m.codigo);
					ServeisGestioM.Add (m.codigo);
			}
			// GestionInformacionM;
			if (rmd.TodosMunicipios [i].GestionInformacion != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				GestionInformacionM.Add (m.codigo);
					ServeisGestioM.Add (m.codigo);
			}
			// GestionFormacionM;
			if (rmd.TodosMunicipios [i].GestionFormacion != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				GestionFormacionM.Add (m.codigo);
					ServeisGestioM.Add (m.codigo);
			}
			// HERMESM;
			if (rmd.TodosMunicipios [i].HERMES != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				HERMESM.Add (m.codigo);
					ServeisGestioM.Add (m.codigo);
			}
			// GestionContabilidadM;
			if (rmd.TodosMunicipios [i].GestionContabilidad != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				GestionContabilidadM.Add (m.codigo);
					ServeisGestioM.Add (m.codigo);
			}
			// GestionPadronM;
			if (rmd.TodosMunicipios [i].GestionPadron != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				GestionPadronM.Add (m.codigo);
					ServeisGestioM.Add (m.codigo);
			}
			//GestionWebsM;
			if (rmd.TodosMunicipios [i].GestionWebs != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				GestionWebsM.Add (m.codigo);
			}
			// MuniappsM;
			if (rmd.TodosMunicipios [i].Muniapps != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				MuniappsM.Add (m.codigo);
					ServeisGestioM.Add (m.codigo);
			}

			// PlataformaUrbana1M;
			if (rmd.TodosMunicipios [i].PlataformaUrbana1 != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				PlataformaUrbana1M.Add (m.codigo);
				PlataformaUrbanaM.Add (m.codigo);
					PlataformaUrbanaV.Add (new Vector3(rmd.TodosMunicipios[i].posX,rmd.TodosMunicipios[i].posY,rmd.TodosMunicipios[i].posZ));
				}
			// PlataformaUrbana2M;
			if (rmd.TodosMunicipios [i].PlataformaUrbana2 != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				PlataformaUrbana2M.Add (m.codigo);
					PlataformaUrbanaM.Add (m.codigo);
					PlataformaUrbanaV.Add (new Vector3(rmd.TodosMunicipios[i].posX,rmd.TodosMunicipios[i].posY,rmd.TodosMunicipios[i].posZ));
			}
			//Hibrid
				if (rmd.TodosMunicipios [i].Hibrid != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				HibridM.Add (m.codigo);
				//PlataformaUrbana2M.Add (m.codigo);
				PlataformaUrbanaM.Add (m.codigo);
				PlataformaUrbanaV.Add (new Vector3(rmd.TodosMunicipios[i].posX,rmd.TodosMunicipios[i].posY,rmd.TodosMunicipios[i].posZ));
			}


			// SITMUNM;
			if (rmd.TodosMunicipios [i].SITMUN != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				SITMUNM.Add (m.codigo);
			}
			// InfraestructurasInformacionM;
			if (rmd.TodosMunicipios [i].InfraestructurasInformacion != 0) {
				Marcador m=new Marcador();
				m.codigo=rmd.TodosMunicipios[i].codigo;
				InfraestructurasInformacionM.Add (m.codigo);
			}
		}
			Debug.Log ("Array bibliotecas:"+bibliotecasM.Count);
			Debug.Log ("Array formacion:"+GestionFormacionM.Count);
	}


	/// 
	/// OSC CONTROL
	/// 
	void OnEnable()
	{
		// You can "map" messages to methods in three ways:

		// 1) For messages with one argument, simply provide the address and
		// a method with one argument. In this case, OnTest1 takes a float argument.
		//PERSONAS
			//oscIn.MapInt( "/persones/biblioteques", StartBiblio);
		//oscIn.Map( "/persones/bibliobuses", StartBuses);
			oscIn.MapInt( "/persones/teleasistencia", StartTeleasis);
		oscIn.MapInt( "/persones/parcs", StartParcs);

		oscIn.Map( "/persones/govern_obert", StartGovernObert);
		oscIn.Map( "/persones/xaloc", StartXaloc);
		oscIn.Map( "/persones/km2", StartKm2);

		//SOSTENIBILIDAD
			oscIn.MapInt( "/sostenibilitat/xarxa", StartXarxa);
			oscIn.Map( "/sostenibilitat/municipis", StartEmisions);
			oscIn.MapInt( "/sostenibilitat/renovables", StartRenovables);
			oscIn.MapInt( "/sostenibilitat/mesura", StartMesura);

			oscIn.MapInt( "/sostenibilitat/otaga", StartOTAGA);
			oscIn.Map( "/sostenibilitat/turisme", StartTurisme);

		//Tecnologia
			oscIn.MapInt( "/tecnologia/serveigestio", StartServeiGestio);
			oscIn.MapInt( "/tecnologia/plataforma", StartPlataforma);
			oscIn.MapInt( "/tecnologia/infraestructures", StartInfraestructures);
			oscIn.Map( "/tecnologia/poligons", StartPoligons);
			oscIn.Map( "/tecnologia/fibra", StartFibra);

		//IDIOMAS
			oscIn.Map( "/persones/eng", IdiomaPersoneseng );
			oscIn.Map( "/persones/cat", IdiomaPersonescat );
			oscIn.Map( "/sostenibilitat/eng", IdiomaSostenibilitateng);
			oscIn.Map( "/sostenibilitat/cat", IdiomaSostenibilitatcat );
			oscIn.Map( "/tecnologia/eng", IdiomaTecnologiaeng );
			oscIn.Map( "/tecnologia/cat", IdiomaTecnologiacat );
		
			//ESPERA

		//oscIn.Map( "/persones/espera", Clean1 );
		oscIn.Map( "/sostenibilitat/espera", Clean2 );
		oscIn.Map( "/tecnologia/espera", Clean3 );


	}


    //CONTROL DE ANIMACIONES DE VIDEO
    public void StartTransition(float state)//transicion de maqueta a tema
    {
            isTransition = true;

            videoPlayerMaqueta.clip = videosMaqueta[Random.Range(0, videosMaqueta.Length)];
            //videoPlayerMaqueta.frame = 0;
            videoPlayerMaqueta.Play();

            videoPlayerLiso.clip= videosLiso[Random.Range(0, videosLiso.Length)];
            videoPlayerLiso.Play();
            //Cambiar color
            if (state==1)//personas
            {
                changeColorVideoMaqueta(layerVideoMaqueta, colorPERSONAS);
                changeColorVideoLiso(layerLisoVideoTransicion, colorPERSONAS);
            }
            if (state == 2)//sostenibilidad
            {
                changeColorVideoMaqueta(layerVideoMaqueta, colorSOSTENIBILIDAD);
                changeColorVideoLiso(layerLisoVideoTransicion, colorSOSTENIBILIDAD);
            }
            if (state == 3)//tecnologia
            {
                changeColorVideoMaqueta(layerVideoMaqueta, colorTECNOLOGIA);
                changeColorVideoLiso(layerLisoVideoTransicion, colorTECNOLOGIA);
            }

            //videos ON
            changeAlphaVideoMaqueta(layerVideoMaqueta, 1);
            changeAlphaVideoLisas(layerLisoVideoTransicion, 1);

     }
    public void EndTransition(float state)//transicion de maqueta a tema
    {
            isEndTransition = true;

            videoPlayerMaqueta.clip = videosMaqueta[1];
            //videoPlayerMaqueta.frame = 0;
            videoPlayerMaqueta.Play();
            videoPlayerLiso.Play();
            //Cambiar color
            if (state == 1)//personas
            {
                changeColorVideoMaqueta(layerVideoMaqueta, colorPERSONAS);
                //changeColorVideoLisas(layerLisoVideoTransicion, 1);
            }
            if (state == 2)//sostenibilidad
            {
                changeColorVideoMaqueta(layerVideoMaqueta, colorSOSTENIBILIDAD);
                //changeColorVideoLisas(layerLisoVideoTransicion, 1);
            }
            if (state == 3)//tecnologia
            {
                changeColorVideoMaqueta(layerVideoMaqueta, colorTECNOLOGIA);
                //changeColorVideoLisas(layerLisoVideoTransicion, 1);
            }
            //videos ON
            changeAlphaVideoMaqueta(layerVideoMaqueta, 1);
            changeAlphaVideoLisas(layerLisoVideoTransicion, 1);

     }

    public void StartIntro(float state) //Comienza videos introductorios
    {
            

    }

    public void StartContent(float state) //Lanza contenido
    {
            StartBiblio2((int)estadoActual[2]);

     }

    //Elige el texto a poner en la zona de cada tablet
    public void writeTextLanguage(int tablet,int estado) {

            //Bibliotecas
            if (estado == 111)
            {
                Debug.Log("Cambia texto leyenda bibliotecaz");
                for (int i = 0; i < 3; i++)
                {
                    if (lenguajeTablets[i] == "cat")
                    {
                        Titulos[i].text = "Biblioteques";
                        Subtitulos[i].text = "";
                    }
                    else if (lenguajeTablets[i] == "eng")
                    {
                        Titulos[i].text = "Libraries";
                        Subtitulos[i].text = "";
                    }
                    else if (lenguajeTablets[i] == "esp")
                    {
                        Titulos[i].text = "Bibliotecas";
                        Subtitulos[i].text = "";
                    }
                }
            }
            //Bibliobuses
            if (estado == 112)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (lenguajeTablets[i] == "cat")
                    {
                        Titulos[0].text = "Bibliobusos";
                        Subtitulos[0].text = "";
                    }
                    else if (lenguajeTablets[i] == "eng")
                    {
                        Titulos[0].text = "Mobile Libraries";
                        Subtitulos[0].text = "";
                    }
                    else if (lenguajeTablets[i] == "esp")
                    {
                        Titulos[0].text = "Bibliobuses";
                        Subtitulos[0].text = "";
                    }
                }
            }
    }

    //PERSONAS
    public void StartBiblio(int value,bool superposicion)
    {
            if (!superposicion) estadoActual[0] = 1; //si no es superposicion se cambia el estado actual

            if (value == 0) //valor por defecto
            {
                if (!superposicion)
                {
                    estadoActual[1] = 11;
                }
                
            }
            else if (value == 1) //Bibliotecas
            {
                if (!superposicion)
                {
                    estadoActual[2] = 111;
                }
                else
                {
                    estadoSuperposicion = 111;
                }

            }
            else if (value == 2) //bibliobuses
            {
                if (!superposicion)
                {
                    estadoActual[2] = 112;
                }
                else
                {
                    estadoSuperposicion = 112;
                }
            }
            else if (value == 3)//bibliolabs
            {
                if (!superposicion)
                {
                    estadoActual[2] = 113;
                }
                else
                {
                    estadoSuperposicion = 113;
                }
            }
            
            

            
            /*for (int i = 0; i < Maquetas.Length; i++)
            {
                Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
                Color cv = m[2].color;
                cv.a = 0;

                m[2].color = cv;
            }
            StartBiblio2(value);*/

    }
    public void StartBiblio2(int value)    //recibe el valor del dato a mostrar y elegirá el tipo que es y como animarlo
	{
		Debug.Log( "Received: biblio "+value);
		MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
			activeTablets [0] = true;
		    mc.colorToChange = colorBibliotecas;
			LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorBibliotecas;
			LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[0];
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			
			if (value == 111) { //bibliotecas
                estadoActual[2] = value;
			    mc.colorToChange = colorBibliotecas;
			    LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorBibliotecas;
			    at.contenido = "Bibliotecas";
                writeTextLanguage(0, value);
                /*if (lenguajeTablets [0] == "cat") {
				    Titulos [0].text = "Biblioteques";
				    Subtitulos [0].text = "";
			    } else {
				    Titulos [0].text = "Libraries";
				    Subtitulos [0].text = "";
			    }*/

			    LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[0];
			    LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
                at.isGrowing = true;
            }
			else if (value == 112) { //bibliobuses
                estadoActual[2] = value;
                //activar bibliobus
                for (int i=0;i < BiblioBusAnim.Length; i++)
                {
                    BiblioBusAnim[i].active = true;
                }
               
                //at.contenido = "Bibliobuses";
                mc.colorToChange = colorBibliobuses;
				LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorBibliobuses;
                writeTextLanguage(0,value);
				/*if (lenguajeTablets [0] == "cat") {
					Titulos [0].text = "Bibliobusos";
					Subtitulos [0].text = "";
				} else if {
					Titulos [0].text = "Mobile Libraries";
					Subtitulos [0].text = "";
				}*/
				

				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[1];
				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (value == 113)//bibliolabs
            {
                estadoActual[2] = value;
                //bibliolabs
                //activar marcadores con color azulado brillante
                changeAlphaMaterialMaqueta(3, 1);
                
            }


           



	}
	/*public void StartBuses(OscMessage message)
	{
		Debug.Log( "Received: buses " );
		MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
		mc.colorToChange = colorBibliobuses;
			at.contenido = "Bibliobuses";
		at.isGrowing = true;
			Titulos[0].text="Bibliobuses";
			Subtitulos[0].text="101 Municipios";
	}
	*/
		public void StartTeleasis(int value )
	{
		Debug.Log( "Received: teleasis ");
		MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
			LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = true;
			activeTablets [0] = true;
			/*if (value == 0) {
				mc.colorToChange = colorTeleasis;
				LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorTeleasis;
				at.contenido = "Atencio";
				at.isGrowing = true;
				if (lenguajeTablets [0] == "cat") {
					Titulos [0].text = "Municipis amb el servei de teleassistència ";
					Subtitulos [0].text = "";
				} else {
					Titulos [0].text = "Municipalities with Telecare Service";
					Subtitulos [0].text = "";
				}

				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[3];
				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			}*/
			if(value == 1 || value==0){
				mc.colorToChange = colorTeleasis;
				LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorTeleasis;
				at.contenido = "Teleasistencia";
				at.isGrowing = true;
				if (lenguajeTablets [0] == "cat") {
					Titulos [0].text = "Municipis amb el servei de teleassistència ";
					Subtitulos [0].text = "72.000 usuaris";
				} else {
					Titulos [0].text = "Municipalities with Telecare Service";
					Subtitulos [0].text = "72.000 users";
				}

				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[3];
				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			}
			else if(value == 2){
				mc.colorToChange = colorHestia;
				LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorHestia;
				at.contenido = "HESTIA";
				at.isGrowing = true;
				if (lenguajeTablets [0] == "cat") {
					Titulos [0].text = "Municipis que utilitzen Hèstia ";
					Subtitulos [0].text = "";
				} else {
					Titulos [0].text = "Municipalities using Hèstia";
					Subtitulos [0].text = "";
				}

				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[7];
				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			}
	}
	public void StartGovernObert(OscMessage message )
	{
		LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[4];
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [0] = true;
		Debug.Log( "Received: GovernObert ");
		MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
		mc.colorToChange = colorGovernObert;
			LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorGovernObert;
		at.contenido = "GovernOBERT";
		at.isGrowing = true;
			if (lenguajeTablets [0] == "cat") {
				Titulos[0].text="Municipis amb actuacions de Govern Obert";
				Subtitulos[0].text="";
			} else {
				Titulos [0].text = "Municipalities with Open Government actions";
				Subtitulos [0].text = "";
			}

	}
	public void StartXaloc(OscMessage message )
	{
			LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[6];
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [0] = true;
		Debug.Log( "Received: Xaloc ");
		MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
		mc.colorToChange = colorXaloc;
			LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorXaloc;
		at.contenido = "Xaloc";
		at.isGrowing = true;
			if (lenguajeTablets [0] == "cat") {
				Titulos[0].text="Municipis dins de la xarxa Xaloc";
				Subtitulos[0].text="";
			} else {
				Titulos [0].text = "Municipalities within the Xaloc network";
				Subtitulos [0].text = "";
			}

	}
	public void StartKm2(OscMessage message )
	{
		Debug.Log( "Received: Km2 ");
			LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[5];
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [0] = true;
		MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
		mc.colorToChange = colorKm21;
			LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorKm21;
		at.contenido = "Km2";
		at.isGrowing = true;
			if (lenguajeTablets [0] == "cat") {
				Titulos[0].text="Municipis amb l'aplicació Km2 Ciutat";
				Subtitulos[0].text="";
			} else {
				Titulos [0].text = "Municipalities with the Km2 City application";
				Subtitulos [0].text = "";
			}


	}
		public void StartParcs(int value )
		{
			Debug.Log( "Received: Parcs ");
			LeyendaMarcadorb [0].GetComponent<SpriteRenderer>().enabled = true;
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[2];
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [0] = true;
			isParcs = true;
			isStartParcs = true;
			isEndParcs = false;
			//MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
			//AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
			//mc.colorToChange = colorKm21;
			//at.contenido = "Km2";
			//at.isGrowing = true;
			if (lenguajeTablets [0] == "cat") {
				Titulos[0].text="Àrees dels parcs naturals";
				Subtitulos[0].text="12 Espais naturals";
			} else {
				Titulos [0].text = "Natural Parcs Areas";
				Subtitulos [0].text = "12 Natural spaces";
			}

		}

	//SOSTENIBILIDAD
		public void StartXarxa(int value )
	{
		Debug.Log( "Received: Xarxa ");
		MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();
			activeTablets [1] = true;
			/*if (value == 0) {
				LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[3];
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorXarxa;
				LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorXarxa;
				if (lenguajeTablets [1] == "cat") {
					Titulos[1].text="Xarxa";
					Subtitulos[1].text=" ";
				} else {
					Titulos [1].text = "Network";
					Subtitulos [1].text = "";
				}
				at.contenido = "Xarxa";
				at.isGrowing = true;

			}*/
			 if(value == 1 ||value == 0){
				LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[6];
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorXarxa1;
				LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorXarxa1;
				at.contenido = "CambioClimatico";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis dins del grup de treball del canvi climàtic i qualitat ambiental ";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities within the working group on climate change and environmental quality";
					Subtitulos [1].text = "";
				}

			}
			else if(value == 2){
				LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[7];
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorXarxa2;
				LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorXarxa2;
				at.contenido = "Sostenibilitat";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis dins dels grup de treball de sostenibilitat per les persones";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities within the working group on sustainability for people";
					Subtitulos [1].text = "";
				}

			}
			else if(value == 3){
				LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[9];
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorXarxa3;
				LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorXarxa3;
				at.contenido = "EconomiaCircular";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis dins del grup de treball d’economia circular i verda ";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities within the working group of circular and green economy";
					Subtitulos [1].text = "";
				}

			}
		
	}
	public void StartEmisions(OscMessage message )
	{
			//LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().enabled=true;
			LeyendaMarcadorb [1].GetComponent<SpriteRenderer>().enabled=true;
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[0];
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled =true;
			activeTablets [1] = true;
		Debug.Log( "Received: Emisions ");
		isEmisions = true;
		isStartEmisions = true;
			isEndEmisions = false;
			contEmisions = 5;
			timeLeftEmisions = 1;
			if (lenguajeTablets [1] == "cat") {
				Titulos[1].text="Municipis compromesos en la lluita contra el canvi climàtic. Evolució de les emissions de CO2 (2005-2014)";
				Subtitulos[1].text=" ";
			} else {
				Titulos [1].text = "Committed municipalities in the fight against climate change. Evolution of CO2 emissions(2005-2014)";
				Subtitulos [1].text = "";
			}

	}
		public void StartRenovables(int value )
	{
			
		Debug.Log( "Received: Renovables ");
		MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();
		
			LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[1];
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [1] = true;
			/*if (value == 0) {
				mc.colorToChange = colorRenovables;
				LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorRenovables;
				at.contenido = "Renovables";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos[1].text="Renovables";
					Subtitulos[1].text=" ";
				} else {
					Titulos [1].text = "Renewables";
					Subtitulos [1].text = "";
				}

			}*/
			 if(value == 1 || value==0){
				mc.colorToChange = colorRenovables;
				LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorRenovables;
				at.contenido = "CalderesBiomasa";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis amb actuacions  de calderes de biomassa";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities with actuations of biomass boilers";
					Subtitulos [1].text = "";
				}

			}
			else if(value == 3){
				mc.colorToChange = colorRenovables;
				LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorRenovables;
				at.contenido = "FotovoltaiquesAuto";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis amb actuacions  de fotovoltaiques d’autoconsum";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities with photovoltaic self-consumption activities";
					Subtitulos [1].text = "";
				}

			}
			else if(value == 2){
				mc.colorToChange = colorRenovables;
				LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorRenovables;
				at.contenido = "FotovoltaiquesVenta";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis amb actuacions  de fotovoltaiques de venda";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities with photovoltaic actions for sale";
					Subtitulos [1].text = "";
				}

			}
	}
		public void StartMesura(int value )
	{
		Debug.Log( "Received: Mesura ");
		
			LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[4];
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [1] = true;

			//Leyenda
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer> ().enabled = true;
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer> ().enabled = true;
			//LeyendaMarcadorb [6].GetComponent<SpriteRenderer>().sprite = IconosTablet2[4];
			//LeyendaMarcadorb [6].GetComponent<SpriteRenderer>().enabled = true;

			if (lenguajeTablets [1] == "cat") {
				Titulos[1].text="Municipis de la xarxa de control de partícules de la contaminació de l’aire.";
				Titulos[3].text="Suport tècnic";
				Titulos[4].text="Equipaments en préstec";


				Subtitulos[1].text=" ";
			} else {
				Titulos [1].text = "Municipalities of the particle control network of air pollution.";
				Titulos[3].text="Technical support ";
				Titulos[4].text="Equipment on loan ";
				Subtitulos [1].text = "";
			}

			MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
			AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();
			mc.colorToChange = colorMesura1;
			at.contenido = "Mesura";
			at.isGrowing = true;

		/*	MarkerControl mc1=AnimStarters[3].GetComponent<MarkerControl>();
			AnimationTrigger at1=AnimStarters[3].GetComponent<AnimationTrigger>();
			mc1.colorToChange = colorMesura1;
			at1.contenido = "SoporteTecnico";
			at1.isGrowing = true;

			MarkerControl mc2=AnimStarters[4].GetComponent<MarkerControl>();
			AnimationTrigger at2=AnimStarters[4].GetComponent<AnimationTrigger>();
			mc2.colorToChange = colorMesura2;
			at2.contenido = "AparatosPrestados";
			at2.isGrowing = true;*/

			/*if (value == 0) {
				mc.colorToChange = colorMesura;
				at.contenido = "Mesura";
				at.isGrowing = true;
				Titulos[1].text="Municipis de la xarxa de control de partícules de la contaminació de l’aire.";
				Subtitulos[1].text=" ";
			}
			else if(value == 1){
				mc.colorToChange = colorRenovables;
				at.contenido = "SoporteTecnico";
				at.isGrowing = true;
				Titulos [1].text = "SoporteTecnico";
				Subtitulos [1].text = "";
			}
			else if(value == 2){
				mc.colorToChange = colorRenovables;
				at.contenido = "AparatosPrestados";
				at.isGrowing = true;
				Titulos [1].text = "AparatosPrestados";
				Subtitulos [1].text = "";
			}*/
	}
		public void StartOTAGA(int value )
	{
		Debug.Log( "Received: OTAGA ");
		MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();
			LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[2];
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [1] = true;
			/*if (value == 0) {
				mc.colorToChange = colorOTAGA;
			LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorOTAGA;
				at.contenido = "OTAGA";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos[1].text="OTAGA";
					Subtitulos[1].text=" ";
				} else {
					Titulos [1].text = "OTAGA";
					Subtitulos [1].text = "";
				}

			}*/
		if(value == 1 || value==0){
			mc.colorToChange = colorOTAGA;
			LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorOTAGA;
				at.contenido = "AnalisisParticulas";
				at.isGrowing = true;

				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis de la xarxa de control de partícules de la contaminació de l’aire.";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities of the particle control network of air pollution.";
					Subtitulos [1].text = "";
				}

			}
			else if(value == 2){
			mc.colorToChange = colorOTAGA;
			LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorOTAGA;
				at.contenido = "AguaFuentes";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis amb actuacions de control de qualitat de l’aigua de les fonts";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities with actions to control the quality of water from the sources";
					Subtitulos [1].text = "";
				}

			}
			else if(value == 3){
			mc.colorToChange = colorOTAGA;
			LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorOTAGA;
				at.contenido = "MediaSonido";
				at.isGrowing = true;
				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis amb actuacions de control de soroll";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities with noise control action";
					Subtitulos [1].text = "";
				}

			}
	}
	public void StartTurisme(OscMessage message )
	{
		Debug.Log( "Received: Turisme ");
		MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();

			LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[5];
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [1] = true;
		mc.colorToChange = colorTurisme;
		LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorTurisme;
			if (lenguajeTablets [1] == "cat") {
				Titulos [1].text = "Municipis amb empreses que s’han adherit al Sistema de Qualitat Turística en Destinacions ";
				Subtitulos [1].text = "";
			} else {
				Titulos [1].text = "Municipalities with companies that have adhered to the Tourist Quality System in Destinations";
				Subtitulos [1].text = "";
			}

		at.contenido = "Turisme";
		at.isGrowing = true;
	}

		//TECNOLOGIA
	public void StartServeiGestio(int value )
	{
		Debug.Log( "Received: ServeiGestio ");
		MarkerControl mc=AnimStarters[2].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[2].GetComponent<AnimationTrigger>();

			LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[3];
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [2] = true;
			/*if (value == 0) {
				
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;

				at.contenido = "ServeiGestio";
				at.isGrowing = true;
				Titulos[2].text="ServeiGestio";
				Subtitulos[2].text=" ";
			}*/
		if(value == 1||value == 0){
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "AsesoramientoJuridico";
				at.isGrowing = true;
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Ajuntaments amb suport d’assessorament jurídic on-line";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "City councils with online legal advice support";
					Subtitulos [2].text = "";
				}

			}
			else if(value == 2){
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionInformacion";
				at.isGrowing = true;
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Ajuntaments que utilitzen el Gestor d’Informació d’Activitats";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "City councils that use the Activity Information Manager.";
					Subtitulos [2].text = "";
				}

			}
			else if(value == 3){
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionFormacion";
				at.isGrowing = true;
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Ajuntaments que utilitzen Gestforma ";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "City councils using Gestforma";
					Subtitulos [2].text = "";
				}

			}
			else if(value == 4){
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "HERMES";
				at.isGrowing = true;
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Ajuntaments que utilitzen Hermes";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "City councils using Hermes";
					Subtitulos [2].text = "";
				}

			}
			else if(value == 5){
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionContabilidad";
				at.isGrowing = true;
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Ajuntaments que utilitzen el sistema de gestió de comptabilitat";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "City councils that use the accounting management system";
					Subtitulos [2].text = "";
				}
			}
			else if(value == 6){
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionPadron";
				at.isGrowing = true;
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Ajuntaments que utilitzen el sistema de gestió del padró d’habitants ";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "City councils that use the census management system";
					Subtitulos [2].text = "";
				}

			}
			else if(value == 7){
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionWebs";
				at.isGrowing = true;
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Ajuntaments que reben el servei de presència institucional a internet (web municipals)";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "City councils that receive the service of institutional presence on the Internet (municipal web)";
					Subtitulos [2].text = "";
				}

			}
			else if(value == 8){
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "MuniApps";
				at.isGrowing = true;
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Municipis amb aplicacions mòbils inventariades";
					Subtitulos [2].text = " ";
				} else {
					Titulos [2].text = "Municipalities with inventoried mobile applications";
					Subtitulos [2].text = "";
				}

			}
	}
	public void StartPlataforma(int value )
	{
		Debug.Log( "Received: Plataforma ");
		
			//LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = true;
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[1];
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled = true;

		//Leyendas
			LeyendaMarcadorb [6].GetComponent<SpriteRenderer> ().enabled = true;
			LeyendaMarcadorb [7].GetComponent<SpriteRenderer> ().enabled = true;
			LeyendaMarcadorb [8].GetComponent<SpriteRenderer> ().enabled = true;
			activeTablets [2] = true;
			if (lenguajeTablets [2] == "cat") {
			Titulos[2].text="                                                                                                                                   Plataforma Urbana Intel·ligent";
				Titulos [5].text = "Plataforma pròpia";
			Titulos[6].text="Plataforma multi-tenant DIBA";
			Titulos[7].text="Solució híbrida";
				Subtitulos[2].text=" ";
			} else {
			Titulos [2].text = "                                                                                                                                          Smart urban platform";
			Titulos[5].text="Own platform";
			Titulos[6].text="DIBA multi-tenant platform";
			Titulos[7].text="Hybrid solution";
				Subtitulos [2].text = "";
			}

			MarkerControl mc=AnimStarters[2].GetComponent<MarkerControl>();
			AnimationTrigger at=AnimStarters[2].GetComponent<AnimationTrigger>();
			mc.colorToChange = colorPlataforma;
			at.contenido = "Plataforma";
			at.isGrowing = true;

			/*MarkerControl mc2=AnimStarters[6].GetComponent<MarkerControl>();
			AnimationTrigger at2=AnimStarters[6].GetComponent<AnimationTrigger>();
			mc2.colorToChange = colorPlataforma;
			at2.contenido = "Plataforma2";
			at2.isGrowing = true;

			MarkerControl mc3=AnimStarters[7].GetComponent<MarkerControl>();
			AnimationTrigger at3=AnimStarters[7].GetComponent<AnimationTrigger>();
			mc3.colorToChange = colorPlataforma;
			at3.contenido = "Plataforma3";
			at3.isGrowing = true;*/

			/*if (value == 0) {
				mc.colorToChange = colorPlataforma;
				at.contenido = "Plataforma";
				at.isGrowing = true;
				Titulos[2].text="Plataforma Urbana Intel·ligent";
				Subtitulos[2].text=" ";
			}*/
			/*else if(value == 1){
				mc.colorToChange = colorPlataforma;
				at.contenido = "Plataforma1";
				at.isGrowing = true;
				Titulos [2].text = "Plataforma 1";
				Subtitulos [2].text = " ";
			}
			else if(value == 2){
				mc.colorToChange = colorPlataforma;
				at.contenido = "Plataforma2";
				at.isGrowing = true;
				Titulos [2].text = "Plataforma 2";
				Subtitulos [2].text = "";
			}*/
	}
		public void StartInfraestructures(int value )
	{
		Debug.Log( "Received: Infraestructures ");
		MarkerControl mc=AnimStarters[2].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[2].GetComponent<AnimationTrigger>();
			activeTablets [2] = true;

			/*if (value == 0) {
				LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = true;
				LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[2];
				LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorInfraestructures;
		LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorInfraestructures;
				at.contenido = "Infraestructures";
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Infraestructures";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "Platforms";
					Subtitulos [2].text = "";
				}
				
				at.isGrowing = true;
			}*/
		if(value == 1 || value == 0){
				LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = true;
				LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[5];
				LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorSitmun;
				LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorSitmun;
				at.contenido = "SITMUN";
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Municipis que utilitzen la plataforma SITMUN";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "Municipalities that use the SITMUN platform";
					Subtitulos [2].text = "";
				}
				
				at.isGrowing = true;
			}
			else if(value == 2){
				LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = true;
				LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[4];
				LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorInfraestructures;
		LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorInfraestructures;
				at.contenido = "Cartografia";
				if (lenguajeTablets [2] == "cat") {
					Titulos [2].text = "Municipis que reben el servei de manteniment de cartografia";
					Subtitulos [2].text = "";
				} else {
					Titulos [2].text = "Municipalities that receive the cartography maintenance service";
					Subtitulos [2].text = "";
				}
				
				at.isGrowing = true;
			}
		
	}
	public void StartPoligons(OscMessage message )
	{
		Debug.Log( "Received: Poligons ");
			activeTablets [2] = true;
			LeyendaMarcadorb [2].GetComponent<SpriteRenderer>().enabled = true;
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[0];
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled =true;

			isPolig = true;
			isStartPolig = true;
			isEndPolig = false;
			if (lenguajeTablets [2] == "cat") {
				Titulos [2].text = "Poligons Industrials";
				Subtitulos [2].text = "";
			} else {
				Titulos [2].text = "Industrial parks";
				Subtitulos [2].text = "";
			}
			
	}
		public void StartFibra(OscMessage message )
		{
			Debug.Log( "Received: Fibra ");
			activeTablets [2] = true;
			//LeyendaMarcadorb [2].GetComponent<SpriteRenderer>().enabled = true;
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[6];
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled =true;

			isFibra = true;
			isStartFibra = true;
			isEndFibra = false;
			if (lenguajeTablets [2] == "cat") {
		Titulos [2].text = "Canalitzacions per a fibra optica.                                                           Nou desplegament: 252km";//"Canalitzacions per a fibra optica. Nou desplegament: 252km";
		Subtitulos [2].text = "";
			} else {
		Titulos [2].text = "Optical fiber trough the local roads.                                                    New deployment: 252km";
				Subtitulos [2].text = "";
			}
			
		}


	//Idiomas
	public void IdiomaPersoneseng(  OscMessage message  )
	{
			lenguajeTablets [0] = "eng";
		Debug.Log( "Received: Lenguaje personeseng "  );
	}
	public void IdiomaPersonescat(  OscMessage message  )
	{
		lenguajeTablets [0] = "cat";
		Debug.Log( "Received: Lenguaje persones cat" );
	}
	public void IdiomaSostenibilitateng(  OscMessage message  )
	{
		lenguajeTablets [1] = "eng";
		Debug.Log( "Received: Lenguaje sostenibilitat eng " );
	}
	public void IdiomaSostenibilitatcat(  OscMessage message  )
	{
		lenguajeTablets [1] = "cat";
		Debug.Log( "Received: Lenguaje sostenibilitat cat"  );
	}
	public void IdiomaTecnologiaeng(  OscMessage message )
	{
		lenguajeTablets [2] = "eng";
		Debug.Log( "Received: Lenguaje Tecnologia eng"  );
	}
	public void IdiomaTecnologiacat(  OscMessage message )
	{
		lenguajeTablets [2] = "cat";
		Debug.Log( "Received: Lenguaje Tecnologia cat"  );
	}

	//Limpiadores
	public void Clean1()//OscMessage message
    {
            Debug.Log("Received: Clean1 ");// + message );
        //Limpiar contornos
        changeAlphaMaterialMaqueta(3, 0);
        
        //limpiar animaciones
        //Limpiar bibliobus
        for (int i=0;i < BiblioBusAnim.Length; i++)
        {
            BiblioBusAnim[i].active = false;
        }

		MarkerControl mc=AnimFinishers[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimFinishers[0].GetComponent<AnimationTrigger>();
			mc.colorToChange = Color.white;
		at.isGrowing = true;

		//Control parques SIEMPRE???
			isEndParcs=true;
			activeTablets [0] = false;
			Titulos [0].text = "";
			Subtitulos [0].text = "";
			LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = false;
			LeyendaMarcadorb [0].GetComponent<SpriteRenderer>().enabled = false;
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = false;
	}
	public void Clean2(  OscMessage message  )
	{
		Debug.Log( "Received: Clean2 " + message );
		MarkerControl mc=AnimFinishers[1].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimFinishers[1].GetComponent<AnimationTrigger>();
		mc.colorToChange = Color.white;
		at.isGrowing = true;
			isEndEmisions=true;
			activeTablets [1] = false;
			Titulos [1].text = "";
			Titulos [3].text = "";
			Titulos [4].text = "";
			Subtitulos [1].text = "";
			LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = false;
			LeyendaMarcadorb [1].GetComponent<SpriteRenderer>().enabled = false;
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = false;

	LeyendaMarcadorb [4].GetComponent<SpriteRenderer> ().enabled = false;
	LeyendaMarcadorb [5].GetComponent<SpriteRenderer> ().enabled = false;
	}
	public void Clean3(  OscMessage message  )
	{
		Debug.Log( "Received: Clean3 " + message );
		MarkerControl mc=AnimFinishers[2].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimFinishers[2].GetComponent<AnimationTrigger>();
		mc.colorToChange = Color.white;
		at.isGrowing = true;
			isEndPolig = true;
			isEndFibra = true;
			activeTablets [2] = false;
			Titulos [2].text = "";
			Titulos[5].text="";
			Titulos[6].text="";
			Titulos[7].text="";
			Subtitulos [2].text = "";
			LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = false;
			LeyendaMarcadorb [2].GetComponent<SpriteRenderer>().enabled = false;
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled = false;

			LeyendaMarcadorb [6].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [7].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [8].GetComponent<SpriteRenderer> ().enabled = false;
	}

	/// 
	/// END OSC CONTROL
	/// 

	public struct Marcador {
		public int codigo;
		public string nombre;
		public int numero;
		public float posX;
		public float posY;
		public float posZ;
		public Color colorM;
		//public List<Escena> escenas;

	}

}
}//END NAMESPACE
