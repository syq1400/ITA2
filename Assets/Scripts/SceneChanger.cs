using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;
    public Animator fadeOut;
    public float fadeTime = 5f;
    public Vector2 newPlayerLocation;
    private Transform _player;
    
    private void OnTriggerEnter2D(Collider2D  other)
    {
        //Debug.Log("working2");

        if (other.gameObject.CompareTag("Player"))
        {
            _player = other.transform;
            fadeOut.Play("FadeToWhite");
            StartCoroutine(DelayedFadeOut());
        }
    }

    IEnumerator DelayedFadeOut()
    {
        //Debug.Log("working3");
        yield return new WaitForSeconds(fadeTime);
        
        _player.position = newPlayerLocation;
        SceneManager.LoadScene(sceneToLoad);
        
    }
}
