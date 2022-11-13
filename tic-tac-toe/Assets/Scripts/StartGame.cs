using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private bool player1turn;
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
        player1turn= (playerTurn==1);
        player1Text.text = "Player1: "+ system.GetComponent<SystemScript>().player1Name +" X";
        player2Text.text = "Player2: "+ system.GetComponent<SystemScript>().player2Name +" O";
    }

    public void advance(){
        player1turn=!player1turn;
        if(computerPlaying && !player1turn){
            computerPlay();
        }
    }

    public bool isPlayer1Turn(){
        return player1turn;
    }

    public void finnishGame(int player){
        system.GetComponent<SystemScript>().finnishGame(player);
    }

    private void computerPlay(){
        int choose =0;
        GameObject button;
        for(int i=0; i<9;i++){
            button= gridButtons[i];
            if(button.GetComponent<Button>().interactable == true){
                if(i==8){
                    button.GetComponent<GridButton>().onClick();
                    break;
                }else{
                    choose= Random.Range(0,2);
                    if(choose==1){
                        button.GetComponent<GridButton>().onClick();
                        break;
                    }
                }
            }
        }
    }
}
