using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool isOpen = false;
    float timePassed = 0;
    public AudioClip openClip;
    public AudioClip openCompleteClip;
    public AudioClip closeClip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if (timePassed < 1)
            {
                transform.rotation = Quaternion.AngleAxis(timePassed * 120, Vector3.up);
            }
            else if (timePassed < 5 && timePassed > 4)
            {
                transform.rotation = Quaternion.AngleAxis(120*(5-timePassed), Vector3.up);
            }
            else if(timePassed > 5)
            {
                audioSource.clip = closeClip;
                audioSource.Play();
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                isOpen = false;
            }
            else
            {
                audioSource.clip = openCompleteClip;
                audioSource.Play();
                transform.rotation = Quaternion.AngleAxis(120, Vector3.up);
            }
        }
        timePassed += Time.deltaTime;
    }

    public void openDoor()
    {
        if (!isOpen)
        {
            audioSource.clip = openClip;
            audioSource.Play();
            isOpen = true;
            timePassed = 0;
        }
    }
}
