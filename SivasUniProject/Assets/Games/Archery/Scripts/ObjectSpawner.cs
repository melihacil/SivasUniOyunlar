using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject oneHundredPointstarget;
    [SerializeField]
    private GameObject fiftyPointstarget;
    [SerializeField]
    private GameObject twentyFivePointstarget;
    [SerializeField]
    private Transform centerPoint; // Çemberlerin merkez noktasý
    [SerializeField]
    private float innerRadius; // Ýç çemberin yarýçapý
    [SerializeField]
    private float outerRadius; // Dýþ çemberin yarýçapý
    [SerializeField]
    private float spawnInterval; // Nesne oluþturma aralýðý (saniye)

    private float spawnTimer; // Nesne oluþturma zamanlayýcýsý

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        // Belirli bir zaman aralýðýnda nesne oluþturma
        if (spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }
    private GameObject RandomTarget(float value)
    {
        switch (value)
        {
            case 1f:
                return twentyFivePointstarget;
            case 2f:
                return fiftyPointstarget;
            case 3f:
                return oneHundredPointstarget;
            default:
                return null;
        }
    }


    [SerializeField] float m_SpawnAngle;
    // From a circle to a cone shaped area
    private void SpawnObject()
    {


        // Rastgele bir nokta seçme
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        // This will give you a circle
        Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) * Random.Range(innerRadius, outerRadius);

        // Nesneyi oluþturma
        Instantiate(RandomTarget(Random.Range(1, 4)), centerPoint.position + spawnPosition, Quaternion.identity);
    }


    private void SpawnObjectOld()
    {


        // Rastgele bir nokta seçme
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        // This will give you a circle
        Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) * Random.Range(innerRadius, outerRadius);

        // Nesneyi oluþturma
        Instantiate(RandomTarget(Random.Range(1, 4)), centerPoint.position + spawnPosition, Quaternion.identity);
    }


}
