using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementRB : MonoBehaviour
{
    /// <summary>
    /// This entity has a target position to move and rotate towards.
    /// </summary>
    public Transform Target { get; protected set; }
    public Rigidbody Rb { get; protected set; }

    /// <summary>
    /// Speed of entity.
    /// </summary>
    [HideInInspector]
    public float speed = 1f;
    /// <summary>
    /// Rotation speed of entity.
    /// </summary>
    [HideInInspector]
    public float rotSpeed = 0.1f;

    float savedSpeed = 0f;

    protected virtual void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Sets entity's movement speed.
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void SetSpeed(float moveSpeed)
    {
        speed = moveSpeed;
        savedSpeed = speed;
    }

    /// <summary>
    /// Sets entity's movement speed and rotation speed.
    /// </summary>
    /// <param name="moveSpeed"></param>
    /// <param name="rotSpeed"></param>
    public void SetSpeed(float moveSpeed, float rotSpeed)
    {
        speed = moveSpeed;
        this.rotSpeed = rotSpeed;
    }

    /// <summary>
    /// Sets entity's rotation Speed.
    /// </summary>
    /// <param name="rotSpeed"></param>
    public void SetRotSpeed(float rotSpeed)
    {
        this.rotSpeed = rotSpeed;
    }

    /// <summary>
    /// Sets this entity's target.
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget(Transform target)
    {
        Target = target;
    }

    /// <summary>
    /// Move entity in the direction it is facing towards.
    /// </summary>
    public void MoveForward()
    {
        if (speed == 0f) 
            return;

        Rb.velocity = transform.forward.normalized * speed;
    }

    /// <summary>
    /// Move entity in the direction specified.
    /// </summary>
    /// <param name="direction">Direction of where entity should move to.</param>
    public void Move(Vector3 direction)
    {
        if (speed == 0f)
            return;

        Rb.velocity = direction.normalized * speed;
    }

    /// <summary>
    /// Move entity towards the target if not null.
    /// </summary>
    public void MoveToTarget()
    {
        if(Target == null)
        {
            Debug.LogError("Entity has no target specified!");
            return;
        }

        if (speed == 0f)
            return;

        Rb.velocity = Vector3.Normalize(Target.position - transform.position) * speed;
    }

    /// <summary>
    /// Rotate entity towards a specified direction.
    /// </summary>
    /// <param name="direction">Quaternion value of direction.</param>
    public void Rotate(Quaternion direction)
    {
        if (rotSpeed == 0f)
            return;

        transform.rotation = Quaternion.Slerp(transform.rotation, direction, rotSpeed);
    }

    /// <summary>
    /// Rotate entity towards target if not null.
    /// </summary>
    public void RotateToTarget()
    {
        if (Target == null)
        {
            Debug.LogError("Entity has no target specified!");
            return;
        }

        if (rotSpeed == 0f)
            return;

        var target = Vector3.Normalize(Target.position - transform.position);
        var targetRot = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed);
    }

    /// <summary>
    /// Is the entity moving or not?
    /// </summary>
    /// <returns>Boolean</returns>
    public bool IsMoving()
    {
        return Vector3.Magnitude(Rb.velocity) > 0f;
    }

    public void StopMovement()
    {
        SetSpeed(0f);
        Rb.velocity = Vector3.zero;
    }

    public void ResumeMovement()
    {
        SetSpeed(savedSpeed);
    }
}
