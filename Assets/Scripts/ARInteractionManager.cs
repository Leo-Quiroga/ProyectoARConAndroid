using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARInteractionManager : MonoBehaviour
{
    private static ARInteractionManager instance;
    //public static ARInteractionManager Intance { get => instance; private set; } 

    private bool isInitPosition;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject scenary;

    [SerializeField] private ARPointCloudManager aRPointManager;
    [SerializeField] private ARPlaneManager aRPlaneManager;


   [SerializeField] private ARRaycastManager aRRaycastManager;
    [SerializeField] private GameObject prefabScene;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    void Start()
    {
        //InstanciarPrefab();
        isInitPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !isInitPosition)
        {
            SetScenary();
        }
    }

    //void InstanciarPrefab()
    //{
    //    // Instancia el Prefab en la posición y rotación del GameObject que contiene este script
    //    Instantiate(prefabScene, transform.position, transform.rotation);
    //}


    void SetScenary()
    {
        if (!isInitPosition)
        {
            Vector2 middelPoint = new Vector2(Screen.width / 2, Screen.height / 2);
            aRRaycastManager.Raycast(middelPoint, hits, TrackableType.Planes);

            if (hits.Count > 0)
            {
                isInitPosition = true;
               // prefabScene.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                scenary = Instantiate(prefabScene, hits[0].pose.position, hits[0].pose.rotation);
                //GameManager.Instance.SetScenary(Scenary);
                aRPointManager.enabled = false;
                aRPlaneManager.enabled = false;
                ARPlane[] planes = FindObjectsOfType<ARPlane>();
                foreach (ARPlane item in planes)
                {
                    Destroy(item.gameObject);
                }
            }
        }
    }
}
