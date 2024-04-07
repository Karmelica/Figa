using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    private Animator animator;
    public Transform head;
    public Image cdImage;
    public AudioSource audioSourceBullet;
    public AudioSource audioSourceShoot;

    private float shootCooldown;
    public Transform gunDown;
    public Transform gunUp;
    public float multi;
    private bool isReloading = false;

    public LayerMask enemy;
    public TextMeshProUGUI textMeshPro;
    static public int totalAmmo = 20;
    private int magAmmo = 5;
    RaycastHit rayCastHit;

    public void AddAmmo()
    {
        totalAmmo += 5;
        textMeshPro.text = magAmmo.ToString() + "/" + totalAmmo.ToString();
    }

    public void Aim()
    {
        if (Input.GetMouseButton(1))
        {
            transform.position = Vector3.Lerp(transform.position, gunUp.position, Time.deltaTime * multi);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, gunDown.position, Time.deltaTime * multi);
        }
    }

    private void Shoot()
    {
        shootCooldown = 2f;
        audioSourceShoot.Play();
        animator.Play("Shoot");
        magAmmo--;
        textMeshPro.text = magAmmo.ToString() + "/" + totalAmmo.ToString();

        Ray ray = new(transform.position, head.forward * 20f);
        if (Physics.Raycast(ray, out rayCastHit, enemy))
        {
            if(rayCastHit.collider.gameObject.CompareTag("Enemy"))
            {
                rayCastHit.collider.SendMessageUpwards("TakeDmg");
            }
        }
    }

    public void BulletSound()
    {
        audioSourceBullet.Play();
    }

    public void ReloadEnd()
    {
        isReloading = false;
    }

    public void ReloadStart()
    {
        isReloading = true;
    }

    public void Reload()
    {
        magAmmo++;
        totalAmmo--;
        textMeshPro.text = magAmmo.ToString() + "/" + totalAmmo.ToString();
        if (magAmmo >= 5)
        {
            animator.SetTrigger("PutBack");
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameMenuScript.isPaused)
        {
            shootCooldown -= Time.deltaTime;
            cdImage.fillAmount = shootCooldown / 2f;
            if (!isReloading)
            {
                Aim();
                if (totalAmmo > 0) {
                    if (Input.GetMouseButtonDown(0) && shootCooldown < 0)
                    {
                        if (magAmmo > 0)
                        {
                            Shoot();
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.R) && shootCooldown < 0 && magAmmo < 5)
                    {
                        animator.Play("Reload");
                    }
                }
                
            }

        }
    }
}
