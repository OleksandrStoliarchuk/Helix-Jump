using UnityEngine;

public class CrashPlatform : MonoBehaviour
{
    private float torque = 500;
    private float radius = 10;
    private float timeToDestroyObject = 2;
    private Rigidbody[] _rb;
    private MeshCollider[] _platformCollider;

    private void Start()
    {
        _rb = GetComponentsInChildren<Rigidbody>();
        _platformCollider = GetComponentsInChildren<MeshCollider>();
    }

    public void Crash()
    {
        foreach(var item in _rb)
        {
            item.isKinematic = false;
            item.AddExplosionForce(torque, transform.position, radius);
            Destroy(gameObject, timeToDestroyObject);
        }
        foreach (var item in _platformCollider)
        {
            item.isTrigger = true;
        }
    }
}
