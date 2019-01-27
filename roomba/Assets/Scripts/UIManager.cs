using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Cat playerCat;
    delegate void MovementDelegate(Vector3 v3);
    MovementDelegate movement;

    private Vector3 v3;

    // Start is called before the first frame update
    void Start()
    {
        playerCat = (Cat)FindObjectOfType(typeof(Cat));
    }

    // Update is called once per frame
    void Update()
    {
        v3 = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        movement = MoveDiagonal;
        MoveDiagonal(v3);

    }

    void MoveDiagonal(Vector3 dir)
    {
        playerCat.MoveDiagonal(dir);
    }




}
