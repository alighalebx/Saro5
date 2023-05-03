using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Collisionhi : MonoBehaviour
{
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;

    [SerializeField] ParticleSystem successParticles;

    [SerializeField] ParticleSystem crashParticles;


    AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        BTSH8ALelFunctions(other);

    }

    private void BTSH8ALelFunctions(Collision other)
    {
        switch (other.gameObject.tag)
        {

            case "Friendly":
                Debug.Log("friendly");
                break;

            case "Finish":

                StartSuccessSequence();
                Debug.Log("Finished!");
                break;

            default:
                StartCrachSequence();
                Debug.Log("Sorry!");
                break;

        }
    }

    void StartSuccessSequence(){

        successParticles.Play();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1f);

    }


    void StartCrachSequence(){

        crashParticles.Play();
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("Reload", 1f);

    }


    void LoadNextLevel(){

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings){

            nextSceneIndex = 0;

        }

        SceneManager.LoadScene(nextSceneIndex);

    }

    void Reload(){

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


        Debug.Log(currentSceneIndex.ToString());

        SceneManager.LoadScene(currentSceneIndex);

    }
}
