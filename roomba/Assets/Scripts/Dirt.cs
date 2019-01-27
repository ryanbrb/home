using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		    
    }
	private void OnCollisionStay2D(Collision2D collision)
	{
		if(BoundsContainedPercentage(collision.collider.bounds, this.GetComponent<Collider2D>().bounds) > 0.999f)
		{
			Destroy(this);
		}
	}
	public static float BoundsContainedPercentage(Bounds obj, Bounds region)
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
