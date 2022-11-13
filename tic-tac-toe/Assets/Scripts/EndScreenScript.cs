using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    public void displayWinner(string winner){
        if(winner == null){
            text.text= "DRAW";
        }else{
            text.text = "Player "+ winner +" wins!";
        }
    }
}
