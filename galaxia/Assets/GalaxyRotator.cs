using UnityEngine;

public class GalaxyRotator : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}