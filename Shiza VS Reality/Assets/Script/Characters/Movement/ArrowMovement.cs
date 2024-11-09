using UnityEngine;
using UnityEngine.UI;
public class ArrowMovement : BaseMovement
{
    private InputButtons inputButtons;
    private float rotationSpeed;
    private Vector3 move;
    public bool w;
    public bool a;
    public bool s;
    public bool d;
    GamePlaySettings settings;
    public Button n;
    public override void Start()
    {
        base.Start();
        inputButtons = InputButtons.instance;
        rotationSpeed = 32;
        settings = GamePlaySettings.instance;
    }
    public void Update()
    {
        if (chars.isAlly && chars.canMove && enabled)
        {
            if (settings.arrowIsFollowMouse)
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;
                float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            }
            #region IFELSE
            if (!w && !a && !s && !d)
            {
                animator.SetBool("walkB", false);
            }
            else
            {
                animator.SetBool("walkB", true);
            }
            if (Input.GetKeyUp(inputButtons.w))
            {
                w = false;
            }
            if (Input.GetKeyUp(inputButtons.a))
            {
                a = false;
            }
            if (Input.GetKeyUp(inputButtons.s))
            {
                s = false;
            }
            if (Input.GetKeyUp(inputButtons.d))
            {
                d = false;
            }
            if (Input.GetKey(inputButtons.w))
            {
                w = true;
            }
            if (Input.GetKey(inputButtons.a))
            {
                a = true;
            }
            if (Input.GetKey(inputButtons.s))
            {
                s = true;
            }
            if (Input.GetKey(inputButtons.d))
            {
                d = true;
            }
            if (Input.GetKey(inputButtons.w) && Input.GetKey(inputButtons.a))
            {
                w = true;
                a = true;
            }
            if (Input.GetKey(inputButtons.w) && Input.GetKey(inputButtons.d))
            {
                w = true;
                d = true;
            }
            if (Input.GetKey(inputButtons.a) && Input.GetKey(inputButtons.s))
            {
                a = true;
                s = true;
            }
            if (Input.GetKey(inputButtons.s) && Input.GetKey(inputButtons.d))
            {
                s = true;
                d = true;
            }
            if (w && !s && !d && !a)
            {
                Move(0, 1);
            }
            if (!w && s && !d && !a)
            {
                Move(0, -1);
            }
            if (!w && !s && d && !a)
            {
                Move(1, 0);
            }
            if (!w && !s && !d && a)
            {
                Move(-1, 0);
            }
            if (w && !s && !d && a)
            {
                Move(-0.5f, 0.5f);
            }
            if (w && !s && d && !a)
            {
                Move(0.5f, 0.5f);
            }
            if (!w && s && d && !a)
            {
                Move(0.5f, -0.5f);
            }
            if (!w && s && !d && a)
            {
                Move(-0.5f, -0.5f);
            }
            #endregion
        }
    }
    private void Move(float x, float y)
    {
        animator.SetBool("walkB", true);
        move.x = x;
        move.z = y;
        rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);
        if (!settings.arrowIsFollowMouse)
        {
            Quaternion quaternion = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, rotationSpeed * Time.deltaTime);
        }
    }
}