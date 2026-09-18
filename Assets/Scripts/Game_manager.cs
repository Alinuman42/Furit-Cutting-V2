using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour
{
    public GameObject[] myObject;
    Ray ray;
    List<Vector3> mylist = new List<Vector3>();
    public float distancebetweenspawnandnew = 0;
    Vector3 myrandomvector;
    [SerializeField] int myValue;


    // For another corutine

    GameObject myinstatieObject;



    void Start()
    {
       
        StartCoroutine(corutineM(1f));
       
    }

    private void Update()
    {
        FireScreenRay();

     

        

    }
    
    void FireScreenRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out RaycastHit hitobject))
        {
            if (hitobject.collider.gameObject.CompareTag("patates") && Input.GetMouseButton(0))
            {
                
                Destroy(hitobject.collider.gameObject);
                mylist.Remove(hitobject.collider.transform.position);


             
            }
            else if(hitobject.collider.gameObject.CompareTag("sisko") && Input.GetMouseButton(0))
            {
                Time.timeScale = 0;
            }
        }
    }

    IEnumerator corutineM(float myTime)
    {
      


        while (true) // do while 1 kez calisiyor 
        {

            Debug.Log(mylist.Count);

            // while/do while, foreach, Vector3.Distance distance koyuyorsam onun bir value ya ihtiyacim var. 

           myValue = Random.Range(0, 2); // red or green random            

          
          

            bool isPostion = true;

            do
            {
                var tryX = Random.Range(-4.5f, 4.5f); //random position X 
                var tryZ = Random.Range(-4.5f, 4.5f); // random position Z
                myrandomvector = new Vector3(tryX, 0f, tryZ);
                
                
                isPostion = true;

                foreach (var item in mylist)
                {
                    distancebetweenspawnandnew = Vector3.Distance(myrandomvector, item);

                    if (distancebetweenspawnandnew < 2f)
                    {
                        isPostion = false; break;
                    }
                    


                }
            } while (!isPostion);

            if (isPostion)
            {
                myinstatieObject =  Instantiate(myObject[myValue], myrandomvector, Quaternion.identity);
                mylist.Add(myrandomvector);

                if(myinstatieObject.CompareTag("sisko"))
                {
                    StartCoroutine(isdestroyingitself(myinstatieObject, 3));

                                         
                }

            }
            else
            {
                Debug.Log("1 Sec Waiting");
            }



            yield return new WaitForSeconds(myTime); // Time is remaining



        }
       
    }


    IEnumerator isdestroyingitself(GameObject objecttodestroy, float destroytime)
    {

        yield return new WaitForSeconds(destroytime);
        mylist.Remove(objecttodestroy.transform.position);
        Destroy(objecttodestroy);
        

        


    }






}
