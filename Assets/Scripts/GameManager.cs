using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text textoTimer;
    public TMP_Text textoDerrota;
    public TMP_Text textoMonedas;
    public float timer = 50f;
    public bool estamosJugando = true;
    public Nave nave;
    int cuentaMonedas = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!estamosJugando) return;        
        //if estamosJugando == false
        //Time.deltaTime = al tiempo que pasa entre frames
        timer -= Time.deltaTime;
        // int timerint = (int)timer;
        // textoTimer.text = timerint.ToString();
        // textoTimer.text = ((int)timer).ToString();
        // textoTimer.text = Mathf.Ceil(timer).ToString();
        // textoTimer.text = Mathf.Floor(timer).ToString();
        textoTimer.text = timer.ToString("00");
        if(timer <= 0) 
        {
            estamosJugando = false;
            Debug.Log("Se acabo el tiempo");
            textoDerrota.gameObject.SetActive(true);
            textoTimer.gameObject.SetActive(false);
            StartCoroutine(nave.DestruirNave());
        }
    }

    public void AgregarMoneda() 
    {
        cuentaMonedas++;
        //Debug.Log("Has recolectado " + cuentaMonedas.ToString() + " monedas");
        Debug.Log($"Has recolectado {cuentaMonedas} monedas");
        textoMonedas.text = cuentaMonedas.ToString();
    }
}
