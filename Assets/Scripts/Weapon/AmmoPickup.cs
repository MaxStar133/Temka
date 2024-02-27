using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 2; // Количество патронов, которые дает данный патронный объект

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, если к объекту подошел игрок
        {
            // Добавляем патроны к количеству игрока
            FindObjectOfType<Pistolet>().GetComponent<Pistolet>().AddAmmo(ammoAmount);

            // Уничтожаем объект патрона
            Destroy(gameObject);
        }
    }
}
