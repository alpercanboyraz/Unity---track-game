using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackManagement : MonoBehaviour
{
    GameObject ring;
    int speed = 5;
    void Start()
    {
        ring = GameObject.FindWithTag("ring");
    }

    // Update is called once per frame
    void Update()
    {
        ring.transform.Rotate(new Vector3(0,0,1)*speed*Time.deltaTime);
    }
}
