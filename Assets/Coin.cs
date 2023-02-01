using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.collectedCoins++;

            // AudioManager.instance.Play("CoinPickup");

            Destroy(gameObject);
        }
    }
}