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

    // Start is called before the first frame update
    void Start()
    {
        computerPlaying = system.GetComponent<SystemScript>().isComputerPlaying();
        Debug.Log(computerPlaying);
        gridButtons = GameObject.FindGameObjectsWithTag("GridButton");
        int playerTurn = Random.Range(1,3);
        player1Turn= (playerTurn==1);
        player1Text.text = "Player1: "+ system.GetComponent<SystemScript>().player1Name +" X";
        player2Text.text = "Player2: "+ system.GetComponent<SystemScript>().player2Name +" O";
        if(!player1Turn && computerPlaying){
            computerPlay();
        }
    }

    public void advance(){
        player1Turn=!player1Turn;
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
        int choose =0;
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
        for(int j=0; j<currentSize;j++){
            if(j==currentSize){
                freeGrids[j].GetComponent<GridButton>().onClick();
                break;
            }else{
                choose= Random.Range(0,2);
                if(choose==1){
                    freeGrids[j].GetComponent<GridButton>().onClick();
                    break;
                }
            }
        }
    }
}
