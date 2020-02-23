using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuentaAtras : MonoBehaviour
{
    public GameObject motorCarreteaGO;
    public MotorCarretera motorCarretaScript;
    public Sprite[] sprt;

    public GameObject contadorNumerosGO;
    public SpriteRenderer contadorNumerosComp;

    public GameObject controladorCocheGO;
    public GameObject cocheGO;

    void Start()
    {
        InicioComponentes();
    }

    void InicioComponentes()
    {
        motorCarreteaGO = GameObject.Find("motoCarretera");
        motorCarretaScript = motorCarreteaGO.GetComponent<MotorCarretera>();

        contadorNumerosGO = GameObject.Find("Numeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

        cocheGO = GameObject.Find("Coche");
        controladorCocheGO = GameObject.Find("ControladorCoche");

        InicioCuentaAtras();

    }

    void InicioCuentaAtras()
    {
        StartCoroutine(Contando());
    }

   

    IEnumerator Contando()
    {
        contadorNumerosGO.GetComponent<AudioSource>().Stop();
        this.gameObject.GetComponent<AudioSource>().Stop();

        controladorCocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3);

        contadorNumerosComp.sprite = sprt[1];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = sprt[2];
        this.gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);

        contadorNumerosComp.sprite = sprt[3];
        motorCarretaScript.setInicioJuego(true);
        contadorNumerosGO.GetComponent<AudioSource>().Play();
        cocheGO.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);

        contadorNumerosGO.SetActive(false);

    }

    void Update()
    {
        
    }
}
