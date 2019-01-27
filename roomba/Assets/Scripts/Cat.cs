using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveDiagonal(Vector3 v3)
    {
        transform.Translate(speed * v3.normalized * Time.deltaTime);
    }
}
