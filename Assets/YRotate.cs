using UnityEngine;

//Rotates game object on z axis
public class YRotate : MonoBehaviour
{
    [Header("Rotation Speed")]
    [SerializeField] private float rotationSpeed = 10f;

    void Update()
    {
        // Rotate the object around its Z axis
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
