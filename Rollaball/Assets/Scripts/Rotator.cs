using UnityEngine;

public class Rotator : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);     // Nesneyi her frame'de belirli bir hızda döndürür

    }
}
