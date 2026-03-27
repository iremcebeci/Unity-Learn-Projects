using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;   // Rigitbody oluşturduk
    private int count;
    private float movementX;    // Hareketin X eksenindeki değeri
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;   // Toplanan nesne sayısını göstermek için TextMeshPro bileşeni
    public GameObject winTextObject;    // Kazanma mesajını göstermek için GameObject (TextMeshPro nesnesi)



    // Start, MonoBehaviour oluşturulduktan sonra Update'in ilk çalıştırılmasından önce bir kez çağrılır
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bileşenini alır

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();  // Hareket vektörünü alır (X,Y)

        movementX = movementVector.x;   // Hareketin X eksenindeki değeri hareket vektöründen alır
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 8)
        {
            winTextObject.SetActive(true);
        }
    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); // Hareket vektörünü oluşturur (Y eksenini 0 yaparak sadece XZ düzleminde hareket sağlar)

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        
    }


}
