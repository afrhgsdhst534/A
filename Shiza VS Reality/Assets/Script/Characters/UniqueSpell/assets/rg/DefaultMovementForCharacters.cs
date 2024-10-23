using UnityEngine;
public class DefaultMovementForCharacters : MonoBehaviour
{
    Rigidbody rb;
    private InputButtons inputButtons;
    Vector3 move;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputButtons = InputButtons.instance;
    }
    void Update()
    {
        if (Input.GetKey(inputButtons.w))
        {
            move.x = 0;
            move.z = 1;
            Move();
        }
        if (Input.GetKey(inputButtons.a))
        {
            move.x = -1;
            move.z = 0;
            Move();
        }
        if (Input.GetKey(inputButtons.s))
        {
            move.x = 0;
            move.z = -1;
            Move();
        }
        if (Input.GetKey(inputButtons.d))
        {
            move.x = 1;
            move.z = 0;
            Move();
        }

    }
    private void Move()
    {
        rb.MovePosition(rb.position+move.normalized*7*Time.deltaTime);
    }
}