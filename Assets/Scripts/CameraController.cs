using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Movement Control")]
    [SerializeField] bool DoMovement = true;

    [Header("Pan Speed")]
    [SerializeField] float panSpeed = 20f;

    [Header("Pan Border Thickness")]
    [SerializeField] float panBorderThickness = 5f;

    /*
    [Header("Pan Axes Limit")]
    [SerializeField] float xMin = 20;
    [SerializeField] float xMax = 50;
    [SerializeField] float yMin = -20;
    [SerializeField] float yMax = 20;
    */

    [Header("Scroll Speed")]
    [SerializeField] float scrollSpeed = 2f;
    [SerializeField] float scrollLimitMax = 90f;
    [SerializeField] float scrollLimitMin = 20f;

    void Update()
    {

        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoMovement = !DoMovement;
        }

        if (!DoMovement)
        {
            return;
        }

        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
            //transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
            //transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
            //transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
            //transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        
        pos.y -= scroll * scrollSpeed * 250 * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, scrollLimitMin, scrollLimitMax);
        
        /*
        pos.x = Mathf.Clamp(pos.x, xMin , xMax );
        pos.z = Mathf.Clamp(pos.z, yMin , yMax );
        */

        transform.position = pos;
    }
}
