using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCBehavior : MonoBehaviour
{
    public NeedsComponent needsComponent;
    NavMeshAgent agent;
    public Transform[] waypoints;
    int wpIndex = 0;
    float thinkInterval = 3f;
    float thinkTimer = 0f;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        if (needsComponent == null) needsComponent = GetComponent<NeedsComponent>();
    }

    void Update() {
        thinkTimer -= Time.deltaTime;
        if (thinkTimer <= 0f) {
            thinkTimer = thinkInterval;
            Decide();
        }
    }

    void Decide() {
        var hunger = needsComponent.GetNeed("hunger");
        var social = needsComponent.GetNeed("social");

        // Priority: eat if low hunger, else social if low social, else follow route
        if (hunger != null && hunger.value < 45f) {
            GoToTag("FoodStand");
            return;
        }

        if (social != null && social.value < 40f) {
            GoToTag("TeaShop");
            return;
        }

        // Otherwise patrol waypoints
        if (waypoints != null && waypoints.Length > 0) {
            agent.SetDestination(waypoints[wpIndex].position);
            if (!agent.pathPending && agent.remainingDistance < 1f) {
                wpIndex = (wpIndex + 1) % waypoints.Length;
            }
        }
    }

    void GoToTag(string tag) {
        var t = GameObject.FindWithTag(tag);
        if (t != null) agent.SetDestination(t.transform.position);
    }
}
