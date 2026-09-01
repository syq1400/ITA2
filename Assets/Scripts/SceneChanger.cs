using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;
    public Animator fadeOut;
    public float fadeTime = 5f;

    private void Start()
    {
        //Debug.Log("working1");
    }
    
    private void OnTriggerEnter2D(Collider2D  other)
    {
        Debug.Log("working2");

        if (other.gameObject.CompareTag("Player"))
        {
            fadeOut.Play("FadeToWhite");
            StartCoroutine(DelayedFadeOut());
        }
    }

    IEnumerator DelayedFadeOut()
    {
        Debug.Log("working3");
        yield return new WaitForSeconds(fadeTime);
        
        SceneManager.LoadScene(sceneToLoad);
        
    }
}
