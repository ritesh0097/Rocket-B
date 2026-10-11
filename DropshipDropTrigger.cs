using UnityEngine;

public class DropshipDropTrigger : MonoBehaviour
{
    [SerializeField] GameObject dropship;

    void OnTriggerEnter(Collider other)
    {
        dropship.GetComponent<Rigidbody>().isKinematic = false;
    }
}
