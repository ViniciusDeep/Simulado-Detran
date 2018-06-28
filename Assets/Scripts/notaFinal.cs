using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class notaFinal : MonoBehaviour
{
    private int idTema;

    public Text txtNota;
    public Text txtInfoTema;

    private int notaF;
    private int acertos;

    void Start()
    {
        idTema = PlayerPrefs.GetInt("idTema");
        notaF = PlayerPrefs.GetInt("notaFinalTemp" + idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + idTema.ToString());
       
        txtNota.text = notaF.ToString();
        txtInfoTema.text = "Você acertou "+acertos.ToString() + " de 30 perguntas";          
    }

    public void jogar()
    {
        SceneManager.LoadScene("T" + idTema.ToString());
    }
}