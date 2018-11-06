using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class Restart : MonoBehaviour
{

    private Button button;
    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();

        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        audioData.Play(0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        Debug.Log("Hello");

    }
}