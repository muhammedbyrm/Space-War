using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DestroyObstacles : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;
    [SerializeField] AudioSource audioSource;

    [SerializeField] private TextMeshProUGUI scoreText; 
    private GameObject[] smallObstacles;
    private GameObject[] bigObstacles;

    private void Start()
    {
        audioSource.clip = sounds[0];
        scoreText.text = (Score.totalScore).ToString();
    }

    private void Update()
    {
        smallObstacles = GameObject.FindGameObjectsWithTag("SmallObstacle");
        bigObstacles = GameObject.FindGameObjectsWithTag("BigObstacle");

        if (smallObstacles.Length == 0 && bigObstacles.Length == 0)
        {

            if (SceneManager.GetActiveScene().name == "FirstLevel")
            {          
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);               
            }

            else {            
                    SceneManager.LoadScene("Win");    
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SmallObstacle")
        {
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(collision.gameObject);
            Score.totalScore += 10;
            scoreText.text = (Score.totalScore).ToString();
        }
        else if (collision.gameObject.tag == "BigObstacle")
        {
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(collision.gameObject);
            Score.totalScore += 50;
            scoreText.text = (Score.totalScore).ToString();
        }
    }
}
