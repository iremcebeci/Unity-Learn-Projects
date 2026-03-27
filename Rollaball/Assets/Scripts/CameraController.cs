using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;   // Kamera takip edeceği oyuncu nesnesi
    private Vector3 offset;     // Kamera ile oyuncu arasındaki mesafe


    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
