using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int fase;
    public string fasee;
    public int points ;
    public int totalScore;
    public Text pointer;
    public static GameController gameController;
    private float segundos=30;
    private int segundosToInt;
    public Text segundosText;
    
    public GameObject Correcao;
    public GameObject ShowGame;
    public static GameController instance;
    public GameObject  player;


    // Start is called before the first frame update
    void Start()
    {
         totalScore=PlayerPrefs.GetInt("totalScore");
        if(gameController==null){
            gameController=this;    
        }
        else if(gameController !=this){
            Destroy(gameObject);
        }
        instance = this;
        
        ShowTotalScore();
        fase=Random.Range(1,3);
        fasee=fase.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Contador();
    }
    public void NextLevel(string lvlName){
     SceneManager.LoadScene(lvlName);

    }
    public void NextFase(){
        SceneManager.LoadScene(fasee);
    }
    public void MostrarCorrecao(){
        Correcao.SetActive(true);
        Destroy(player);
    
    }
    public void MostrarPontos(){
        ShowGame.SetActive(true);
        SetPoints();
        ShowTotalScore();
        Destroy(player);
        segundos-=Time.deltaTime;
        Destroy(segundosText);
       
    }
     public void SetPoints(){
        points++;
        pointer.text=points.ToString();
        PlayerPrefs.SetInt("totalScore", totalScore);
        totalScore++;
        PlayerPrefs.Save();
     }
     public int GetPoints(){
        return points;
        
        
    }
    public void ShowTotalScore(){
        
        pointer.text=totalScore.ToString();
      
        

      
    }
    public void Contador(){
        segundos-=Time.deltaTime;
        segundosToInt=(int)segundos;
        segundosText.text=segundosToInt.ToString();
        if(segundos<=0){
            MostrarCorrecao();
            Destroy(segundosText);
        }
      
    }

}
