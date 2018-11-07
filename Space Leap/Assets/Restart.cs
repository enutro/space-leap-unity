using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class Restart : MonoBehaviour
{

    private Button button;
    AudioSource audioData;
    RectTransform rectTransform;
    void Start()
    {
        audioData = GetComponent<AudioSource>();

        button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Screen.width / 1.4f, Screen. height / 9);
        rectTransform.position = new Vector3(Screen.width / 2, Screen.height/1.7f, 0);
    }

    void TaskOnClick()
    {
        audioData.Play(0);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        Debug.Log("Hello");

    }
}