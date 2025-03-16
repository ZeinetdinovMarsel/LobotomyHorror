using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f; // Скорость полёта фаербола
    public float lifetime = 5f; // Время жизни фаербола в секундах

    void Start()
    {
        // Уничтожаем фаербол через заданное время, чтобы избежать накопления объектов в сцене
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Перемещаем фаербол в направлении его текущего вектора скорости
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // Метод для установки направления полёта фаербола
    public void SetDirection(Vector2 direction)
    {
        // Нормализуем направление, чтобы скорость была постоянной
        Vector2 normalizedDirection = direction.normalized;
        float angle = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Здесь можно добавить логику взаимодействия с другими объектами, например, нанесение урона
        // Например:
        // if (collision.gameObject.CompareTag("Enemy"))
        // {
        //     // Логика нанесения урона
        //     Destroy(gameObject);
        // }

        // Уничтожаем фаербол при столкновении
        Destroy(gameObject);
    }
}