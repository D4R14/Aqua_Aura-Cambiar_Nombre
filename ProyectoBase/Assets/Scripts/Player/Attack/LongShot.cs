using System.Collections;
using UnityEngine;
using TMPro;

public class LongShot : MonoBehaviour
{
    private GameObject bullet;

    [Header("Attack settings")]
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform bulletSpawn;

    private int bulletSpeed = 10;
    private int cartriche = 10;

    private float cooldown = 1f;
    //private float timeAlive = 2f; Esta configuración esta en el script de Bullet

    private int bulletDamage = 1;


    [Header("UI settings")]
    [SerializeField] private TextMeshProUGUI cartricheText;

    /*private void Start()
    {
        bullet = GameObject.FindWithTag("Bullet");
    }*/
    private void Update()
    {
        // Si se presiona el boton izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            shootBullet();
            //StartCoroutine(LifeBullet());
        }
        cartricheText.text = cartriche.ToString(); //Actualizamos el texto de las balas
    }
    private void shootBullet()
    {
        //Si hay balas en el cargador
        if (cartriche > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation); //Instanciamos la bala
            Rigidbody rb = bullet.GetComponent<Rigidbody>(); //Obtenemos el rigidbody de la bala
            rb.AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse); //Aplicamos una fuerza hacia adelante
            //cartriche--; //Restamos una

            Bullet bulletScript = bullet.AddComponent<Bullet>();
            bulletScript.SetLifeTime(2f);
            bulletScript.SetDamage(bulletDamage); //Daño de bala

            cartriche--; //Restamos una

            //Destroy(bullet, timeAlive); //Destruimos la bala despues de un tiempo
        }
        //Si no hay balas en el cargador
        else
        {
            StartCoroutine(Reload());
        }
    }

    //Corutina para recargar
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(cooldown);
        cartriche = 10;
    }

    //Tiempo de vida de la bala
    /*private IEnumerator LifeBullet()
    {
        yield return new WaitForSecondsRealtime(timeAlive);
        Destroy(bullet);
    }

    //destruimos la bala al colisionar con algo
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(bullet);
    }*/

}
