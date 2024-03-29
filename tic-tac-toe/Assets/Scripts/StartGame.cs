using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private bool player1Turn;
    public Text player1Text;
    public Text player2Text;
    public GameObject system;
    private bool computerPlaying;
    private GameObject[] gridButtons;
    private bool isEasyMode;

    // Start is called before the first frame update
    void Start()
    {
        computerPlaying = system.GetComponent<SystemScript>().isComputerPlaying();
        gridButtons = GameObject.FindGameObjectsWithTag("GridButton");
        isEasyMode = system.GetComponent<SystemScript>().isInEasyMode();
        int playerTurn = Random.Range(1,3);
        player1Turn= (playerTurn==1);
        changeNameColors();
        player1Text.text = "Player1: "+ system.GetComponent<SystemScript>().player1Name +" X";
        player2Text.text = "Player2: "+ system.GetComponent<SystemScript>().player2Name +" O";
        if(!player1Turn && computerPlaying){
            computerPlay();
        }
    }

    public void advance(){
        player1Turn=!player1Turn;
        changeNameColors();
        if(computerPlaying && !player1Turn){
            computerPlay();
        }
    }

    public bool isPlayer1Turn(){
        return player1Turn;
    }

    public void finnishGame(int player){
        system.GetComponent<SystemScript>().finnishGame(player);
    }

    private void computerPlay(){
        GameObject button;
        GameObject[] freeGrids = new GameObject[9];
        int currentSize=0;
        for(int i=0; i<9;i++){
            button= gridButtons[i];
            if(button.GetComponent<Button>().interactable == true){
                freeGrids[currentSize] =button;
                currentSize++;
            }
        }
        
        if(isEasyMode){
            stupidPlay(freeGrids, currentSize);
        }else{
            notSoStupidPlay();
        }
    }

    private void stupidPlay(GameObject[] freeGrids, int amount){
        int choose =0;
        for(int j=0; j<amount;j++){
            if(freeGrids[j] == null){
                break;
            }
            if(j==amount-1 ){
                freeGrids[j].GetComponent<GridButton>().onClick();
                break;
            }else{
                choose= Random.Range(0,1);
                if(choose==0){
                    freeGrids[j].GetComponent<GridButton>().onClick();
                    break;
                }
            }
        }
    }

    private void notSoStupidPlay(){

    }

    private void changeNameColors(){
        if(player1Turn){
            player1Text.color = Color.blue;
            player2Text.color = Color.white;
        }else{
            player2Text.color = Color.blue;
            player1Text.color = Color.white;
        }
    }
}
