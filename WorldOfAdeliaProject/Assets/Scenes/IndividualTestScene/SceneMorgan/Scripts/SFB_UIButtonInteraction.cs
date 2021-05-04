using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace DefaultNamespace
{
    public class UIButtonInteraction : MonoBehaviour
    {
        public Text textButton;

        public void ChangeColour()
        {
            textButton.color = new Color(111, 111, 115);
        }
    }
}