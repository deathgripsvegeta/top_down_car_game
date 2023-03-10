using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCarMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _boostSpeed = 10f;
    [SerializeField] private float _sideSpeed = 5f;
    [SerializeField] private float _xRange = 4.643f;
    private bool _isGameActive = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(LevelManager.Instance.StartGame())
        {
            NPCCarMove();
        }
    }
    public void NPCCarMove()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if(transform.position.x > _xRange)
        {
            transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -_xRange)
        {
            transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
        }
    }
    
    IEnumerator SetBoost()
    {
        float currentSpeed = _speed;
        _speed = currentSpeed + _boostSpeed;
        yield return new WaitForSeconds(2f);
        _speed = currentSpeed;
    }
}
