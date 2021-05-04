using UnityEngine;
using UnityEngine.UI;

public class MuteInteractionControllerMenu : MonoBehaviour {

    public void SliderInteraction(bool toggleState) {

        GetComponent<Slider>().interactable = !toggleState;
    }
}
