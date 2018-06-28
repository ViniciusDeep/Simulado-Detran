using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class temaJogo : MonoBehaviour {


    public Button       btnPlay;
    public Text         txtNomeTema;
    public Text         txtInfoTema;

    //public GameObject   infoTema;
    public GameObject         InfoTema;
    public string[]     nomeTema;
    public int          numeroQuestoes;

    private int          idTema;


    void Start () {
        
        idTema = 0;
        txtNomeTema.text = nomeTema[idTema];
        txtInfoTema.text ="Você acertou X de X questões!";
        InfoTema.SetActive(false);
        //txtInfoTema.text = "";
        //btnPlay.interactable = false;
    }
	
	public void selecioneTema(int i)
    {
        idTema = i;
        PlayerPrefs.SetInt("idTema", idTema);
        int notaFinal = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());
        int acertos = PlayerPrefs.GetInt("acertos" + idTema.ToString());


        txtNomeTema.text = nomeTema[i];
        txtInfoTema.text = "Você acertou "+acertos.ToString()+ " de " + numeroQuestoes.ToString() + " questões";
        InfoTema.SetActive(true);
       // btnPlay.interactable = true; 

    }
	
    public void jogar()
    {
        SceneManager.LoadScene("T" + idTema.ToString());
    }

    

}
