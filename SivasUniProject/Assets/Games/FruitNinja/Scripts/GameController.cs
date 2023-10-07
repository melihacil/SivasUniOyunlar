using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using TMPro;
public class GameController : MonoBehaviour
{
    //Singleton pattern
    public static GameController instance;
    [SerializeField] private bool m_UseFruitMaterial = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //  DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //Reference for other singletons
    Pooler pooler;
    UIManager uIManager;

    //sliced new mesh material
    public Material sliceMaterial;
    [SerializeField] private Material m_defaultSliceMat;
    [SerializeField] private List<Material> materials = new List<Material>();
    public TextureRegion textureRegion;

    //3,2,1, GO!
    public List<string> CountdownElements;
    public TextMeshPro CountdownText;
    SoundManager soundManager;

    private void Start()
    {
        pooler = Pooler.instance;
        uIManager = UIManager.instance;
        CountdownText.gameObject.SetActive(false);
        soundManager = SoundManager.instance;
    }
    // UI sistemini kullanarak kalan süreyi geriye say
    IEnumerator Countdown(GameObject _Fruit)
    {
  
        string parentName =  _Fruit.transform.parent.name;
        //Debug.Log(parentName + " parent fruit name");
        // Arcade mod şeklinde oluşturulan bir mevye tag'i
        if (parentName == "Arcade")
        {
            CountdownText.gameObject.SetActive(true);
            // Süreyi bekle
            for (int i = 0; i < CountdownElements.Count; i++)
            {
                CountdownText.text = CountdownElements[i];
                // 1 saniye sonra yeniden çalış
                yield return new WaitForSeconds(1f);
            }
            CountdownText.gameObject.SetActive(false);
        }
        uIManager.SelectButton(parentName);
    }






    //Check you slice a fruit or not , and slice it!
    public void Slice(GameObject _Fruit, Weapon weapon, Material _FruitMaterial)
    {
        //Material fruitMat;
        //Meyvelerin uygun materyallere göre değiştirilme bloğu
        switch (_Fruit.GetComponent<Fruit>().particleTyp)
        {
            // Uygun tipte değişim uygulaması
            case particleType.Red:
                //Debug.Log("Cut red");
                sliceMaterial = materials[0];
                break;
            case particleType.Yellow:
                //Debug.Log("Cut yellow");
                sliceMaterial = materials[1];
                break;
            case particleType.Orange:
                //Debug.Log("Cut orange");
                sliceMaterial = materials[2];
                break;
            case particleType.Ice:
                sliceMaterial = materials[3];
                break;
            default:
                sliceMaterial = m_defaultSliceMat;
                break;
        }

        SlicedHull slicedObject;

        slicedObject = Sliceed(_Fruit, weapon.slicePanel, sliceMaterial);

        if (slicedObject != null)
        {
            // Skor meyvesi ise
            if (_Fruit.CompareTag("fruit"))
            {
                _Fruit.SetActive(false);
                Fruit fruit = _Fruit.GetComponent<Fruit>();
                pooler.ReycleFruit(fruit);
                // Bomba tipi meyve -- skor azalt
                if (fruit.particleTyp == particleType.Explosion)
                {
                    soundManager.BombSound();
                    // Haptic feedback
                    weapon.Vibrate(0.5f);
                }
                // Dondurucu güç veren meyve -- oyunu yavaşlat
                else if (fruit.particleTyp == particleType.Ice)
                {
                    soundManager.FrozenSound();
                    uIManager.IncreaseScore(4);
                    // Haptic feedback
                    weapon.Vibrate(0.2f);
                }
                // Normal tip meyve -- skor arttır
                else
                {
                    soundManager.SplashFruit();
                    uIManager.IncreaseScore(1);
                    // Haptic feedback
                    weapon.Vibrate(0.1f);
                }
            }
            // Eğer buton tipi bir meyve ise
            else if (_Fruit.CompareTag("button"))
            {
                weapon.Vibrate(0.1f);
                uIManager.BeforeSelectButton();
                soundManager.SplashFruit();
                StartCoroutine(Countdown(_Fruit));
            }
            pooler.GetParticle(_Fruit.GetComponent<Fruit>().particleTyp, _Fruit.transform.position, _Fruit.transform.rotation);
            GameObject upperPart = slicedObject.CreateUpperHull(_Fruit);          
            GameObject lowPart = slicedObject.CreateLowerHull(_Fruit);
            AddComponents(upperPart);
            AddComponents(lowPart);
        }
        else
        {
            Debug.Log("null");
            if (_Fruit.CompareTag("button"))
            {
                StartCoroutine(Countdown(_Fruit));
            }
        }
    }

    //the function that performs the actual cutting
    public SlicedHull Sliceed(GameObject objectToSlice, GameObject plane, Material material)
    {
        return objectToSlice.Slice(plane.transform.position, plane.transform.up, material);

    }
    //add components to new sliced objects
    public void AddComponents(GameObject objPart)
    {

        objPart.AddComponent<BoxCollider>();
        //objPart.GetComponent<MeshRenderer>().materials[1] = sliceMaterial;
        objPart.GetComponent<MeshRenderer>().SetMaterials(new List<Material>() { objPart.GetComponent<MeshRenderer>().materials[0], sliceMaterial });
        objPart.AddComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        objPart.GetComponent<Rigidbody>().AddExplosionForce(350, objPart.transform.position, 30);
        Destroy(objPart, 8f);
    }


}
