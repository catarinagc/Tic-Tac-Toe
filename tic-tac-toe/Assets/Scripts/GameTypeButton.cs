using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTypeButton : MonoBehaviour
{
    public GameObject player1name;
    public GameObject player2name;
    public GameObject otherNameButton;
    public GameObject startButton;
    public int totalPlayers;


    public void onClick(){
        if(totalPlayers==2){
            player2name.SetActive(true);
        }
        player1name.SetActive(true);
        startButton.SetActive(true);
        Destroy(otherNameButton);
        Destroy(this.gameObject);
    }
}
