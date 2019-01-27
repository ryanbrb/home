using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private float speed;
	private Vector3 myScale;
	
	
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
		myScale = transform.localScale;
		myScale.x = myScale.x * -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveDiagonal(Vector3 v3)
    {
		if(v3.x > 0)
		{
			Vector3 newScale = myScale;
			//newScale.x = newScale.x * -1;
			transform.localScale = newScale;
		}
		else if(v3.x < 0)
		{
			Vector3 newScale = myScale;
			newScale.x = newScale.x * -1;
			transform.localScale = newScale;
		}
        transform.Translate(speed * v3.normalized * Time.deltaTime);
    }
}
