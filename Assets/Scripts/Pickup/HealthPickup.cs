using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, если к объекту подошел игрок
        {
            // Добавляем аптечки к количеству игрока
            FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>().AddAidKit();

            // Уничтожаем объект 
            Destroy(gameObject);
        }
    }
}
