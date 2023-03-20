using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTypeButton : MonoBehaviour
{
    public int totalPlayers;
    public GameObject menuScreen;

    public void onClick(){
        menuScreen.GetComponent<PrepareGame>().setPlayerAmount(totalPlayers);
    }
}
