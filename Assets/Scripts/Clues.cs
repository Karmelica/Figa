using System.Collections;
using UnityEngine;

public class Clues : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject Enemy;
    public GameObject shotgunPickup;
    public GameObject shotgunText;

    public GameObject bonesEq;
    public GameObject figsEq;
    public GameObject noteEq;
    public GameObject clothesEq;
    private GameObject currentGobject;

    private int pickCount = 0;
    private bool canPick = false;
    private bool shotgunPicked = false;
    public GameObject text;
    private Collider currentColli;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Note"))
        {
            currentGobject = noteEq;
            currentColli = other;
            text.SetActive(true);
            canPick = true;

        }
        if (other.gameObject.CompareTag("Figa"))
        {
            currentGobject = figsEq;
            currentColli = other;
            text.SetActive(true);
            canPick = true;

        }
        if (other.gameObject.CompareTag("Bone"))
        {
            currentGobject = bonesEq;
            currentColli = other;
            text.SetActive(true);
            canPick = true;

        }
        if (other.gameObject.CompareTag("Clothes"))
        {
            currentGobject = clothesEq;
            currentColli = other;
            text.SetActive(true);
            canPick = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            text.SetActive(false);
            canPick = false;

        }
        if (other.gameObject.CompareTag("Figa"))
        {
            text.SetActive(false);
            canPick = false;

        }
        if (other.gameObject.CompareTag("Bone"))
        {
            text.SetActive(false);
            canPick = false;

        }
        if (other.gameObject.CompareTag("Clothes"))
        {
            text.SetActive(false);
            canPick = false;
        }
    }

    private IEnumerator EnemySpawn()
    {
        shotgunText.SetActive(true);
        shotgunPickup.SetActive(true);
        yield return new WaitForSeconds(7f);
        Enemy.SetActive(true);
    }

    private void Update()
    {
        if (canPick)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickCount++;
                currentGobject.SetActive(true);
                currentColli.gameObject.SetActive(false);
                text.SetActive(false);
                canPick = false;
            }
        }

        if (pickCount == 4 && !shotgunPicked)
        {
            shotgunPicked = true;
            audioSource.Play();
            StartCoroutine(EnemySpawn());
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pickCount = 0;
        bonesEq.SetActive(false);
        figsEq.SetActive(false); ;
        noteEq.SetActive(false); ;
        clothesEq.SetActive(false); ;
        shotgunPickup.SetActive(false);
    }

}
