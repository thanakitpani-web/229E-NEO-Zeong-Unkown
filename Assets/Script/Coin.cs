using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(1);  
            gameObject.SetActive(false);
        }
    }
}