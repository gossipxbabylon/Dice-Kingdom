using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject button, buttonReady1, buttonReady2, textPlayer2;

    public bool selected, ready1, ready2;
    public bool[] selectedCharacter;
    public Text selectedText;

    private int index, aux, player, index1, index2;

    void Start()
    {
        selectedText.text = "Select?";
        index = 0;
        aux = -2;
        player = 1;
    }

    void Update()
    {
        if (aux == -1)
        {
            characters[index].SetActive(true);
        }
    }

    public void ActivateTarget(int idx)
    {
        ActiveTargetAux(idx);
    }

    public void DeactivateTarget(int idx)
    {
        DeactiveTargetAux(idx);
    }

    public void onButtonClick()
    {
        if (player == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i != aux)
                    selectedCharacter[i] = false;
            }
            buttonReady1.SetActive(true);
        }
        else
        {
            for (int i = 6; i < 12; i++)
            {
                if (i != aux)
                    selectedCharacter[i] = false;
            }
            buttonReady2.SetActive(true);
        }

        selected = true;
        selectedCharacter[aux] = true;
        index = aux;
        selectedText.text = "Selected";
        buttonReady1.SetActive(true);
    }

    public void onButtonReadyClick()
    {
        if (player == 1)
        {
            player = 2;
            index1 = index;
            textPlayer2.SetActive(true);
            ready1 = true;
        }else if (player == 2)
        {
            player = 3;
            index2 = index;
            ready2 = true;
        }
    }

    private void ActiveTargetAux(int a)
    {
        if (player == 1)
        {
            characters[index].SetActive(false);
            characters[a].SetActive(true);
            button.SetActive(true);
            aux = a;

            if (index != aux)
            {
                selectedText.text = "Select?";
            }
            else
            {
                selectedText.text = "Selected";
            }

        }
        else if (player == 2)
        {
            if (index != index1)
                characters[index].SetActive(false);
            characters[a+6].SetActive(true);
            button.SetActive(true);
            aux = a + 6;

            if (index != aux)
            {
                selectedText.text = "Select?";
            }
            else
            {
                selectedText.text = "Selected";
            }
        }

    }

    private void DeactiveTargetAux(int a)
    {
        if (player == 1)
        {
            button.SetActive(false);

            if (selected)
            {
                aux = -1;
                if (index == a)
                    return;
            }
            else
            {
                aux = -2;
            }
                
            characters[a].SetActive(false); 
            
        }else if (player == 2)
        {
            button.SetActive(false);

            if (selected)
            {
                aux = -1;
                if (index == (a+6))
                    return;
            }
            else
            {
                aux = -2;
            }

            characters[a+6].SetActive(false);

            
            
        }

        if (ready1)
            buttonReady1.SetActive(false);
        if (ready2)
            buttonReady2.SetActive(false);
        if (selected)
            button.SetActive(false);
    }
}
