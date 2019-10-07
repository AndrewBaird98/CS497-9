using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scoreboard : MonoBehaviour
{
    public GameObject pointManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void updateBoard(string score)
    {
        TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.SetText(score);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
