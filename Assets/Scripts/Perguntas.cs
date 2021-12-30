using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perguntas : MonoBehaviour
{

    // Start is called before the first frame update
    public  GameObject pergunta1;
    public  GameObject pergunta2;
    public static Perguntas perguntas;
    public bool pergunta;
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void Resposta1(){
        pergunta=true;
        GameController.gameController.MostrarPontos();

    }
    public void Resposta2(){
        pergunta=false;
    }
}
