using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private float speed;
    private Vector3 myScale;
    public float scareTime;
	public Animator myAnimation;


    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
        myScale = transform.localScale;
        myScale.x = myScale.x * -1;
        //scareTime = 5.0f;
    }

    private void Update()
    {
        if (scareTime > 0.0f)
        {
            scareTime -= Time.deltaTime;
            speed = -1.0f;
        }
        else
        {
            speed = 1.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case GameTag.Roomba:
                scareTime = 1.0f;
                scareTime -= Time.deltaTime;
                break;
        }
    }

    public void MoveDiagonal(Vector3 v3)
    {
		if(Mathf.Abs(v3.x) > 0) // != Vector3.zero)
		{
			myAnimation.SetBool("Moving", true);
		}
		else
		{
			myAnimation.SetBool("Moving", false);
		}


        if (v3.x > 0)
        {
            Vector3 newScale = myScale;
            newScale.x = newScale.x * -1;
            transform.localScale = newScale;
        }
        else if (v3.x < 0)
        {
            Vector3 newScale = myScale;
            //newScale.x = newScale.x * -1;
            transform.localScale = newScale;
        }
        transform.Translate(speed * v3.normalized * Time.deltaTime);
    }


}
