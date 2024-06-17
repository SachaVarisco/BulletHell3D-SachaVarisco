using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [Header("Timer")]
    private float currentTime;
    [SerializeField] private float maxTime;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    private Transform gun;
    

    private void Start()
    {
        currentTime = maxTime;
        gun = transform.GetChild(0).gameObject.transform;
    }

    private void Update()
    {

        currentTime -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") || currentTime <= 0)
        {

            Instantiate(bulletPrefab, gun.position, Quaternion.identity);

            Debug.Log("Shoot");
            currentTime = maxTime;
        }
    }
    
}
