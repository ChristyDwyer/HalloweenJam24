using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public HalloweenJam24 controls;

    [SerializeField]private Vector2 mouse_pos;
    [SerializeField] private Vector3 selection_XY;
    [SerializeField]private GameObject building_to_place = null;
    [SerializeField]private bool in_build_mode = false;
    [SerializeField] private GameObject grave_prefab;
    Plane plane;
    [SerializeField] private LayerMask ignore_layer;
    [SerializeField] private GameObject ground;

    // Start is called before the first frame update
    void Awake()
    {
        SetUpControls();
    }

    private void Start()
    {
        plane = new Plane(ground.transform.up, Vector3.zero);
    }

    private void SetUpControls()
    {
        controls = new HalloweenJam24();
        controls.UI.MousePosition.performed += ctx => mouse_pos = ctx.ReadValue<Vector2>();
        controls.UI.Click.performed += ctx => Selection();
        //controls.Player.Move.performed += ctx => movement_inputs = ReadInput(ctx.ReadValue<Vector2>());
        //controls.Player.Move.canceled += ctx => movement_inputs = Vector2.zero;
        // controls.Player.Move.canceled += ctx => walk.enabled = false;
        //controls.Player.Interact.performed += ctx => HandleInteraction();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(mouse_pos);
        float entrance_distance;
        if (plane.Raycast(ray, out entrance_distance))
        {
            selection_XY = ray.GetPoint(entrance_distance);
            if (in_build_mode && building_to_place != null)
            {
                building_to_place.transform.position = selection_XY;
            }

        }
    }

    private void Selection()
    {
        Ray ray = Camera.main.ScreenPointToRay(mouse_pos);
        RaycastHit hit;

        if (building_to_place != null && !building_to_place.GetComponent<ObjectHandling>().intersects)
        {
            building_to_place.transform.position = selection_XY;
            FindObjectOfType<ObjectListManager>().AddObject(building_to_place);
            building_to_place.GetComponent<ObjectHandling>().is_placed_down = true;
            building_to_place = null;
            //selected_build = null;
            in_build_mode = false;
            Debug.Log("Placed thing down");
        }
        else
        { Debug.Log("Buildings interescting, can not bulid here"); }
    }

    public void PlaceGrave()
    {
        in_build_mode = true;
        building_to_place = Instantiate(grave_prefab, Vector3.zero, Quaternion.identity);
        building_to_place.GetComponent<ObjectHandling>().is_placed_down = false;
    }

    public void EnableInput()
    {
        controls.UI.Enable();
    }
    /// <summary>
    /// Diables usage of the Player input map from the new input system
    /// </summary>
    public void DisableInput()
    {
        controls.UI.Disable();
    }
    private void OnDisable()
    {
        DisableInput();
    }
    private void OnEnable()
    {
        EnableInput();
    }
}
