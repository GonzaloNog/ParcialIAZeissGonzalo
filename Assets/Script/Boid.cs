
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 position;
    public Vector3 velocity;
    public Vector3 lookat;
    public Waypoint waypoint { get; set; }
    public Transform targetPosition { get; set; }
    public Transform enemyPosition { get; set; }
    public int puntos { get; set; }
    public Material enemyMat;
    public bool enemy { get; set; }
    Vector3 dir;

    public float velMax;
    public float xMax;
    public float zMax;
    public float xMin;
    public float zMin;
    private float x;
    private float z;
    private float time;
    private float angle;
    Vector3 target;

    void Awake()
    {
        puntos = 0;
        enemy = false;
        enemyMat = Resources.Load("Material/EnemyMat", typeof(Material)) as Material;
        if(enemyMat != null)
            print("Textura cargada");
        velMax = 0.01f;
        x = Random.Range(-velMax, velMax);
        z = Random.Range(-velMax, velMax);
        angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
        xMax = 22;
        zMax = 30;
        xMin = -20;
        zMin = -12;
        target = new Vector3(this.transform.position.x, 10.0f, this.transform.position.z);
    }

    void Update()
    {
        Mutate();        
        GameObject aux = GameObject.Find("Enemy(Clone)");
        if (aux != null)
        {
            targetPosition = aux.transform;
        }
        if (enemy)
        {
            if (this.transform.position.y < 9.5f)
            {
                target = new Vector3(this.transform.position.x, 10.0f, this.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, target, 10 * Time.deltaTime);
            }            
            enemyPosition = this.transform;
            Wander();
        }
        position = transform.position;
        transform.LookAt(lookat);
    }

    public void IncreasePuntos()
    {
        puntos++;
    }

    public void Mutate()
    {
        if (!enemy)
        {
            if (puntos >= 2)
            {
                this.transform.localScale = new Vector3(3f,3f,3f);
                /*Renderer rend = GetComponentInChildren<SkinnedMeshRenderer>();
                rend.material = enemyMat;*/
                enemy = true;
            }
        }
    }

    void Wander()
    {        
        time += Time.deltaTime;

        if (transform.localPosition.x > xMax)
        {
            x = Random.Range(-velMax, 0.0f);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }
        if (transform.localPosition.x < xMin)
        {
            x = Random.Range(0.0f, velMax);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }
        if (transform.localPosition.z > zMax)
        {
            z = Random.Range(-velMax, 0.0f);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }
        if (transform.localPosition.z < zMin)
        {
            z = Random.Range(0.0f, velMax);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }

        if (time > 1.0f)
        {
            x = Random.Range(-velMax, velMax);
            z = Random.Range(-velMax, velMax);
            angle = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }

        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);
    }



}




