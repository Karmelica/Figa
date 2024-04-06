using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [Header("Components")]
    public Transform orientation;
    private Rigidbody rb;
    public Image sprintBar;

    [Header("Stats")]
    public float moveSpeed;
    public float sprintSpeed;
    private float speed;

    private float moveX, moveY;
    private bool isSprinting;
    private float sprintCd = 0f;

    private void MyInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            speed = sprintSpeed;
        }
        else
        {
            isSprinting = false;
            speed = moveSpeed;
        }
    }

    private void Movement()
    {
        Vector3 direction = orientation.right * moveX + orientation.forward * moveY;
        rb.AddForce(speed * direction.normalized, ForceMode.Force);
    }

    private void Sprint()
    {
        sprintCd -= Time.deltaTime;

        if (isSprinting)
        {
            sprintBar.fillAmount -= Time.deltaTime * 0.4f;
        }
        else if (sprintCd <= 0f)
        {
            sprintBar.fillAmount += Time.deltaTime * 0.2f;
        }

        if (sprintBar.fillAmount <= 0 && sprintCd <= 0f)
        {
            sprintCd = 2f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameMenuScript.isPaused)
        {
            MyInput();
        }
        Sprint();
    }
}
