using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;   // Rigitbody oluşturduk
    private float movementX;    // Hareketin X eksenindeki değeri
    private float movementY;
    public float speed = 0;



    // Start, MonoBehaviour oluşturulduktan sonra Update'in ilk çalıştırılmasından önce bir kez çağrılır
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bileşenini alır
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();  // Hareket vektörünü alır (X,Y)

        movementX = movementVector.x;   // Hareketin X eksenindeki değeri hareket vektöründen alır
        movementY = movementVector.y;

    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); // Hareket vektörünü oluşturur (Y eksenini 0 yaparak sadece XZ düzleminde hareket sağlar)

        rb.AddForce(movement * speed);
    }


}
