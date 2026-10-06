using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 20;
    [SerializeField] float boostSpeed = 28;
    [SerializeField] ParticleSystem powerUpParticles;

    InputAction moveAction;
    Rigidbody2D myRigidBody2D;
    SurfaceEffector2D mySurfaceEffector2D;
    ScoreManager scoreManager;

    Vector2 moveInput;
    bool canControlPlayer = true;
    float previousRotation;
    float totalRotation;
    int activePowerUpCount = 0;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidBody2D = GetComponent<Rigidbody2D>();
        mySurfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
        moveAction.Enable();
        scoreManager = FindAnyObjectByType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canControlPlayer)
        {
            rotatePlayer();
            boostPlayer();
            calculateFlips();
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

    void calculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

        if (totalRotation > 340 || totalRotation < -340)
        {
            totalRotation = 0f;
            scoreManager.addScore(100);
        }

        previousRotation = currentRotation;
    }

    public void disableControls()
    {
        canControlPlayer = false;
    }

    public void activatePowerUp(PowerUpSO powerUp)
    {
        powerUpParticles.Play();
        activePowerUpCount += 1;

        if (powerUp.getPowerUpType() == "Speed")
        {
            baseSpeed += powerUp.getValueChange();
            boostSpeed += powerUp.getValueChange();
        }

       else if (powerUp.getPowerUpType() == "Torque")
        {
            torqueAmount += powerUp.getValueChange();
        }
    }

    public void deactivatePowerUp(PowerUpSO powerUp)
    {
        activePowerUpCount -= 1;

        if (activePowerUpCount <= 0)
        {
            powerUpParticles.Stop();
        }

        if (powerUp.getPowerUpType() == "Speed")
        {
            baseSpeed -= powerUp.getValueChange();
            boostSpeed -= powerUp.getValueChange();
        }

        else if (powerUp.getPowerUpType() == "Torque")
        {
            torqueAmount -= powerUp.getValueChange();
        }
    }

}
