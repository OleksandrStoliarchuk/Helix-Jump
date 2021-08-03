using UnityEngine;

public class CrashPlatform : MonoBehaviour
{
    private float torque = 500f, radius = 10f;
    private Rigidbody[] rb;
    private MeshCollider[] platformCollider;

    private void Start()
    {
        rb = GetComponentsInChildren<Rigidbody>();
        platformCollider = GetComponentsInChildren<MeshCollider>();
    }

    public void Crash()
    {
        foreach(var item in rb)
        {
            item.isKinematic = false;
            item.AddExplosionForce(torque, transform.position, radius);
            Destroy(gameObject, 2f);
        }
        foreach (var item in platformCollider)
        {
            item.isTrigger = true;
        }
    }
}
