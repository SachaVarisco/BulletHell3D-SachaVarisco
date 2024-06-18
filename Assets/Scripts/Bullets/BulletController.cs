using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float speed;

    [Header("Target")]
    private Transform target;

    [Header("BulletType")]
    [SerializeField] private bool isTarget;

    [Header("Timer")]
    private float currentTime;
    [SerializeField] private float maxTime;

    private void Start()
    {
        currentTime = maxTime;
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }

    private void Update()
    {
        if (isTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                Pool.Instance.ReturnBullet(gameObject);
                currentTime = maxTime; 
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
