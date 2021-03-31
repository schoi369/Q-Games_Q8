using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int framesToWait = 300;
    private int currentFrame;

    // Custom method to be called instead of Start()
    public void OnObjectSpawn() {
        currentFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentFrame++;

        // Condition 4: Returns the coin to the pool after 300 frames
        if (currentFrame >= framesToWait) {
            CoinObjectPool.Instance.ReturnObject(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Condition 3: When player collides with the coin, return the coin to the pool.
        if (other.CompareTag("Player")) {
            CoinObjectPool.Instance.ReturnObject(this.gameObject);
        }
    }
}
