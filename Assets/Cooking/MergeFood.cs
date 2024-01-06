using UnityEngine;

public class MergeFood : MonoBehaviour
{
    public enum Material
    {
        LatteCup, ParfaitCup, Plate, Cereal, Vinyl, Box,
        CakeTopping, Tray,
        Milk, Ice, CakeSheet,
        Base1, Base2, Base3, CookieDough, CakeCream, MacaronCoq, MacaronFilling,
        Oven, Mixer,
        MilkCup, MilkCupBass, CookieTray, SmoothieCup, Empty1, CakePlate, Cake2stack, Cake3stack, Cake4stack, Cake5stack, Cake6stack,
        CakeDeco1, CakeDeco2, CakeDeco3, CakeToping1, CakeToping2, CakeToping3, CoqTray1, CoqTray2, RoastCoq1, RoastCoq2, Smoothie1, Smoothie2, Smoothie3,
        Parfait1, Parfait2, Parfait3, MarcaronCream
    }

    bool MilkCup, MilkCupBase1, MilkCupBase2, MilkCupBase3, MixIce, MixMilk, MixBase,
        CookieTray, CTOven, CakePlate, CTCream, CakeStack2, CakeStack3, CakeStack4, CakeStack5, CakeStack6,
        CakeDeco1, CakeDeco2, CakeDeco3, CoqTray1, CoqTray2, MTOven1, MTOven2, RoastCoq1, RoastCoq2, Marcaron, CCookie, MarcaronCream, 
        MixBase1, MixBase2, MixBase3, SmoothieCup, Parfait, Parfait1Deco1, Parfait1Deco2, Parfait2Deco1, Parfait2Deco2, Parfait3Deco1, Parfait3Deco2;

    public Material FoodMaterial;

    public GameObject EnterItem;
    public ItemManager itemManager;

    private void Start()
    {
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Latte
            if (MilkCup)
            {
                Debug.Log("밀크컵");
                Instantiate(itemManager.MilkCup);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (MilkCupBase1)
            {
                BaseDrag basedrop = GameObject.Find("Base1").GetComponent<BaseDrag>();
                basedrop.isBeingHeld = false;
                basedrop.DropBass();

                Debug.Log("밀크컵베이스");
                Instantiate(itemManager.Latte1);
                Destroy(gameObject);
            }
            if (MilkCupBase2)
            {
                BaseDrag basedrop = GameObject.Find("Base2").GetComponent<BaseDrag>();
                basedrop.isBeingHeld = false;
                basedrop.DropBass();

                Debug.Log("밀크컵베이스");
                Instantiate(itemManager.Latte2);
                Destroy(gameObject);
            }
            if (MilkCupBase3)
            {
                BaseDrag basedrop = GameObject.Find("Base3").GetComponent<BaseDrag>();
                basedrop.isBeingHeld = false;
                basedrop.DropBass();

                Debug.Log("밀크컵베이스");
                Instantiate(itemManager.Latte3);
                Destroy(gameObject);
            }

            // Smoothie
            if (MixIce)
            {
                MixerSprite mixer = GameObject.Find("Mixer").GetComponent<MixerSprite>();
                if (mixer.Tempi == 0)
                {
                    Debug.Log("믹스 아이스");
                    mixer.ChangeSprite(1);
                    Destroy(gameObject);
                }
            }
            if (MixMilk)
            {
                MixerSprite mixer = GameObject.Find("Mixer").GetComponent<MixerSprite>();
                if (mixer.Tempi == 1)
                {
                    Parfait = false; SmoothieCup = false;
                    MixBase1 = false; MixBase2 = false; MixBase3 = false;
                    Debug.Log("믹스 우유");
                    mixer.ChangeSprite(2);
                    Destroy(gameObject);
                }
            }
            if (MixBase1)
            {
                MixerSprite mixer = GameObject.Find("Mixer").GetComponent<MixerSprite>();
                if (mixer.Tempi == 2)
                {
                    BaseDrag basedrop = GameObject.Find("Base1").GetComponent<BaseDrag>();
                    basedrop.isBeingHeld = false;
                    basedrop.DropBass();

                    Debug.Log("믹스 베이스1");
                    mixer.ChangeSprite(3);
                    MixBase1 = false;
                } 
            }
            if (MixBase2)
            {
                MixerSprite mixer = GameObject.Find("Mixer").GetComponent<MixerSprite>();
                if (mixer.Tempi == 2)
                {
                    BaseDrag basedrop = GameObject.Find("Base2").GetComponent<BaseDrag>();
                    basedrop.isBeingHeld = false;
                    basedrop.DropBass();

                    Debug.Log("믹스 베이스2");
                    mixer.ChangeSprite(4);
                    MixBase2 = false;
                }
            }
            if (MixBase3)
            {
                MixerSprite mixer = GameObject.Find("Mixer").GetComponent<MixerSprite>();
                if (mixer.Tempi == 2)
                {
                    BaseDrag basedrop = GameObject.Find("Base3").GetComponent<BaseDrag>();
                    basedrop.isBeingHeld = false;
                    basedrop.DropBass();

                    Debug.Log("믹스 베이스3");
                    mixer.ChangeSprite(5);
                    MixBase3 = false;

                }
            }
            if (SmoothieCup)
            {
                MixerSprite mixer = GameObject.Find("Mixer").GetComponent<MixerSprite>();
                if (mixer.Mixing && mixer.OpenMixer)
                {
                    Debug.Log("썪");
                    mixer.Mixing = false; mixer.OpenMixer = false;

                    if(mixer.Tempi == 3)
                        Instantiate(itemManager.Smothie1);
                    else if (mixer.Tempi == 4)
                        Instantiate(itemManager.Smothie2);
                    else if (mixer.Tempi == 5)
                        Instantiate(itemManager.Smothie3);

                    mixer.ChangeSprite(0);
                    Destroy(gameObject);
                }
            }


            //parPet
            if (Parfait)
            {
                MixerSprite mixer = GameObject.Find("Mixer").GetComponent<MixerSprite>();
                if (mixer.Mixing && mixer.OpenMixer)
                {
                    Debug.Log("썪");
                    mixer.Mixing = false; mixer.OpenMixer = false;

                    if (mixer.Tempi == 3)
                        Instantiate(itemManager.Parfait1);
                    else if (mixer.Tempi == 4)
                        Instantiate(itemManager.Parfait2);
                    else if (mixer.Tempi == 5)
                        Instantiate(itemManager.Parfait3);

                    mixer.ChangeSprite(0);
                    Destroy(gameObject);
                }
            }
            if (Parfait1Deco1)
            {
                Instantiate(itemManager.Parfait1Deco1);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (Parfait1Deco2)
            {
                Instantiate(itemManager.Parfait1Deco2);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (Parfait2Deco1)
            {
                Instantiate(itemManager.Parfait2Deco1);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (Parfait2Deco2)
            {
                Instantiate(itemManager.Parfait2Deco2);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (Parfait3Deco1)
            {
                Instantiate(itemManager.Parfait3Deco1);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (Parfait3Deco2)
            {
                Instantiate(itemManager.Parfait3Deco2);
                Destroy(EnterItem);
                Destroy(gameObject);
            }

            // Cookie And Marcaron
            if (CookieTray)
            {
                Debug.Log("쿠키트레이");
                Instantiate(itemManager.CookieTray);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if(CTOven)
            {
                Debug.Log("구웠음");
            }

            if (CoqTray1)
            {
                Debug.Log("마카롱트레이");
                Instantiate(itemManager.CoqTray1);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (CoqTray2)
            {
                Debug.Log("국희트레이");
                Instantiate(itemManager.CoqTray2);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (MTOven1)
            {
                OvenWait oven = GameObject.Find("Oven").GetComponent<OvenWait>();
                if (!oven.RoastingOven)
                {
                    Debug.Log("구웠음");
                    oven.startCoroutine(0);
                    Destroy(gameObject);
                }
                
            }
            if (MTOven2)
            {
                OvenWait oven = GameObject.Find("Oven").GetComponent<OvenWait>();
                if (!oven.RoastingOven)
                {
                    Debug.Log("구웠음");
                    oven.startCoroutine(1);
                    Destroy(gameObject);
                }
            }
            if(CCookie)
            {
                Debug.Log("쿠키");
                Instantiate(itemManager.CoqCream1);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if(MarcaronCream)
            {
                Debug.Log("마카롱");
                Instantiate(itemManager.CoqCream2);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (Marcaron)
            {
                Debug.Log("마카롱");
                Instantiate(itemManager.Maracaron);
                Destroy(EnterItem);
                Destroy(gameObject);
            }



            if (CakePlate)
            {
                Debug.Log("케이크트레이");
                Instantiate(itemManager.CakePlate);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (CakeStack2)
            {
                Debug.Log("시트크림");
                Instantiate(itemManager.CakeStack2);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (CakeStack3)
            {
                Debug.Log("시트크림");
                Instantiate(itemManager.CakeStack3);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (CakeStack4)
            {
                Debug.Log("시트크림");
                Instantiate(itemManager.CakeStack4);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (CakeStack5)
            {
                Debug.Log("케이크끝");
                Instantiate(itemManager.CakeStack5);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (CakeStack6)
            {
                Debug.Log("케이크끝");
                Instantiate(itemManager.CakeStack6);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (CakeDeco1)
            {
                Debug.Log("케이크데코1");
                Instantiate(itemManager.CakeDeco1);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (CakeDeco2)
            {
                Debug.Log("케이크데코2");
                Instantiate(itemManager.CakeDeco2);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
            if (CakeDeco3)
            {
                Debug.Log("케이크데코3");
                Instantiate(itemManager.CakeDeco3);
                Destroy(EnterItem);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Material"))
        {
            EnterItem = other.gameObject;
            MergeFood GetEnum = other.GetComponent<MergeFood>();

            if (FoodMaterial == Material.Milk && GetEnum.FoodMaterial == Material.LatteCup)
                MilkCup = true;

            if (FoodMaterial == Material.MilkCup && GetEnum.FoodMaterial == Material.Base1)
                MilkCupBase1 = true;
            if (FoodMaterial == Material.MilkCup && GetEnum.FoodMaterial == Material.Base2)
                MilkCupBase2 = true;
            if (FoodMaterial == Material.MilkCup && GetEnum.FoodMaterial == Material.Base3)
                MilkCupBase3 = true;



            if (FoodMaterial == Material.Ice && GetEnum.FoodMaterial == Material.Mixer)
                MixIce = true;
            if (FoodMaterial == Material.Milk && GetEnum.FoodMaterial == Material.Mixer)
                MixMilk = true;
            if (FoodMaterial == Material.Base1 && GetEnum.FoodMaterial == Material.Mixer)
                MixBase1 = true;
            if (FoodMaterial == Material.Base2 && GetEnum.FoodMaterial == Material.Mixer)
                MixBase2 = true;
            if (FoodMaterial == Material.Base3 && GetEnum.FoodMaterial == Material.Mixer)
                MixBase3 = true;
            if (FoodMaterial == Material.SmoothieCup && GetEnum.FoodMaterial == Material.Mixer)
                SmoothieCup = true;

            if (FoodMaterial == Material.ParfaitCup && GetEnum.FoodMaterial == Material.Mixer)
                Parfait = true;

            if (FoodMaterial == Material.Parfait1 && GetEnum.FoodMaterial == Material.CakeCream)
                Parfait1Deco1 = true;
            if (FoodMaterial == Material.Parfait2 && GetEnum.FoodMaterial == Material.CakeCream)
                Parfait2Deco1 = true;
            if (FoodMaterial == Material.Parfait3 && GetEnum.FoodMaterial == Material.CakeCream)
                Parfait3Deco1 = true;
            if (FoodMaterial == Material.Parfait1 && GetEnum.FoodMaterial == Material.Cereal)
                Parfait1Deco2 = true;
            if (FoodMaterial == Material.Parfait2 && GetEnum.FoodMaterial == Material.Cereal)
                Parfait2Deco2 = true;
            if (FoodMaterial == Material.Parfait3 && GetEnum.FoodMaterial == Material.Cereal)
                Parfait3Deco2 = true;



            if (FoodMaterial == Material.MacaronCoq && GetEnum.FoodMaterial == Material.Tray)
                CoqTray1 = true;
            if (FoodMaterial == Material.CookieDough && GetEnum.FoodMaterial == Material.Tray)
                CoqTray2 = true;
            if (FoodMaterial == Material.CoqTray1 && GetEnum.FoodMaterial == Material.Oven)
                MTOven1 = true;
            if (FoodMaterial == Material.CoqTray2 && GetEnum.FoodMaterial == Material.Oven)
                MTOven2 = true;
            if (FoodMaterial == Material.RoastCoq1 && GetEnum.FoodMaterial == Material.MacaronFilling)
                MarcaronCream = true;
            if (FoodMaterial == Material.RoastCoq2 && GetEnum.FoodMaterial == Material.Plate)
                CCookie = true;
            if (FoodMaterial == Material.MarcaronCream && GetEnum.FoodMaterial == Material.Plate)
                Marcaron = true;




            if (FoodMaterial == Material.CakeSheet && GetEnum.FoodMaterial == Material.Plate)
                CakePlate = true;
            if (FoodMaterial == Material.CakePlate && GetEnum.FoodMaterial == Material.CakeCream)
                CakeStack2 = true;
            if (FoodMaterial == Material.Cake2stack && GetEnum.FoodMaterial == Material.CakeSheet)
                CakeStack3 = true;
            if (FoodMaterial == Material.Cake3stack && GetEnum.FoodMaterial == Material.CakeCream)
                CakeStack4 = true;
            if (FoodMaterial == Material.Cake4stack && GetEnum.FoodMaterial == Material.CakeSheet)
                CakeStack5 = true;
            if (FoodMaterial == Material.Cake5stack && GetEnum.FoodMaterial == Material.CakeCream)
                CakeStack6 = true;

            if (FoodMaterial == Material.Cake6stack && GetEnum.FoodMaterial == Material.CakeToping1)
                CakeDeco1 = true;
            if (FoodMaterial == Material.Cake6stack && GetEnum.FoodMaterial == Material.CakeToping2)
                CakeDeco2 = true;
            if (FoodMaterial == Material.Cake6stack && GetEnum.FoodMaterial == Material.CakeToping3)
                CakeDeco3 = true;


        }
    }
}
