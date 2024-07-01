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

        // Cada vez que se sobrepase el maximo, reiniciar el contador y al finalizar eliminar las inactivas sobrantes
        // Corrutina o poner un contador en el update con varios if

        GameObject Bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        BulletList.Add(Bullet);
        Bullet.transform.SetParent(gameObject.transform);
        StartCoroutine(DestroyBullet(Bullet));
        return Bullet;
    }

    public void ReturnBullet(GameObject Bullet)
    {
        Bullet.SetActive(false); 
    }

    private IEnumerator DestroyBullet(GameObject Bullet){

        yield return new WaitForSeconds(5f);
        BulletList.Remove(Bullet);
        Destroy(Bullet);
    }
    
}
