using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loja : MonoBehaviour
{
    GameController gController;
  
    public Text[] button_txt;
    public int [] preço;
    public GameObject[] personagens;
    public int  numeroButton;
    
    // Start is called before the first frame update
    void Start()
    {
        gController=GameObject.FindObjectOfType<GameController>();
        if(PlayerPrefs.GetInt("0")==0){
            PlayerPrefs.SetInt("0",1);
        }

        gController.points=PlayerPrefs.GetInt("totalScore");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<button_txt.Length; i++){
            if(PlayerPrefs.GetInt(i.ToString())==0){
                button_txt[i].text=preço[i].ToString();


            }else{
                button_txt[i].text="selecionar";
            }
            
            gController.pointer.text=PlayerPrefs.GetInt("totalScore").ToString();
        }
    }
    public void select(int numeroButton){
        if(PlayerPrefs.GetInt(numeroButton.ToString())==0){
            if(gController.totalScore>=preço[numeroButton]){
                PlayerPrefs.SetInt(numeroButton.ToString(),1);
                PlayerPrefs.Save();
                gController.totalScore-=preço[numeroButton];
                PlayerPrefs.SetInt("totalScore", gController.totalScore);
                PlayerPrefs.Save();
            }

        }else{
            print("selecionado");
            PlayerPrefs.SetInt("personagem",numeroButton);
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.Save();

        }
    }
}
