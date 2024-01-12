using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 initialOffset = new Vector3(0f, 1f, -5f);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position + initialOffset; 
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = target.position + initialOffset;

    }

    void LateUpdate(){
        transform.position = target.position + initialOffset;
    }
    
}
