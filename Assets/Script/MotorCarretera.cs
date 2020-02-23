using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarretera : MonoBehaviour
{
    public GameObject contenedorCalleGO;
    public GameObject[] contenedorCallesArray;
    public GameObject calleAnterior;
    public GameObject calleNueva;
    public GameObject mCamGO;
    public Camera cameera;

    private float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;
    public float sizeStreet = 0;
    public bool salidaPantalla;

    public Vector2 medidaLimitePantalla;

    int contador = 0;
    int numeroSelectorCalles;

   

    void Start()
    {

        InicioJuego();
    }

    void Update()
    {
        if (inicioJuego == true && juegoTerminado == false)
        {
            transform.Translate(Vector2.down * getVelocidadMotor() * Time.deltaTime);

            if (calleAnterior.transform.position.y + sizeStreet < medidaLimitePantalla.y && salidaPantalla == false)
            {
                salidaPantalla = true;
                Destruyocalles();
            }
        }

    }

    public void setJuegoTerminado(bool n)
    {
        this.juegoTerminado = n;
    }

    public void setInicioJuego(bool n)
    {
        this.inicioJuego = n;
    }

    public bool getInicioJuego()
    {
        return inicioJuego;
    }

    public bool getJuegoTerminado()
    {
        return juegoTerminado;
    }

    void InicioJuego()
    {
        contenedorCalleGO = GameObject.Find("ContenedorCalles");
        mCamGO = GameObject.Find("MainCamera");
        cameera = mCamGO.GetComponent<Camera>();
        getVelocidadMotor();
        buscoCalles();
    }

    public float getVelocidadMotor()
    {
        
         return velocidad = 18f;
    }

    void buscoCalles()
    {
        contenedorCallesArray = GameObject.FindGameObjectsWithTag("calle");

        for(int i = 0; i < contenedorCallesArray.Length; i++)
        {
            contenedorCallesArray[i].gameObject.transform.parent = contenedorCalleGO.transform;
            contenedorCallesArray[i].gameObject.SetActive(false);
            contenedorCallesArray[i].gameObject.name = " CalleOFF_" + i;
        }

        CrearCalles();
    }

    void CrearCalles()
    {
        contador++;
        numeroSelectorCalles = Random.Range(0, contenedorCallesArray.Length);

        GameObject Calle = Instantiate(contenedorCallesArray[numeroSelectorCalles]);
        Calle.gameObject.SetActive(true);
        Calle.name = "Calle" + contador;
        Calle.transform.parent = this.gameObject.transform;
        calleAnterior = GameObject.Find("Calle" + (contador - 1));
        calleNueva = GameObject.Find("Calle" + contador);


        PosicionoCalles();
    }

    void PosicionoCalles()
    {
        
        MidoCalle();
        calleNueva.transform.position = new Vector2(calleAnterior.transform.position.x, (calleAnterior.transform.position.y + sizeStreet));

        salidaPantalla = false;
    }

    void MidoCalle()
    {
        for(int i = 1; i < calleAnterior.transform.childCount; i++)
        {
            if(calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float tamanoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                sizeStreet = sizeStreet + tamanoPieza;
                Debug.Log(sizeStreet);
            }
           
        }
    }

    void MedirPantalla()
    {
        medidaLimitePantalla = new Vector2(0,cameera.ScreenToWorldPoint(new Vector2(0,0)).y - 0.5f);
    }

    

    void Destruyocalles()
    {
        Destroy(calleAnterior);
        sizeStreet = 0;
        calleAnterior = null;
        CrearCalles();
    }
}


