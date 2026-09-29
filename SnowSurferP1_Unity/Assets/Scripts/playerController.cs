using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    InputAction moveAction;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput;

        moveInput = moveAction.ReadValue<Vector2>();
        print(moveInput);
    }
}
