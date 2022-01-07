using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static Perguntas perguntas;
    public int valorMin=1;
    public int valorMax=4;
    public int fase;
    public string fasee;
    public List <int> fasesFeitas =new List <int>();
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
    
    public Text[] questao;
    public int[] nQuestao;


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
        fase=PlayerPrefs.GetInt("fase");
        ShowTotalScore();
        
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
   /* public int FasesFeitas(){
        if(Mathf.Abs(valorMax-valorMin)>fasesFeitas.Count){
            while (true){
                fase=Random.Range(valorMin,valorMax);
                fasee=fase.ToString();
                if (!fasesFeitas.Contains (fase)){
                    fasesFeitas.Add(fase);
                    return fase;
                    
                }
            }
            
        }else{
             ShowGame.SetActive(true);
            return 0;
        }
        

    }*/

    public void MostrarCorrecao(){
        Correcao.SetActive(true);
     
    
    }
    
    public void MostrarPontos(){
        ShowGame.SetActive(true);
        SetPoints();
        ShowTotalScore();
       
        segundos-=Time.deltaTime;
        Destroy(segundosText);
       
    }
     public void MudaPergunta(){
         for (int i=0;i<questao.Length; i++){
            if(PlayerPrefs.GetInt(i.ToString())==0){
                questao[i].text="Nova Pergunta";


            }else{
               
            }
        }
        
    }
      public void VoltarProJogo(){
        ShowGame.SetActive(false);
        Correcao.SetActive(false);
        MudaPergunta();
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
