using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba : MonoBehaviour{

    public float speed = 0;
    private GameObject target;

    void Start(){
        target = GameObject.FindWithTag("Goal");
    }

    void Update(){
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }
}
