using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Roomba : MonoBehaviour{

    private Transform trans;
    private Rigidbody2D rig;
    private CircleCollider2D coll;

    //Transform of the goal
    private Transform objective;

    //Object the roomba is moving toward
    private Transform target;

    //Declaring audio objects
    private AudioSource RoombaSounds;
    private float RoombaSoundVolume;
    public AudioClip RoombaMove;
    public AudioClip RoombaClean;
    public AudioClip[] WallHitArray;
    private AudioClip WallHit;



    void Start() {
        rig = GetComponent<Rigidbody2D>();
        trans = transform;
        coll = GetComponent<CircleCollider2D>();
        var goal = GameObject.FindWithTag(GameTag.Home);
        RoombaSounds = GetComponent<AudioSource>();
        RoombaSoundVolume = GetComponent<AudioSource>().volume;

        if(goal != null) {
            objective = goal.transform;
            target = objective;
        }
    }

    private void FixedUpdate() {
        //rig.MovePosition(rig.position + )
        if(target == objective || target == trans) {
            Scan(target == trans);

        }
        rig.position = Vector2.MoveTowards(rig.position, target.transform.position, Time.fixedDeltaTime);
    }

    /*Finds the closest dirt within the roomba sight range. Returns the following code:
     * 0: No accessible dirt found. Obstruction between roomba and home not found
     * 1: No accessible dirt or pot found. Obstruction between roomba and home found (Completely stuck)
     * 2: Accessible dirt found.
     * 3: No accessible dirt found. Accessible pot found. (Frozen but not completely stuck)
    */
    private int Scan(bool haltIfScanFails = false) {
        var dirts = GameObject.FindGameObjectsWithTag(GameTag.Dirt);
        bool directHomeSight = true;
        var rhObstacle = Physics2D.CircleCastAll(trans.position, coll.radius, objective.position - trans.position, Vector2.Distance(trans.position, objective.position));
        foreach(var i in rhObstacle) {
            if (i.transform.CompareTag(GameTag.Wall)) {
                directHomeSight = false;
                break;
            }
        }

        if(dirts.Length > 0) {
            dirts = dirts.OrderBy(x => Vector2.Distance(trans.position, x.transform.position)).ToArray();

            for (int i = 0; i < dirts.Length; ++i) {
                bool hasSight = true;
                var obstacles = Physics2D.CircleCastAll(trans.position, coll.radius, dirts[i].transform.position - trans.position, Vector2.Distance(trans.position, dirts[i].transform.position));
                foreach (var j in obstacles) {
                    if (j.transform.CompareTag(GameTag.Cat) || j.transform.CompareTag(GameTag.Wall)) {
                        hasSight = false;
                        break;
                    }
                }
                if (hasSight) {
                    target = dirts[i].transform;
                    return 2;
                }
            }
        }

        if (directHomeSight) {
            target = objective;
            return 0;
        }

        //No accessible dirt and no direct path to home
        //TODO: Check if its possible to go home at all
        target = haltIfScanFails ? trans : objective;
        return 3;

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Debug.LogFormat("Collision: {0}", collision.gameObject.tag);
        switch (collision.gameObject.tag) {
            case GameTag.Pot:
                //Break the pot. the dirt created from it is first priority. drops the original target
                //coll.isTrigger = true;
                break;
            case GameTag.Cat:
                //Scan the entire premise
                Scan();
                break;
            case GameTag.Wall:
                //Stops. Rescans until dirt is detected.
                RoombaSounds.clip = WallHitArray[Random.Range(0, WallHitArray.Length)];
                RoombaSounds.PlayOneShot(RoombaSounds.clip);
                Scan(true);
                break;
            default:
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        switch (collider.tag) {
            case GameTag.Dirt:
                //Clean it up. Rescan.
                //Debug.LogFormat("Colliding dirt: {0}", BoundsContainedPercentage(collider.bounds, coll.bounds));
                if (BoundsContainedPercentage(collider.bounds, coll.bounds) > 0.999f) {
                    Debug.Log("Destroy dirt");
                    collider.gameObject.SetActive(false);
                    Scan();
                }
                break;
            case GameTag.Pot:
                //Break the pot. the dirt created from it is first priority. drops the original target

                break;
            case GameTag.Cat:
                //Scan the entire premise
                Scan();
                break;
            case GameTag.Home:
                //Fire a event to level manager that roomba reached the goal
                Debug.Log("Reached home");
                LevelManager.CallEvent(GameEvent.NextLevel);
                break;
            default:
                break;
        }
    }

    public static float BoundsContainedPercentage(Bounds obj, Bounds region) {
        var total = 1f;
        for (var i = 0; i < 2; i++) {
            var dist = obj.min[i] > region.center[i] ?
                obj.max[i] - region.max[i] :
                region.min[i] - obj.min[i];
            total *= Mathf.Clamp01(1f - dist / obj.size[i]);
        }
        return total;
    }
}
