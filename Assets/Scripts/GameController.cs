using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject[] quadrantes;
    public GameObject whose_turn_image;
    public Transform bolinha_and_xis_place_holder;

    public int who_won;
    public bool nobody_won = true;

    public GameObject text_gameobject;
    public Text won_text;

    public string bolinha_won_message = "O won!";
    public string xis_won_message = "X won!";

    //Linhas
    public List<int> linha1;
    public List<int> linha2;
    public List<int> linha3;

    //Colunas
    public List<int> coluna1;
    public List<int> coluna2;
    public List<int> coluna3;

    //Diagonal
    public List<int> diagonal1;
    public List<int> diagonal2;

    public List<List<int>> matriz_do_board = new List<List<int>>();

    // Start is called before the first frame update
    void Start()
    {
        won_text = text_gameobject.GetComponent<Text>();

        matriz_do_board.Add(linha1);
        matriz_do_board.Add(linha2);
        matriz_do_board.Add(linha3);
        matriz_do_board.Add(coluna1);
        matriz_do_board.Add(coluna2);
        matriz_do_board.Add(coluna3);
        matriz_do_board.Add(diagonal1);
        matriz_do_board.Add(diagonal2);
    }

    // Update is called once per frame
    void Update()
    {
        if (nobody_won)
        {
            won_text.text = "";
            update_lines_filled_with_values(out linha1, out linha2, out linha3);
            update_columns_filled_with_values(out coluna1, out coluna2, out coluna3);
            update_diagonals_filled_with_values(out diagonal1, out diagonal2);
            if (somebody_won(matriz_do_board, out who_won))
            {
                switch (who_won)
                {
                    case 1:
                        won_text.text = xis_won_message;
                        won_text.enabled = true;
                        foreach (GameObject quadrante in quadrantes)
                        {
                            quadrante.GetComponent<TouchController>().filled = true;
                        }
                        nobody_won = false;
                        break;
                    case 2:
                        won_text.text = bolinha_won_message;
                        won_text.enabled = true;
                        foreach (GameObject quadrante in quadrantes)
                        {
                            quadrante.GetComponent<TouchController>().filled = true;
                        }
                        nobody_won = false;
                        break;
                }
            }
        }

    }

    void update_lines_filled_with_values(out List<int> Linha1, out List<int> Linha2, out List<int> Linha3)
    {
        Linha1 = new List<int>();
        Linha2 = new List<int>();
        Linha3 = new List<int>();

        //Pegando filled_with values para a linha1 e colocando na váriavel linha3
        for (int i = 0; i < 3; i++)
        {
            Linha1.Add(quadrantes[i].GetComponent<TouchController>().filled_with);
        }

        //Pegando filled_with values para a linha2 e colocando na váriavel linha3
        for (int i = 3; i < 6; i++)
        {
            Linha2.Add(quadrantes[i].GetComponent<TouchController>().filled_with);
        }

        //Pegando filled_with values para a linha3 e colocando na váriavel linha3
        for (int i = 6; i < 9; i++)
        {
            Linha3.Add(quadrantes[i].GetComponent<TouchController>().filled_with);
        }

        //Dando um update na matriz do board
        update_matriz_do_board();
    }

    //Este método só pode ser chamado depois que os valores das linhas foram atualizados
    void update_columns_filled_with_values(out List<int> Coluna1, out List<int> Coluna2, out List<int> Coluna3)
    {
        Coluna1 = new List<int>();
        Coluna2 = new List<int>();
        Coluna3 = new List<int>();

        //Pegando valores da coluna1 através dos valores das linhas
        Coluna1.Add(linha1[0]);
        Coluna1.Add(linha2[0]);
        Coluna1.Add(linha3[0]);

        //Pegando valores da coluna2 através dos valores das linhas
        Coluna2.Add(linha1[1]);
        Coluna2.Add(linha2[1]);
        Coluna2.Add(linha3[1]);

        //Pegando valores da coluna3 através dos valores das linhas
        Coluna3.Add(linha1[2]);
        Coluna3.Add(linha2[2]);
        Coluna3.Add(linha3[2]);

        //Dando um update na matriz do board
        update_matriz_do_board();
    }

    //Este método só pode ser chamado depois que os valores das linhas foram atualizados
    void update_diagonals_filled_with_values(out List<int> Diagonal1, out List<int> Diagonal2)
    {
        Diagonal1 = new List<int>();
        Diagonal2 = new List<int>();

        //Pegando valores da diagonal1 através dos valores das linhas
        Diagonal1.Add(linha1[0]);
        Diagonal1.Add(linha2[1]);
        Diagonal1.Add(linha3[2]);

        //Pegando valores da diagonal2 através dos valores das linhas
        Diagonal2.Add(linha1[2]);
        Diagonal2.Add(linha2[1]);
        Diagonal2.Add(linha3[0]);

        //Dando um update na matriz do board
        update_matriz_do_board();
    }

    //Neste método é utilizado um algoritmo que verifica se em alguma das linhas/colunas/diagonais todos os números são iguais, caso isso aconteça um dos jogadores ganhou
    bool somebody_won(List<List<int>> MatrizDoBoard, out int WhoWon)
    {
        WhoWon = 0;
        int numero_anterior = 0;
        foreach (List<int> list in MatrizDoBoard){
            //O número anterior começa sendo três, esse é o valor que utilizaremos como padrão para nulo
            for (int i = 0; i < list.Count; i++)
            {
                if (i != 0)
                {
                    if(list[i] != numero_anterior || list[i] == 0)
                    {
                        break; //Saímos do loop caso a sequência de números for diferente entre si
                    }
                }
                if(i == 2)
                {
                    WhoWon = list[i];
                    return true;
                }

                numero_anterior = list[i];
            }
        }
        WhoWon = 0;
        return false;
    }

    void update_matriz_do_board()
    {
        matriz_do_board.Clear();
        matriz_do_board.Add(linha1);
        matriz_do_board.Add(linha2);
        matriz_do_board.Add(linha3);
        matriz_do_board.Add(coluna1);
        matriz_do_board.Add(coluna2);
        matriz_do_board.Add(coluna3);
        matriz_do_board.Add(diagonal1);
        matriz_do_board.Add(diagonal2);
    }

    public void update_whose_turn()
    {
        foreach(GameObject quadrante in quadrantes)
        {
            quadrante.GetComponent<TouchController>().x_turn = !quadrante.GetComponent<TouchController>().x_turn;
        }
        whose_turn_image.GetComponent<WhoseTurnImageController>().x_turn = !whose_turn_image.GetComponent<WhoseTurnImageController>().x_turn;
    }
    public void play_again()
    {
        linha1.Clear();
        linha2.Clear();
        linha3.Clear();
        coluna1.Clear();
        coluna2.Clear();
        coluna3.Clear();
        diagonal1.Clear();
        diagonal2.Clear();
        matriz_do_board.Clear();

        foreach (Transform child in bolinha_and_xis_place_holder)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach(GameObject quadrante in quadrantes)
        {
            quadrante.GetComponent<TouchController>().filled = false;
            quadrante.GetComponent<TouchController>().filled_with = 0;
        }
        nobody_won = true;
    }
}
