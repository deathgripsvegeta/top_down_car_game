using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject ObjectToFollow;
    public float FollowOffset = -7.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0f, ObjectToFollow.transform.position.y + FollowOffset, -10f);
    }
}
