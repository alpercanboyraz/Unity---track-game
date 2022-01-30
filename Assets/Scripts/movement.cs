using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private Touch _touch;

    private Vector3 _touchDown; // alınan ilk nokta
    private Vector3 _touchUp;   // ikinci nokta

    private bool _dragStarted;
    private bool _isMoving;

    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {

         if (Input.touchCount > 0)
         {
             _touch = Input.GetTouch(0); // ekrana dokunulan ilk nokta
             if (_touch.phase == TouchPhase.Began)
             {
                 _dragStarted = true;
                 _isMoving = true;
                 //anim.SetBool("isRun", true);
                 _touchDown = _touch.position;
                 _touchUp = _touch.position;
             }
         }

         if (_dragStarted)
         {
             if(_touch.phase == TouchPhase.Moved) // eğer kullanıcı parmağı ile sürüklerse
             {
                 _touchDown = _touch.position;
             }
             if (_touch.phase == TouchPhase.Ended) // parmağını çektiğinde
             {
                 _touchDown = _touch.position;
                 _isMoving = false;
                 //anim.SetBool("isRun", false);
                 _dragStarted = false;
             }
             gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, calculateRotation(), rotationSpeed * Time.deltaTime); //rotateTowards karakterin yönünün değişmesini sağlar
             gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed); // karakter baktığı yöne doğru hareket eder
         }
        //anim.SetBool("isRun", true);
        //gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed); // karakter baktığı yöne doğru hareket eder
    }

    Vector3 calculateDirection()
    {
        Vector3 temp = (_touchDown - _touchUp).normalized; // normalize değerleri küçültür
        temp.z = temp.y;
        temp.y = 0;
        return temp;

    }  

    Quaternion calculateRotation()
    {
        Quaternion temp = Quaternion.LookRotation(calculateDirection(), Vector3.up);
        return temp;
    }
    public bool IsMoving()
    {
        return _isMoving;
    }
}
