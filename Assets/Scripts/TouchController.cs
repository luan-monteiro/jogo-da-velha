using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public GameObject bolinha;
    public GameObject xis;
    public GameObject game_controller;
    GameController game_controller_component;
    public GameObject parent_bolinha_and_xis;
    public bool x_turn = false;
    public int filled_with = 0;
    public bool filled = false;
    

    // Start is called before the first frame update
    void Start()
    {
       game_controller_component = game_controller.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (filled == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (x_turn)
                {
                    var X = Instantiate(xis, transform.position, transform.rotation);
                    X.transform.parent = parent_bolinha_and_xis.transform;
                    filled_with = 1;
                    game_controller_component.update_whose_turn();
                    filled = true;
                }
                else
                {
                    var O = Instantiate(bolinha, transform.position, transform.rotation);
                    O.transform.parent = parent_bolinha_and_xis.transform;
                    filled_with = 2;
                    game_controller_component.update_whose_turn();
                    filled = true;
                }
            }
        }
    }
}
