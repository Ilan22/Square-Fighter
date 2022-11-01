using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PauseController : MonoBehaviour
{
    public GameObject choices;

    public PostProcessVolume volume;
    private DepthOfField dof = null;

    private void Start(){
        volume.profile.TryGetSettings(out dof);
    }

    public void pause(){
        dof.enabled.value = enabled;
        choices.SetActive(true);
        choices.GetComponent<ChoiceGenerator>().generate();
        Time.timeScale = 0;
    }

    public void resume() {
        dof.enabled.value = !enabled;
        choices.SetActive(false);
        Time.timeScale = 1;
    }
}