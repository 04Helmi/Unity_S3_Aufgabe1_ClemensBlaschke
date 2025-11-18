using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControll : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] Rigidbody2D rb;
    private Vector2 moveInput;
    [SerializeField] private GameObject DialogBox;
    public bool canMove;
    [SerializeField] private Toto Toto;
    [SerializeField] private Scraecrow Scarecrow;
    public DialogManager DialogManager;
    private void Start()
    {
        canMove = true;
        if (rb != null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
    private void Update()
    {
        if (canMove)
        {
            rb.linearVelocity= moveInput * moveSpeed;
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DialogTotoTrigger"))
        {
            Toto.canBeInteracted = true;
        }
        if (other.CompareTag("DialogScarecrowTrigger"))
        {
            Scarecrow.canBeInteracted = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DialogTotoTrigger"))
        {
            Toto.canBeInteracted = false;
        }
        if (other.CompareTag("DialogScarecrowTrigger"))
        {
            Scarecrow.canBeInteracted = false;
        }
    }
    public void InitiateScarecrowDialog()
    {
      if(Scarecrow.canBeInteracted == true && DialogBox.active == false)
        {
            canMove = false;
            rb.linearVelocity = Vector2.zero;
            DialogBox.SetActive(true);
            DialogManager.InkyContinue();
        }
    }
    public void InitiateTotoDialog()
    {
        if (Toto.canBeInteracted == true && DialogBox.active == false)
        {
            canMove = false;
            rb.linearVelocity = Vector2.zero;
            DialogBox.SetActive(true);
            DialogManager.InkyContinue();
        }
    }
    public void EndDialog()
    {
        if(DialogBox.activeSelf== true)
        {
            canMove = true;
            DialogBox.SetActive (false);
        }
    }

}