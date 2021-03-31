using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObjectPool : MonoBehaviour
{
    public static CoinObjectPool Instance; // To use this object as a singleton
    public GameObject coinPrefab;
    [SerializeField] private int coinCount = 10000; // Number of coins that are initially allocated

    Queue<GameObject> coinQueue = new Queue<GameObject>();

    void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    // Condition 1. Allocates all (10000) coins to the pool initially.
    void Start()
    {
        for (int i = 0; i < coinCount; i++) {
            GameObject coinObject = Instantiate(coinPrefab);
            coinObject.SetActive(false);
            coinObject.transform.SetParent(this.transform);
            coinQueue.Enqueue(coinObject);
        }
    }

    // Method for getting an object from the pool
    public GameObject SpawnObject(Vector3 position) {
        // Check for available coin left in the pool
        if (coinQueue.Count <= 0) {
            return null;
        }

        // Displays the coin at appropriate position and remove it from the pool
        GameObject coinToSpawn = coinQueue.Dequeue();
        coinToSpawn.SetActive(true);
        coinToSpawn.transform.position = position;
        coinToSpawn.GetComponent<Coin>().OnObjectSpawn();

        return coinToSpawn;
    }

    // Method for returning an object to the pool
    public void ReturnObject(GameObject coinToReturn) {
        // Removes the coin from being displayed and add it back to the pool
        coinToReturn.SetActive(false);
        coinToReturn.transform.SetParent(this.transform);
        coinQueue.Enqueue(coinToReturn);
    }
}
