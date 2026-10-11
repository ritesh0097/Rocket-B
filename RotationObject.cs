using UnityEngine;

public class RotationObject : MonoBehaviour
{
    [SerializeField] GameObject rotateObject;

    [SerializeField] float rotationspeed;

    void Update()
    {
        rotateObject.transform.Rotate(0, rotationspeed, 0);        
    }

}
