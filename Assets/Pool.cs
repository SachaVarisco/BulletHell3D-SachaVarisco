using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static BulletPool Instance;
    private List<GameObject> Ammo;
    [SerializeField] GameObject Bullet;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        Ammo = new List<GameObject>(); 
        for (int i = 0; i < 10; i++) {

            
            Ammo.Add(GameObject.Instantiate())
        }

    }
    public Bullet GetBullet(){}

    public void ReturnBullet(){}
}
