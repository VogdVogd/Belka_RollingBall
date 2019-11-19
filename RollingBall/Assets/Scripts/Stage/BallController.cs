using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Control ball and move it.
[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    [Header("Params from scriptable object")]
    [SerializeField]
    private BallParams ballParams;

    [SerializeField]
    private BallScores ballScores;

    enum BallState
    {
        wait,
        move_down,
        move_up,
        dead
    }

    private Rigidbody2D body;
    private float speed;
    private BallState state;
    private bool canChangeSide;
    private Vector2 oldPosition;
    private bool waitForLanding;

    public float MoveSpeed
    {
        get { return speed; }
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = ballParams.StartSpeed;
        state = BallState.move_down;
        oldPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BallState.wait || state == BallState.dead)
            return;

        IncreaseSpeed();

        if (!EventSystem.current.IsPointerOverGameObject())
            if (Input.GetMouseButtonDown(0))
                Jump();

        CheckBorders();
        UpdateDistance();
    }

    private void FixedUpdate()
    {
        if (state == BallState.wait || state == BallState.dead)
            return;

        MoveBall();
    }

    private void MoveBall()
    {
        body.AddForce(Vector2.right * ballParams.AccelerationForce);

        // Control maximum value of the speed.
        Vector2 v = body.velocity;
        if (v.x > speed)
        {
            v.x = speed;
            body.velocity = v;
        }
    }

    private void CheckBorders()
    {
        Vector3 lt = Stage.Inst.LeftTop;
        Vector3 rb = Stage.Inst.RightBottom;
        Vector3 p = transform.position;

        if (p.y < rb.y || p.y > lt.y)
            Kill();
    }

    // Bring the ball to the other side.
    private void Jump()
    {
        if (!canChangeSide)
            return;

        body.gravityScale = -body.gravityScale;
        body.AddForce(-Vector2.up * body.gravityScale * ballParams.JumpForce, ForceMode2D.Impulse);

        state = state == BallState.move_down ? BallState.move_up : BallState.move_down;

        // Change rotation direction.
        body.angularVelocity = -body.angularVelocity;

        // Wait untill new collision enter.
        canChangeSide = false;

        Stage.Inst.score += ballScores.GetScore(transform.position);
        waitForLanding = true;
    }

    private void IncreaseSpeed()
    {
        if (speed < ballParams.MaxSpeed)
        {
            float dist = transform.position.x - oldPosition.x;
            speed += dist * ballParams.SpeedIncrease * 0.01f;
        }
    }

    private void UpdateDistance()
    {
        Stage.Inst.distance += transform.position.x - oldPosition.x;
        oldPosition = transform.position;
    }

    public void AllowChangeSide()
    {
        canChangeSide = true;

        // First collider touch after jumping - landing
        if (waitForLanding)
        {
            Stage.Inst.score += ballScores.GetScore(transform.position);
            waitForLanding = false;
        }
    }

    public void Kill()
    {
        if (state == BallState.dead)
            return;

        body.isKinematic = true;
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
        state = BallState.dead;

        Stage.Inst.Loose();
    }
}
