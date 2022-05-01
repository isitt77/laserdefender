using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed;



    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void PlayerMove()
    {
        Vector3 delta = moveInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }
}
