using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProps : MonoBehaviour
{
    [SerializeField] public float speed = 10;
    [SerializeField] private float _xRange = 13.59f;
    // Start is called before the first frame update
    void Start()
    {
        MoveProp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveProp()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(transform.position.x < -_xRange)
        {
            transform.position = new Vector2(_xRange, 4.34f);
        }
        
        
    }

}
