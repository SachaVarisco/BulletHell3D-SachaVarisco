using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontal; 
    private float vertical;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Move();
    }

    private void Move(){
        if (vertical != 0)
        {
            transform.position = transform.position + transform.forward * vertical * speed * Time.deltaTime;
        }
        if (horizontal != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward * horizontal), rotationSpeed * Time.deltaTime);
        }
       
    }
}
