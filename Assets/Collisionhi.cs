using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Collisionhi : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag){

            case "Friendly":
            Debug.Log("friendly");
            break;

            case "Finish":
            Debug.Log("Finished!");
            break;

            default:
            Reload();
            Debug.Log("Sorry!");
            break;

        }



    }

    void Reload(){

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


        Debug.Log(currentSceneIndex.ToString());

        SceneManager.LoadScene(currentSceneIndex);

    }
}
