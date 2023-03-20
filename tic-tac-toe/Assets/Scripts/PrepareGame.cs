using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareGame : MonoBehaviour
{
    private int totalPlayers;
    public GameObject startButton;
    public GameObject player1NameInput;
    public GameObject player2NameInput;
    public GameObject gameModeButton;
    public GameObject system;
    // Update is called once per frame
    void Update()
    {

    }

    public void setPlayerAmount(int amount){
        totalPlayers=amount;
        if(amount==1){
            gameModeButton.SetActive(true);
            system.GetComponent<SystemScript>().setPlayer2Name("PC");
        }else{
            player2NameInput.SetActive(true);
        }
        player1NameInput.SetActive(true);
        startButton.SetActive(true);
    }

}
