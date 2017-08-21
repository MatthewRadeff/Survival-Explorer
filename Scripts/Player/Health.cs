using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Image m_healthBar;
    private float m_tempHealth = 1.0f;


    public float m_health = 100f;
    public Text m_healthText;


    private int m_signalPercentage = 0;
    public Text m_signalStrengthText;
    public Text m_signalSentenceText;


    // when the player collects food to gain health
    private AudioSource soundHealthClip;
    public AudioClip healthClip;

    // when player gets hit 
    private AudioSource soundHurtClip;
    public AudioClip hurtClip;


    // when player collects signals
    private AudioSource soundSignalClip;
    public AudioClip signalClip;



    void Awake()
    {
        soundHealthClip = GetComponent<AudioSource>();
        soundHurtClip = GetComponent<AudioSource>();
        soundSignalClip = GetComponent<AudioSource>();
    }


	// Use this for initialization
	void Start ()
    {

        m_healthBar = GameObject.Find("Canvas").transform.FindChild("Health Bar").GetComponent<Image>();
        m_signalStrengthText = GameObject.Find("Canvas").transform.FindChild("signals left").GetComponent<Text>();
        m_signalSentenceText = GameObject.Find("Canvas").transform.FindChild("sentence").GetComponent<Text>();
        m_healthText.GetComponent<Text>();

    }
	
	
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            if(m_tempHealth > 0  && (m_tempHealth != 0 || m_tempHealth < 0))
            {
                m_tempHealth -= 0.05f;
                m_healthBar.fillAmount = m_tempHealth;
                //Debug.Log(m_tempHealth);
                soundHurtClip.PlayOneShot(hurtClip, 1f);

                m_health -= 0.05f * 100f;
                m_healthText.text = m_health.ToString("f0");
            }
            else
            {
                //Application.LoadLevel("GameOver");.....too old...

                // new one
                SceneManager.LoadScene("GameOver");

            }
        }
        if(other.gameObject.CompareTag("Food"))
        {
            
            if ((m_tempHealth > 0 && m_tempHealth != 1f) && (m_tempHealth != 0 || m_tempHealth < 0))
            {
                soundHealthClip.PlayOneShot(healthClip, 1f);
                m_tempHealth += 0.05f;
                m_healthBar.fillAmount = m_tempHealth;
                Destroy(other.gameObject);
                //Debug.Log(m_tempHealth);
                m_health += 0.05f * 100f;
                m_healthText.text = m_health.ToString("f0");

            }

        }

        if(other.gameObject.CompareTag("Signal"))
        {
            m_signalPercentage += 4;
            m_signalStrengthText.text = m_signalPercentage.ToString();
            soundSignalClip.PlayOneShot(signalClip, 1f);
            Destroy(other.gameObject);

            if(m_signalPercentage == 100)
            {
                //Application.LoadLevel("Win");
                SceneManager.LoadScene("Win");
            }

        }


    }




}
