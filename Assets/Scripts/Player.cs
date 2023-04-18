using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float runSpeed;

    private Rigidbody2D rig;

    private float initialSpeed;
    private bool isRunning;
    private bool isRolling;
    private Vector2 direction;

    public Vector2 Direction
    {
        get { return direction; }
        // set { direction = value; }
    }
    public bool IsRunning
    {
        get { return isRunning; }
        // set { isRunning = value; }
    }
    public bool IsRolling
    {
        get { return isRolling; }
        // set { isRolling = value; }
    }

    private void Start()
    {
        isRunning = false;
        initialSpeed = speed;
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement

    private void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void OnMove()
    {
        rig.MovePosition(rig.position + speed * Time.fixedDeltaTime * direction);
    }

    private void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    private void OnRolling()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isRolling = false;
        }
    }

    #endregion
}
