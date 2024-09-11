using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject DeathWallPrefab;
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private int poolSizeCoins;
    [SerializeField] private int poolSizeDeathWalls;

    private List<GameObject> pool;
    private System.Random random = new System.Random();

    private void Awake()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSizeDeathWalls; i++)
        {
            GameObject obj = Instantiate(DeathWallPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }

        for (int i = 0; i < poolSizeCoins; i++)
        {
            GameObject obj = Instantiate(CoinPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }

        for (int i = pool.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            GameObject temp = pool[i];
            pool[i] = pool[j];
            pool[j] = temp;
        }
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(DeathWallPrefab);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
