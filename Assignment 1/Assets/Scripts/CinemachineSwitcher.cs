using UnityEngine;
using UnityEngine.InputSystem;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private InputAction action;

    private Animator animator;

    private bool player1Camera = true;
    //private bool player2Camera = false;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.performed += _ => SwitchState();
    }

    private void SwitchState()
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
