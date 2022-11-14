using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    // Start is called before the first frame update
    private int freeSpaces;
    private int[,] gameBoard;
    private bool gameOver;
    private int winner;
    public GameObject gameSystem;
    void Start()
    {
        gameBoard = new int[3,3];
        freeSpaces=9;
        winner=0;
        gameOver=false;
        gameSystem=this.gameObject;
    }

    public void updateGame(int player, GameObject button)
    {
        int linha = button.GetComponent<GridButton>().linha;
        int coluna = button.GetComponent<GridButton>().coluna;
        if(player==1){
            gameBoard[linha, coluna] =1;
        }else{
            gameBoard[linha, coluna] =2;
        }
        freeSpaces--;
        if(updatePoints(player)){
            gameSystem.GetComponent<StartGame>().finnishGame(winner);
        }
    }

    private bool updatePoints(int player){
        while(!gameOver){
            for(int i=0; i<3; i++){
                if(gameBoard[i,0] == player && gameBoard[i,0] == gameBoard[i,1] && gameBoard[i,1] == gameBoard[i,2]){
                    gameOver=true;
                    break;
                }
            }
            for(int j=0; j<3; j++){
                if(gameBoard[0,j] == player && gameBoard[0,j] == gameBoard[1,j] && gameBoard[1,j] == gameBoard[2,j]){
                    gameOver=true;
                    break;
                }
            }

            if(gameBoard[0,0]==player && gameBoard[0,0]==gameBoard[1,1] && gameBoard[1,1]==gameBoard[2,2]){
                gameOver=true;
            }

            if(gameBoard[0,2] ==player && gameBoard[0,2]== gameBoard[1,1] && gameBoard[1,1]==gameBoard[2,0]){
                gameOver=true;
            }
            break;
        }
        if(gameOver){
            winner = player;
            return true;
        }else if(freeSpaces==0){
            winner=3;
            return true;
        }
        return false;
    }

    public bool isGameOver(){
        return gameOver;
    }
}
