using UnityEngine;

public class Ball : MonoBehaviour
{
    public float torque;
    public GameObject gameController;
    public Vector3 local;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameObject.Find("GameController");
    }

    private void Update()
    {
        local = transform.InverseTransformDirection(rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            rb.AddRelativeForce(Vector3.up * torque, ForceMode.Impulse);
        if (collision.gameObject.CompareTag("Finish"))
            gameController.GetComponent<NextLevel>().levelBtn.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crash"))
            other.GetComponentInParent<CrashPlatform>().Crash();
    }
}
