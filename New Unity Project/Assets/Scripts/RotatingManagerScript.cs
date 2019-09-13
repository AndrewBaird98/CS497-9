using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingManagerScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space bar pressed, Going Faster Now.");
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                var script = child.GetComponent<RotationScript>();
                if (script != null)
                {
                    script.speed = script.speed + 1f;
                }           
            }
        } 
    }


}
