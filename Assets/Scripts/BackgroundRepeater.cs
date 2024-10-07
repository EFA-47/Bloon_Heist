using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundRepeater : MonoBehaviour
{
    private float length;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<Renderer>().bounds.size.x;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - length/2){
            transform.position = startPos;
        }
    }
}
