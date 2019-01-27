using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
	private Bounds MyBounds;
	private Bounds RBounds;
	// Start is called before the first frame update
	void Start()
	{
		MyBounds = this.GetComponent<Collider2D>().bounds;
		RBounds = MyBounds;
	}

	// Update is called once per frame
	void Update()
	{
		if (RBounds != MyBounds)
		{
			if (BoundsContainedPercentage(MyBounds, RBounds) > 0.999f)
			{
				Destroy(this);
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Roomba"))
		{
			RBounds = collision.collider.bounds;
		}
	}

	//region is the larger
	public float BoundsContainedPercentage(Bounds obj, Bounds region)
	{
		var total = 1f;
		for (var i = 0; i < 2; i++)
		{
			var dist = obj.min[i] > region.center[i] ?
				obj.max[i] - region.max[i] :
				region.min[i] - obj.min[i];
			total *= Mathf.Clamp01(1f - dist / obj.size[i]);
		}
		return total;
	}
}
