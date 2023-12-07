using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Accident : MonoBehaviour {
	public GameObject redPanel; // The panel that will appear in case of win.
	public GameObject losePanel; // The text that will appear in case of lose.
	public float redTime = .3f; // Time display red panel before the three chances were lost.
	public AudioSource audioSource; //AudioSource:A representation of audio sources in 3D.
	public AudioClip loseClip; //AudioClip: A container for audio data.
	//Note : AudioClips are referenced and used by AudioSources to play sounds.
	public static int health = 3; // number of chances.
	
	
	void OnCollisionEnter2D (Collision2D col){

		if (col.gameObject.tag == "Wall") { //If the player gets stuck in the maze,we will do the following.

			StartCoroutine(Red()); //Warnning
			//allow you to execute code over multiple frames, allowing for more flexibility and control over the execution of certain tasks.

			GetComponent<AudioSource>().Play(); //Fetch the AudioSource from the GameObject and play audio.

			health--; //lose chance.

            if (health <= 0 ) //When you lose all chance, call 'lose function'.
            {
				StartCoroutine(lose());				

            }
		}	
	}

	IEnumerator Red()
	{
		redPanel.SetActive(true);  //activate redpanel.
		yield return new WaitForSeconds(redTime); //to pause for the specified duration of redTime seconds.
		redPanel.SetActive(false); //deactivate redpanel.
	}

	IEnumerator lose()  //delay between losepanel and loading 'exit scene'.
    {
		losePanel.SetActive(true);  //activate losepanel.
		audioSource.clip = loseClip; //determines the audio clip that will be played next.
		audioSource.Play();  //Play the audio you attach to the AudioSource component.
		yield return new WaitForSeconds(2f);	//to pause for the specified duration of 4 seconds.	
		losePanel.SetActive(false);  //deactivate losepanel.
		SceneManager.LoadScene("exit"); // load exit scene.
    }
}
