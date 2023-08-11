using UnityEngine;

public class player : MonoBehaviour
{
    void Update()
    {
        float mouse_x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector3(mouse_x, transform.position.y, transform.position.z);
    }
}
