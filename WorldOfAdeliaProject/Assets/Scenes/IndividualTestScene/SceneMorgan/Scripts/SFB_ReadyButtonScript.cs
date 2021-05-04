using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyButtonScript : MonoBehaviour
{
    private bool isWorks;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isWorks = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isWorks = false;
    }
    

    void Update()
    {
        if (isWorks)
        {
            
        }
    }
    
}
