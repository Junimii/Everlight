using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset =0.5f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + yOffset, -10f);
    }

}
