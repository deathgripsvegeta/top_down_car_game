using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControls : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _sideSpeed = 5f;
    [SerializeField] private float _xRange = 4.643f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        transform.Translate(Vector3.right * _sideSpeed * horizontalInput * Time.deltaTime);
        
        if(transform.position.x > _xRange)
        {
            transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -_xRange)
        {
            transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
        }
    }
}
