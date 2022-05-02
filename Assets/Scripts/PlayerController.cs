using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;

    Vector2 moveInput;

    Vector2 minBoundary;
    Vector2 maxBoundary;

    void Start()
    {
        InitBoundaries();    
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }


    void InitBoundaries()
    {
        Camera mainCamera = Camera.main;
        minBoundary = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBoundary = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void PlayerMove()
    {
        Vector2 delta = moveInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBoundary.x + paddingLeft, maxBoundary.x -paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBoundary.y + paddingBottom, maxBoundary.y - paddingTop);
        transform.position = newPos;
    }
}
