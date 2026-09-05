using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 4f;
    CharacterController cc;
    Camera cam;
    public NeedsComponent needs;

    void Start() {
        cc = GetComponent<CharacterController>();
        cam = Camera.main;
        if (needs == null) needs = GetComponent<NeedsComponent>();
    }

    void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        if (dir.magnitude > 1) dir.Normalize();
        Vector3 world = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * dir;
        cc.SimpleMove(world * speed);

        if (Input.GetKeyDown(KeyCode.E)) {
            TryInteract();
        }
    }

    void TryInteract() {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 2.5f)) {
            var tag = hit.collider.gameObject.tag;
            if (tag == "Food") {
                var n = needs.GetNeed("hunger");
                if (n != null) n.Modify(30f);
                Destroy(hit.collider.gameObject);
            } else if (tag == "TeaShop") {
                var n = needs.GetNeed("social");
                if (n != null) n.Modify(20f);
            }
        }
    }
}
