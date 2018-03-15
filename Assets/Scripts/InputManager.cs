using UnityEngine;
using System.Collections;
using System;

public class InputManager : MonoBehaviour
{
    public GridManager gridManager;

    public GameObject particle;
    public TimerForLoading timer;
    private bool isSelected;
    private GameObject selection;

    private const int tileLayerMask = 1 << 8;

    void Awake() { }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer.time <= 0 && Timer.time > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 20.0f, tileLayerMask))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    Animator anim = hitObject.GetComponent<Animator>();

                    if (selection == null)
                    {
                        Debug.Log("Selection 1: " + hitObject);
                        anim.speed = 5;
                        selection = hitObject;
                    }
                    else if (selection == hitObject)
                    {
                        Debug.Log("Same object clicked");
                        anim.speed = 1;
                        selection = null;
                    }
                    else if (!gridManager.SwitchTilesInGrid(selection, hitObject))
                    {
                        Debug.Log("Pieces are not neighbours");
                        Animator selectionAnim = selection.GetComponent<Animator>();
                        selectionAnim.speed = 1;
                        selection = null;
                    }

                    else if (gridManager.CheckForMatches(false) == 0)
                    {
                        Debug.Log("Switched tiles don't make any new matches. Switching back");
                        gridManager.SwitchTilesInGrid(selection, hitObject);
                        Animator selectionAnim = selection.GetComponent<Animator>();
                        selectionAnim.speed = 1;
                        selection = null;
                    }
                    else
                    {
                        Animator selectionAnim = selection.GetComponent<Animator>();
                        selectionAnim.speed = 1;

                        Debug.Log("Selection 2: " + hitObject);
                        Vector3 selectionPos = selection.transform.position;
                        Vector3 hitObjectPos = hitObject.transform.position;

                        selection.GetComponent<TileMover>().MoveTo(hitObjectPos);
                        hitObject.GetComponent<TileMover>().MoveTo(selectionPos);

                        selection = null;
                    }
                }
                else
                {
                    Debug.Log("Hit nothing");
                }
            }
        }
    }

    void OnMouseDown()
    {
        ToogleSelector();
    }

    private void ToogleSelector()
    {
        isSelected = !isSelected;
        particle.SetActive(isSelected);
    }
}
