using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public GameObject obj;
    public float height = 0.0f;

    private float initial = 0.0f;
    private float moveTo = 0.0f;
    private bool up = true;
    // Start is called before the first frame update
    void Start()
    {
        initial = obj.transform.position.y;
        moveTo = initial + height;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            obj.transform.position += new Vector3(0f, 0.03f, 0.0f);
            if (obj.transform.position.y >= moveTo)
                up = !up;
        }
        else
        {
            obj.transform.position += new Vector3(0f, -0.03f, 0.0f);
            if (obj.transform.position.y <= initial)
                up = !up;
        }
    }
}
