using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(1);

            // ลบ Destroy
            // Destroy(gameObject);

            // ซ่อนแทน
            gameObject.SetActive(false);
        }
    }
}