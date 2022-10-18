using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [Header("Attributes")]
    [SerializeField] float moveSpeed;

    Shooter shooter;

    Vector2 minBound;
    Vector2 maxBound;

    [Header("Padding")]
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        InitBound();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void InitBound()
    {
        Camera mainCam = Camera.main;
        minBound = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();

        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingBottom, maxBound.y - paddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
