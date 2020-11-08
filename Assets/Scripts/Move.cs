using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = transform.position + new Vector3(-speed,0,0);
    }
}
