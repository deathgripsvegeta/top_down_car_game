using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProp : MonoBehaviour
{
    public float xStart;
    public float speed;
    public float trainSpeed;
    public GameObject Train;
    public GameObject PropCar;
    
    private bool _isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        _isGameActive=true;
    }
    void Update()
    {
        if(_isGameActive == true)
        {
            CarMove();
            TrainMove();
        }
    }
    public void CarMove()
    {
        PropCar.gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(PropCar.transform.position.x < -xStart)
        {
            StartCoroutine(Wait());
            PropCar.transform.position = new Vector2(xStart, PropCar.transform.position.y);
        }
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }
    
    public void TrainMove()
    {
        Train.gameObject.transform.Translate(Vector3.left * trainSpeed * Time.deltaTime);
        if(Train.transform.position.x < -xStart)
        {
            StartCoroutine(Wait());
            Train.transform.position = new Vector2(xStart, Train.transform.position.y);
        }
    }

}
