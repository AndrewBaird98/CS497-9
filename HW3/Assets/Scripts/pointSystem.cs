using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class pointSystem : MonoBehaviour
{
    public Scoreboard scoreboardScript;

    private int score = 0;



    // Start is called before the first frame update
    public void incrementPoints()
    {
        score++;
        scoreboardScript.updateBoard(score.ToString());
        Debug.Log(score);

    }

    //public int getScore()
    //{
    //    return score;
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
