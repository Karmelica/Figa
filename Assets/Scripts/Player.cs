using System.Threading;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Shooting shooting;
    public Transform orientation;
    private Rigidbody rb;
    public Image sprintBar;
    public Animator animator;
    public GameObject shotgun;
    public GameObject flashlight;

    [Header("Stats")]
    public float moveSpeed;
    public float sprintSpeed;
    private float speed;

    private float moveX, moveY;
    private bool isSprinting;
    private float sprintCd = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shotgun"))
        {
            other.gameObject.SetActive(false);
            shotgun.SetActive(true);
        }
        if (other.CompareTag("Flashlight"))
        { 
            other.gameObject.SetActive(false);
            flashlight.SetActive(true);
        }
        if (other.CompareTag("Ammo"))
        {
            if (shotgun.activeInHierarchy)
            {
                other.gameObject.SetActive(false);
                shooting.AddAmmo();
            }
        }
    }

    private void MyInput()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && sprintCd <= 0)
        {
            isSprinting = true;
            speed = sprintSpeed;
            animator.speed = 2f;
        }
        else
        {
            isSprinting = false;
            speed = moveSpeed;
            animator.speed = 1f;
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
        shotgun.SetActive(false);
        flashlight.SetActive(false);
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
            animator.SetFloat("Speed", rb.velocity.magnitude);
        }
        Sprint();
    }
}
