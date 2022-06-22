using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;   // using Unity engine 
public class Bird : MonoBehaviour
{

    [SerializeField] private float _launchForce = 500; 
    // define a start position. 
    private Vector2 _startPosition;

    // define var:
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // the start position might be in vector 2. 
        _startPosition = _rigidbody2D.position;
        // Get the rigidbody to the component that prevent the bird to be falling.
        // isKinematic enables us to interact with a subject. The subject still simulated but just moves by our code not the physics subject like the gravity. 
        _rigidbody2D . isKinematic= true;  
    }
    // Change the color of the bird to red when you click up the mouse 
    private void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }
    // Change the color of the bird to white when you click down the mouse 
    private void OnMouseUp()
    {
        // define a current position:
        Vector2 currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition; 
        direction . Normalize();
        _rigidbody2D. isKinematic= false; 
        _rigidbody2D.AddForce(direction * _launchForce);
        _spriteRenderer.color = Color.white;
    }
    // By dragging the mouse the position of the bird would be changed.
    // Maybe by clicking and dragging the bird, it vanished due to Z factor of its position. So we should write a code in which the Z position does not move by dragging.
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Get the direction:
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());

    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D . isKinematic= true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}

