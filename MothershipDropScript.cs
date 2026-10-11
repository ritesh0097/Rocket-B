using UnityEngine;

public class MothershipDropScript : MonoBehaviour
{
    [SerializeField] GameObject mothership;

    void OnTriggerEnter(Collider other)
    {
        mothership.GetComponent<Rigidbody>().isKinematic = false;
    }
}
