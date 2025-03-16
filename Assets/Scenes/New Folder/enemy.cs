using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject fireballPrefab; // Префаб фаербола
    public float launchForce = 10f; // Сила запуска фаербола

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Если нажата левая кнопка мыши
        {
            // Получаем позицию мыши в мировых координатах
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Вычисляем направление от объекта к позиции мыши
            Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;

            // Создаём фаербол
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

            // Получаем компонент Fireball и устанавливаем направление
            Fireball fb = fireball.GetComponent<Fireball>();
            if (fb != null)
            {
                fb.SetDirection(direction);
            }
        }
    }
}