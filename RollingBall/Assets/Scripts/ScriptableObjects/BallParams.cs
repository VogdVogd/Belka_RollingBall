
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "New BallParams", menuName = "Ball Params", order = 51)]
public class BallParams : ScriptableObject
{
    [Header("Move params")]
    [SerializeField]
    private float _startSpeed;
    [SerializeField]
    private float _accelerationForce;

    [Header("Increase speed params")]
    [SerializeField]
    private float _speedIncrease100Meters;
    [SerializeField]
    private float _maxSpeed;

    [Header("Jump force")]
    [SerializeField]
    private float _jumpForce;


    // Access.
    public float StartSpeed
    {
        get { return _startSpeed; }
    }

    public float AccelerationForce
    {
        get { return _accelerationForce; }
    }

    public float SpeedIncrease
    {
        get { return _speedIncrease100Meters; }
    }

    public float MaxSpeed
    {
        get { return _maxSpeed; }
    }

    public float JumpForce
    {
        get { return _jumpForce; }
    }
}
