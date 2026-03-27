using UnityEngine;

public class CarSound : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip idleSound;     
    public AudioClip accelSound;  
    public AudioClip decelSound;
    public Rigidbody rb;

    public float speedThreshold = 5f;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        audioSource.loop = true;
        audioSource.clip = idleSound;
        audioSource.Play();

    }

    void Update()
    {
        float speed = rb.linearVelocity.magnitude;

        // กดเร่ง
        if (Input.GetKey(KeyCode.W))
        {
            if (audioSource.clip != accelSound)
            {
                audioSource.clip = accelSound;
                audioSource.Play();
                
            }
        }
        // ปล่อย / เบรก
        else if (Input.GetKey(KeyCode.S) || speed > speedThreshold)
        {
            if (audioSource.clip != decelSound)
            {
                audioSource.clip = decelSound;
                audioSource.Play();
            }
        }
        // ช้า
        else
        {
            if (audioSource.clip != idleSound)
            {
                audioSource.clip = idleSound;
                audioSource.Play();
            }
        }
    }
}