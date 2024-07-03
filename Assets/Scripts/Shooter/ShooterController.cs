using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [Header("Pool")]
    
    [SerializeField] private GameObject pool;

    [Header("Timer")]
    private float currentTime;
    [SerializeField] private float maxTime;

    [Header("Gun")]
    private Transform gun;

    private void Start()
    {
        currentTime = maxTime;
        gun = transform.GetChild(0).gameObject.transform;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject Bullet = pool.GetComponent<Pool>().GetBullet();
            //GameObject Bullet = Pool.Instance.GetBullet();
            if (Bullet != null)
            {
                Bullet.transform.position = gun.position;
                Bullet.SetActive(true);
                
            }
            currentTime = maxTime;
        }
    }

}
