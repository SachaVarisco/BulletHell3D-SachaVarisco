using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static BulletPool Instance;
    private List<GameObject> Ammo;
    [SerializeField] GameObject Bullet;

<<<<<<< Updated upstream:Assets/Pool.cs
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
=======
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
    
>>>>>>> Stashed changes:Assets/Scripts/Pool/Pool.cs
}
