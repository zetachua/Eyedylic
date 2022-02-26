using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectRandomMovement : MonoBehaviour
{

    RectTransform canvas;
    RectTransform currentObj;
    public GameObject canvasObject;
    public float speed;
    public float horizontalSpeedMultiplier = 1f; // +1 moves right, -1 moves left
    public float verticalSpeedMultiplier = -1f; // +1 moves upward, -1 moves downward

    float UIConst = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        currentObj = gameObject.GetComponent<RectTransform>();
        canvas = canvasObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(horizontalSpeedMultiplier * speed * UIConst, verticalSpeedMultiplier * speed * UIConst, 0f);
        //Debug.Log(gameObject.transform.localPosition);
        if (gameObject.transform.localPosition.y > canvas.rect.height / 2)
        {
            verticalSpeedMultiplier = -1f; // now start moving downward
        }

        if (gameObject.transform.localPosition.y < -canvas.rect.height / 2)
        {
            verticalSpeedMultiplier = 1f; // now start moving upward
        }

        if (gameObject.transform.localPosition.x < -canvas.rect.width / 2)
        {
            horizontalSpeedMultiplier = 1f; // now start moving towards right
        }

        if (gameObject.transform.localPosition.x > canvas.rect.width / 2)
        {
            horizontalSpeedMultiplier = -1f; // now start moving towards left
        }
    }
}
