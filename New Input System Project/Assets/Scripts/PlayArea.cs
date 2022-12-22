using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    public float playAreaX = 24.0f;
    public float playAreaY = 24.0f;
    public float transformX;
    public float transformY;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        transformX = transform.position.x;
        transformY = transform.position.z;
        //Right bound
        if (transform.position.x >= playAreaX)
        {
            transform.position = new Vector3(playAreaX,transform.position.y,transform.position.z);
        }
        //left bound
        if (transform.position.x <= -playAreaX)
        {
            transform.position = new Vector3(-playAreaX, transform.position.y, transform.position.z);
        }
        //top bound
        if (transform.position.z >= playAreaY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, playAreaY);
        }
        //bottom bound
        if (transform.position.z <= -playAreaY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -playAreaY);
        }
    }
}
