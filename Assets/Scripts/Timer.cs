using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float gameTime = 30f; // Total game time in seconds . 
    public Text timerText;   // text of timer.
    public GameObject gameoverPanel; //The text that will appear in case of time end.
    public GameObject player;
    public AudioSource audioSource;  //AudioSource:A representation of audio sources in 3D.

    public static float currentTime; // Current time left in the game .

    void Start()  // execute in start of game.
    {
        timerText = GetComponent<Text>();  //Fetch the Text from the GameObject.
        currentTime = gameTime;        // Current time equal Total game time.
        GetComponent<AudioSource>().Play(); //Fetch the AudioSource from the GameObject  and Play the audio.
    }
    void Update()  // Update is called once per frame.
    {
        currentTime -= Time.deltaTime;  // decrease a timer value based on the elapsed time since the last frame.
        Updatetimer();  // call update time function .

        if (Accident.health == 0 || End.winner == true  )
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0);   //stop timer when lose or win

        else if (currentTime <= 0)   // if time end,we will do the following.
        {
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0); // represent current time equal zero.

            gameoverPanel.SetActive(true); // activate gameover panel.
            audioSource.clip = null; //determines the audio clip that will be played next.
            audioSource.Play(); //Play the audio you attach to the AudioSource component.
            Destroy(player);  // hide the player.
        }
    }

    void Updatetimer()  //update timergame
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);  //calculate minutes from current time and floor.
        int seconds = Mathf.FloorToInt(currentTime % 60f);  // calculate seconds from current time and floor.
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // represent of minutes and seconds.
    }

    public void RestartTimer()  //when reload game
    {
        currentTime = gameTime; //return to value of game Time.
        gameoverPanel.SetActive(false);  //deactivate gameover panel.
    
    }
}