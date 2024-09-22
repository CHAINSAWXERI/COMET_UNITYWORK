using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private DeathWallBody DeathWallPrefab;
    [SerializeField] private CoinBody CoinPrefab;
    [SerializeField] private int poolSizeCoins;
    [SerializeField] private int poolSizeDeathWalls;

    private List<CoinBody> CoinPool;
    private List<DeathWallBody> DeathWallPool;
    private System.Random random = new System.Random();

    private void Awake()
    {
        CoinPool = new List<CoinBody>();
        DeathWallPool = new List<DeathWallBody>();

        for (int i = 0; i < poolSizeDeathWalls; i++)
        {
            DeathWallBody obj = Instantiate(DeathWallPrefab);
            obj.gameObject.SetActive(false);
            DeathWallPool.Add(obj);
            obj.objectPool = this;
        }

        for (int i = 0; i < poolSizeCoins; i++)
        {
            CoinBody obj = Instantiate(CoinPrefab);
            obj.gameObject.SetActive(false);
            CoinPool.Add(obj);
            obj.objectPool = this;
        }
    }

    public GameObject GetObjectDeathWall()
    {
        foreach (DeathWallBody obj in DeathWallPool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
                return obj.gameObject;
            }
        }

        DeathWallBody newObj = Instantiate(DeathWallPrefab);
        newObj.gameObject.SetActive(true);
        DeathWallPool.Add(newObj);
        return newObj.gameObject;
    }

    public GameObject GetObjectCoin()
    {
        foreach (CoinBody obj in CoinPool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
                return obj.gameObject;
            }
        }

        CoinBody newObj = Instantiate(CoinPrefab);
        newObj.gameObject.SetActive(true);
        CoinPool.Add(newObj);
        return newObj.gameObject;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
