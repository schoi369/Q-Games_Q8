using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject coinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            CoinObjectPool.Instance.SpawnObject(transform.position);
            Destroy(this.gameObject);
        }
    }
}
