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
        if (value == 3f)
        {
            return oneHundredPointstarget;
        }
        else if (value == 2f)
        {
            return fiftyPointstarget;
        }
        else if(value==1f)
        {
            return twentyFivePointstarget;
        }
        else
        {
            return null;
        }
    }


    [SerializeField] float m_SpawnAngle;
    // From a circle to a cone shaped area
    private void SpawnObject()
    {

        //float angleInRad = Random.Range(0.0f, m_SpawnAngle) * Mathf.Deg2Rad;
        // Rastgele bir nokta se�me
        //Vector2 randomPoint = Random.insideUnitCircle.normalized * Mathf.Sin(angleInRad);
        // This will give you a circle
        Vector3 spawnPosition = GetPointOnUnitSphereCap(centerPoint.position, m_SpawnAngle) * Random.Range(innerRadius, outerRadius);

        // Nesneyi olu�turma
        Instantiate(RandomTarget(Random.Range(1,4)), centerPoint.position + spawnPosition, Quaternion.identity);
    }

    private void SpawnObjectOld()
    {

        float angleInRad = Random.Range(0.0f, m_SpawnAngle) * Mathf.Deg2Rad;
        // Rastgele bir nokta se�me
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        // This will give you a circle
        Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) * Random.Range(innerRadius, outerRadius);

        // Nesneyi olu�turma
        Instantiate(RandomTarget(Random.Range(1, 4)), centerPoint.position + spawnPosition, Quaternion.identity);
    }

    public static Vector3 GetPointOnUnitSphereCap(Quaternion targetDirection, float angle)
    {
        var angleInRad = Random.Range(0.0f, angle) * Mathf.Deg2Rad;
        var PointOnCircle = (Random.insideUnitCircle.normalized) * Mathf.Sin(angleInRad);
        var V = new Vector3(PointOnCircle.x, PointOnCircle.y, Mathf.Cos(angleInRad));
        return targetDirection * V;
    }

    public static Vector3 GetPointOnUnitSphereCap(Vector3 targetDirection, float angle)
    {
        return GetPointOnUnitSphereCap(Quaternion.LookRotation(targetDirection), angle);
    }


}
