
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class playerAnimationHandler : MonoBehaviour
{
    public Animator animator;
    private float x;
    private float y;
    private bool moving;
    private Vector2 XnY;


    // все что ниже стоит переделать, в AimDirection добавить булей с другими направлениями и в последствии переделать shooting. А так же можно всё объединить в один метод

    private void Update()
    {
        InputRegister();
        Animate();
        AimDirection();
    }

    private void InputRegister()
    {
        x = playerInput.leftStick.x;
        y = playerInput.leftStick.y;
        XnY = playerInput.leftStick;
    }


    private void AimDirection()
    {
        Vector2 leftStick = playerInput.leftStick.normalized;
        Vector2 rightStick = playerInput.rightStick.normalized;

        bool movingUp = leftStick.y > 0.1f;
        bool movingRight = leftStick.x > 0.1f;

        bool aimingUp = Mathf.Abs(rightStick.y) > Mathf.Abs(rightStick.x) && ((movingUp && rightStick.y < -0.1f) || (!movingUp && rightStick.y > 0.1f));
        bool aimingRight = Mathf.Abs(rightStick.x) > Mathf.Abs(rightStick.y) && ((movingRight && rightStick.x < -0.1f) || (!movingRight && rightStick.x > 0.1f));

        bool shooting = aimingUp || aimingRight;

        animator.SetBool("Shooting", shooting);
    }

    private void Animate()
    {
        if(XnY.magnitude > 0.01f || XnY.magnitude < -0.01f) 
        { 
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving) 
        {
            animator.SetFloat("X", x);
            animator.SetFloat("Y", y);
        }
        animator.SetBool("Moving", moving);
    }
}
