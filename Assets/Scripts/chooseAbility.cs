using UnityEngine;

public class chooseAbility : MonoBehaviour{
    public int choice;
    public PauseController pauseController;

    public addAbility addAbility;

    public void choose(){
        pauseController.resume();
        addAbility.add(choice);
    }
}
