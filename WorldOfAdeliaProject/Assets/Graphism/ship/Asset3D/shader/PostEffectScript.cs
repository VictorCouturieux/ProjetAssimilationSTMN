using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour {

    public Material mat;
    
    void OnRenderImage(RenderTexture src, RenderTexture dest) {

//        Color[] pixels = new Color[1920 * 1080];
//
//        for (int i = 0; i < 1920; i++) {
//            for (int j = 0; j < 1080; j++) {
//                pixels[i + j * 1080].r = Mathf.Pow(2.18f, 3.17f);
//            }
//        }
        
        Graphics.Blit(src, dest, mat);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
