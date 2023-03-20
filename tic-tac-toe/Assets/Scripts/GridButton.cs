using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour
{
    public GameObject system;
    public GameObject gameScreen;
    public Button button;
    public Text buttonText;
    public int coluna;
    public int linha;

    public void onClick(){
        int player =0;
        if(gameScreen.GetComponent<StartGame>().isPlayer1Turn()){
            player =1;
            buttonText.text = "X";
        }else{
            buttonText.text = "O";
            player =2;
        }
        button.interactable = false;
        system.GetComponent<SystemScript>().updatePoints(player, this.gameObject);
        if(!gameScreen.GetComponent<GameScore>().isGameOver()){
            gameScreen.GetComponent<StartGame>().advance();
        }
    }
       
}
