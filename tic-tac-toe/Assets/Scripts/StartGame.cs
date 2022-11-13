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
    // Start is called before the first frame update
    void Start()
    {
        int playerTurn = Random.Range(1,3);
        player1turn= (playerTurn==1);
        player1Text.text = "Player1: "+ system.GetComponent<SystemScript>().player1Name +" X";
        player2Text.text = "Player2: "+ system.GetComponent<SystemScript>().player2Name +" O";
    }

    // Update is called once per frame
    public void advance(){
        player1turn=!player1turn;
    }

    public bool isPlayer1Turn(){
        return player1turn;
    }

    public void finnishGame(int player){
        system.GetComponent<SystemScript>().finnishGame(player);
    }
}
