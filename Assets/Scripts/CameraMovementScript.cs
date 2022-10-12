using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovementScript : MonoBehaviour
{
    public Vector2[] pos = new Vector2[6];
    // 0 - mines
    // 1 - grass
    // 2 - desert
    // 3 - tundra
    // 4 - moutain
    // 5 -sky
    // 6 - mountain
    public Button[] buttons;
    //0 - left
    //1 - right
    //2 - up
    //3 - down
    public int currentpos = 1; // current position of camera - starts at grassland
    public float duration;
    public bool canClick = true;
    public UnitUIScript ui;
    public GameManager gm;

    public void Start()
    {
        ButtonCheckFunction(currentpos);
    }
    IEnumerator Movement(Vector3 start, float x, float y)
    {
        var target = new Vector3(x, y, -10);
        var elapsed = 0f;

        while(elapsed < duration)
        {
            float t = elapsed / duration;
            t = Mathf.Sin(t * Mathf.PI * .5f);
            transform.position = Vector3.Lerp(start, target, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
        ButtonCheckFunction(currentpos);
        Debug.Log("while done");
        canClick = true;
        yield return null;
        
    }
    public void ButtonCheckFunction(int index)
    {
        switch(index)
        {
            case 0: //mines
                buttons[0].gameObject.SetActive(false);
                buttons[1].gameObject.SetActive(false);
                buttons[2].gameObject.SetActive(true);
                buttons[3].gameObject.SetActive(false);
                ui.unitButtons.SetActive(false);
                ui.mineButtons.SetActive(true);

                break;
                 case 1: //grass
                buttons[0].gameObject.SetActive(false);
                buttons[1].gameObject.SetActive(true);
                buttons[2].gameObject.SetActive(false);
                buttons[3].gameObject.SetActive(true);
                ui.unitButtons.SetActive(true);
                ui.mineButtons.SetActive(false);
                break;
                 case 4: //mountain
                buttons[0].gameObject.SetActive(true);
                buttons[1].gameObject.SetActive(false);
                buttons[2].gameObject.SetActive(true);
                buttons[3].gameObject.SetActive(false);
                break;
                 case 5: //sky
                buttons[0].gameObject.SetActive(false);
                buttons[1].gameObject.SetActive(false);
                buttons[2].gameObject.SetActive(true);
                buttons[3].gameObject.SetActive(true);
                break;
                 case 6: //space
                buttons[0].gameObject.SetActive(false);
                buttons[1].gameObject.SetActive(false);
                buttons[2].gameObject.SetActive(false);
                buttons[3].gameObject.SetActive(true);
                break;
                 default: //anywhere else
                buttons[0].gameObject.SetActive(true);
                buttons[1].gameObject.SetActive(true);
                buttons[2].gameObject.SetActive(false);
                buttons[3].gameObject.SetActive(false);
                break;
        }
        if (currentpos == gm.currentLevel)
        {
            //Debug.Log("current level reached");
            buttons[1].gameObject.SetActive(false);
            buttons[2].gameObject.SetActive(false);
        }
    }

    public void RightArrow()
    {
        if(currentpos < 6 && canClick)
        {
            currentpos += 1;
            canClick = false;
            StartCoroutine(Movement(transform.position, pos[currentpos].x, pos[currentpos].y));
        }
    }

    public void LeftArrow()
    {
        if(currentpos > 0 && canClick)
        {
            currentpos -= 1;
            canClick = false;
            StartCoroutine(Movement(transform.position, pos[currentpos].x, pos[currentpos].y));
        }
    }
}
