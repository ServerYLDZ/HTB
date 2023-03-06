using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextColorScript : MonoBehaviour
{
    public GameManagerScript GM;
    RawImage img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {

        // here we do switch case  with  color code  there is important  .........................................
        //also we need matarial array for every NextColorSicript...................................................
        // materyalini   GM Den çekip değiştirebilirim bu yüzden  gm deki  mataryel arrayi bunları içericek.........................................................

        //img.color = GM.NextColor[0];
        img.texture = GM.NextMatarial[0];
    }
   
}
