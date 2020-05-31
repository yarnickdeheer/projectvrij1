using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calmness : MonoBehaviour
{
    public GameObject Text;
    public Image bar;
    [HideInInspector]public float Cmeter= 0;
    private float maxM;
    private float minM;
    public bool save = false;
    public Image foto;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        minM = 0;
        maxM = 365;
        Text.SetActive(false);
   
    }

    // Update is called once per frame
    void Update()
    {
        bar.rectTransform.sizeDelta = new Vector2(Cmeter, 70.72f);
        if (Cmeter <= minM)
        {
            Cmeter = minM;
        }
        else if (Cmeter >= maxM)
        {
            Cmeter = maxM;
        }
        if (Input.GetKey(KeyCode.E) && save == true)
        {
            Cmeter = Cmeter - 5;
        }


        if (Cmeter <= 121)
        {
            foto.sprite = sprites[0];
        }
        else if(Cmeter > 121 && Cmeter < 242){
            foto.sprite = sprites[1];
        }
        else if (Cmeter > 242 && Cmeter <= 365)
        {
            foto.sprite = sprites[2];
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "hiding")
        {
            Text.SetActive(true);
            save = true;
           
        }
    }
      
private void OnTriggerExit(Collider coll)
{
    if (coll.gameObject.tag == "hiding")
    {
        Text.SetActive(false);
            save = false;
    }
}
}
