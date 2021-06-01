using System;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float _speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //ignored
    }

    // Update is called once per frame
    void Update()
    {
        var _moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.position += _moveInput * Time.deltaTime * _speed;
    }

}
