using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// the new scene changing
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float m_timer = 300;
    public Text m_timerText;


	// Use this for initialization
	void Start ()
    {
        m_timerText.GetComponent<Text>();
	}
	

	// Update is called once per frame
	void Update ()
    {
        m_timer -= Time.deltaTime;
        m_timerText.text = m_timer.ToString("f0");

        if(m_timer <= 0)
        {
            // the new scene changing
            SceneManager.LoadScene("TimerGameOver");
        }

	}
}
