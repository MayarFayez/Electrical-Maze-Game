using UnityEngine;
public class End : MonoBehaviour {
	//GameObject:Base class for all entities in Unity Scenes.
	public GameObject winPanel;  // The text that will appear in case of win.
	public AudioSource audioSource;  //AudioSource:A representation of audio sources in 3D.
	public AudioClip winClip; //AudioClip: A container for audio data.
	//Note : AudioClips are referenced and used by AudioSources to play sounds.
	public static bool winner; // states of player (winner=true,failer=false).

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag == "Player") {  //If the player reaches the end point, we will do the following.

			GetComponent<AudioSource>().Play(); //Fetch the AudioSource from the GameObject and play audio.
			
			winner = true;    // states of player is winner.

			winPanel.SetActive(true);  //activate winpanel.

			audioSource.clip = winClip;  //determines the audio clip that will be played next.
			audioSource.Play();  //Play the audio you attach to the AudioSource component.

			Destroy(col.gameObject);  // hide the player after winning.
		}
	}

	public void Restart()   //when reload game.
    {
        winner = false;  // states of player is failer.

    }


}
