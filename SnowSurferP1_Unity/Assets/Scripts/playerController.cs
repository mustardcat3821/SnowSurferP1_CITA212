using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    InputAction moveAction;
    Rigidbody2D myRigidBody2D;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput;

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
}
