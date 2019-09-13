using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;

    private int HitCount = 0;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Jumper")
        {
            HitCount++;
            if (HitCount > 1 && HitCount < 12)
            {
                //modify vect to change spawn points
                Vector3 vect = col.gameObject.transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 0f, 4f);
          
                Instantiate(prefab, vect, new Quaternion(), parent);
                Debug.Log("New Rotating Prefab Created, Number: " + (HitCount-1));
            }

        }
    }
}
