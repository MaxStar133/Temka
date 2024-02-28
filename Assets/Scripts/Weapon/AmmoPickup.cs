using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    // Количество патронов, которые дает данный патронный объект
    public int minAmmoAmount = 2; 
    public int maxAmmoAmount = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, если к объекту подошел игрок
        {
            // Добавляем патроны к количеству игрока
            FindObjectOfType<Pistolet>().GetComponent<Pistolet>().AddAmmo(Random.Range(minAmmoAmount,maxAmmoAmount+1));

            // Уничтожаем объект патрона
            Destroy(gameObject);
        }
    }
}
