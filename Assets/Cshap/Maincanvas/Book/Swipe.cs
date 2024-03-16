using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public Vector2 RectY;
    public float result1;
    public float result2;
    public float result3;

    private Vector2 SlideDown;
    private Vector2 Slideing;
    private Vector2 SlideInit;
    private RectTransform BookScrollArray;

    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        SlideInit = transform.position;
        rect = GetComponent<RectTransform>();
        RectY = rect.position;
        BookScrollArray = gameObject.transform.parent.GetComponent<RectTransform>();
        //BookScrollArray = GameObject.Find("BookScrollArray").GetComponent<RectTransform>();
     /*   GetMouseButtonDown
        GetMouseButton
        GetMouseButtonUp*/
        /*Vector3 mousePos = Input.mousePosition;*/
        /* Vector2 wheelInput2 = Input.mouseScrollDelta;*/
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.anyKey){
            if(Input.GetMouseButtonDown(0)){
                Debug.Log("입력");
                SlideDown = Input.mousePosition;
            }
            if(Input.GetMouseButton(0)){
                Debug.Log("입력 중");

                gameObject.transform.Translate(0, (-SlideDown.y + Input.mousePosition.y)/10, 0);
                //기본 좌표가 

                if(rect.position.y < RectY.y){
                    rect.position = new Vector2(rect.position.x, RectY.y);
                } else 
                
                if(rect.rect.height < rect.position.y + (BookScrollArray.rect.height/2)){
                    if(BookScrollArray.rect.height > rect.rect.height){
                        rect.position = new Vector2(rect.position.x, -rect.rect.height + rect.rect.height + RectY.y);
                    } else {
                        rect.position = new Vector2(rect.position.x, rect.rect.height - (BookScrollArray.rect.height/2)+25);
                    }
                }
/*
                if(RectY.y + rect.rect.height < RectY.y + rect.position.y){
                    Debug.Log("발동");
                    if(BookScrollArray.rect.height > rect.rect.height){
                    rect.position = new Vector2(rect.position.x, -rect.rect.height + BookScrollArray.rect.height);
                    } else {
                        rect.position = new Vector2(rect.position.x, -rect.rect.height + rect.rect.height + RectY.y);
                    }
                }
                */  
            }

            if(Input.GetMouseButtonUp(0)){
                Debug.Log("터치 해제");
                
            }
        }
    }
}
