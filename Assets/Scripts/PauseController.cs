using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject choices;

    public void pause(){
        choices.SetActive(true);
        choices.GetComponent<ChoiceGenerator>().generate();
        Time.timeScale = 0;
    }

    public void resume() {
        choices.SetActive(false);
        Time.timeScale = 1;
    }
}