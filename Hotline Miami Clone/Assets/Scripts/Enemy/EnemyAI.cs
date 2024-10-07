using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public bool patrol = true, gaurd = false, clockwise = false;
    public bool moving = true;
    public bool pursuingPlayer = false, goingToLastLoc = false;
    Vector3 target;
    Rigidbody2D rid;
    public Vector3 playerLastPos;
    RaycastHit2D hit;

    float speed = 2.0f; //changed bullets to be kenimatic

    int layerMask = 1 << 8;//explain layermask for tutorial (how it works changes to weapon attack)

    ObjectManager obj;
    GameObject[] weapons;
    EnemyWeaponController ewc;
    public GameObject weaponToGoTo;
    public bool goingToWeapon = false;
    public bool hasGun = false;
    // Use this for initialization

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerLastPos = this.transform.position;

        //hit PhysicsJD.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dir.x, dir.y)):

        rid = this.GetComponent<Rigidbody2D>();
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        playerDetect();
        canEnemyFindWeapon();

    }
    void setWeaponToGoTo(GameObject weapon)
    {
        weaponToGoTo = weapon;
        goingToWeapon = true;
        patrol = false;
        pursuingPlayer =false;
        goingToLastLoc=false;
    }
    void canEnemyFindWeapon()
    {
        if (ewc.getCur() == null && weaponToGoTo == null && goingToWeapon == false)
        {
            weapons = obj.getWeapons();
            for (int x = 0; x < weapons.Length; x++)
            {
                float distance = Vector3.Distance(this.transform.position, weapons[x].transform.position);
                Debug.Log("Weapon" + weapons[x].name + "Distance" + distance);
                if (distance < 10)
                {
                    Vector3 dir = weapons[x].transform.position - transform.position;
                    RaycastHit2D wepCheck = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dir.x, dir.y), distance, layerMask);
                    if (wepCheck.collider.gameObject.tag == "Weapon")
                    {
                        setWeaponToGoTo(weapons[x]);
                    }
                }
            }

        }
    }
    void movement()
    {

        float dist = Vector3.Distance(player.transform.position, this.transform.position);

        Vector3 dir = player.transform.position - transform.position;

        hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dir.x, dir.y), dist, layerMask);
        Debug.DrawRay(transform.position, dir, Color.red);

        Vector3 fwt = this.transform.TransformDirection(Vector3.right);

        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(fwt.x, fwt.y), 1.0f, layerMask);

        Debug.DrawRay(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(fwt.x, fwt.y), Color.cyan);

        if (moving == true)
        {
            if(hasGun == false)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                if(Vector3.Distance(this.transform.position, player.transform.position)< 5 && pursuingPlayer == true)
                {
                    //new enemy weapom

                }
                else
                {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
            }
           
        }
        if (patrol == true)
        {
            Debug.Log("Патруль норм");
            speed = 2.0f;

            if (hit2.collider != null)
            {
                if (hit2.collider.gameObject.tag == "Wall")
                {
                    if (clockwise == false)
                    {
                        transform.Rotate(0, 0, 90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
            }
            if (weaponToGoTo != null)
            {
                patrol = false;
                goingToWeapon = true;
            }
        }

        if (pursuingPlayer == true)
        {
            Debug.Log("Pursuing Player");
            speed = 3.5f;
            rid.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((playerLastPos.y - transform.position.y), (playerLastPos.x - transform.position.x)) * Mathf.Rad2Deg);

            if (hit.collider.gameObject.tag == "Player")
            {
                playerLastPos = player.transform.position;
            }
        }
        if (goingToLastLoc == true)
        {
            Debug.Log("Cheking last known player location");
            speed = 3.0f;
            if (Vector3.Distance(this.transform.position, playerLastPos) < 1.5f)
            {
                //враг игрока не нашел, возвращается к патрулю
                patrol = true;
                goingToLastLoc = false;
            }
        }
    }
    public void playerDetect()
    {
        Vector3 pos = this.transform.InverseTransformPoint(player.transform.position);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Player" && pos.x > 1.2f && Vector3.Distance(this.transform.position, player.transform.position) < 9)
            {
                patrol = false;
                pursuingPlayer = true;
            }
            else
            {
                if (pursuingPlayer == true)
                {
                    goingToLastLoc = true;
                    pursuingPlayer = false;
                }
            }
        }
    }
}
