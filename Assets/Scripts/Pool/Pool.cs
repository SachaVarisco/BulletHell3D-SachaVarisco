using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private int ammoBullet;

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
        for (int i = 0; i < ammoBullet; i++)
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
                //BulletList.Remove(bullet.gameObject);
                return bullet.gameObject;
            }
        }
        Debug.Log("Nueva bala");
        GameObject Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        // Crearlas con un timer y que cuando esten desactivadas las destruya
        StartCoroutine(DestroyBullet(Bullet));
        BulletList.Add(Bullet);
        Bullet.transform.SetParent(gameObject.transform);
        return Bullet;
    }

    public void ReturnBullet(GameObject Bullet)
    {
        Bullet.SetActive(false); 
    }

    private IEnumerator DestroyBullet(GameObject Bullet){
        yield return new WaitForSeconds(5f);
        if (!Bullet.activeSelf)
        {
            BulletList.Remove(Bullet);
            Destroy(Bullet);
        }
    }
    
}
