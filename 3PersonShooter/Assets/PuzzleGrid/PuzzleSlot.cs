using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PuzzleSlot : MonoBehaviour
{
    bool solved;
    [SerializeField] Icon solvedIcon;
    [SerializeField] Icon[] iconRotation;
    Icon currentIcon;
    byte currentIconIndex;

    public byte CurrentIconIndex
    {
        get => currentIconIndex; set
        {
            currentIconIndex = value;
            CurrentIcon = iconRotation[currentIconIndex];
        }
    }

    public Icon CurrentIcon { get => currentIcon; set => currentIcon = value; }

    public bool CheckSolved()
    {
        if(solvedIcon.iconID == CurrentIcon.iconID)
        {
            solved = true;
        }
        else
        {
            solved = false;
        }
        return solved;
    }

    public void AdvanceIcon()
    {
        GetComponent<Image>().color = new Color(Random.value, Random.value, Random.value, 1);
        //CurrentIconIndex++;
    }

}


