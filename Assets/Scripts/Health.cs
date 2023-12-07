using UnityEngine;

public class Health : MonoBehaviour
{
    public  GameObject[] healthUI = new GameObject[3];  //array consists of 3 elements.
    // this represent the three boxes as 3 chances.    
 
    // Update is called once per frame
    void Update()
    {
        switch (Accident.health)
        {
            case 2:  // if health=2
                healthUI[2].SetActive(false); // deactivate 3rd square.
                break;
            case 1:  // if health=1
                healthUI[1].SetActive(false); //deactivate 2nd square.
                break;
            case 0: // if health=0
                healthUI[0].SetActive(false); //deactivate 1st square.
                break;
        }
    }

    public void RestartHealth()  //when reload game.
    {
        Accident.health = 3;   // return 3 chances.
        for(int i = 0; i < 3; i++){
            healthUI[i].SetActive(true);  // activate all squares.
        }
      }
}
