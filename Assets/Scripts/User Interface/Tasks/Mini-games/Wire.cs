using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace User_Interface.Tasks
{

    public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        Vector2 startPos;
        Quaternion startRot;
        Quaternion startWireRot;
        Vector2 startWireSize;
        public Image wire;
        bool inSocket;

        Collider2D collider;

        void Start()
        {
            startRot = wire.transform.rotation;

            startPos = wire.transform.position;

            startWireSize = wire.rectTransform.sizeDelta;

            startWireRot = wire.transform.rotation;
        }

        void Update()
        {
            /*Vector2 newPos = Input.mousePosition;

            //transform.position = newPos;

            float dist = Vector2.Distance(startPos, newPos);

            GetComponent<Image>().rectTransform.sizeDelta = new Vector2(dist, GetComponent<Image>().sprite.rect.height);*/
        }

        public void OnDrag(PointerEventData eventData)
        {
            GetComponent<BoxCollider2D>().enabled = true;

            Vector2 newPos = Input.mousePosition;

            //Vector3 newPos = cam.ScreenToWorldPoint(Input.mousePosition);

            //newPos.z = 0;

            //transform.position = newPos;

            //wire.transform.rotation = transform.rotation;

            transform.position = newPos;

            Vector2 dir = newPos - startPos;

            wire.transform.right = dir * transform.lossyScale.x;

            transform.rotation = wire.transform.rotation;

            float dist = Vector2.Distance(startPos, transform.position) / transform.lossyScale.y;

            wire.rectTransform.sizeDelta = new Vector2(dist, wire.rectTransform.sizeDelta.y);

            //wire.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, GetComponent<Image>().sprite.rect.width, dist);

            //GetComponent<Image>().rectTransform.sizeDelta = new Vector2(dist, GetComponent<Image>().sprite.rect.height);

            //wireEnd.size = new Vector2(dist / 100, wireEnd.size.y);

            //wireTempRot = wireEnd.transform.rotation;
        }

        public void OnEndDrag(PointerEventData eventData)
        {




            if (inSocket == true)
            {

                transform.rotation = startRot;

                //wire.transform.rotation = wireTempRot;

                //GetComponent<Image>().color = new Color32(255, 255, 255, 0);

                Vector2 targetPos = collider.transform.position;

                float dist = Vector2.Distance(startPos, targetPos) / transform.lossyScale.y;

                wire.rectTransform.sizeDelta = new Vector2(dist, wire.rectTransform.sizeDelta.y);

                GetComponent<Image>().enabled = false;

                switch (collider.gameObject.name)
                {
                    case "Socket1":
                        {
                            transform.GetComponentInParent<TaskWires>().suggestion[0] = transform.parent.name;

                            transform.GetComponentInParent<TaskWires>().pluggingCount++;

                            transform.GetComponentInParent<TaskWires>().Solve();

                        }
                        break;

                    case "Socket2":
                        {
                            transform.GetComponentInParent<TaskWires>().suggestion[1] = transform.parent.name;

                            transform.GetComponentInParent<TaskWires>().pluggingCount++;

                            transform.GetComponentInParent<TaskWires>().Solve();
                        }
                        break;

                    case "Socket3":
                        {
                            transform.GetComponentInParent<TaskWires>().suggestion[2] = transform.parent.name;

                            transform.GetComponentInParent<TaskWires>().pluggingCount++;

                            transform.GetComponentInParent<TaskWires>().Solve();
                        }
                        break;
                }
            }
            else
            {
                transform.position = startPos;

                transform.rotation = startRot;

                wire.rectTransform.sizeDelta = startWireSize;

                wire.transform.rotation = startRot;
            }

            GetComponent<BoxCollider2D>().enabled = false;
        }

        void OnTriggerStay2D(Collider2D col)
        {
            if (col.GetComponent<CircleCollider2D>() != null)
            {
                Debug.Log(col.name);


                collider = col;

                inSocket = true;

                //transform.parent.parent.GetComponent<TaskWires>().pluggingCount++;


            }

        }
        
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.GetComponent<CircleCollider2D>() != null)
            {
                collider = null;

                inSocket = false;

                if (transform.parent.parent.GetComponent<TaskWires>().pluggingCount > 0) transform.parent.parent.GetComponent<TaskWires>().pluggingCount--;
            }
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            /*


           if (inSocket == true) 
           {
               inSocket = !inSocket;

               switch (collider.gameObject.name)
               {
                   case "Socket1":
                       {
                           transform.parent.parent.GetComponent<TaskWires>().suggestion[0] = null;
                       }
                       break;

                   case "Socket2":
                       {
                           transform.parent.parent.GetComponent<TaskWires>().suggestion[1] = null;
                       }
                       break;

                   case "Socket3":
                       {
                           transform.parent.parent.GetComponent<TaskWires>().suggestion[2] = null;
                       }
                       break;
               }
           }



            */
        }





        
    }

}

