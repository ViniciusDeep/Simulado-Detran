using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour {

    public int idTema;

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text InfoResposta;

    public string[] perguntas;      //ARMAZENA TODAS AS PERGUNTAS
    public string[] alternativaA; //ARMAZENA TODAS AS ALTERNATIVAS A   
    public string[] alternativaB; //ARMAZENA TODAS AS ALTERNATIVAS B
    public string[] alternativaC;   //ARMAZENA TODAS AS ALTERNATIVAS C
    public string[] alternativaD; //ARMAZENA TODAS AS ALTERNATIVAS D
    public string[] corretas; //ARMAZENA CORRETAS
   

    private int idPergunta;

    private float acertos;
    private float questoes;
    private float media;
    private int notaFinal;


    void Start () {
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        questoes = perguntas.Length;
        
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];

        InfoResposta.text = "Respondendo " + (idPergunta + 1).ToString() + "/" + questoes.ToString() + " Perguntas.";

    }
	
    public void resposta(string alternativa){
        if (alternativa == "A") {
            //EXECUTA O COMANDO PARA RESPOSTA A
            if(alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "B") {
            //EXECUTA O COMANDO PARA RESPOSTA B
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "C"){
            //EXECUTA O COMANDO PARA RESPOSTA C
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

        else if (alternativa == "D")
        {
            //EXECUTA O COMANDO PARA RESPOSTA D
            if (alternativaD[idPergunta] == corretas[idPergunta]){
                acertos += 1;
            }
        }

        proximaPergunta();
    }

    void proximaPergunta(){
        idPergunta +=1;


        if(idPergunta <= (questoes-1))
        {
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];

            InfoResposta.text = "Respondendo " + (idPergunta + 1).ToString() + "/" + questoes.ToString() + " Perguntas.";
             
        }
        else
        {
            
            media = 10 * (acertos / questoes);

            notaFinal = Mathf.RoundToInt(media);

            if (notaFinal > PlayerPrefs.GetInt("notaFinal"+idTema.ToString()))
            {
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int) acertos);
            }
            
            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);


            SceneManager.LoadScene("notaFinal");
        }

       
    }
		
}
