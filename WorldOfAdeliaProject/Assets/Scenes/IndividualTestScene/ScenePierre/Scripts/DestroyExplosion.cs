using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(), SFB_SoundManager.SoundFX.DestroyBullet);
        StartCoroutine(makeDisappearExplosion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator makeDisappearExplosion()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
