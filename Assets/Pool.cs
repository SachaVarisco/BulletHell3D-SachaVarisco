using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance;
    public GameObject BulletPrefab;

    private List<GameObject> BulletList;
    private void Awake()
    {
        if (Pool.Instance == null)
        {
            Pool.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        BulletList = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            GameObject Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            Bullet.transform.SetParent(gameObject.transform);
            Bullet.SetActive(false);
            BulletList.Add(Bullet);
        }
    }
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in BulletList)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                return bullet.gameObject;
            }
        }
        Debug.Log("Nueva bala");
        GameObject Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        BulletList.Add(Bullet);
        Bullet.transform.SetParent(gameObject.transform);
        return Bullet;
    }

    public void ReturnBullet(GameObject Bullet)
    {
        //BulletList.Add(Bullet);
        
        /*for (int i = 0; i < BulletList.Count; i++) // Intento de que se borren las balas sobrantes
        {
            if (i > 3)
            {
                GameObject  BulletBye = BulletList[i];
                BulletList.Remove(BulletBye);
                Destroy(BulletBye);
            }
            Bullet.SetActive(false);
        } */
        Bullet.SetActive(false); 
    }
    
}
