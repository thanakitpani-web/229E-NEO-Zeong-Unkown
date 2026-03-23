using UnityEngine;

public class AutoFlip : MonoBehaviour
{
    private float flipTimer = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.up.y < 0.3f)
        {
            flipTimer += Time.deltaTime;

            if (flipTimer > 2f)
            {
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
                transform.position += Vector3.up * 1f;

                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                flipTimer = 0f;
            }
        }
        else
        {
            flipTimer = 0f;
        }
    }
}