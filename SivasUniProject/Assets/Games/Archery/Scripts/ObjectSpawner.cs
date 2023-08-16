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
    private Transform centerPoint; // �emberlerin merkez noktas�
    [SerializeField]
    private float innerRadius; // �� �emberin yar��ap�
    [SerializeField]
    private float outerRadius; // D�� �emberin yar��ap�
    [SerializeField]
    private float spawnInterval; // Nesne olu�turma aral��� (saniye)

    private float spawnTimer; // Nesne olu�turma zamanlay�c�s�

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        // Belirli bir zaman aral���nda nesne olu�turma
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


        // Rastgele bir nokta se�me
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        // This will give you a circle
        Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) * Random.Range(innerRadius, outerRadius);

        // Nesneyi olu�turma
        Instantiate(RandomTarget(Random.Range(1, 4)), centerPoint.position + spawnPosition, Quaternion.identity);
    }


    private void SpawnObjectOld()
    {


        // Rastgele bir nokta se�me
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        // This will give you a circle
        Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) * Random.Range(innerRadius, outerRadius);

        // Nesneyi olu�turma
        Instantiate(RandomTarget(Random.Range(1, 4)), centerPoint.position + spawnPosition, Quaternion.identity);
    }


}
