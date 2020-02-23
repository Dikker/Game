using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public GameObject motorCarreteaGO;
    public MotorCarretera motorCarretaScript;
    public Text txtTiempo;
    public Text txtDistancia;

    public float tiempo;
    public float Distancia;


    // Start is called before the first frame update
    void Start()
    {
        motorCarreteaGO = GameObject.Find("motoCarretera");
        motorCarretaScript = motorCarreteaGO.GetComponent<MotorCarretera>();
        txtTiempo.text = "02:00";
        txtDistancia.text = "0";

        tiempo = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (motorCarretaScript.getInicioJuego() == true && motorCarretaScript.getJuegoTerminado() == false )
        {
          CalculoTiempoDistancia();
          if (tiempo <= 0 && motorCarretaScript.getJuegoTerminado() == false)
            {
                motorCarretaScript.setJuegoTerminado(true);
            }
        }

        
        
    }

    void CalculoTiempoDistancia()
    {
        
        Distancia += Time.deltaTime * motorCarretaScript.getVelocidadMotor();
        txtDistancia.text = ((int)Distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo %  60;
        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');

    }
}
