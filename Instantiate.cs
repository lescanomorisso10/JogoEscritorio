using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    Loja loja;
    public GameObject [] personagens;
    public GameObject inicialPos;
    
    // Start is called before the first frame update
    void Start()
    {
        loja=GameObject.FindObjectOfType<Loja>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake(){
        
        
     
        Instantiate(personagens[PlayerPrefs.GetInt("personagem")],transform.position,Quaternion.identity);
        
    }
}
