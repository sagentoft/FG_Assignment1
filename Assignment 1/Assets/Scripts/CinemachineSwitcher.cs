using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
    private Animator animator;

    private bool player1Camera = true;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchState()
    {
        if (player1Camera)
        {
            animator.Play("Player2Camera");
        }
        else
        {
            animator.Play("Player1Camera");
        }
        player1Camera = !player1Camera;
    }
}
