using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(1);

            
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            gameObject.SetActive(false);
        }
    }
}