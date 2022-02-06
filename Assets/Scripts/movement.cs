using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rig;
    bool left, right;

    [SerializeField]
    float speed;

    [SerializeField]
    float jump_force;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Vector3 go_right = new Vector3(3.15f, transform.position.y, transform.position.z);
        Vector3 go_left = new Vector3(-4.80f, transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if(finger.deltaPosition.x > 20.0f)
            {
                right = true;
                left = false;
            }
           
            if (finger.deltaPosition.x <  -20.0f)
            {
                right = false;
                left = true;
            }
            
            if (finger.deltaPosition.y > 30.0f)
            {
                rig.velocity = Vector3.zero;
                rig.velocity = Vector3.up * jump_force;
            }
            
            if (right == true)
            {
                transform.position = Vector3.Lerp(transform.position, go_right, 5 * Time.deltaTime);
            }

            if (left == true)
            {
                transform.position = Vector3.Lerp(transform.position, go_left, 5 * Time.deltaTime);
            }

        }

    }
}
