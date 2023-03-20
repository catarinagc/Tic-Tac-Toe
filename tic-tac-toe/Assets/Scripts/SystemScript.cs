using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemScript : MonoBehaviour
{
    private int amountOfPlayers;
    public string player1Name;
    public string player2Name;
    public GameObject menuScreen;
    public GameObject gameScreen;
    public GameObject endScreen;
    public InputField player2NameInputBox;
    private bool isEasyMode;

    // Start is called before the first frame update
    void Start()
    {
        amountOfPlayers=1;
        player1Name="player1";
        player2Name="player2";
        isEasyMode=false;
    }

    public void setPlayer1Name(string name){
        player1Name=name;
    }

    public void setPlayer2Name(string name){
        player2Name=name;
    }

    public void startGame(){
        if(player2NameInputBox.gameObject.activeSelf==true){
            amountOfPlayers=2;
        }
        gameScreen.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void updatePoints(int player, GameObject button){
        gameScreen.GetComponent<GameScore>().updateGame(player, button);
    }

    public void finnishGame(int winner){
        string winnerName = null;
        if(winner==1){
            winnerName = player1Name;
        }else if(winner ==2){
            winnerName = player2Name;
        }
        gameScreen.SetActive(false);
        endScreen.SetActive(true);
        endScreen.GetComponent<EndScreenScript>().displayWinner(winnerName);
    }

    public bool isComputerPlaying(){
        return amountOfPlayers==1;
    }

    public void playInEasyMode(){
        isEasyMode= !isEasyMode;
    }

    public bool isInEasyMode(){
        return isEasyMode;
    }
}
