using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 20;
    [SerializeField] float boostSpeed = 28;

    InputAction moveAction;
    Rigidbody2D myRigidBody2D;
    SurfaceEffector2D mySurfaceEffector2D;

    Vector2 moveInput;
    bool canControlPlayer = true;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody2D = GetComponent<Rigidbody2D>();
        mySurfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        moveAction.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        if (canControlPlayer)
        {
            rotatePlayer();
            boostPlayer();
        }
    }

    void rotatePlayer()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.x < 0f)
        {
            myRigidBody2D.AddTorque(torqueAmount);
        }
        else if (moveInput.x > 0f)
        {
            myRigidBody2D.AddTorque(-torqueAmount);
        }
    }

    void boostPlayer()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.y > 0f)
        {
            mySurfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            mySurfaceEffector2D.speed = baseSpeed;
        }

    }
    public void disableControls()
    {
        canControlPlayer = false;
    }

}
