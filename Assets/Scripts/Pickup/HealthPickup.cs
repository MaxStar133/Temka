using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Количество ХП, которые дает данный объект
    public int minHpAmount = 2;
    public int maxHpAmount = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, если к объекту подошел игрок
        {
            // Добавляем патроны к количеству игрока
            FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>().AddHp(Random.Range(minHpAmount, maxHpAmount + 1));

            // Уничтожаем объект 
            Destroy(gameObject);
        }
    }
}
