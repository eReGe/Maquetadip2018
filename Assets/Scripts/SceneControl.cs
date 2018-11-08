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
		public GameObject AnimEndSuper;
	public Camera CamaraCotas;
	public Camera CamaraAnimaciones;
	public GameObject[] Maquetas;
	public GameObject[] MaquetasCotas;
	public GameObject[] MaquetasAnimaciones;
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
		public Text[]TitulosPlataformaT1;
		public Text[] TitulosPlataformaT2;
		public Text[] TitulosPlataformaT3;
		public Text[] Subtitulos;
	private ReadMunicipiData rmd;
	public OscIn oscIn;
		private bool isLandscape = true;  //para saber si estamos en modo paisaje o contenido

        //ANIMACIONES
        public GameObject[] BiblioBusAnim;
		public Texture[] texturesCO2;
        //VIDEO PLAYER
        public VideoPlayer videoPlayerMaqueta;
        public VideoClip[] videosMaqueta;
        public VideoPlayer videoPlayerLiso;
		public VideoPlayer videoPlayerMapping;
		public VideoClip[] videosMapping;
		public VideoPlayer videoPlayerSuperficie;
		public GameObject[] superficiesVideos;
		public VideoClip[] videosSuperficie;
        public VideoClip[] videosLiso;
        private bool isTransition = false;
        private bool isEndTransition = false;
		private bool isChange=true;
        private bool isIntro = false;
		private cotasAnimation caScript;


        //CONTROL
        public float[] estadoActual;  //codigos del json que indican en que estado estamos [tema, subestado,datos]
        public float estadoSiguiente;
        public float estadoSuperposicion;
        public string superposicionActual;
		public bool[] activeTablets;
		public float[] lenguajeTablets;
        public float[] lenguajes;
		private bool skipVideo=false;

		public int[] codigosBibliotecas;
		public int contBibliotecas;
		public Leyenda[] leyendaBibliotecas= new Leyenda[3];
		public int[] codigosTeleasistencia;
		public int contTeleasistencia;
		public Leyenda[] leyendaTeleasistencia= new Leyenda[1];
		public int[] codigosGovernObert;
		public int contGovernObert;
		public Leyenda[] leyendaGovernObert= new Leyenda[10];
		public int[] codigosPromocioEconomica;
		public int contPromocioEconomica;
		public Leyenda[] leyendaPromocioEconomica= new Leyenda[3];
		public int[] codigosKm2;
		public int contKm2;
		public Leyenda[] leyendaKm2= new Leyenda[1];
		public int[] codigosPatrimoni;
		public int contPatrimoni;
		public Leyenda[] leyendaPatrimoni= new Leyenda[6];
		public int[] codigosOficinaPatrimoni;
		public int contOficinaPatrimoni;
		public Leyenda[] leyendaOficinaPatrimoni= new Leyenda[3];

		public int[] codigosXarxaCiutats;
		public int contXarxaCiutats;
		public Leyenda[] leyendaXarxaCiutats= new Leyenda[3];
		public int[] codigosPAES;
		public int contPAES;
		public Leyenda[] leyendaPAES= new Leyenda[5];
		public int[] codigosRenovables;
		public int contRenovables;
		public Leyenda[] leyendaRenovables = new Leyenda[3];
		public int[] codigosEvaluacio;
		public int contEvaluacio;
		public Leyenda[] leyendaEvaluacio= new Leyenda[3];
		public int[] codigosParques;
		public int contParques;
		public Leyenda[] leyendaParques= new Leyenda[13];
		public int[] codigosTurismo;
		public int contTurismo;
		public Leyenda[] leyendaTurismo= new Leyenda[3];

		public int[] codigosServeisGestio;
		public int contServeisGestio;
		public Leyenda[] leyendaServeisGestio= new Leyenda[8];
		public int[] codigosPlataformaUrbana;
		public int contPlataformaUrbana;
		public Leyenda[] leyendaPlataformaUrbana= new Leyenda[2];
		public int[] codigosGeografia;
		public int contGeografia;
		public Leyenda[] leyendaGeografia= new Leyenda[2];
		public int[] codigosInfraestructuras;
		public int contInfraestructuras;
		public Leyenda[] leyendaInfraestructuras= new Leyenda[2];
		public int[] codigosFibraOptica;
		public int contFibraOptica;
		public Leyenda[] leyendaFibraOptica= new Leyenda[1];
		public List<Leyenda> Leyendas;

		public float alphaCo2impar=0;
		public float alphaCo2par = 1;
		public float alphaCo2Speed;


        //public int layerCotas = 0;
        

		//MAQUETA PRINCIPAL
		public int layerSatelite;
		public int layerExteriorMaqueta;
		public int layerRios;
		public int layerRios2;
		public int layerLuces;
		public int layerLuces2;
		public int layerFondoLiso;
		public int layerVideoMaqueta;
		public int layerAnimaciones;
		public int layerZonasSup;
		public int layerMunicipios;
		public int layerFronteras;
		public int layerMunicipiosSolos;
		public int layerVideoMapping;

		//zonas planas
		public int layerLisoExteriorMaqueta = 0;
		public int layerLisoFondo = 1;
		public int layerLisoVideoTransicion = 2;

		//MAQUETA COTAS
		public int layerMCcotas=0;

		//MAQUETA ANIMACIONES
		public int layerMAzonas=0;
		public int layerMAparques=1;
		public int layerMAPoligonos=2;
		public int layerMAturismo1=3;
		public int layerMAturismo2=4;
		public int layerMAturismo3=5;
		public int layerMAvideoAnimado=6;
		public int layerMACo2impar=7;
		public int layerMACo2par=8;
		public int layerMAFibra=9;
		public int layerMAFibra2=10;
		public int layerMATurismo1=11;
		public int layerMATurismo2=12;
		public int layerMAfronteras=13;


        public bool writeJSON = false;
		public bool	isParcs = false;
		public bool isStartParcs = false;
		public bool isEndParcs = false;
		public float parcFlickerSpeed;
		public float parcSpeed;
		public float fibraFlickerSpeed;

		public bool	isEmisions = false;
		public bool isStartEmisions = false;
		public bool isEndEmisions = false;
		public bool	isTurismo = false;
		public bool isStartTurismo = false;
		public bool isEndTurismo = false;
		public bool	isSuperposicion = false;
		public bool isSuperposicionPuntos=false;
		public bool isStartSuperposicion = false;
		public bool isEndSuperposicion = false;
		public int contEmisions=5;
		public float timeLapseEmisions;
		public float timeLeftEmisions;
		public string[] co2Anys;
		public string[] stringsTurismo;
		public Sprite[] iconosExplicativos;

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

		//MUNICIPIOS
		public Texture[] imgMunicipio;

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
        public Color colorBiblioLabs;
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
		public Color[]	coloresTurismo;

		//IMAGENES
		public Texture texturaXaloc;
		public Texture texturaPoligonos;
		public Texture[] texturasPatrimonios;
		public Texture[] texturasOficinaPatrimoni;
		public Texture[] texturasRenovables;
		public Texture[] texturasParques;
		public Texture[] texturasParquesSolos;
		public Texture[] texturasTurismoSostenible;
		public Texture[] texturasTurismoReputacion;
		public Texture[] texturasRutasTurismo;
		public Texture[] texturasPAES;
		public Texture[] texturasGovernObert;
		public Texture[] texturasInfraestructuras;
		public Texture[] texturasMunicipiosSolos;
		public Sprite[] texturesTurismo;

	 


	// START
	void Start() {
            // Ensure that we have a OscIn component.
            //if( !oscIn ) oscIn = gameObject.AddComponent<OscIn>();

            // Start receiving from unicast and broadcast sources on port 7000.
            //oscIn.Open( 8015 );

           
            //Inicializar lenguajes
            lenguajes = new float[3];
            lenguajes[0] = 0;
            lenguajes[1] = 1;
            lenguajes[2] = 2;

			lenguajeTablets = new float[3];
        for (int i = 0; i < 3; i++)
        {
                lenguajeTablets[i] = 0;
        }


		//Scriptsexternos
		caScript = CamaraAnimaciones.GetComponent<cotasAnimation> ();

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
            Color c = m[layerLuces].color;
                c.a = 0;
				m[layerLuces].color = c; //Luces1

				c = m[layerLuces2].color;
				c.a = 0;
				m[layerLuces2].color = c; //Luces2

                c = m[layerFondoLiso].color;
                c.a = 0;
				m[layerFondoLiso].color = c; //colorLiso

				c = m[layerVideoMaqueta].color;
				c.a = 0;
				m[layerVideoMaqueta].color = c; //Video Maqueta

				//c = m[layerAnimaciones].color;
				//c = new Color (0,0,0,0);

				m[layerAnimaciones].color = c; //Animaciones

				c = m[layerZonasSup].color;
				c.a = 0;
				m[layerZonasSup].color = c; //ZonasMunicipios para superposicion

				c = m[layerMunicipios].color;
				c.a = 0;
				m[layerMunicipios].color = c; //Municipios solos

				c = m[layerFronteras].color;
				c.a = 0;
				m[layerFronteras].color = c; //Fornteras

				c = m[layerVideoMapping].color;
				c.a = 0;
				m[layerVideoMapping].color = c; //Video mapping

        }
        //Maqueta animaciones
			for (int i = 0; i < MaquetasAnimaciones.Length; i++)
		{
			Material[] m = MaquetasAnimaciones[i].GetComponent<Renderer>().materials;
				/*public int layerMAzonas=0;
		public int layerMAparques=1;
		public int layerMAPoligonos=2;
		public int layerMAturismo1=3;
		public int layerMAturismo2=4;
		public int layerMAturismo3=5;
		public int layerMAvideoAnimado=6;
		public int layerMAfronteras=7;*/

				Color c = m[layerMAzonas].color;
			c.a = 1;
				m[layerMAzonas].color = c; //Zonas municipios

				c = m[layerMAparques].color;
			c.a = 0;
				m[layerMAparques].color = c; //Parques

				c = m[layerMAPoligonos].color;
			c.a = 0;
				m[layerMAPoligonos].color = c; //Poligonos

				c = m[layerMAturismo1].color;
			c.a = 0;
				m[layerMAturismo1].color = c; //Turismo1

				c = m[layerMAturismo2].color;
			c.a = 0;
				m[layerMAturismo2].color = c; //Turismo2

				c = m[layerMAturismo3].color;
			c.a = 0;
				m[layerMAturismo3].color = c; //Turismo3

				c = m[layerMAvideoAnimado].color;
			c.a = 0;
				m[layerMAvideoAnimado].color = c; //VideoAnimado


				c = m[layerMAFibra].color;
				c.a = 0;
				m[layerMAFibra].color = c; //fibra óptica
				c = m[layerMAFibra2].color;
				c.a = 0;
				m[layerMAFibra2].color = c; //fibra óptica2

				c = m[layerMAfronteras].color;
			c.a = 0;
				m[layerMAfronteras].color = c; //Fronteras

		}

        //VIDEOS en off
        changeAlphaVideoMaqueta(layerVideoMaqueta,0);
        changeAlphaVideoLisas(layerLisoVideoTransicion,0);

		//VIDEOS DE MOTION EN OFF
			for(int i=0;i<superficiesVideos.Length;i++){
				superficiesVideos [i].GetComponent<MeshRenderer> ().enabled = false;
		}
        
		//APAGAR ICONOS
			enableIconosLeyenda(IconosTablet1[0],colorPERSONAS,0);
			enableIconosLeyendaSup (IconosTablet1 [0], Color.white, 0);
			disableIconosPlataforma ();
		/*for(int i=0;i<LeyendaMarcador.Length;i++){
			LeyendaMarcador [i].GetComponent<MeshRenderer> ().enabled = false;
			//LeyendaMarcadorb [i].GetComponent<SpriteRenderer> ().enabled = false;
			//LeyendaMarcadorc [i].GetComponent<SpriteRenderer> ().enabled = false;
		}*/
			for(int i=0;i<LeyendaMarcadorb.Length;i++){
				Debug.Log ("APAGA ICONOS EXTRA");
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
			//Rellenar codigos y leyendas
			fillCodigos();



	}// START
	
	//UPDATE
	void Update () {
            keyControl();
            //zonas limpar
			if(caScript.animationType==0 && !caScript.isUp){
				changeAlphaMaterialMaquetaAnim(layerMAzonas,0);
			}
            if (isTransition) {//transicion de maqueta a contenido
                if (videoPlayerMaqueta.frame >= 20 && isChange)//frame en el cual se cambia el fondo
                {
                   // Debug.Log("enciende materialliso");
                    changeAlphaMaterialMaqueta(layerFondoLiso, 1);
                    changeAlphaMaterialPlanos(layerLisoFondo, 1);
					changeAlphaMaterialMaqueta (layerRios, 0);
					changeAlphaMaterialMaqueta (layerRios2, 0);
					isChange = false;

                }
               // Debug.Log("isPlaying"+ videoPlayerMaqueta.frame+" fc: "+ videoPlayerMaqueta.frameCount);
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
				if (videoPlayerMaqueta.frame >= 20 && isChange)//frame en el cual se cambia el fondo
                {
                    Debug.Log("Apaga materialliso");
                    changeAlphaMaterialMaqueta(layerFondoLiso, 0);
                    changeAlphaMaterialPlanos(layerLisoFondo, 0);
					changeAlphaMaterialMaqueta (layerRios, 1);
					changeAlphaMaterialMaqueta (layerRios2, 1);
					isChange = false;

                }
                //Debug.Log("isPlaying" + videoPlayerMaqueta.frame + " fc: " + videoPlayerMaqueta.frameCount);
                if (videoPlayerMaqueta.frame == (long)videoPlayerMaqueta.frameCount)
                {
                    isEndTransition = false;
					isLandscape = true;
                    videoPlayerMaqueta.Stop();
                    changeAlphaVideoMaqueta(layerVideoMaqueta, 0);
                    changeAlphaVideoLisas(layerLisoVideoTransicion, 0);
                    //StartIntro(estadoActual[0]);
                }
            }
            if (isIntro)//video introduccion tema
            {
                
				//Debug.Log("isPlaying" + videoPlayerSuperficie.frame + " fc: " + videoPlayerSuperficie.frameCount);
				if (videoPlayerSuperficie.frame == (long)videoPlayerSuperficie.frameCount || skipVideo)
                {
					videoPlayerMapping.Stop ();
					changeAlphaVideoMaqueta (layerVideoMapping, 0);
					videoPlayerSuperficie.Stop();
					for(int i=0;i<superficiesVideos.Length;i++){
						superficiesVideos [i].GetComponent<MeshRenderer> ().enabled = false;
					}
					isIntro = false;
					skipVideo = false;
					//START CONTENT
					StartContent(estadoSiguiente);
                    
                }
            }
			/*if (isAnimIntro)//animacion de entrada de datos
			{

				Debug.Log("isPlaying" + videoPlayerLiso.frame + " fc: " + videoPlayerLiso.frameCount);
				if (videoPlayerLiso.frame == (long)videoPlayerLiso.frameCount)
				{

					videoPlayerLiso.Stop();
					StartContent(estadoActual[0]);
					changeAlphaVideoLisas(layerLisoVideoTransicion, 0);
					StartContent(estadoActual[1]);
				}
			}*/


            /*AnimationTrigger atScript = AnimStarters[0].GetComponent<AnimationTrigger>();
            if(atScript.finish==true){
                AnimationTrigger atScript2 = AnimFinishers[0].GetComponent<AnimationTrigger>();
                atScript2.isGrowing = true;
            }*/

            timer = timer + Time.deltaTime;
			//timer = 0;
		//LIMPIAR SI ESTA  sin actividad
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
			int numTexturaParcs = layerMAparques; //hacerlo solo para 
			if(isParcs){
				if (isStartParcs) {
					Material[] m =MaquetasAnimaciones [0].GetComponent<Renderer>().materials;
					c = m [numTexturaParcs].color;
					c.a = c.a + parcSpeed;
					changeAlphaMaterialMaquetaAnim (numTexturaParcs, c.a);
					if (c.a >= 0.75f) {
						c.a = 0.75f;
						isStartParcs = false;
					}

				}else if(!isEndParcs ){
					/*float spd = parcFlickerSpeed;
					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {
						Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
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
					*/


				}

				if (isEndParcs) {
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
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
				if(!isEndEmisions){
					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {


						if(contEmisions%2==1){
							alphaCo2impar += alphaCo2Speed;
							alphaCo2par -= alphaCo2Speed;
						}
						else{
							alphaCo2impar -= alphaCo2Speed;
							alphaCo2par += alphaCo2Speed;
						}
						if(alphaCo2impar <=0){
							alphaCo2impar = 0;
						}
						if(alphaCo2par <=0){
							alphaCo2par = 0;
						}
						if(alphaCo2impar >=1){
							alphaCo2impar = 1;
						}
						if(alphaCo2par >=1){
							alphaCo2par = 1;
						}

						changeAlphaMaterialMaquetaAnim (layerMACo2par,alphaCo2par);
						changeAlphaMaterialMaquetaAnim (layerMACo2impar,alphaCo2impar);

						/*Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
						for (int j = 5; j <=14; j++) {  //5-14
							c1 = m [j].color;
							c1.a = 0;
							m [j].color = c1;
						}
						c1 = m [contEmisions].color;
						c1.a = 0.6f;

						m [contEmisions].color = c1;*/


						//writeLeyendaCo2 ;
						//Titulos[2].text="Plataforma";
						string t=co2Anys[contEmisions];
						Subtitulos[i].text=t;

					}
					timeLeftEmisions -= Time.deltaTime;
				}
				if (timeLeftEmisions < 0) {
					
					if(contEmisions%2==1){
						changeTextureMaterialMaquetaAnim(layerMACo2par,texturesCO2[contEmisions]);
					}
					else{
						changeTextureMaterialMaquetaAnim(layerMACo2impar,texturesCO2[contEmisions]);
					}
					contEmisions++;
					if (contEmisions >= texturesCO2.Length) {
						contEmisions = 0;
					}
					timeLeftEmisions = timeLapseEmisions;


				}


				//este no hace  falta ahora??? se quita con la capa de animacion
				if (isEndEmisions) {
					disableIconosCo2 ();
					alphaCo2impar -= alphaCo2Speed;
					alphaCo2par -= alphaCo2Speed;
					if(alphaCo2impar <=0){
						alphaCo2impar = 0;
					}
					if(alphaCo2par <=0){
						alphaCo2par = 0;
					}
					changeAlphaMaterialMaquetaAnim (layerMACo2par,alphaCo2par);
					changeAlphaMaterialMaquetaAnim (layerMACo2impar,alphaCo2impar);
					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {
						Subtitulos [i].text = "";
					}
					//isEndEmisions = false;
					//isEmisions = false;
					if (alphaCo2par <= 0 && alphaCo2impar <= 0) {
						Debug.Log ("EMISIONS A CERO");
						isEndEmisions = false;
						isEmisions = false;
					}

				}//end emisions

			}
			//TURISMO
			Color ct = new Color();
			if(isTurismo){
				if(isStartTurismo){
					contTurismo = 0;
					isStartTurismo = false;
				}
				if(!isEndTurismo){
					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {


						if(contTurismo%2==1){
							alphaCo2impar += alphaCo2Speed;
							alphaCo2par -= alphaCo2Speed;
						}
						else{
							alphaCo2impar -= alphaCo2Speed;
							alphaCo2par += alphaCo2Speed;
						}
						if(alphaCo2impar <=0){
							alphaCo2impar = 0;
						}
						if(alphaCo2par <=0){
							alphaCo2par = 0;
						}
						if(alphaCo2impar >=1){
							alphaCo2impar = 1;
						}
						if(alphaCo2par >=1){
							alphaCo2par = 1;
						}

						changeAlphaMaterialMaquetaAnim (layerMATurismo1,alphaCo2par);
						changeAlphaMaterialMaquetaAnim (layerMATurismo2,alphaCo2impar);

						/*Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
						for (int j = 5; j <=14; j++) {  //5-14
							c1 = m [j].color;
							c1.a = 0;
							m [j].color = c1;
						}
						c1 = m [contEmisions].color;
						c1.a = 0.6f;

						m [contEmisions].color = c1;*/


						//writeLeyendaCo2 ;
						//Titulos[2].text="Plataforma";
						string t=stringsTurismo[contTurismo];
						Subtitulos[i].text=t;
						Subtitulos [i].color = coloresTurismo[contTurismo%3];

					}
					timeLeftEmisions -= Time.deltaTime;
				}
				if (timeLeftEmisions < 0) {
					contTurismo++;
					if (contTurismo >= texturesTurismo.Length) {
						contTurismo = 0;
					}

					if(contTurismo%3==0 && contTurismo%2==0){
						changeTextureMaterialMaquetaAnim(layerMATurismo1,texturasTurismoReputacion[contTurismo%3]);
					}

					if(contTurismo%3==1 && contTurismo%2==0){
						changeTextureMaterialMaquetaAnim(layerMATurismo1,texturasTurismoReputacion[contTurismo%3]);
					}

					if(contTurismo%3==2 && contTurismo%2==0){
						changeTextureMaterialMaquetaAnim(layerMATurismo1,texturasTurismoReputacion[contTurismo%3]);
					}

					if(contTurismo%3==0 && contTurismo%2==1){
						changeTextureMaterialMaquetaAnim(layerMATurismo2,texturasTurismoReputacion[contTurismo%3]);
					}

					if(contTurismo%3==1 && contTurismo%2==1){
						changeTextureMaterialMaquetaAnim(layerMATurismo2,texturasTurismoReputacion[contTurismo%3]);
					}

					if(contTurismo%3==2 && contTurismo%2==1){
						changeTextureMaterialMaquetaAnim(layerMATurismo2,texturasTurismoReputacion[contTurismo%3]);
					}


					timeLeftEmisions = timeLapseEmisions;


				}


				//este no hace  falta ahora??? se quita con la capa de animacion
				if (isEndTurismo) {
					disableIconosExplicativos ();
					alphaCo2impar -= alphaCo2Speed;
					alphaCo2par -= alphaCo2Speed;
					if(alphaCo2impar <=0){
						alphaCo2impar = 0;
					}
					if(alphaCo2par <=0){
						alphaCo2par = 0;
					}
					changeAlphaMaterialMaquetaAnim (layerMATurismo1,alphaCo2par);
					changeAlphaMaterialMaquetaAnim (layerMATurismo2,alphaCo2impar);
					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {
						Subtitulos [i].text = "";
						Subtitulos [i].color = Color.white;
					}
					//isEndEmisions = false;
					//isEmisions = false;
					if (alphaCo2par <= 0 && alphaCo2impar <= 0) {
						Debug.Log ("EMISIONS A CERO");
						isEndTurismo = false;
						isTurismo = false;
					}

				}//end turisme

			}

			//Poligons
			Color c3 = new Color();
			int numTexturaPol = layerMAPoligonos;
			if(isPolig){
				if (isStartPolig) {

					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {
						Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
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
					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {
						Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
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
					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {
						Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
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
			Color c42 = new Color();
			int numTexturaFibra = layerMAFibra;
			int numTexturaFibra2 = layerMAFibra2;
			if(isFibra){
				if (isStartFibra) {

					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {
						Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
						c4 = m [numTexturaFibra].color;
						c4.a = c4.a + parcSpeed;
						c42 = m [numTexturaFibra2].color;
						c42.a = c42.a + parcSpeed;

						m [numTexturaFibra].color = c4;
						m [numTexturaFibra2].color = c42;
					}
					Debug.Log ("Fibra alfa:"+c4.a+" "+c42.a);
					if (c4.a >=1f) {
						c4.a = 1f;
						isStartFibra = false;
					}

				}else if(!isEndFibra ){
					float spd = fibraFlickerSpeed;
					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {
						Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
						c42 = m [numTexturaFibra2].color;
						c42.a = c42.a + fibraFlickerSpeed;
						if (c42.a >= 1f) {
							c42.a = 1f;
						}
						if (c42.a <= 0.15f) {
							c42.a = 0.15f;
						}
						m [numTexturaFibra2].color = c42;
					}

					if (c42.a >=1f) {
						c42.a =1f;
						//isStartParcs = false;
						fibraFlickerSpeed = -fibraFlickerSpeed;
					} 
					if(c42.a<=0.15f){
						c42.a = 0.15f;
						//isStartParcs = false;
						fibraFlickerSpeed = -fibraFlickerSpeed;
					}


				}

				if (isEndFibra) {
					for (int i = 0; i < MaquetasAnimaciones.Length; i++) {
						Material[] m =MaquetasAnimaciones [i].GetComponent<Renderer>().materials;
						c4 = m [numTexturaFibra].color;
						c4.a = c4.a - parcSpeed;
						c42 = m [numTexturaFibra2].color;
						c42.a = c42.a - parcSpeed;
						if (c4.a <= 0) {
							c4.a = 0;
						}
						if (c42.a <= 0) {
							c42.a = 0;
						}

						m [numTexturaFibra].color = c4;
						m [numTexturaFibra2].color = c42;
					}
					if (c4.a <= 0 && c42.a <= 0) {
						c4.a = 0;
						c42.a = 0;
						isEndFibra = false;
						isFibra = false;
					}
				}

			}//End fibra
			//Superposicion
			Color c5 = new Color();
			int numTexturaSup = layerZonasSup;
			if(isSuperposicion){
				if (isStartSuperposicion) {

					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c5 = m [numTexturaSup].color;
						c5.a = c5.a + parcSpeed;

						m [numTexturaSup].color = c5;
					}
					if (c5.a >= 0.85f) {
						c5.a = 0.85f;
						isStartSuperposicion = false;
					}

				}else if(!isEndSuperposicion ){
					float spd = poligFlickerSpeed;
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c5 = m [numTexturaSup].color;
						c5.a = c5.a + poligFlickerSpeed;
						if (c5.a >= 0.85f) {
							c5.a = 0.85f;
						}
						if (c5.a <= 0.15f) {
							c5.a = 0.15f;
						}
						m [numTexturaSup].color = c5;
					}

					if (c5.a >= 0.85f) {
						c5.a = 0.85f;
						poligFlickerSpeed = -poligFlickerSpeed;
					} 
					if(c5.a<=0.15f){
						c5.a = 0.15f;
						poligFlickerSpeed = -poligFlickerSpeed;
					}


				}

				if (isEndSuperposicion) {
					for (int i = 0; i < Maquetas.Length; i++) {
						Material[] m =Maquetas [i].GetComponent<Renderer>().materials;
						c5 = m [numTexturaSup].color;
						c5.a = c5.a - parcSpeed;

						m [numTexturaSup].color = c5;
					}
					if (c5.a <= 0) {
						c5.a = 0;
						isEndSuperposicion = false;
						isSuperposicion = false;
					}
				}

			}//End superposicion
				

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
	void changeAlphaMaterialMaquetaAnim(int material, float a)
	{
		for (int i = 0; i < MaquetasAnimaciones.Length; i++)
		{
			Material[] m = MaquetasAnimaciones[i].GetComponent<Renderer>().materials;
			Color cv = m[material].color;
			cv.a = a;

			m[material].color = cv; //colorLiso
		}

	}
	void changeColorMaterialMaquetaAnim(int material, Color c)
	{
		for (int i = 0; i < MaquetasAnimaciones.Length; i++)
		{
			Material[] m = MaquetasAnimaciones[i].GetComponent<Renderer>().materials;
			m[material].color = c; //colorLiso
		}

	}
	void changeTextureMaterialMaquetaAnim(int material, Texture t)
	{
		for (int i = 0; i < MaquetasAnimaciones.Length; i++)
		{
			Material[] m = MaquetasAnimaciones[i].GetComponent<Renderer>().materials;
			
				m[material].SetTexture("_MainTex",t);
		}

	}
	void changeTextureMaterialMaqueta(int material, Texture t)
	{
		for (int i = 0; i < Maquetas.Length; i++)
		{
				Material[] m = Maquetas[i].GetComponent<Renderer>().materials;

			m[material].SetTexture("_MainTex",t);
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

		void enableAnimationLayer (int onoff){ //int[] capas,

			if(onoff==0){
				caScript.startAnimation (4);// (Random.Range(4,5));
				/*for (int i = 0; i < Maquetas.Length; i++)
				{
					Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
					Color c = m[layerAnimaciones].color;
					c = m[layerAnimaciones].color;
					c = new Color (0,0,0,0);
					m[layerAnimaciones].color=c;
				}*/
			}
			if(onoff==1){
				caScript.startAnimation (2);
					/*for (int i = 0; i < Maquetas.Length; i++)
				{
					Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
					Color c = m[layerAnimaciones].color;
					c = m[layerAnimaciones].color;
					c = new Color (1,1,1,1);
					m[layerAnimaciones].color=c;
				}*/
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
		if (Input.GetKeyDown(KeyCode.Alpha0)) //PERSONAS
		{
				skipVideo = true;
		}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("startbiblio");
				StartIntro (codigosBibliotecas[0]);
            //StartBiblio2(111);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("startbuses");
				StartIntro (codigosBibliotecas[1]);
            //StartBiblio2(112);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("startlabs");
				StartIntro (codigosBibliotecas[2]);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("startteleasistencia");
				StartIntro (codigosTeleasistencia[0]);
            //StartTeleasis(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("startHestia");
            StartTeleasis(2,0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("startMunicipio solo");
				StartIntro (1);
            //StartGovernObert(130);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("startXALOC");
				StartIntro (codigosPromocioEconomica[0]);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("startGovernObert");
				StartIntro (codigosGovernObert[0]);
        }
			if (Input.GetKeyDown(KeyCode.C))
		{
			Debug.Log("startServeisempresas");
				//StartIntro (17);
		}
        if (Input.GetKeyDown(KeyCode.R))
        {
				Debug.Log("startPlataforma(0)");
				StartPlataforma (0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("startSuperposicion");
				StartSuperposition (codigosPromocioEconomica[0]);
        }
		if (Input.GetKeyDown(KeyCode.T))
		{
			Debug.Log("startEmisions");
				StartIntro (codigosPAES[0]);
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
				Debug.Log("startSuperposicion");
				StartSuperposition (codigosPromocioEconomica[1]);
		}
			if (Input.GetKeyDown(KeyCode.H))
			{
				Debug.Log("End Superposition");
				EndSuperposition (1);
			}
		if (Input.GetKeyDown(KeyCode.V))
		{
			Debug.Log("startParcs");
				StartIntro (codigosParques[0]);
		}
			if (Input.GetKeyDown(KeyCode.K))
			{
				Debug.Log("startfibra");
				StartContent (codigosFibraOptica[0]);
			}
			if (Input.GetKeyDown(KeyCode.L))
			{
				Debug.Log("startfibrasup");
				StartSuperposition (codigosFibraOptica[0]);
			}
		if (Input.GetKeyDown(KeyCode.B))
		{
			Debug.Log("startPoligons");
			StartIntro (codigosPromocioEconomica[1]);
		}
				
		if (Input.GetKeyDown(KeyCode.N))
		{
			Debug.Log("Superposition");
				StartSuperposition (codigosBibliotecas [0]);
		}
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Clean");
            Clean1(0);
        }
		
		if (Input.GetKeyDown(KeyCode.Y))
		{
				cotasAnimation ca = CamaraAnimaciones.GetComponent<cotasAnimation> ();
				changeAlphaMaterialMaqueta (8, 1);

				ca.startAnimation(2);
				for (int i = 0; i < Maquetas.Length; i++)
				{
					Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
					Color c = m[8].color;
					c = m[layerAnimaciones].color;
					c = new Color (1,1,1,1);
					m[8].color=c;
				}
			Debug.Log("Anim");

		}
		if (Input.GetKeyDown(KeyCode.U))
		{
				cotasAnimation ca = CamaraAnimaciones.GetComponent<cotasAnimation> ();
				changeAlphaMaterialMaqueta (8, 1);

				ca.startAnimation(3);
				for (int i = 0; i < Maquetas.Length; i++)
				{
					Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
					Color c = m[8].color;
					c = m[layerAnimaciones].color;
					c = new Color (1,1,1,1);
					m[8].color=c;
				}
			Debug.Log("Anim");

		}
		if (Input.GetKeyDown(KeyCode.I))
		{
				cotasAnimation ca = CamaraAnimaciones.GetComponent<cotasAnimation> ();
				changeAlphaMaterialMaqueta (8, 1);

				ca.startAnimation(4);
				for (int i = 0; i < Maquetas.Length; i++)
				{
					Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
					Color c = m[8].color;
					c = m[layerAnimaciones].color;
					c = new Color (1,1,1,1);
					m[8].color=c;
				}
			Debug.Log("Anim");

		}
			if (Input.GetKeyDown(KeyCode.O))
		{
				cotasAnimation ca = CamaraAnimaciones.GetComponent<cotasAnimation> ();
				changeAlphaMaterialMaqueta (8, 1);

				ca.startAnimation(5);
				for (int i = 0; i < Maquetas.Length; i++)
				{
					Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
					Color c = m[8].color;
					c = m[layerAnimaciones].color;
					c = new Color (1,1,1,1);
					m[8].color=c;
				}
			Debug.Log("Anim");

		}
		if (Input.GetKeyDown(KeyCode.P))
		{
				cotasAnimation ca = CamaraAnimaciones.GetComponent<cotasAnimation> ();
				changeAlphaMaterialMaqueta (8, 1);

				ca.startAnimation(6);
				for (int i = 0; i < Maquetas.Length; i++)
				{
					Material[] m = Maquetas[i].GetComponent<Renderer>().materials;
					Color c = m[8].color;
					c = m[layerAnimaciones].color;
					c = new Color (1,1,1,1);
					m[8].color=c;
				}
			Debug.Log("Anim");

		}
   }
	void fillCodigos(){
		rmd=GetComponent<ReadMunicipiData>();
		for(int i=0;i<rmd.TodasLeyendas.Count;i++){
				if(rmd.TodasLeyendas[i].codigoPadre == 11){ //Bibliotecas
					codigosBibliotecas[contBibliotecas]=rmd.TodasLeyendas[i].codigo;
					leyendaBibliotecas [contBibliotecas].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaBibliotecas [contBibliotecas].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaBibliotecas [contBibliotecas].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaBibliotecas [contBibliotecas].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contBibliotecas++;
				}
				//teleasistencia
				if(rmd.TodasLeyendas[i].codigoPadre == 12){ 
					codigosTeleasistencia[contTeleasistencia]=rmd.TodasLeyendas[i].codigo;
					leyendaTeleasistencia [contTeleasistencia].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaTeleasistencia [contTeleasistencia].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaTeleasistencia [contTeleasistencia].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaTeleasistencia [contTeleasistencia].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contTeleasistencia++;
				}
				//governobert
				if(rmd.TodasLeyendas[i].codigoPadre == 13){ 
					codigosGovernObert[contGovernObert]=rmd.TodasLeyendas[i].codigo;
					Debug.Log("codigos governobert"+rmd.TodasLeyendas[i].codigo + "  "+codigosGovernObert[contGovernObert]+ " "+contGovernObert);
					leyendaGovernObert [contGovernObert].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaGovernObert [contGovernObert].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaGovernObert [contGovernObert].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaGovernObert [contGovernObert].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					Debug.Log ("codigos governobert2");
					contGovernObert++;
				}
				//Pormocio
				if(rmd.TodasLeyendas[i].codigoPadre == 14){ 
					Debug.Log("codigos promocio");
					codigosPromocioEconomica[contPromocioEconomica]=rmd.TodasLeyendas[i].codigo;
					leyendaPromocioEconomica [contPromocioEconomica].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaPromocioEconomica [contPromocioEconomica].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaPromocioEconomica [contPromocioEconomica].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaPromocioEconomica [contPromocioEconomica].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contPromocioEconomica++;
				}
				//km2
				if(rmd.TodasLeyendas[i].codigoPadre == 15){ 
					codigosKm2[contKm2]=rmd.TodasLeyendas[i].codigo;
					leyendaKm2 [contKm2].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaKm2 [contKm2].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaKm2 [contKm2].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaKm2 [contKm2].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contKm2++;
				}
				//patrimoni
				if(rmd.TodasLeyendas[i].codigoPadre == 16){ 
					codigosPatrimoni[contPatrimoni]=rmd.TodasLeyendas[i].codigo;
					leyendaPatrimoni [contPatrimoni].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaPatrimoni [contPatrimoni].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaPatrimoni [contPatrimoni].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaPatrimoni [contPatrimoni].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contPatrimoni++;
				}
				//oficina patrimoni
				if(rmd.TodasLeyendas[i].codigoPadre == 17){ 
					codigosOficinaPatrimoni[contOficinaPatrimoni]=rmd.TodasLeyendas[i].codigo;
					leyendaOficinaPatrimoni [contOficinaPatrimoni].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaOficinaPatrimoni [contOficinaPatrimoni].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaOficinaPatrimoni [contOficinaPatrimoni].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaOficinaPatrimoni [contOficinaPatrimoni].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contOficinaPatrimoni++;
				}

				//SOSTENIBILIDAD
				//xarxa
				if(rmd.TodasLeyendas[i].codigoPadre == 21){ 
					codigosXarxaCiutats[contXarxaCiutats]=rmd.TodasLeyendas[i].codigo;
					leyendaXarxaCiutats [contXarxaCiutats].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaXarxaCiutats [contXarxaCiutats].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaXarxaCiutats [contXarxaCiutats].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaXarxaCiutats [contXarxaCiutats].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contXarxaCiutats++;
				}
				//PAES
				if(rmd.TodasLeyendas[i].codigoPadre == 22){ 
					codigosPAES[contPAES]=rmd.TodasLeyendas[i].codigo;
					leyendaPAES [contPAES].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaPAES [contPAES].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaPAES [contPAES].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaPAES [contPAES].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contPAES++;
				}
				//Renovables
				if(rmd.TodasLeyendas[i].codigoPadre == 23){ 
					codigosRenovables[contRenovables]=rmd.TodasLeyendas[i].codigo;
					leyendaRenovables [contRenovables].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaRenovables [contRenovables].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaRenovables [contRenovables].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaRenovables [contRenovables].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contRenovables++;
				}
				//Evaluacio
				if(rmd.TodasLeyendas[i].codigoPadre == 24){ 
					codigosEvaluacio[contEvaluacio]=rmd.TodasLeyendas[i].codigo;
					leyendaEvaluacio [contEvaluacio].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaEvaluacio [contEvaluacio].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaEvaluacio [contEvaluacio].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaEvaluacio [contEvaluacio].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contEvaluacio++;
				}
				//Parques
				if(rmd.TodasLeyendas[i].codigoPadre == 25){ 
					codigosParques[contParques]=rmd.TodasLeyendas[i].codigo;
					leyendaParques [contParques].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaParques [contParques].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaParques [contParques].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaParques [contParques].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contParques++;
				}
				//Turismo
				if(rmd.TodasLeyendas[i].codigoPadre == 26){ 
					codigosTurismo[contTurismo]=rmd.TodasLeyendas[i].codigo;
					leyendaTurismo [contTurismo].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaTurismo [contTurismo].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaTurismo [contTurismo].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaTurismo [contTurismo].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contTurismo++;
				}
				//TECNOLOGIA
				//serveisgestio
				if(rmd.TodasLeyendas[i].codigoPadre == 31){ 
					codigosServeisGestio[contServeisGestio]=rmd.TodasLeyendas[i].codigo;
					leyendaServeisGestio [contServeisGestio].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaServeisGestio [contServeisGestio].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaServeisGestio [contServeisGestio].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaServeisGestio [contServeisGestio].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contServeisGestio++;
				}
				//plataforma urbana
				if(rmd.TodasLeyendas[i].codigoPadre == 32){ 
					codigosPlataformaUrbana[contPlataformaUrbana]=rmd.TodasLeyendas[i].codigo;
					leyendaPlataformaUrbana [contPlataformaUrbana].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaPlataformaUrbana [contPlataformaUrbana].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaPlataformaUrbana [contPlataformaUrbana].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaPlataformaUrbana [contPlataformaUrbana].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contPlataformaUrbana++;
				}
				//infraestructuras
				if(rmd.TodasLeyendas[i].codigoPadre == 33){ 
					codigosInfraestructuras[contInfraestructuras]=rmd.TodasLeyendas[i].codigo;
					leyendaInfraestructuras [contInfraestructuras].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaInfraestructuras [contInfraestructuras].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaInfraestructuras [contInfraestructuras].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaInfraestructuras [contInfraestructuras].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contInfraestructuras++;
				}
				//fibra optica
				if(rmd.TodasLeyendas[i].codigoPadre == 34){ 
					codigosFibraOptica[contFibraOptica]=rmd.TodasLeyendas[i].codigo;
					leyendaFibraOptica [contFibraOptica].codigo=rmd.TodasLeyendas[i].codigo;
					leyendaFibraOptica [contFibraOptica].leyenda_esp = rmd.TodasLeyendas [i].leyenda_esp;
					leyendaFibraOptica [contFibraOptica].leyenda_cat = rmd.TodasLeyendas [i].leyenda_cat;
					leyendaFibraOptica [contFibraOptica].leyenda_ing = rmd.TodasLeyendas [i].leyenda_ing;
					contFibraOptica++;
				}
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
		//ENTRAR A TEMAS
		oscIn.MapInt( "/personas", oscPersonas);
		oscIn.MapInt( "/sostenibilidad", oscSostenibilidad);
		oscIn.MapInt( "/tecnologia", oscTecnologia);
			oscIn.MapInt( "/inicio", oscInicio);
			oscIn.MapInt( "/videostop", oscVideoStop);

		//PERSONAS
		oscIn.MapInt( "/personas/bibliotecas", oscBiblio);
			oscIn.MapInt( "/personas/teleasistencia", oscTeleasis);


			oscIn.MapInt( "/personas/governobert", oscGovernObert);
			oscIn.MapInt( "/personas/ocupacio", oscPromocio);
			oscIn.MapInt( "/personas/oficina_patrimoni", oscOficinaPatrimoni);
			oscIn.MapInt( "/personas/patrimoni", oscPatrimoni);
			oscIn.MapInt( "/personas/km2", oscKm2);
		//oscIn.Map( "/persones/xaloc", StartXaloc);

		//SOSTENIBILIDAD
			oscIn.MapInt( "/sostenibilidad/xarxapobles", oscXarxa);
			//oscIn.Map( "/sostenibilidad/municipis", StartEmisions);
			oscIn.MapInt( "/sostenibilidad/energias", oscRenovables);
			oscIn.MapInt( "/sostenibilidad/municipis", oscPaes);

			oscIn.MapInt( "/sostenibilidad/mesura", oscEvaluacio);
			oscIn.MapInt( "/sostenibilidad/parques", oscParques);
			oscIn.MapInt( "/sostenibilidad/turismo", oscTurismo);

		//Tecnologia
			oscIn.MapInt( "/tecnologia/serveisgestio", oscServei);
			oscIn.MapInt( "/tecnologia/plataforma", oscPlataforma);
			oscIn.MapInt( "/tecnologia/infraestructuras", oscInfraestructuras);
			//oscIn.Map( "/tecnologia/poligons", StartPoligons);
			oscIn.MapInt( "/tecnologia/mobilidad", oscFibra);

		//IDIOMAS
			oscIn.MapInt( "/tablet0/idioma", oscIdioma1 );
			oscIn.MapInt( "/tablet1/idioma", oscIdioma2 );
			oscIn.MapInt( "/tablet2/idioma", oscIdioma3 );
			oscIn.Map( "/persones/cat", IdiomaPersonescat );
			oscIn.Map( "/sostenibilitat/eng", IdiomaSostenibilitateng);
			oscIn.Map( "/sostenibilitat/cat", IdiomaSostenibilitatcat );
			oscIn.Map( "/tecnologia/eng", IdiomaTecnologiaeng );
			oscIn.Map( "/tecnologia/cat", IdiomaTecnologiacat );
		
			//SUPERPOSICIONES
			//oscIn.MapInt( "/superposicion", StartSuperposition );
			//oscIn.Map( "/superposicion/out", oscEndSuperposition );
			//ESPERA

		oscIn.Map( "/personas/espera", Clean1osc );
			oscIn.Map( "/sostenibilidad/espera", Clean1osc );
			oscIn.Map( "/tecnologia/espera", Clean1osc );
		/*oscIn.Map( "/sostenibilidad/espera", Clean2 );
		oscIn.Map( "/tecnologia/espera", Clean3 );*/


	}
	public void oscPersonas(int value)
	{
			StartTransition (1);
	}
	public void oscSostenibilidad(int value)
	{
			StartTransition (2);
	}
	public void oscTecnologia(int value)
	{
		
			StartTransition (3);
	}
	public void oscInicio(int value)
	{
		Debug.Log ("vuelva a inicio: "+value);
		if (value == 0)EndTransition (1);
		else if (value == 1)EndTransition (2);
		else if (value == 2)EndTransition (3);
	}
	public void oscVideoStop(int value)
	{
		skipVideo = true;
	}
    //CONTROL DE ANIMACIONES DE VIDEO
    public void StartTransition(float state)//transicion de maqueta a tema
    {
            isTransition = true;
			isLandscape = false;
			isChange = true;
			estadoActual [0] = state;
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
				changeColorText (colorPERSONAS);
            }
            if (state == 2)//sostenibilidad
            {
                changeColorVideoMaqueta(layerVideoMaqueta, colorSOSTENIBILIDAD);
                changeColorVideoLiso(layerLisoVideoTransicion, colorSOSTENIBILIDAD);
				changeColorText (colorSOSTENIBILIDAD);
            }
            if (state == 3)//tecnologia
            {
                changeColorVideoMaqueta(layerVideoMaqueta, colorTECNOLOGIA);
                changeColorVideoLiso(layerLisoVideoTransicion, colorTECNOLOGIA);
				changeColorText (colorTECNOLOGIA);
            }

            //videos ON
            changeAlphaVideoMaqueta(layerVideoMaqueta, 1);
            changeAlphaVideoLisas(layerLisoVideoTransicion, 1);

     }
    public void EndTransition(float state)//transicion de maqueta a tema
    {
			Debug.Log ("End transition.");
            isEndTransition = true;
			isChange = true;

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
			estadoSiguiente = state;
			//personas
			if(state==codigosBibliotecas[0] || state==codigosBibliotecas[1] || state==codigosBibliotecas[2]) //bibliotecas
			{
				videoPlayerSuperficie.clip=videosSuperficie[0];
			}

			if(state==codigosTeleasistencia[0]) //teleasistencia
			{
				videoPlayerSuperficie.clip=videosSuperficie[1];
			}

			if(state==codigosGovernObert[0] || state==codigosGovernObert[1]  || state==codigosGovernObert[2] || state==codigosGovernObert[3]  || state==codigosGovernObert[4] || state==codigosGovernObert[5]) //governObert
			{
				videoPlayerSuperficie.clip=videosSuperficie[2];
			}
			if(state==codigosPromocioEconomica[0] || state==codigosPromocioEconomica[1] || state==codigosPromocioEconomica[2]) //Promocion de empresas
			{
				videoPlayerSuperficie.clip=videosSuperficie[3];
			}
			if(state==codigosKm2[0]  ) //km2
			{
				videoPlayerSuperficie.clip=videosSuperficie[4];
			}
			if(state==codigosPatrimoni[0] || state==codigosPatrimoni[1] || state==codigosPatrimoni[2]|| state==codigosPatrimoni[3]|| state==codigosPatrimoni[4]|| state==codigosPatrimoni[5]) //Patrimoni
			{
				videoPlayerSuperficie.clip=videosSuperficie[5];
			}
			if(state==codigosOficinaPatrimoni[0] ||  state==codigosOficinaPatrimoni[1] || state==codigosOficinaPatrimoni[1]) //Patrimoni
			{
				videoPlayerSuperficie.clip=videosSuperficie[6];
			}

			//Sostenibilidad
			if(state==codigosXarxaCiutats[0] || state==codigosXarxaCiutats[1] || state==codigosXarxaCiutats[2]) //xarxa
			{
				videoPlayerSuperficie.clip=videosSuperficie[7];
			}
			if(state==codigosPAES[0] || state==codigosPAES[1]) //Emsiones co2
			{
				videoPlayerSuperficie.clip=videosSuperficie[8];
			}
			if(state==codigosRenovables[0] || state==codigosRenovables[1] || state==codigosRenovables[2]) //renovables
			{
				videoPlayerSuperficie.clip=videosSuperficie[9];
			}
			if(state==codigosEvaluacio[0] || state==codigosEvaluacio[1] || state==codigosEvaluacio[2]) //Evaluacio
			{
				Debug.Log ("Evaluacio start intro");
				videoPlayerSuperficie.clip=videosSuperficie[10];
			}
			if(state==codigosParques[0] ) //Parques
			{
				videoPlayerSuperficie.clip=videosSuperficie[11];
			}
			if(state==codigosTurismo[0] || state==codigosTurismo[1] || state==codigosTurismo[2]) //Turismo
			{
				videoPlayerSuperficie.clip=videosSuperficie[12];
			}


			//Tecnologia
			if(state==codigosServeisGestio[0] || state==codigosServeisGestio[1] ||state==codigosServeisGestio[2] || state==codigosServeisGestio[3]
				|| state==codigosServeisGestio[4] || state==codigosServeisGestio[5] || state==codigosServeisGestio[6] || state==codigosServeisGestio[7]) //Emsiones co2
			{
				videoPlayerSuperficie.clip=videosSuperficie[13];
			}
			if(state==codigosPlataformaUrbana[0] || state==codigosPlataformaUrbana[1]) //Plataforma
			{
				videoPlayerSuperficie.clip=videosSuperficie[14];
			}
			if(state==codigosInfraestructuras[0] || state==codigosInfraestructuras[1]) //Infraestructures
			{
				videoPlayerSuperficie.clip=videosSuperficie[15];
			}
			if(state==codigosFibraOptica[0]) //Fibra
			{
				videoPlayerSuperficie.clip=videosSuperficie[16];
			}
			//




			//videoPlayerSuperficie.clip=videosSuperficie[Random.Range(0,videosSuperficie.Length )];
			videoPlayerMapping.clip=videosMapping[0];
			videoPlayerMapping.Play ();
			if (estadoActual[0]==1)//personas
			{
				changeColorVideoMaqueta (layerVideoMapping,colorPERSONAS );
			}
			if (estadoActual[0] == 2)//sostenibilidad
			{
				changeColorVideoMaqueta (layerVideoMapping,colorSOSTENIBILIDAD );
			}
			if (estadoActual[0] == 3)//tecnologia
			{
				changeColorVideoMaqueta (layerVideoMapping,colorTECNOLOGIA );
			}
			if(state==0 )//caso especial de superoposicion para demo
			{
				StartContent (0);
			}
			else if(state==1 )//caso especial de superoposicion para demo
			{
				StartContent (1);
			}else{
				changeAlphaVideoMaqueta (layerVideoMapping, 1);
				videoPlayerSuperficie.Play ();
				videoPlayerSuperficie.frame = 0;
				for(int i=0;i<superficiesVideos.Length;i++){
					superficiesVideos [i].GetComponent<MeshRenderer> ().enabled = true;
				}
			}
			isIntro = true;

    }
		public void oscEndSuperposition(OscMessage message) //Lanza contenido
		{
			Debug.Log ("End superposition osc");
			EndSuperposition(0);

		}
		public void EndSuperposition(int state) //Lanza contenido
		{
			Debug.Log ("End superposition");
			isEndSuperposicion = true;
			//disableIconosLeyenda
			enableIconosLeyendaSup (IconosTablet1[0],Color.white,0);
			MarkerControl mc=AnimEndSuper.GetComponent<MarkerControl>();
			AnimationTrigger at=AnimEndSuper.GetComponent<AnimationTrigger>();
			activeTablets [0] = true;
			at.isGrowing = true;
		}


	
	public void StartSuperposition(int state) //Lanza contenido
	{
		Debug.Log ("Start State:"+state);
			isSuperposicionPuntos = false;
		//PERSONAS
		if(state==codigosBibliotecas[0] || state==codigosBibliotecas[1] || state==codigosBibliotecas[2]) //bibliotecas
		{
			isSuperposicionPuntos = true;
			StartBiblio2((int)state,1);
		}

		if(state==codigosTeleasistencia[0]) //teleasistencia
		{
			StartTeleasis((int)state,1);
		}

		
		if(state==codigosPromocioEconomica[0] || state==codigosPromocioEconomica[1] || state==codigosPromocioEconomica[2]) //Promocion de empresas
		{
			StartPromocio((int)state,1);
		}
		
		//SOSTENIBILIDAD
		if(state==codigosParques[0] || state==codigosParques[1] || state==codigosParques[2] || state==codigosParques[3]
			|| state==codigosParques[4] || state==codigosParques[5] || state==codigosParques[6]  || state==codigosParques[7]
			|| state==codigosParques[8] || state==codigosParques[9] || state==codigosParques[10] || state==codigosParques[11]
			|| state==codigosParques[12]) //Parques
		{
			StartParcs((int)state);
		}
		if(state==codigosXarxaCiutats[0] || state==codigosXarxaCiutats[1] || state==codigosXarxaCiutats[2]) //xarxa
		{
			StartXarxa((int)state);
		}
		if(state==codigosPAES[0]) //Emsiones co2
		{
			StartEmisions((int)state);
		}
		if(state==codigosPAES[1] || state==codigosPAES[2] || state==codigosPAES[3]|| state==codigosPAES[4]) //PAES
		{
			StartPAES((int)state);
		}
		if(state==codigosRenovables[0] || state==codigosRenovables[1] || state==codigosRenovables[2]) //renovables
		{
			StartRenovables((int)state);
		}
		if(state==codigosEvaluacio[0] || state==codigosEvaluacio[1] || state==codigosEvaluacio[2]) //Evaluacio
		{
			StartOTAGA((int)state);
		}
		if(state==codigosTurismo[0] || state==codigosTurismo[1] || state==codigosTurismo[2]) //Turismo
		{
			StartTurisme((int)state);
		}

		//Tecnologia
		if(state==codigosFibraOptica[0]) //Emsiones co2
		{
			StartFibra((int)state,1);
		}
		if(state==codigosServeisGestio[0] || state==codigosServeisGestio[1] ||state==codigosServeisGestio[2] || state==codigosServeisGestio[3]
			|| state==codigosServeisGestio[4] || state==codigosServeisGestio[5] || state==codigosServeisGestio[6] || state==codigosServeisGestio[7]) //Emsiones co2
		{
			StartServeiGestio((int)state);
		}
		
		





		if(state==0) //caso especial superposicion demo
		{
			isSuperposicion = true;
			changeTextureMaterialMaquetaAnim(layerMunicipios,texturasPatrimonios[0]);
		}
		if(state==1) //caso especial superposicion demo
		{
			//isSuperposicion = true;
			changeTextureMaterialMaqueta(layerMunicipiosSolos,texturasMunicipiosSolos[Random.Range(0,texturasMunicipiosSolos.Length)]);
			changeAlphaMaterialMaqueta (layerMunicipiosSolos, 1);
		}


	}//end start superposicion

    public void StartContent(float state) //Lanza contenido
    {
			Debug.Log ("Start State:"+state);
			Debug.Log ("Codigo teleasis:"+codigosTeleasistencia[0]);
			//PERSONAS
			if(state==codigosBibliotecas[0] || state==codigosBibliotecas[1] || state==codigosBibliotecas[2]) //bibliotecas
			{
				StartBiblio2((int)state,0);
			}

			if(state==codigosTeleasistencia[0]) //teleasistencia
			{
				StartTeleasis((int)state,0);
			}

			if(state==codigosGovernObert[0] || state==codigosGovernObert[1]  || state==codigosGovernObert[2] || state==codigosGovernObert[3]  
				|| state==codigosGovernObert[4] || state==codigosGovernObert[5] || state==codigosGovernObert[6]|| state==codigosGovernObert[7]
				|| state==codigosGovernObert[8] || state==codigosGovernObert[9]) //governObert
			{
				StartGovernObert((int)state);
			}
			if(state==codigosPromocioEconomica[0] || state==codigosPromocioEconomica[1] || state==codigosPromocioEconomica[2]) //Promocion de empresas
			{
				StartPromocio((int)state,0);
			}
			if(state==codigosKm2[0]  ) //km2
			{
				StartKm2((int)state);
			}
			if(state==codigosPatrimoni[0] || state==codigosPatrimoni[1] || state==codigosPatrimoni[2]|| state==codigosPatrimoni[3]
				|| state==codigosPatrimoni[4]|| state==codigosPatrimoni[5]) //Patrimoni
			{
				StartPatrimoni((int)state);
			}
			if(state==codigosOficinaPatrimoni[0] ||  state==codigosOficinaPatrimoni[1] || state==codigosOficinaPatrimoni[2]) //Patrimoni
			{
				StartOficinaPatrimoni((int)state);
			}
			//SOSTENIBILIDAD
			if(state==codigosParques[0] || state==codigosParques[1] || state==codigosParques[2] || state==codigosParques[3]
				|| state==codigosParques[4] || state==codigosParques[5] || state==codigosParques[6]  || state==codigosParques[7]
				|| state==codigosParques[8] || state==codigosParques[9] || state==codigosParques[10] || state==codigosParques[11]
				|| state==codigosParques[12]) //Parques
			{
				StartParcs((int)state);
			}
			if(state==codigosXarxaCiutats[0] || state==codigosXarxaCiutats[1] || state==codigosXarxaCiutats[2]) //xarxa
			{
				StartXarxa((int)state);
			}
			if(state==codigosPAES[0]) //Emsiones co2
			{
				StartEmisions((int)state);
			}
			if(state==codigosPAES[1] || state==codigosPAES[2] || state==codigosPAES[3]|| state==codigosPAES[4]) //PAES
			{
				StartPAES((int)state);
			}
			if(state==codigosRenovables[0] || state==codigosRenovables[1] || state==codigosRenovables[2]) //renovables
			{
				StartRenovables((int)state);
			}
			if(state==codigosEvaluacio[0] || state==codigosEvaluacio[1] || state==codigosEvaluacio[2]) //Evaluacio
			{
				StartOTAGA((int)state);
			}
			if(state==codigosTurismo[0] || state==codigosTurismo[1] || state==codigosTurismo[2]) //Turismo
			{
				StartTurisme((int)state);
			}

			//Tecnologia
			if(state==codigosFibraOptica[0]) //Emsiones co2
			{
				StartFibra((int)state,0);
			}
			if(state==codigosServeisGestio[0] || state==codigosServeisGestio[1] ||state==codigosServeisGestio[2] || state==codigosServeisGestio[3]
				|| state==codigosServeisGestio[4] || state==codigosServeisGestio[5] || state==codigosServeisGestio[6] || state==codigosServeisGestio[7]) //Emsiones co2
			{
				StartServeiGestio((int)state);
			}
			if(state==codigosPlataformaUrbana[0] || state==codigosPlataformaUrbana[1]) //Plataforma
			{
				StartPlataforma((int)state);
			}
			if(state==codigosInfraestructuras[0] || state==codigosInfraestructuras[1]) //Infraestructures
			{
				StartInfraestructures((int)state);
			}





			if(state==0) //caso especial superposicion demo
			{
				isSuperposicion = true;
				changeTextureMaterialMaquetaAnim(layerMunicipios,texturasPatrimonios[0]);
			}
			if(state==1) //caso especial superposicion demo
			{
				//isSuperposicion = true;
				changeTextureMaterialMaqueta(layerMunicipiosSolos,texturasMunicipiosSolos[Random.Range(0,texturasMunicipiosSolos.Length)]);
				changeAlphaMaterialMaqueta (layerMunicipiosSolos, 1);
			}


     }
	public void changeColorText(Color c)
	{
		Debug.Log ("Change color text");
		for (int i = 0; i < 3; i++)
		{
				Titulos[i].color = c;
				//Subtitulos[i].text = "";
			
		}
		
	}
    //Elige el texto a poner en la zona de cada tablet
    public void writeTextLanguage(int sup,int state ) {

            //Bibliotecas
			if (state == codigosBibliotecas[0])
            {
                Debug.Log("Cambia texto leyenda bibliotecaz");
                for (int i = 0; i < 3; i++)
                {
                    if (lenguajeTablets[i] == 0)
                    {
						Titulos[i].text = leyendaBibliotecas [0].leyenda_cat;
                        Subtitulos[i].text = "";
                    }
                    else if (lenguajeTablets[i] == 2)
                    {
						Titulos[i].text = leyendaBibliotecas [0].leyenda_ing;
						Subtitulos[i].text = "";
                    }
                    else if (lenguajeTablets[i] == 1)
                    {
						Titulos[i].text = leyendaBibliotecas [0].leyenda_esp;
                        Subtitulos[i].text = "";
                    }
                }
            }
            //Bibliobuses
			if (state == codigosBibliotecas[1])
            {
                for (int i = 0; i < 3; i++)
                {
                    if (lenguajeTablets[i] == 0)
                    {
						Titulos[i].text = leyendaBibliotecas [1].leyenda_cat;
						Subtitulos[i].text = "";
                    }
                    else if (lenguajeTablets[i] == 2)
                    {
						Titulos[i].text = leyendaBibliotecas [1].leyenda_ing;
						Subtitulos[i].text = "";
                    }
                    else if (lenguajeTablets[i] == 1)
                    {
						Titulos[i].text = leyendaBibliotecas [1].leyenda_esp;
						Subtitulos[i].text = "";
                    }
                }
            }
			//Bibliolabs
			if (state == codigosBibliotecas[2])
			{
				for (int i = 0; i < 3; i++)
				{
					if (lenguajeTablets[i] == 0)
					{
						Titulos[i].text = leyendaBibliotecas [2].leyenda_cat;
						Subtitulos[i].text = "";
					}
					else if (lenguajeTablets[i] == 2)
					{
						Titulos[i].text = leyendaBibliotecas [2].leyenda_ing;
						Subtitulos[i].text = "";
					}
					else if (lenguajeTablets[i] == 1)
					{
						Titulos[i].text = leyendaBibliotecas [2].leyenda_esp;
						Subtitulos[i].text = "";
					}
				}
			}

			//Teleasistencia
			if (state == codigosTeleasistencia[0])
			{
				for (int i = 0; i < 3; i++)
				{
					if (lenguajeTablets [i] == 0) {
						if (sup == 0)Titulos [i].text = leyendaTeleasistencia [0].leyenda_cat;
						else Subtitulos [i].text = leyendaTeleasistencia [0].leyenda_cat;
					} else if (lenguajeTablets[i] == 2) {
						if (sup == 0)Titulos [i].text = leyendaTeleasistencia [0].leyenda_ing;
						else Subtitulos [i].text = leyendaTeleasistencia [0].leyenda_ing;
					}
					else if (lenguajeTablets[i] == 1)
					{
						if (sup == 0)Titulos[i].text = leyendaTeleasistencia [0].leyenda_esp;
						else Subtitulos[i].text = leyendaTeleasistencia [0].leyenda_esp;
					}
				}
			}

			//GovernObert
			if(state==codigosGovernObert[0] || state==codigosGovernObert[1]  || state==codigosGovernObert[2] || state==codigosGovernObert[3]  
				|| state==codigosGovernObert[4] || state==codigosGovernObert[5] || state==codigosGovernObert[6]|| state==codigosGovernObert[7]
				|| state==codigosGovernObert[8] || state==codigosGovernObert[9])  //governObert
			{
				Debug.Log ("TextoGO: "+leyendaGovernObert [0].leyenda_cat+ "Codigo"+leyendaGovernObert[1].codigo+" Length "+leyendaGovernObert.Length);
				for(int j = 0; j < leyendaGovernObert.Length; j++){
					if(leyendaGovernObert[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaGovernObert[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos [i].text = leyendaGovernObert [j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaGovernObert [j].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaGovernObert [j].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}
			//ocupacio y promocio
			if (state == codigosPromocioEconomica[0] || state == codigosPromocioEconomica[1] || state == codigosPromocioEconomica[2])
			{
				
					for(int j = 0; j < leyendaPromocioEconomica.Length; j++){
						if(leyendaPromocioEconomica[j].codigo==state){
							Debug.Log ("entra a state:"+leyendaPromocioEconomica[j].codigo);
							for (int i = 0; i < 3; i++)
							{
								if (lenguajeTablets[i] == 0)
								{
								if(sup==0)Titulos[i].text=leyendaPromocioEconomica[j].leyenda_cat;
								else	Subtitulos[i].text=leyendaPromocioEconomica[j].leyenda_cat;
								}
								else if (lenguajeTablets[i] == 2)
								{
								if (sup == 0)Titulos [i].text = leyendaPromocioEconomica [j].leyenda_ing;
								else Subtitulos [i].text = leyendaPromocioEconomica [j].leyenda_ing;
								}
								else if (lenguajeTablets[i] == 1)
								{
								if(sup==0)Titulos[i].text = leyendaPromocioEconomica[j].leyenda_esp;
								else	Subtitulos[i].text =leyendaPromocioEconomica[j].leyenda_ing;
								}
							}
						}
					}
				

			}
			//Km2
			if (state == codigosKm2[0])
			{
				Debug.Log ("TextoKm2"+leyendaKm2 [0].leyenda_cat);
				for (int i = 0; i < 3; i++)
				{
					if (lenguajeTablets[i] == 0)
					{
						Titulos[i].text=leyendaKm2 [0].leyenda_cat;
						Subtitulos[i].text="";
					}
					else if (lenguajeTablets[i] == 2)
					{
						Titulos [i].text = leyendaKm2 [0].leyenda_ing;
						Subtitulos [i].text = "";
					}
					else if (lenguajeTablets[i] == 1)
					{
						Titulos[i].text = leyendaKm2 [0].leyenda_esp;
						Subtitulos[i].text = "";
					}
				}
			}
			//Patrimoni
			if(state==codigosPatrimoni[0] || state==codigosPatrimoni[1] || state==codigosPatrimoni[2]|| state==codigosPatrimoni[3]
				|| state==codigosPatrimoni[4]|| state==codigosPatrimoni[5]) //Patrimoni
			{
				for(int j = 0; j < leyendaPatrimoni.Length; j++){
					if(leyendaPatrimoni[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaPatrimoni[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaPatrimoni[j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaPatrimoni[j].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaPatrimoni[j].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}
			//Oficina Patrimoni
			if (state == codigosOficinaPatrimoni[0] || state == codigosOficinaPatrimoni[1]|| state == codigosOficinaPatrimoni[2])
			{
				for(int j = 0; j < leyendaOficinaPatrimoni.Length; j++){
					if(leyendaOficinaPatrimoni[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaOficinaPatrimoni[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaOficinaPatrimoni[j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaOficinaPatrimoni[j].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaOficinaPatrimoni[j].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}

			//SOSTENIBILIDAD
			//xarxa pobles
			if (state == codigosXarxaCiutats[0] ||state == codigosXarxaCiutats[1]||state == codigosXarxaCiutats[2])
			{
				for(int j = 0; j < leyendaXarxaCiutats.Length; j++){
					if(leyendaXarxaCiutats[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaXarxaCiutats[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaXarxaCiutats[j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaXarxaCiutats[j].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaXarxaCiutats[j].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}
			//Municipis cambio
			if (state == codigosPAES[0] ||state == codigosPAES[1]||state == codigosPAES[2]||state == codigosPAES[3]||state == codigosPAES[4])
			{
				for(int j = 0; j < leyendaPAES.Length; j++){
					if(leyendaPAES[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaPAES[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaPAES[j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaPAES[j].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaPAES[j].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}
			//evaluacio
			if (state == codigosEvaluacio[0] ||state == codigosEvaluacio[1]||state == codigosEvaluacio[2])
			{
				for(int j = 0; j < leyendaEvaluacio.Length; j++){
					if(leyendaEvaluacio[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaEvaluacio[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaEvaluacio[j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaEvaluacio[j].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaEvaluacio[j].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}
			//Renovables
			if (state == codigosRenovables[0] || state == codigosRenovables[1] || state == codigosRenovables[2])
			{
				for(int j = 0; j < leyendaRenovables.Length; j++){
					if(leyendaRenovables[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaRenovables[j].codigo);
							for (int i = 0; i < 3; i++)
							{
								if (lenguajeTablets[i] == 0)
								{
								Titulos[i].text=leyendaRenovables[j].leyenda_cat;
									Subtitulos[i].text="";
								}
								else if (lenguajeTablets[i] == 2)
								{
								Titulos [i].text = leyendaRenovables[j].leyenda_ing;
									Subtitulos [i].text = "";
								}
								else if (lenguajeTablets[i] == 1)
								{
								Titulos[i].text = leyendaRenovables[j].leyenda_esp;
									Subtitulos[i].text = "";
								}
							}
					}
				}
			}
			//Parques
			if(state==codigosParques[0] || state==codigosParques[1] || state==codigosParques[2] || state==codigosParques[3]
				|| state==codigosParques[4] || state==codigosParques[5] || state==codigosParques[6]  || state==codigosParques[7]
				|| state==codigosParques[8] || state==codigosParques[9] || state==codigosParques[10] || state==codigosParques[11]
				|| state==codigosParques[12]) //Parques
			{
				for(int j = 0; j < leyendaParques.Length; j++){
					if(leyendaParques[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaParques[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaParques [0].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaParques [0].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaParques [0].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}
			//Turismo
			if (state == codigosTurismo[0] || state == codigosTurismo[1]||state == codigosTurismo[2])
			{
				for(int j = 0; j < leyendaTurismo.Length; j++){
					if(leyendaTurismo[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaTurismo[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaTurismo[j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaTurismo[j].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaTurismo[j].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}

			//TECNOLOGIA
			//Serveis gestio
			if(state==codigosServeisGestio[0] || state==codigosServeisGestio[1] ||state==codigosServeisGestio[2] || state==codigosServeisGestio[3]
				|| state==codigosServeisGestio[4] || state==codigosServeisGestio[5] || state==codigosServeisGestio[6] || state==codigosServeisGestio[7]) //serveis gestio
			{
				for(int j = 0; j < leyendaServeisGestio.Length; j++){
					if(leyendaServeisGestio[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaServeisGestio[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaServeisGestio[j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaServeisGestio[j].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaServeisGestio[j].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}
			//Plataforma urbana
			if (state == codigosPlataformaUrbana[0]|| state == codigosPlataformaUrbana[1])
			{
				string tpropia;
				string tmulti;
			
				for (int i = 0; i < 3; i++)
				{
					if (lenguajeTablets[i] == 0)
					{
						 tpropia="Plataforma pròpia";
						 tmulti="Plataforma multi-tenant DIBA";
						if(i==0){
							TitulosPlataformaT1 [0].text =tpropia;
							TitulosPlataformaT1[1].text=tmulti;
						}
						if(i==1){
							TitulosPlataformaT2 [0].text =tpropia;
							TitulosPlataformaT2[1].text=tmulti;
						}
						if(i==2){
							TitulosPlataformaT2 [0].text =tpropia;
							TitulosPlataformaT2[1].text=tmulti;
						}
						Titulos[i].text="Plataforma urbana intelligent";
						Subtitulos[i].text="";
					}
					else if (lenguajeTablets[i] == 2)
					{
						 tpropia="Own Platform";
						 tmulti="Multi-tenant DIBA platform";
						if(i==0){
							TitulosPlataformaT1 [0].text =tpropia;
							TitulosPlataformaT1[1].text=tmulti;
						}
						if(i==1){
							TitulosPlataformaT2 [0].text =tpropia;
							TitulosPlataformaT2[1].text=tmulti;
						}
						if(i==2){
							TitulosPlataformaT2 [0].text =tpropia;
							TitulosPlataformaT2[1].text=tmulti;
						}
						Titulos [i].text = "Smart urban platform";
						Subtitulos [i].text = "";
					}
					else if (lenguajeTablets[i] == 1)
					{
						 tpropia="Plataforma propia";
						 tmulti="Plataforma multi-tenant DIBA";
						if(i==0){
							TitulosPlataformaT1 [0].text =tpropia;
							TitulosPlataformaT1[1].text=tmulti;
						}
						if(i==1){
							TitulosPlataformaT2 [0].text =tpropia;
							TitulosPlataformaT2[1].text=tmulti;
						}
						if(i==2){
							TitulosPlataformaT2 [0].text =tpropia;
							TitulosPlataformaT2[1].text=tmulti;
						}
						Titulos[i].text = "Plataforma urbana inteligente";
						Subtitulos[i].text = "";
					}
				}
				/*
				for(int j = 0; j < leyendaPlataformaUrbana.Length; j++){
					if(leyendaPlataformaUrbana[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaPlataformaUrbana[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaPlataformaUrbana[j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaPlataformaUrbana[j].leyenda_cat;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaPlataformaUrbana[j].leyenda_cat;
								Subtitulos[i].text = "";
							}
						}
					}
				}*/
			}
			//Infraestructuras
			if (state == codigosInfraestructuras[0] || state == codigosInfraestructuras[1])
			{
				for(int j = 0; j < leyendaInfraestructuras.Length; j++){
					if(leyendaInfraestructuras[j].codigo==state){
						Debug.Log ("entra a state:"+leyendaInfraestructuras[j].codigo);
						for (int i = 0; i < 3; i++)
						{
							if (lenguajeTablets[i] == 0)
							{
								Titulos[i].text=leyendaInfraestructuras[j].leyenda_cat;
								Subtitulos[i].text="";
							}
							else if (lenguajeTablets[i] == 2)
							{
								Titulos [i].text = leyendaInfraestructuras[j].leyenda_ing;
								Subtitulos [i].text = "";
							}
							else if (lenguajeTablets[i] == 1)
							{
								Titulos[i].text = leyendaInfraestructuras[j].leyenda_esp;
								Subtitulos[i].text = "";
							}
						}
					}
				}
			}
			//Fibra optica
			if (state == codigosFibraOptica[0])
			{
				for (int i = 0; i < 3; i++)
				{
					if (lenguajeTablets[i] == 0)
					{
						if(sup==0)Titulos[i].text=leyendaFibraOptica [0].leyenda_cat;
						else Subtitulos[i].text=leyendaFibraOptica [0].leyenda_cat;
					}
					else if (lenguajeTablets[i] == 2)
					{
						if(sup==0)Titulos [i].text = leyendaFibraOptica [0].leyenda_ing;
						else Subtitulos [i].text = leyendaFibraOptica [0].leyenda_ing;
					}
					else if (lenguajeTablets[i] == 1)
					{
						if(sup==0)Titulos[i].text = leyendaFibraOptica [0].leyenda_esp;
						else Subtitulos[i].text =  leyendaFibraOptica [0].leyenda_esp;
					}
				}
			}

    }

    //PERSONAS
    public void StartBiblio(int value,bool superposicion) //NO SIRVE¿¿??
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
		public void enableIconosPlataforma()
		{
			LeyendaMarcadorb [6].GetComponent<SpriteRenderer> ().enabled = true;
			LeyendaMarcadorb [7].GetComponent<SpriteRenderer> ().enabled = true;
			LeyendaMarcadorb [8].GetComponent<SpriteRenderer> ().enabled = true;
			LeyendaMarcadorb [9].GetComponent<SpriteRenderer> ().enabled = true;
			LeyendaMarcadorb [10].GetComponent<SpriteRenderer> ().enabled = true;
			LeyendaMarcadorb [11].GetComponent<SpriteRenderer> ().enabled = true;
		}
		public void disableIconosPlataforma()
		{
			LeyendaMarcadorb [6].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [7].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [8].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [9].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [10].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [11].GetComponent<SpriteRenderer> ().enabled = false;
		}
		public void enableIconosCo2()
		{
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().enabled=true;
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer>().enabled=true;
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer>().enabled=true;
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];
			/*LeyendaMarcadorb [0].GetComponent<SpriteRenderer>().enabled=true; //para fechas
			LeyendaMarcadorb [1].GetComponent<SpriteRenderer>().enabled=true; //para fechas
			LeyendaMarcadorb [2].GetComponent<SpriteRenderer>().enabled=true; //para fechas*/
		}
		public void disableIconosCo2()
		{
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];
			/*LeyendaMarcadorb [0].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [1].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [2].GetComponent<SpriteRenderer>().enabled=false;*/
		}
		public void enableIconosExplicativos(Sprite s)
		{
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().enabled=true;
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().sprite=s;
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer>().enabled=true;
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer>().sprite=s;
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer>().enabled=true;
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer>().sprite=s;
			/*LeyendaMarcadorb [0].GetComponent<SpriteRenderer>().enabled=true; //para fechas
			LeyendaMarcadorb [1].GetComponent<SpriteRenderer>().enabled=true; //para fechas
			LeyendaMarcadorb [2].GetComponent<SpriteRenderer>().enabled=true; //para fechas*/
		}
		public void disableIconosExplicativos()
		{
			Debug.Log ("disable iconosleyenda");
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];
			/*LeyendaMarcadorb [0].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [1].GetComponent<SpriteRenderer>().enabled=false;
			LeyendaMarcadorb [2].GetComponent<SpriteRenderer>().enabled=false;*/
		}

		public void enableIconosLeyenda(Sprite s,Color c,int fade)
	{
		Debug.Log ("Enable iconos:"+fade);
			if(fade==0){
				for (int i = 0; i < 3; i++)
				{
				//LeyendaMarcadorb [i].GetComponent<SpriteRenderer>().sprite = s;
				//LeyendaMarcadorb [i].GetComponent<SpriteRenderer>().color = c;
				LeyendaMarcador [i].GetComponent<SpriteRenderer>().enabled = false;
				}
			}
			else{
				for (int i = 0; i < 3; i++)
				{
					LeyendaMarcador [i].GetComponent<SpriteRenderer>().sprite = s;
					LeyendaMarcador [i].GetComponent<SpriteRenderer>().color = c;
					LeyendaMarcador [i].GetComponent<SpriteRenderer>().enabled = true;
				}
			}
	}
	public void enableIconosLeyendaSup(Sprite s,Color c,int fade)
	{
		Debug.Log ("Enable iconos:"+fade);
		if(fade==0){
			for (int i = 0; i < 3; i++)
			{
				//LeyendaMarcadorb [i].GetComponent<SpriteRenderer>().sprite = s;
				LeyendaMarcadorb [i].GetComponent<SpriteRenderer>().color = c;
				LeyendaMarcadorb [i].GetComponent<SpriteRenderer>().enabled = false;
			}
		}
		else{
			for (int i = 0; i < 3; i++)
			{
				LeyendaMarcadorb [i].GetComponent<SpriteRenderer>().sprite = s;
				LeyendaMarcadorb [i].GetComponent<SpriteRenderer>().color = c;
				LeyendaMarcadorb [i].GetComponent<SpriteRenderer>().enabled = true;
			}
		}
	}
		public void oscBiblio(int message)
	{
			Debug.Log (message);
			Debug.Log ("biblio");
			if (message == 0)StartIntro (codigosBibliotecas[0]);
			if (message == 1 ) StartContent (codigosBibliotecas[0]);
			if (message == 2) StartContent (codigosBibliotecas[1]);
			if (message == 3) StartContent (codigosBibliotecas[2]);
	}
		public void StartBiblio2(int value,int super)    //recibe el valor del dato a mostrar y elegirá el tipo que es y como animarlo
	{
		Debug.Log( "Received: biblio "+value);
		MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
			activeTablets [0] = true;
		    mc.colorToChange = colorBibliotecas;
			/*LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorBibliotecas;
			LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = true;*/
			enableIconosLeyenda (IconosTablet1[0], colorPERSONAS,1);

			
			if (value == codigosBibliotecas[0]) { //bibliotecas
				estadoActual[2] = value;
				if(super==0){
	               
				    mc.colorToChange = colorBibliotecas;
				    at.contenido = "Bibliotecas";
	                writeTextLanguage(0, value);

				    LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[0];
				    
	                at.isGrowing = true;
					CleanVideoMapping (); //limpia si no es superposicion
				}
				else //SUPERPOSICION
				{
					mc.isSuperposition = true;
					mc.colorToChange = Color.white;
					at.contenido = "Bibliotecas";
					writeTextLanguage(1, value);
					at.isGrowing = true;
				}
				
            }
			else if (value == codigosBibliotecas[1]) { //bibliobuses
				if(!isSuperposicion) CleanPuntos(); //limpia si no es superposicion
                estadoActual[2] = value;
                //activar bibliobus
				changeAlphaMaterialMaqueta(layerVideoMapping,1);
				changeColorVideoMaqueta (layerVideoMapping, colorBibliobuses);
				videoPlayerMapping.clip = videosMapping[2];
               
                //at.contenido = "Bibliobuses";
				LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorBibliobuses;
                writeTextLanguage(0,value);

				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[1];



            }
			else if (value == codigosBibliotecas[2])//bibliolabs
            {
                estadoActual[2] = value;
                //bibliolabs
                //activar marcadores con color azulado brillante
				//changeAlphaMaterialMaqueta(layerMunicipios, 1);
				mc.colorToChange = colorBibliotecas;
				LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorBibliotecas;
				at.contenido = "Bibliotecas";
				writeTextLanguage(0, value);

				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[0];
				at.isGrowing = true;
				if(!isSuperposicion)CleanVideoMapping ();//limpia si no es superposicion
            }

			//Enable leyendas
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			//Animaciones maqueta2
			if(super==0){
				changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
				enableAnimationLayer(1);
			}



	}
		public void oscTeleasis(int message)
		{
			Debug.Log (message);
			Debug.Log ("teleasis");
			if ( message == 0) StartIntro (codigosTeleasistencia[0]);
			if (message == 1 ) StartContent (codigosTeleasistencia[0]);
		}
		public void StartTeleasis(int value, int super )
	{
		Debug.Log( "Received: teleasis ");
		MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
			//LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = true;
			activeTablets [0] = true;
			enableIconosLeyenda (IconosTablet1[0], colorPERSONAS,1);

			if(value == codigosTeleasistencia[0] || value==0){
				if(super==0){
					mc.colorToChange = colorPERSONAS;
					at.contenido = "Teleasistencia";
					at.isGrowing = true;
					writeTextLanguage (0, value);
					LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[3];
					LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
				}
				else //SUPERPOSICION
				{
					mc.isSuperposition = true;
					mc.colorToChange = Color.white;
					at.contenido = "Teleasistencia";
					writeTextLanguage(1, value);
					at.isGrowing = true;
				}



			}
			else if(value == 2){
				mc.colorToChange = colorHestia;
				LeyendaMarcador [0].GetComponent<Renderer> ().material.color = colorHestia;
				at.contenido = "HESTIA";
				at.isGrowing = true;
				if (lenguajeTablets [0] == 0) {
					Titulos [0].text = "Municipis que utilitzen Hèstia ";
					Subtitulos [0].text = "";
				} else {
					Titulos [0].text = "Municipalities using Hèstia";
					Subtitulos [0].text = "";
				}

				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[7];
				LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			}
			//Animaciones maqueta2
			changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
			enableAnimationLayer(1);
	}
		public void oscGovernObert(int message)
		{
			Debug.Log (message);
			Debug.Log ("Governobert");
			if (message == 0) StartIntro (codigosGovernObert[0]);
			else StartContent (codigosGovernObert[message-1]);
		}
		public void StartGovernObert(int value )
	{
			estadoActual[2] = value;
			enableIconosLeyenda (IconosTablet1[2], colorPERSONAS,1);
			if(value == codigosGovernObert[0] || value==0){ //Responsables politcs
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[0]);
				writeTextLanguage(0, value);
			}
			if(value == codigosGovernObert[1]){ //estrategia
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[1]);
				writeTextLanguage(0, value);
			}
			if(value == codigosGovernObert[2]){ //web
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[2]);
				writeTextLanguage(0, value);
			}
			if(value == codigosGovernObert[3]){ //respostes publiques
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[3]);
				writeTextLanguage(0, value);
			}
			if(value == codigosGovernObert[4]){ //arxiu municipal
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[4]);
				writeTextLanguage(0, value);
			}
			if(value == codigosGovernObert[5]){ //portal transparencia
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[5]);
				writeTextLanguage(0, value);
			}
			if(value == codigosGovernObert[6]){ //acces informacion
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[6]);
				writeTextLanguage(0, value);
			}
			if(value == codigosGovernObert[7]){ //presupost obert
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[7]);
				writeTextLanguage(0, value);
			}
			if(value == codigosGovernObert[8]){ //procesos participatius
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[8]);
				writeTextLanguage(0, value);
			}
			if(value == codigosGovernObert[9]){ //dades obertes
				Debug.Log( "Received: GovernObert ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasGovernObert[9]);
				writeTextLanguage(0, value);
			}

			//MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
			//AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
			//mc.colorToChange = colorGovernObert;

			//at.contenido = "GovernOBERT";
			//at.isGrowing = true;
			//Leyendas
			/*
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[4];
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
			*/

			activeTablets [0] = true;


			//Encender capas de municipios
			changeColorMaterialMaquetaAnim (layerMAzonas,colorPERSONAS);
			changeAlphaMaterialMaquetaAnim(layerMAzonas,1);

			//Animaciones lineas maqueta2
			changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
			enableAnimationLayer(1);


	}
		public void oscPromocio(int message)
		{
			Debug.Log (message);
			Debug.Log ("Promocio y ocupacio");
			if (message == 0) StartIntro (codigosPromocioEconomica[0]);
			else StartContent (codigosPromocioEconomica[message-1]);
		}
		public void StartPromocio(int value, int super) //xaloc, poligonos y serveis
	{
			
			if(super==0) {
				estadoActual[2] = value;
				enableIconosLeyenda (IconosTablet1[0], colorPERSONAS,1);
			}
			else{
				enableIconosLeyendaSup (IconosTablet1[0],Color.white,1);
			}
			Debug.Log( "Received: Promocio Economica ");

			if(value == codigosPromocioEconomica[0]  || value==0){ //XALOC
				if(super==0) {
					CleanPoligonos();
					CleanPuntos();
					enableIconosLeyenda (IconosTablet1[2], colorPERSONAS,1);
					changeTextureMaterialMaquetaAnim (layerMAzonas,texturaXaloc);
					//Encender capas de municipios
					changeColorMaterialMaquetaAnim (layerMAzonas,colorPERSONAS);
					changeAlphaMaterialMaquetaAnim(layerMAzonas,1);
					writeTextLanguage(0, value);
				}
				else{
					enableIconosLeyendaSup (IconosTablet1[2],Color.white,1);
					changeTextureMaterialMaqueta (layerZonasSup,texturaXaloc);
					isSuperposicion = true;
					isStartSuperposicion = true;
					writeTextLanguage(1, value);
				}

			}
			if(value == codigosPromocioEconomica[1] ){//poligonos
				if(super==0) {
					enableIconosLeyenda (IconosTablet1[4], colorPERSONAS,1);
					CleanPuntos(); //limpia puntos si no es superposicion
					CleanZonas();
					StartPoligons();
					writeTextLanguage(0, value);
				}
				else{
					enableIconosLeyendaSup (IconosTablet1[4],Color.white,1);
					changeTextureMaterialMaqueta (layerZonasSup,texturaPoligonos);
					isSuperposicion = true;
					isStartSuperposicion = true;
					writeTextLanguage(1, value);
				}
			}
			if(value == codigosPromocioEconomica[2] ){//serveis a empreses

				//NuevosDatos
				if(super==0){
					CleanPoligonos();
					CleanZonas ();
				}
				Debug.Log ("Entra a serveis");
				enableIconosLeyenda (IconosTablet1[0], colorPERSONAS,1);
				MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
				AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
				mc.colorToChange = colorPERSONAS;
				at.contenido = "ServeisEmpresas";
				at.isGrowing = true;

				writeTextLanguage(0, value);
			}

			//Leyendas
			//LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = true;
			activeTablets [0] = true;
			if(super==0){
				//Animaciones maqueta2
				changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
				enableAnimationLayer(1);
			}

	}
		public void oscKm2(int message)
		{
			Debug.Log (message);
			Debug.Log ("Km2");
			if (message == 0) StartIntro (codigosKm2[0]);
			else StartContent (codigosKm2[message-1]);
		}
	public void StartKm2(int value )
	{
		Debug.Log( "Received: Km2 ");
			estadoActual[2] = value;
			enableIconosLeyenda (IconosTablet1[0], colorPERSONAS,1);
			activeTablets [0] = true;
		MarkerControl mc=AnimStarters[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[0].GetComponent<AnimationTrigger>();
		mc.colorToChange = colorKm21;
		at.contenido = "Km2";
		at.isGrowing = true;
		writeTextLanguage(0, value);
			//Animaciones maqueta2
			changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
			enableAnimationLayer(1);

	}
		public void oscPatrimoni(int message)
		{
			Debug.Log (message);
			Debug.Log ("Patrimoni");
			if (message == 0) StartIntro (codigosPatrimoni[0]);
			else StartContent (codigosPatrimoni[message-1]);
		}
	public void StartPatrimoni(int value )
	{
			estadoActual[2] = value;
			enableIconosLeyenda (IconosTablet1[2], colorPERSONAS,1);
			if(value == codigosPatrimoni[0] || value==0){ //iglesias
				Debug.Log( "Received: Patrimoni ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasPatrimonios[0]);
				writeTextLanguage(0, value);
			}
			if(value == codigosPatrimoni[1] ){ //monasterios
				Debug.Log( "Received: Patrimoni ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasPatrimonios[1]);
				writeTextLanguage(0, value);
			}
			if(value == codigosPatrimoni[2]){ //cstillos
				Debug.Log( "Received: Patrimoni ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasPatrimonios[2]);
				writeTextLanguage(0, value);
			}
			if(value == codigosPatrimoni[3]){ //puentes
				Debug.Log( "Received: Patrimoni ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasPatrimonios[3]);
				writeTextLanguage(0, value);
			}
			if(value == codigosPatrimoni[4]){ //Yacimientos
				Debug.Log( "Received: Patrimoni ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasPatrimonios[4]);
				writeTextLanguage(0, value);
			}
			if(value == codigosPatrimoni[5]){ //Otros
				Debug.Log( "Received: Patrimoni ");
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasPatrimonios[5]);
				writeTextLanguage(0, value);
			}


			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[4];
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;

			activeTablets [0] = true;

			//Encender capas de municipios
			changeColorMaterialMaquetaAnim (layerMAzonas,colorPERSONAS);
			changeAlphaMaterialMaquetaAnim(layerMAzonas,1);

			//Animaciones lineas maqueta2
			changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
			enableAnimationLayer(1);
	}

	public void oscOficinaPatrimoni(int message)
	{
		Debug.Log (message);
		Debug.Log ("Patrimoni");
			if (message == 0) StartIntro (codigosOficinaPatrimoni[0]);
			else StartContent (codigosOficinaPatrimoni[message-1]);
	}
	public void StartOficinaPatrimoni(int value )
	{
		estadoActual[2] = value;
			enableIconosLeyenda (IconosTablet1[2], colorPERSONAS,1);
		if(value == codigosOficinaPatrimoni[0] || value==0){ //mapas
			Debug.Log( "Received: OficinaPatrimoni ");
			changeTextureMaterialMaquetaAnim (layerMAzonas,texturasOficinaPatrimoni[0]);
			writeTextLanguage(0, value);
		}
		if(value == codigosOficinaPatrimoni[1] ){ //xarxa archius
			Debug.Log( "Received: OficinaPatrimoni ");
			changeTextureMaterialMaquetaAnim (layerMAzonas,texturasOficinaPatrimoni[1]);
			writeTextLanguage(0, value);
		}
		if(value == codigosOficinaPatrimoni[2]){ //xarxa museus
			Debug.Log( "Received: OficinaPatrimoni ");
			changeTextureMaterialMaquetaAnim (layerMAzonas,texturasOficinaPatrimoni[2]);
			writeTextLanguage(0, value);
		}


		LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[4];
		LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;

		activeTablets [0] = true;

		//Encender capas de municipios
		changeColorMaterialMaquetaAnim (layerMAzonas,colorPERSONAS);
		changeAlphaMaterialMaquetaAnim(layerMAzonas,1);

		//Animaciones lineas maqueta2
		changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
		enableAnimationLayer(1);
	}


	

	//SOSTENIBILIDAD
		public void oscParques(int message)
		{
			Debug.Log (message);
			Debug.Log ("Parques");
			if (message == 0) StartIntro (codigosParques[0]);
			else StartContent (codigosParques[message-1]);
		}
	public void StartParcs(int value )
	{
			estadoActual[2] = value;
			enableIconosLeyenda (IconosTablet1[2], colorSOSTENIBILIDAD,1);
		Debug.Log( "Received: Parcs ");
		LeyendaMarcadorb [0].GetComponent<SpriteRenderer>().enabled = true;
		LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[2];
		LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;
		activeTablets [0] = true;
		isParcs = true;
		isStartParcs = true;
		isEndParcs = false;
		//apagar emisiones
			isEndEmisions=true;

		writeTextLanguage (0, value);

		//Animaciones maqueta2
		changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
		enableAnimationLayer(1);

		/*if (lenguajeTablets [0] == "cat") {
		Titulos[0].text="Àrees dels parcs naturals";
		Subtitulos[0].text="12 Espais naturals";
	} else {
		Titulos [0].text = "Natural Parcs Areas";
		Subtitulos [0].text = "12 Natural spaces";
	}*/

	}
		public void oscXarxa(int message)
		{
			Debug.Log (message);
			Debug.Log ("Xarxa sotenibilidad");
			if (message == 0) StartIntro (codigosXarxaCiutats[0]);
			else StartContent (codigosXarxaCiutats[message-1]);
		}
	public void StartXarxa(int value )
	{
			estadoActual[2] = value;
			enableIconosLeyenda (IconosTablet1[0], colorSOSTENIBILIDAD,1);
		Debug.Log( "Received: Xarxa ");
			//apagar emisiones
			isEndEmisions=true;
		MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();
			activeTablets [1] = true;

			if(value == codigosXarxaCiutats[0] ||value == 0){
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[6];
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorSOSTENIBILIDAD;
				at.contenido = "CambioClimatico";
				at.isGrowing = true;
				writeTextLanguage (0, value);
				/*if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis dins del grup de treball del canvi climàtic i qualitat ambiental ";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities within the working group on climate change and environmental quality";
					Subtitulos [1].text = "";
				}*/

			}
			else if(value == codigosXarxaCiutats[1]){
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[7];
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorSOSTENIBILIDAD;
				at.contenido = "Sostenibilitat";
				at.isGrowing = true;
				writeTextLanguage (0, value);
				/*if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis dins dels grup de treball de sostenibilitat per les persones";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities within the working group on sustainability for people";
					Subtitulos [1].text = "";
				}*/

			}
			else if(value == codigosXarxaCiutats[2]){
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[9];
				LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
				mc.colorToChange = colorSOSTENIBILIDAD;
				at.contenido = "EconomiaCircular";
				at.isGrowing = true;
				writeTextLanguage (0, value);
				/*
				if (lenguajeTablets [1] == "cat") {
					Titulos [1].text = "Municipis dins del grup de treball d’economia circular i verda ";
					Subtitulos [1].text = "";
				} else {
					Titulos [1].text = "Municipalities within the working group of circular and green economy";
					Subtitulos [1].text = "";
				}*/

			}
			//Animaciones lineas maqueta2
			changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
			enableAnimationLayer(1);
		
	}
	public void oscPaes(int message)
	{
		Debug.Log (message);
		Debug.Log ("PAES");
			if (message == 0) StartIntro (codigosPAES[1]);
			else StartContent (codigosPAES[message-1]);
	}
	public void StartEmisions(int value )
	{
			estadoActual[2] = value;
			enableIconosLeyenda (IconosTablet1[2], colorSOSTENIBILIDAD,1);
			CleanPuntos ();
			//LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = true;
			enableIconosCo2();
			//LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().enabled=true;
			//LeyendaMarcadorb [3].GetComponent<SpriteRenderer>().sprite=IconosTablet2[0];

			//LeyendaMarcadorb [1].GetComponent<SpriteRenderer>().enabled=true; //para fechas
			/*LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[0];
			LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled =true;*/
			activeTablets [1] = true;
		Debug.Log( "Received: Emisions ");
			isEmisions = true;
			isStartEmisions = true;
			isEndEmisions = false;
			contEmisions = 0;
			timeLeftEmisions = 1;

			//Animaciones maqueta2
			changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
			enableAnimationLayer(1);

			//writetextfunction
			writeTextLanguage(0, value);


	}

		public void StartPAES(int value )
		{
			//apagar emisiones
			isEndEmisions=true;
			estadoActual[2] = value;


			if(value == codigosPAES[0] || value==0){ //PAES
				enableIconosLeyenda (IconosTablet1[2], colorSOSTENIBILIDAD,1);
				Debug.Log( "Received: Emisions ");
				StartEmisions (value);
				//changeTextureMaterialMaquetaAnim (layerMAzonas,texturasOficinaPatrimoni[0]);
				writeTextLanguage(0, value);
			}
			if(value == codigosPAES[1] ){ //paes
				Debug.Log( "Received: Paes ");
				CleanZonas ();
				enableIconosLeyenda (IconosTablet1[0], colorSOSTENIBILIDAD,1);
				disableIconosExplicativos();
				MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
				AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();
				mc.colorToChange = colorSOSTENIBILIDAD;
				at.contenido = "GestionContabilidad";
				at.isGrowing = true;
				writeTextLanguage(0, value);
			}
			if(value == codigosPAES[2]){ //calor
				CleanPuntos();
				enableIconosLeyenda (IconosTablet1[2], colorSOSTENIBILIDAD,1);
				Debug.Log( "Received: Paes calor ");
				//activar leyenda
				//enableIconosPaes();
				//changeTexturaIconosPaes ();
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasPAES[0]);
				enableIconosExplicativos(IconosTablet2[1]);
				writeTextLanguage(0, value);
				//Encender capas de municipios
				changeColorMaterialMaquetaAnim (layerMAzonas,Color.white);
				changeAlphaMaterialMaquetaAnim(layerMAzonas,1);
			}
			if(value == codigosPAES[3]){ //sequeras
				CleanPuntos();
				Debug.Log( "Received: Paes sequeras ");
				enableIconosLeyenda (IconosTablet1[2], colorSOSTENIBILIDAD,1);
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasPAES[1]);
				enableIconosExplicativos(IconosTablet2[2]);
				writeTextLanguage(0, value);
				//Encender capas de municipios
				changeColorMaterialMaquetaAnim (layerMAzonas,Color.white);
				changeAlphaMaterialMaquetaAnim(layerMAzonas,1);
			}
			if(value == codigosPAES[4]){ //bosques
				CleanPuntos();
				Debug.Log( "Received: Paes boscos ");
				enableIconosLeyenda (IconosTablet1[2], colorSOSTENIBILIDAD,1);
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasPAES[2]);
				enableIconosExplicativos(IconosTablet2[3]);
				writeTextLanguage(0, value);
				//Encender capas de municipios
				changeColorMaterialMaquetaAnim (layerMAzonas,Color.white);
				changeAlphaMaterialMaquetaAnim(layerMAzonas,1);
			}


			//LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().sprite = IconosTablet1[4];
			//LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = true;

			activeTablets [0] = true;



			//Animaciones lineas maqueta2
			changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
			enableAnimationLayer(1);
		}

		public void oscRenovables(int message)
		{
			Debug.Log (message);
			Debug.Log ("Renovables");
			if (message == 0) StartIntro (codigosRenovables[0]);
			else StartContent (codigosRenovables[message-1]);
		}


		public void StartRenovables(int value )
	{
			
		Debug.Log( "Received: Renovables ");
			estadoActual[2] = value;
			enableIconosLeyenda (IconosTablet1[2], colorSOSTENIBILIDAD,1);
			//apagar emisiones
			isEndEmisions=true;
		//MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
		//AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();
		
			//LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().sprite = IconosTablet2[1];
			//LeyendaMarcadorc [1].GetComponent<SpriteRenderer>().enabled = true;
			activeTablets [1] = true;
			/*if (value == 0) {
				mc.colorToChange = colorRenovables;
				LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorRenovables;
				at.contenido = "Renovables";
				at.isGrowing = true;
				if (lenguajeTablets [1] == 0) {
					Titulos[1].text="Renovables";
					Subtitulos[1].text=" ";
				} else {
					Titulos [1].text = "Renewables";
					Subtitulos [1].text = "";
				}

			}*/
			if(value == codigosRenovables[0] || value==0){
				/*mc.colorToChange = colorSOSTENIBILIDAD;
				at.contenido = "CalderesBiomasa";
				at.isGrowing = true;
				writeTextLanguage(0, value);*/
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasRenovables[0]);
				writeTextLanguage(0, value);


			}
			else if(value == codigosRenovables[1]){
				/*mc.colorToChange = colorSOSTENIBILIDAD;
				at.contenido = "FotovoltaiquesAuto";
				at.isGrowing = true;*/
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasRenovables[1]);
				writeTextLanguage(0, value);


			}
			else if(value == codigosRenovables[2]){
				/*mc.colorToChange = colorSOSTENIBILIDAD;
				at.contenido = "FotovoltaiquesVenta";
				at.isGrowing = true;*/
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasRenovables[2]);
				writeTextLanguage(0, value);

			}

			//Encender capas de municipios
			changeColorMaterialMaquetaAnim (layerMAzonas,colorSOSTENIBILIDAD);
			changeAlphaMaterialMaquetaAnim(layerMAzonas,1);
			//Animaciones lineas maqueta2
			changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
			enableAnimationLayer(1);
	}

		/*public void oscMesura(int message)
		{
			Debug.Log (message);
			Debug.Log ("Evaluacion y gestion mesura");
			if (message == 0) StartIntro (codigosEvaluacio[0]);
			else StartContent (codigosEvaluacio[message-1]);
		}*/

		public void StartMesura(int value ) //NO VA ESTE AÑO?  VA EN EVALUACIO
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
			writeTextLanguage(0, value);
			if (lenguajeTablets [1] == 0) {
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

	public void oscEvaluacio(int message) //ANTIGUO OTAGA
	{
		Debug.Log (message);
		Debug.Log ("Evaluacion y gestion mesura");
		if (message == 0) StartIntro (codigosEvaluacio[0]);
		else StartContent (codigosEvaluacio[message-1]);
	}
		public void StartOTAGA(int value )
	{
		Debug.Log( "Received: OTAGA ");
		estadoActual[2] = value;
		enableIconosLeyenda (IconosTablet1[0], colorSOSTENIBILIDAD,1);
		//apagar emisiones
		isEndEmisions=true;
		MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();
			activeTablets [1] = true;
			
		if(value ==  codigosEvaluacio[0]|| value==0){
			mc.colorToChange = colorOTAGA;
			//LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorOTAGA;
				at.contenido = "AnalisisParticulas";
				at.isGrowing = true;
				writeTextLanguage(0, value);
			}
		else if(value == codigosEvaluacio[1]){
			mc.colorToChange = colorOTAGA;
			//LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorOTAGA;
				at.contenido = "AguaFuentes";
				at.isGrowing = true;
				writeTextLanguage(0, value);

			}
		else if(value == codigosEvaluacio[2]){
			mc.colorToChange = colorOTAGA;
			//LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorOTAGA;
				at.contenido = "MediaSonido";
				at.isGrowing = true;
				writeTextLanguage(0, value);

			}
		//Animaciones lineas maqueta2
		changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
		enableAnimationLayer(1);
	}

	public void oscTurismo(int message)
	{
		Debug.Log (message);
		Debug.Log ("TURISMo");
		if (message == 0) StartIntro (codigosTurismo[0]);
		else StartContent (codigosTurismo[message-1]);
	}
	public void StartTurisme(int value )
	{
		Debug.Log( "Received: Turisme ");
		estadoActual[2] = value;

		//apagar emisiones
		isEndEmisions=true;
			

		if(value ==  codigosTurismo[0]|| value==0){ //turismo sostenible
			enableIconosLeyenda (IconosTablet1[2], colorSOSTENIBILIDAD,1);
			MarkerControl mc=AnimStarters[1].GetComponent<MarkerControl>();
			AnimationTrigger at=AnimStarters[1].GetComponent<AnimationTrigger>();
			isEndTurismo = true;
			activeTablets [1] = true;
			mc.colorToChange = colorSOSTENIBILIDAD;
			//LeyendaMarcador [1].GetComponent<Renderer> ().material.color = colorTurisme;
			writeTextLanguage(0, value);

			at.contenido = "Turisme";
			at.isGrowing = true;
			changeTextureMaterialMaquetaAnim (layerMAzonas,texturasTurismoSostenible[0]);
			//Encender capas de municipios
			//changeColorMaterialMaquetaAnim (layerMAzonas,colorSOSTENIBILIDAD);
			changeAlphaMaterialMaquetaAnim(layerMAzonas,1);
		}
		else if(value == codigosTurismo[1]){
			isEndTurismo = true;
			enableIconosLeyenda (IconosTablet1[5], colorSOSTENIBILIDAD,1);
			CleanPuntos ();
			changeTextureMaterialMaquetaAnim (layerMAzonas,texturasRutasTurismo[0]);
			//Encender capas de municipios
			//changeColorMaterialMaquetaAnim (layerMAzonas,colorSOSTENIBILIDAD);
			changeAlphaMaterialMaquetaAnim(layerMAzonas,1);
			writeTextLanguage(0, value);

		}
		else if(value == codigosTurismo[2]){
			CleanPuntos ();
			isTurismo = true;
			isStartTurismo = true;
			isEndTurismo = false;
			contTurismo = 0;
			timeLeftEmisions = 1;
			enableIconosExplicativos(texturesTurismo[0]);

			//LeyendaMarcadorb [1].GetComponent<SpriteRenderer>().enabled=true; //para fechas
			enableIconosLeyenda (IconosTablet1[2], colorSOSTENIBILIDAD,1);
			writeTextLanguage(0, value);
				//isTurismo = true;

		}

		//Animaciones lineas maqueta2
		changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.58f);
		enableAnimationLayer(1);
	}

		//TECNOLOGIA
	public void oscServei(int message)
	{
		Debug.Log (message);
		Debug.Log ("ServeiGestio");
		if (message == 0) StartIntro (codigosServeisGestio[0]);
		else StartContent (codigosServeisGestio[message-1]);
	}
	public void StartServeiGestio(int value )
	{
		Debug.Log( "Received: ServeiGestio ");
		estadoActual[2] = value;
		enableIconosLeyenda (IconosTablet1[0], colorTECNOLOGIA,1);
		MarkerControl mc=AnimStarters[2].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimStarters[2].GetComponent<AnimationTrigger>();

		activeTablets [2] = true;
			/*if (value == 0) {
				
				mc.colorToChange = colorServeiGestio;
			LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;

				at.contenido = "ServeiGestio";
				at.isGrowing = true;
				Titulos[2].text="ServeiGestio";
				Subtitulos[2].text=" ";
			}*/
		if(value == codigosServeisGestio[0]||value == 0){
				mc.colorToChange = colorServeiGestio;
			//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "AsesoramientoJuridico";
				at.isGrowing = true;
				writeTextLanguage(0, value);

			}
		else if(value == codigosServeisGestio[1]){
				mc.colorToChange = colorServeiGestio;
			//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionInformacion";
				at.isGrowing = true;
				writeTextLanguage(0, value);

			}
		else if(value == codigosServeisGestio[2]){
				mc.colorToChange = colorServeiGestio;
			//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionFormacion";
				at.isGrowing = true;
				writeTextLanguage(0, value);

			}
		else if(value == codigosServeisGestio[3]){
				mc.colorToChange = colorServeiGestio;
			//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "HERMES";
				at.isGrowing = true;
				writeTextLanguage(0, value);

			}
		else if(value == codigosServeisGestio[4]){
				mc.colorToChange = colorServeiGestio;
			//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionContabilidad";
				at.isGrowing = true;
				writeTextLanguage(0, value);
			}
		else if(value == codigosServeisGestio[5]){
				mc.colorToChange = colorServeiGestio;
			//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionPadron";
				at.isGrowing = true;
				writeTextLanguage(0, value);

			}
		else if(value == codigosServeisGestio[6]){
				mc.colorToChange = colorServeiGestio;
			//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "GestionWebs";
				at.isGrowing = true;
				writeTextLanguage(0, value);

			}
		else if(value == codigosServeisGestio[7]){
				mc.colorToChange = colorServeiGestio;
			//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorServeiGestio;
				at.contenido = "MuniApps";
				at.isGrowing = true;
				writeTextLanguage(0, value);

			}

		//Animaciones maqueta2
		changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
		enableAnimationLayer(1);
	}

	public void oscPlataforma(int message)
	{
		Debug.Log (message);
		Debug.Log ("ServeiGestio");
		if (message == 0) StartIntro (codigosPlataformaUrbana[0]);
		else StartContent (codigosPlataformaUrbana[message-1]);
	}
	public void StartPlataforma(int value )
	{
		Debug.Log( "Received: Plataforma ");
		estadoActual[2] = value;
		//enableIconosLeyenda (IconosTablet1[0], colorTECNOLOGIA,1);
			

		//Leyendas
		enableIconosPlataforma ();
		activeTablets [2] = true;
		if(value == codigosPlataformaUrbana[0]||value == 0){
			MarkerControl mc=AnimStarters[2].GetComponent<MarkerControl>();
			AnimationTrigger at=AnimStarters[2].GetComponent<AnimationTrigger>();
			mc.colorToChange = colorTECNOLOGIA;
			at.contenido = "Plataforma";
			at.isGrowing = true;
		}
		/*else if(value == codigosPlataformaUrbana[1]){
			MarkerControl mc=AnimStarters[2].GetComponent<MarkerControl>();
			AnimationTrigger at=AnimStarters[2].GetComponent<AnimationTrigger>();
			mc.colorToChange = colorTECNOLOGIA;
			at.contenido = "Plataforma";
			at.isGrowing = true;

			}*/

			
			//if (lenguajeTablets [2] == 0) {
			//Titulos[2].text="Plataforma Urbana Intel·ligent";
		string tpropia="Plataforma pròpia";
		string tmulti="Plataforma multi-tenant DIBA";
		Titulos [5].text =tpropia;
		Titulos[6].text=tmulti;
		Titulos [7].text = tpropia;
		Titulos[8].text=tmulti;
		Titulos [9].text = tpropia;
		Titulos[10].text=tmulti;
			//Titulos[7].text="Solució híbrida";
				Subtitulos[2].text=" ";
			//} else {
			//Titulos [2].text = "                                                                                                                                          Smart urban platform";
			//Titulos[5].text="Own platform";
			//Titulos[6].text="DIBA multi-tenant platform";
			//Titulos[7].text="Hybrid solution";
				Subtitulos [2].text = "";
			//}*/

		writeTextLanguage(0, value);

			

		//Animaciones maqueta2
		changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
		enableAnimationLayer(1);

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

	public void oscInfraestructuras(int message)
	{
		Debug.Log (message);
		Debug.Log ("Infraestructuras");
		if (message == 0) StartIntro (codigosInfraestructuras[0]);
	else StartContent (codigosInfraestructuras[message-1]);
	}
	public void StartInfraestructures(int value )
	{
		Debug.Log( "Received: Infraestructures ");
		estadoActual[2] = value;
		
			MarkerControl mc=AnimStarters[2].GetComponent<MarkerControl>();
			AnimationTrigger at=AnimStarters[2].GetComponent<AnimationTrigger>();
				activeTablets [2] = true;

				
		if(value == codigosInfraestructuras[0] || value == 0){
				CleanZonas ();
			enableIconosLeyenda (IconosTablet1[0], colorTECNOLOGIA,1);
					//LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = true;
					LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[5];
					LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled = true;
			mc.colorToChange = colorTECNOLOGIA;
			//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorTECNOLOGIA;
					at.contenido = "SITMUN";
					writeTextLanguage(0, value);
					
					at.isGrowing = true;
				}
		else if(value == codigosInfraestructuras[1]){
					//LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = true;
					/*LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[4];
					LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled = true;
			mc.colorToChange = colorTECNOLOGIA;
					//LeyendaMarcador [2].GetComponent<Renderer> ().material.color = colorInfraestructures;
					at.contenido = "Cartografia";
					at.isGrowing = true;*/
				enableIconosLeyenda (IconosTablet1[5], colorTECNOLOGIA,1);
				CleanPuntos ();
				changeTextureMaterialMaquetaAnim (layerMAzonas,texturasInfraestructuras[0]);
				//Encender capas de municipios
				changeColorMaterialMaquetaAnim (layerMAzonas,colorTECNOLOGIA);
				changeAlphaMaterialMaquetaAnim(layerMAzonas,1);
				writeTextLanguage(0, value);
					
					
		}
		//Animaciones maqueta2
		changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.38f);
		enableAnimationLayer(1);
		
	}
	public void StartPoligons( )
	{
		Debug.Log( "Received: Poligons ");
			activeTablets [2] = true;
		CleanZonas ();
			isPolig = true;
			isStartPolig = true;
			isEndPolig = false;
	}
	public void oscFibra(int message)
	{
		Debug.Log (message);
		Debug.Log ("Fibra osc");
		if (message == 0) StartIntro (codigosFibraOptica[0]);
		else StartContent (codigosFibraOptica[message-1]);
	}
public void StartFibra(int value , int sup)
{
	if(sup==0){
			estadoActual[2] = value;
			enableIconosLeyenda (IconosTablet1[5], colorTECNOLOGIA,1);
			//changeColorMaterialMaquetaAnim ();
			Debug.Log( "Received: Fibra ");
			activeTablets [2] = true;
			//LeyendaMarcadorb [2].GetComponent<SpriteRenderer>().enabled = true;
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().sprite = IconosTablet3[6];
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled =true;

			isFibra = true;
			isStartFibra = true;
			isEndFibra = false;

			//Animaciones maqueta2
			changeAlphaMaterialMaquetaAnim(layerMAfronteras,0.19f);
			enableAnimationLayer(1);

			writeTextLanguage(0, value);
	}
	else{
		enableIconosLeyendaSup (IconosTablet1[5], Color.white,1);
		//changeColorMaterialMaquetaAnim ();
		Debug.Log( "Received: Fibra sup ");
		activeTablets [2] = true;

		isFibra = true;
		isStartFibra = true;
		isEndFibra = false;

		writeTextLanguage(1, value);
	}
}


	//Idiomas
	public void oscIdioma1(  int idioma  )
	{
		lenguajeTablets [0] = idioma;
	writeTextLanguage(0,(int)estadoActual[2]);
		Debug.Log( "Received: Lenguaje tablet 0 "  );
	}
	public void oscIdioma2(  int idioma  )
	{
		lenguajeTablets [1] = idioma;
		writeTextLanguage(0,(int)estadoActual[2]);
		Debug.Log( "Received: Lenguaje tablet 1 "  );
	}
	public void oscIdioma3(  int idioma  )
	{
		lenguajeTablets [2] = idioma;
		writeTextLanguage(0,(int)estadoActual[2]);
		Debug.Log( "Received: Lenguaje tablet 2 "  );
	}


	public void IdiomaPersoneseng(  OscMessage message  )
	{
			lenguajeTablets [0] = 2;
		Debug.Log( "Received: Lenguaje personeseng "  );
	}
	public void IdiomaPersonescat(  OscMessage message  )
	{
		lenguajeTablets [0] = 0;
		Debug.Log( "Received: Lenguaje persones cat" );
	}
	public void IdiomaSostenibilitateng(  OscMessage message  )
	{
		lenguajeTablets [1] = 2;
		Debug.Log( "Received: Lenguaje sostenibilitat eng " );
	}
	public void IdiomaSostenibilitatcat(  OscMessage message  )
	{
		lenguajeTablets [1] = 0;
		Debug.Log( "Received: Lenguaje sostenibilitat cat"  );
	}
	public void IdiomaTecnologiaeng(  OscMessage message )
	{
		lenguajeTablets [2] = 2;
		Debug.Log( "Received: Lenguaje Tecnologia eng"  );
	}
	public void IdiomaTecnologiacat(  OscMessage message )
	{
		lenguajeTablets [2] = 0;
		Debug.Log( "Received: Lenguaje Tecnologia cat"  );
	}

	//Limpiadores
public void Clean1osc(OscMessage m){
			Clean1 (0);
}
public void CleanPuntos()//OscMessage message
{
	MarkerControl mc=AnimFinishers[0].GetComponent<MarkerControl>();
	AnimationTrigger at=AnimFinishers[0].GetComponent<AnimationTrigger>();
	mc.colorToChange = Color.white;
	at.isGrowing = true;

	MarkerControl mc1=AnimFinishers[1].GetComponent<MarkerControl>();
	AnimationTrigger at1=AnimFinishers[1].GetComponent<AnimationTrigger>();
	mc1.colorToChange = Color.white;
	at1.isGrowing = true;

	MarkerControl mc2=AnimFinishers[2].GetComponent<MarkerControl>();
	AnimationTrigger at2=AnimFinishers[2].GetComponent<AnimationTrigger>();
	mc2.colorToChange = Color.white;
	at2.isGrowing = true;
}
public void CleanVideoMapping()//OscMessage message
{
	changeAlphaVideoMaqueta(layerVideoMapping,0);
	videoPlayerMapping.Stop();//video de mapping extra (bibliobuses, fibra optica,etc)
}
public void CleanTitulos()//OscMessage message
{
	for (int i = 0; i < Titulos.Length; i++)
	{
		Titulos [i].text = "";
	}
}

public void CleanSubtitulos()//OscMessage message
{
	for (int i = 0; i < Subtitulos.Length; i++)
	{
		Subtitulos [i].text = "";
	}
}

public void CleanPoligonos()//OscMessage message
{
	isEndPolig = true;
}
public void CleanZonas()//OscMessage message
{
	changeAlphaMaterialMaquetaAnim(layerMAzonas,0);
}

public void Clean1(int value)//OscMessage message
    {
            Debug.Log("Received: Clean1 ");// + message );
        //Limpiar contornos
		
		
        
        //limpiar animaciones
	changeAlphaVideoMaqueta(layerVideoMapping,0);
	videoPlayerMapping.Stop();//video de mapping extra (bibliobuses, fibra optica,etc)
		enableAnimationLayer(0);
			//isEmisions = false;
		isEndEmisions=true;
		isEndFibra = true;
		isEndPolig = true;
			isEndTurismo = true;
			isEndSuperposicion = true;
		//changeAlphaMaterialMaquetaAnim(layerMAfronteras,0);
	changeAlphaMaterialMaqueta (layerMunicipiosSolos, 0);
	//limpiar iconos
	enableIconosLeyenda (IconosTablet1[0], colorPERSONAS,0); 
	//Limpiar leyendas
	CleanTitulos();
			disableIconosExplicativos ();
			disableIconosPlataforma ();

        

		MarkerControl mc=AnimFinishers[0].GetComponent<MarkerControl>();
		AnimationTrigger at=AnimFinishers[0].GetComponent<AnimationTrigger>();
			mc.colorToChange = Color.white;
		at.isGrowing = true;

	MarkerControl mc1=AnimFinishers[1].GetComponent<MarkerControl>();
	AnimationTrigger at1=AnimFinishers[1].GetComponent<AnimationTrigger>();
	mc1.colorToChange = Color.white;
	at1.isGrowing = true;

	MarkerControl mc2=AnimFinishers[2].GetComponent<MarkerControl>();
	AnimationTrigger at2=AnimFinishers[2].GetComponent<AnimationTrigger>();
	mc2.colorToChange = Color.white;
	at2.isGrowing = true;

		//Control parques SIEMPRE???
			isEndParcs=true;
			activeTablets [0] = false;
			
			//LeyendaMarcador [0].GetComponent<MeshRenderer> ().enabled = false;
			LeyendaMarcadorb [0].GetComponent<SpriteRenderer>().enabled = false;
			LeyendaMarcadorc [0].GetComponent<SpriteRenderer>().enabled = false;

			activeTablets [1] = false;
			Titulos [1].text = "";
			Titulos [3].text = "";
			Titulos [4].text = "";
			Subtitulos [0].text = "";
			Subtitulos [1].text = "";
			Subtitulos [2].text = "";
			
			LeyendaMarcadorb [4].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [5].GetComponent<SpriteRenderer> ().enabled = false;

			activeTablets [2] = false;
			Titulos [2].text = "";
			Titulos[5].text="";
			Titulos[6].text="";
			Titulos[7].text="";
			Titulos[8].text="";
			Titulos [9].text = "";
			Titulos[10].text="";
					
			//LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = false;
			LeyendaMarcadorb [2].GetComponent<SpriteRenderer>().enabled = false;
			LeyendaMarcadorc [2].GetComponent<SpriteRenderer>().enabled = false;

			LeyendaMarcadorb [6].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [7].GetComponent<SpriteRenderer> ().enabled = false;
			LeyendaMarcadorb [8].GetComponent<SpriteRenderer> ().enabled = false;

		changeAlphaMaterialMaqueta(layerMunicipios, 0);
		changeAlphaMaterialMaqueta(layerVideoMapping,0);
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
			//LeyendaMarcador [1].GetComponent<MeshRenderer> ().enabled = false;
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
			//LeyendaMarcador [2].GetComponent<MeshRenderer> ().enabled = false;
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

public struct Leyenda {
	public int codigo;
	public int codigoPadre;
	public string leyenda_esp;
	public string leyenda_ing;
	public string leyenda_cat;
}

}
}//END NAMESPACE
