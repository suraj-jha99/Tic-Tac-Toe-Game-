using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Functionality : MonoBehaviour
{
    public GameObject[] cellVal;
    public GameObject[] cellObj;
    public GameObject turnObj;

    //public Button btn;

    //flag var to rep "turn" of players
    //true -> player "x" turn and false -> player "O" turn
    private bool flag = true;
    private int win = 0;


    //make a array of string of size 9 to store cell values
    private string[] arr = new string[9];

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Method is called");

        bool prev = false;

        //check if there is a prev game -> ppref should be empty
        for (int i = 0; i < 9; i++)
        {
            //PlayerPrefs.GetString(System.Convert.ToString(i)) != null
            if (PlayerPrefs.HasKey(System.Convert.ToString(i)))
            {
                Debug.Log("Prefab is not null");
                Debug.Log("value of " + i + " cell is " + PlayerPrefs.GetString(System.Convert.ToString(i)));
                prev = true;
            }
            else
            {
                Debug.Log("prefab is null");
            }
        }


        //there is a prev game
        if (prev)
        {
            Debug.Log("previous game is loaded");

            //update "Turn" of player
            if (PlayerPrefs.GetString("Turn") == "X")
            {
                turnObj.GetComponent<Text>().text = "Player 'X' Turn";
                flag = true;
            }
            else
            {
                turnObj.GetComponent<Text>().text = "Player 'O' Turn";
                flag = false;
            }

            for (int i = 0; i < 9; i++)
            {
                //if cur cell is already filled
                if (PlayerPrefs.HasKey(System.Convert.ToString(i)))
                {
                    cellVal[i].GetComponent<Text>().text = PlayerPrefs.GetString(System.Convert.ToString(i));
                    cellObj[i].GetComponent<Button>().interactable = false;
                }

                else
                {
                    cellVal[i].GetComponent<Text>().text = "";
                    cellObj[i].GetComponent<Button>().interactable = true;
                }


            }

        }

        else // -> there is no prev game
        {
            Debug.Log("There is no previous game");
            NewGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewGame()
    {
        for(int i=0; i<9; i++)
        {
            //PlayerPrefs.SetString(System.Convert.ToString(i), null);
            cellObj[i].GetComponent<Button>().interactable = true;
            cellVal[i].GetComponent<Text>().text = "";
      
        }
        flag = true;
    }

    //rematch fun -> to restart the game
    public void ReStart()
    {
        //reset all 9 button values to "empty string"
        for (int i = 0; i < 9; i++)
        {
            cellVal[i].GetComponent<Text>().text = "";

            //reset ppref values
            //PlayerPrefs.SetString(System.Convert.ToString(i), null);
           
        }

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        //again make buttons clickable 
        for (int i = 0; i < 9; i++)
        {
            cellObj[i].GetComponent<Button>().interactable = true;
        }

        //reset flag back to "x" player turn
        //flag = true;
        
    }

    
    //game over fun -> no more moves can be played by either player
    public void GameOver()
    {

        //make all 9 buttons non-interactable or non-clickable
        for(int i=0; i<9; i++)
        {
            cellObj[i].GetComponent<Button>().interactable = false;
        }

        ReStart();

    }

    //iswin fun
    public void iswin()
    {
        string chr = (flag == true) ? "X" : "O";

        //check 1st row
        if(cellVal[0].GetComponent<Text>().text == chr && cellVal[1].GetComponent<Text>().text == chr
            && cellVal[2].GetComponent<Text>().text == chr)
        {
            turnObj.GetComponent<Text>().text = "Player " + chr + " wins";
            Debug.Log("Player " + chr + " wins");
            win = 1;
            GameOver();
        }

        //check 2nd row
        if (cellVal[3].GetComponent<Text>().text == chr && cellVal[4].GetComponent<Text>().text == chr
            && cellVal[5].GetComponent<Text>().text == chr)
        {
            turnObj.GetComponent<Text>().text = "Player " + chr + " wins";
            Debug.Log("Player " + chr + " wins");
            win = 1;
            GameOver();
        }

        //check 3rd row
        if (cellVal[6].GetComponent<Text>().text == chr && cellVal[7].GetComponent<Text>().text == chr
            && cellVal[8].GetComponent<Text>().text == chr)
        {
            turnObj.GetComponent<Text>().text = "Player " + chr + " wins";
            Debug.Log("Player " + chr + " wins");
            win = 1;
            GameOver();
        }

        //check 1st col
        if (cellVal[0].GetComponent<Text>().text == chr && cellVal[3].GetComponent<Text>().text == chr
            && cellVal[6].GetComponent<Text>().text == chr)
        {
            turnObj.GetComponent<Text>().text = "Player " + chr + " wins";
            Debug.Log("Player " + chr + " wins");
            win = 1;
            GameOver();
        }

        //check 2nd col
        if (cellVal[1].GetComponent<Text>().text == chr && cellVal[4].GetComponent<Text>().text == chr
            && cellVal[7].GetComponent<Text>().text == chr)
        {
            turnObj.GetComponent<Text>().text = "Player " + chr + " wins";
            Debug.Log("Player " + chr + " wins");
            win = 1;
            GameOver();
        }

        //check 3rd col
        if (cellVal[2].GetComponent<Text>().text == chr && cellVal[5].GetComponent<Text>().text == chr
            && cellVal[8].GetComponent<Text>().text == chr)
        {
            turnObj.GetComponent<Text>().text = "Player " + chr + " wins";
            Debug.Log("Player " + chr + " wins");
            win = 1;
            GameOver();
        }

        //check diag 1
        if (cellVal[0].GetComponent<Text>().text == chr && cellVal[4].GetComponent<Text>().text == chr
            && cellVal[8].GetComponent<Text>().text == chr)
        {
            turnObj.GetComponent<Text>().text = "Player " + chr + " wins";
            Debug.Log("Player " + chr + " wins");
            win = 1;
            GameOver();
        }

        //check diag 2
        if (cellVal[2].GetComponent<Text>().text == chr && cellVal[4].GetComponent<Text>().text == chr
            && cellVal[6].GetComponent<Text>().text == chr)
        {
            turnObj.GetComponent<Text>().text = "Player " + chr + " wins";
            Debug.Log("Player " + chr + " wins");
            win = 1;
            GameOver();
        }



    }
    //fun to update the value of cell when players marks it as "x" or "O"
    public void OnClick(int CellNum)
    {
        //make cur cell as non intercatable -> so that a player can't change val of a used cell
        cellObj[CellNum].GetComponent<Button>().interactable = false;

        //update turn or flag
        if (flag) PlayerPrefs.SetString("Turn", "Y");
        else PlayerPrefs.SetString("Turn", "X");

        if (flag)
        {
            cellVal[CellNum].GetComponent<Text>().text = "X";
            PlayerPrefs.SetString(System.Convert.ToString(CellNum), "X");
            PlayerPrefs.Save();

            //Debug.Log(cellVal[CellNum].GetComponent<Text>().text);

            //change turn message on board
            turnObj.GetComponent<Text>().text = "Player 'O' Turn"; 
        }
        else
        {
            cellVal[CellNum].GetComponent<Text>().text = "O";
            PlayerPrefs.SetString(System.Convert.ToString(CellNum), "O");
            PlayerPrefs.Save();

            //Debug.Log(cellVal[CellNum].GetComponent<Text>().text);

            //change turn message on board
            turnObj.GetComponent<Text>().text = "Player 'X' Turn";
        }

        //check win
        iswin();

       
        flag = !flag;

    }
}
