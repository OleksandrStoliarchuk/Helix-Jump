using UnityEngine;

public class Ball : MonoBehaviour
{
    private float torque = 1.5f;
    private Vector3 _local;
    public Vector3 Local => _local;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _local = transform.InverseTransformDirection(_rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            _rb.AddForce(Vector3.up * torque, ForceMode.Impulse);
        if (collision.gameObject.CompareTag("Finish"))
            GameManager.IsPlay = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crash"))
            other.GetComponentInParent<CrashPlatform>().Crash();
    }
}
