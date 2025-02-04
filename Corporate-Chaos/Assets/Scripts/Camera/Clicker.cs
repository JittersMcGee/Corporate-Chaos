using UnityEngine;

public class Clicker : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 location = Input.mousePosition;
        location.z = -Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(location);

    }
}
