using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;   // using Unity engine 
public class Bird : MonoBehaviour
{   
    // define a start position. 
    private Vector2 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        // the start position might be in vector 2. 
        _startPosition = GetComponent<Rigidbody2D>().position;
        // Get the rigidbody to the component that prevent the bird to be falling.
        // isKinematic enables us to interact with a subject. The subject still simulated but just moves by our code not the physics subject like the gravity. 
        GetComponent<Rigidbody2D>(). isKinematic= true;  
    }
    // Change the color of the bird to red when you click up the mouse 
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
        // Change the color of the bird to white when you click down the mouse 
    private void OnMouseUp()
    {
        // define a current position:
        var currentPosition = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    // By dragging the mouse the position of the bird would be changed.
    // Maybe by clicking and dragging the bird, it vanished due to Z factor of its position. So we should write a code in which the Z position does not move by dragging.
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
