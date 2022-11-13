using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemScript : MonoBehaviour
{
    private int amountOfPlayers;
    public string player1Name;
    public string player2Name;
    public GameObject menuScreen;
    public GameObject gameScreen;
    public GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        amountOfPlayers=1;
        player1Name="player1";
        player2Name="player2";
    }

    public void getPlayer1Name(string name){
        player1Name=name;
    }

    public void getPlayer2Name(string name){
        player2Name=name;
        amountOfPlayers=2;
    }

    public void startGame(){
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
}
