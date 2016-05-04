
using UnityEngine;
using System.Collections;
 
public class DragGameObject : MonoBehaviour
{
    private Rigidbody rb;
    bool drag = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (drag)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 difPosition = objPosition - transform.position;
            Debug.Log("Curr : " + transform.position);
            Debug.Log("Mouse : " + objPosition);
            //transform.position = objPosition;
            rb.AddForce(difPosition * 10);
        }
    }
}
