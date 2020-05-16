using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhoseTurnImageController : MonoBehaviour
{
    Image image_component;
    public Sprite x;
    public Sprite o;
    public bool x_turn = true;

    // Start is called before the first frame update
    void Start()
    {
        image_component = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!x_turn)
        {
            image_component.sprite = x;
        }
        else
        {
            image_component.sprite = o;
        }
    }
}
