using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grid : MonoBehaviour
{

    [SerializeField] EventSystem eventSystem;
    [SerializeField] PuzzleSlotRow[] puzzleGrid;


    private void Start()
    {
        if (!eventSystem)
            eventSystem = FindObjectOfType<EventSystem>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            UIShot();
        }
    }

    private bool IsPuzzleComplete()
    {
        for (int i = 0; i < puzzleGrid.Length; i++)
        {
            for (int j = 0; j < puzzleGrid[i].row.Length; j++)
            {
                if (!puzzleGrid[i].row[j].CheckSolved())
                {
                    return false;
                }
            }
        }
        return true;
    }

    [System.Serializable]
    private struct PuzzleSlotRow
    {
        public PuzzleSlot[] row;
    }


    public void UIShot()
    {
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        
        if (raycastResults.Count > 0)
        {
            foreach (RaycastResult result in raycastResults)
            {
                PuzzleSlot puzzleSlot = result.gameObject.GetComponent<PuzzleSlot>();
                if (puzzleSlot)
                {
                    puzzleSlot.AdvanceIcon();
                }
            }
        }
    }

}
