using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : Singleton<Pool>
{
    //Bullet pool
    public List<GameObject> bulletPoolObjects = new List<GameObject>();
    public int bulletsPoolAmount = 40;
    [SerializeField] private GameObject bulletPrefab;

    //Muzzleflash pool
    public List<GameObject> muzzleFlashPoolObjects = new List<GameObject>();
    public int muzzleFlashPoolAmount = 40;
    [SerializeField] private GameObject muzzleFlashPrefab;

    // Start is called before the first frame update
    void Start()
    {
        FillPool(bulletPoolObjects, bulletPrefab, bulletsPoolAmount);
        FillPool(muzzleFlashPoolObjects, muzzleFlashPrefab, muzzleFlashPoolAmount);
    }

    public void FillPool(List<GameObject> poolToFill, GameObject whatPrefabToUse, int numberOfItemsInPool)
    {
        for (int i = 0; i < numberOfItemsInPool; i++)                           //Will run as many times as we want the pool amount to be
        {
            GameObject itemToAddToThePool = Instantiate(whatPrefabToUse);       //Will instantiate an item prebab each round
            itemToAddToThePool.transform.parent = transform;                    //Will set each item to be a child of the gameobject this script is attached to
            itemToAddToThePool.SetActive(false);                                //Will deactivate it
            poolToFill.Add(itemToAddToThePool);                                 //Will add it to the pool list
        }
    }

    private GameObject GetPooledObject(List<GameObject> listToLookAt)
    {
        for (int i = 0; i < listToLookAt.Count; i++)   //Will go through the pool
        {
            if (!listToLookAt[i].activeInHierarchy)    //Will look for the first bullet that is not active
            {
                return listToLookAt[i];                //And will return it
            }
        }

        return null;                                    //If there are none, return nothing
    }

    public GameObject GetBullet()
    {
        return GetPooledObject(bulletPoolObjects);
    }

    public GameObject GetMuzzleFlash()
    {
        return GetPooledObject(muzzleFlashPoolObjects);
    }
}
