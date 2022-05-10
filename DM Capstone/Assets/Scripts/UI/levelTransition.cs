using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTransition : MonoBehaviour
{
    public GameObject playerBody;
    public GameObject caveFade;
    public Animator caveFadeAnimator;
    public GameObject forestFade;
    public Animator forestFadeAnimator;

    public GameObject mainMusic;
    public AudioClip caveMusic;
    public AudioClip forestMusic;

    public bool goingToCaveSide;

    // Start is called before the first frame update
    void Start()
    {
        /* caveFade = GameObject.FindWithTag("Fade In");
        caveFadeAnimator = caveFade.GetComponent<Animator>();
        forestFade = GameObject.FindWithTag("Fade In");
        forestFadeAnimator = forestFade.GetComponent<Animator>(); */

        //forestFade.SetActive(false);
        goingToCaveSide = true;
    }

    // Update is called once per frame
    void Update()
    {
        checkForTransition();
    }

    void checkForTransition()
    {
        if(playerBody.transform.position.x == 176 && goingToCaveSide)
        {
            goingToCaveSide = false;
            print("cave Fade");
            caveFade.SetActive(false);
            forestFade.SetActive(true);
            caveFadeAnimator.Play("FadeIn", 0, 0);
            mainMusic.GetComponent<AudioSource>().Stop();
            mainMusic.GetComponent<AudioSource>().clip = caveMusic;
            mainMusic.GetComponent<AudioSource>().Play();
        }
        else if(playerBody.transform.position.x == 176 && !goingToCaveSide)
        {
            goingToCaveSide = true;
            print("forest Fade");
            caveFade.SetActive(true);
            forestFade.SetActive(false);
            forestFadeAnimator.Play("FadeIn", 0, 0);
            mainMusic.GetComponent<AudioSource>().Stop();
            mainMusic.GetComponent<AudioSource>().clip = forestMusic;
            mainMusic.GetComponent<AudioSource>().Play();
        }
    }
}
