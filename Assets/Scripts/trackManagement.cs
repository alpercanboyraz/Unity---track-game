using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackManagement : MonoBehaviour
{
    public GameObject[] ring;
    public GameObject[] rightCone;
    public GameObject[] leftCone;// konileri right ve left olarak ikiye ayır
   
    
    [SerializeField]
    int speed;
    [SerializeField]
    float right_amplitude;
    [SerializeField]
    float left_amplitude;
    
    void Update()
    {
        rotateRing(ring);
        right_coneMovement(rightCone);
        left_coneMovement(leftCone);
    }

     public void rotateRing(GameObject[] ring)
     {
        for (int i = 0; i < ring.Length; i++)
        {
            ring[i].transform.Rotate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
    }  

     public void right_coneMovement(GameObject[] ring)
    {
        
        for (int i = 0; i < rightCone.Length; i++)
        {
            float x = Mathf.Sin(Time.time) * right_amplitude;
            float y = rightCone[i].transform.position.y;
            float z = rightCone[i].transform.position.z;

            rightCone[i].transform.position = new Vector3(x, y, z);
        }
    }

    public void  left_coneMovement(GameObject[] ring)
    {

        for (int i = 0; i < leftCone.Length; i++)
        {
            float x = Mathf.Sin(Time.time) * left_amplitude * -1;
            float y = leftCone[i].transform.position.y;
            float z = leftCone[i].transform.position.z;

            leftCone[i].transform.position = new Vector3(x, y, z);
        }
    }

}
