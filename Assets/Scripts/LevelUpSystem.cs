using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSystem : MonoBehaviour
{
    public GameObject upgrade1;
    public GameObject upgrade2;
    public GameObject upgrade3;
    public GameObject spawner;

    public GameObject yakantop1;
    public GameObject yakantop2;

    public ExplosionEffect bomb;

    public int upgrade1ID;
    public int upgrade2ID;
    public int upgrade3ID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameObject player;
    private bool cancelRicoShot = false;
    public GameObject bullet;
    public int defence = 0;

    private int bulletRewardlvl = 0;
    private int yakanToplvl = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        upgrade1.GetComponent<TMP_Text>().text = null;
        upgrade2.GetComponent<TMP_Text>().text = null;
        upgrade3.GetComponent<TMP_Text>().text = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelUp()
    {
        Time.timeScale = 0;
        upgrade1.transform.parent.parent.gameObject.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            int randomID = Random.Range(0, 18);

            if (randomID == 0) //saldırı hızı
            {
                if (player.GetComponent<AnimatedController>().bulletInterval <= 0.3f)
                {
                    LevelUp();
                    Debug.Log("break");
                    break;

                }
                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "SALDIRI HIZI +%10";
                    upgrade1ID = 0;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "SALDIRI HIZI +%10";
                    upgrade2ID = 0;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "SALDIRI HIZI +%10";
                    upgrade3ID = 0;
                }
            }

            else if (randomID == 1)
            {
                if (bullet.GetComponent<BulletScript>().damage >= 18)
                {
                    LevelUp();
                    break;
                }
                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "SALDIRI HASARI +%15";
                    upgrade1ID = 1;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "SALDIRI HASARI +%15";
                    upgrade2ID = 1;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "SALDIRI HASARI +%15";
                    upgrade3ID = 1;
                }
            }

            else if (randomID == 2)
            {
                if (player.GetComponent<AnimatedController>().moveSpeed >= 7)
                {
                    LevelUp();
                    break;
                }
                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "HAREKET HIZI +%50";
                    upgrade1ID = 2;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "HAREKET HIZI +%50";
                    upgrade2ID = 2;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "HAREKET HIZI +%50";
                    upgrade3ID = 2;
                }
            }

            else if (randomID == 3)
            {
                if (player.GetComponent<AnimatedController>().DefenceScale >= 75)
                {
                    LevelUp();
                    break;
                }
                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "DEFANS +%25";
                    upgrade1ID = 3;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "DEFANS +%25";
                    upgrade2ID = 3;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "DEFANS +%25";
                    upgrade3ID = 3;
                }
            }

            else if (randomID == 4)
            {
                if (bulletRewardlvl >= 2)
                {
                    LevelUp();
                    break;
                }
                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "ZAMAN ODULU +%50";
                    upgrade1ID = 4;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "ZAMAN ODULU +%50";
                    upgrade2ID = 4;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "ZAMAN ODULU +%50";
                    upgrade3ID = 4;
                }
            }

            else if (randomID == 5)
            {
                if (yakanToplvl >= 2)
                {
                    LevelUp();
                    break;
                }
                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "YAKAN TOP +1";
                    upgrade1ID = 5;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "YAKAN TOP +1";
                    upgrade2ID = 5;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "YAKAN TOP +1";
                    upgrade3ID = 5;
                }
            }

            else if (randomID == 6)
            {
                if (player.GetComponent<AnimatedController>().invincibilityDuration >= 6)
                {
                    LevelUp();
                    break;
                }
                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "OLUMSUZLUK SURESI +6s";
                    upgrade1ID = 6;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "OLUMSUZLUK SURESI +6s";
                    upgrade2ID = 6;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "OLUMSUZLUK SURESI +6s";
                    upgrade3ID = 6;
                }
            }

            else if (randomID == 7)
            {
                if (bullet.GetComponent<BulletScript>().bulletHp >= 5 || bullet.GetComponent<BulletScript>().isRicochet == true)
                {
                    LevelUp();
                    break;
                }
                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "DUSMAN DELME +1";
                    upgrade1ID = 7;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "DUSMAN DELME +1";
                    upgrade2ID = 7;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "DUSMAN DELME +1";
                    upgrade3ID = 7;
                }
            }


            else if (randomID == 8)
            {
                if (bullet.GetComponent<BulletScript>().spreadCount >= 5)
                {
                    LevelUp();
                    break;
                }

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "SACMALI ATES +1";
                    upgrade1ID = 8;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "SACMALI ATES +1";
                    upgrade2ID = 8;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "SACMALI ATES +1";
                    upgrade3ID = 8;
                }
            }

            else if (randomID == 9)
            {
                if (bullet.GetComponent<BulletScript>().bulletHp >= 5 || cancelRicoShot == true)
                {
                    LevelUp();
                    break;
                }

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "SILAH SEKMESI +1";
                    upgrade1ID = 9;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "SILAH SEKMESI +1";
                    upgrade2ID = 9;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "SILAH SEKMESI +1";
                    upgrade3ID = 9;
                }
            }

            else if (randomID == 10)
            {
                if (bullet.GetComponent<BulletScript>().criticalChance >= 90)
                {
                    LevelUp();
                    break;
                }

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "KRITIK SANSI +%40";
                    upgrade1ID = 10;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "KRITIK SANSI +%40";
                    upgrade2ID = 10;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "KRITIK SANSI +%40";
                    upgrade3ID = 10;
                }
            }
            else if (randomID == 11)
            {
                if (bullet.GetComponent<BulletScript>().criticalDamage >= 200)
                {
                    LevelUp();
                    break;
                }

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "KRITIK HASARI +%50";
                    upgrade1ID = 11;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "KRITIK HASARI +%50";
                    upgrade2ID = 11;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "KRITIK HASARI +%50";
                    upgrade3ID = 11;
                }
            }

            else if (randomID == 12)
            {
                if (bullet.GetComponent<BulletScript>().spreadAngle <= 2 || bullet.GetComponent<BulletScript>().spreadCount == 1)
                {
                    LevelUp();
                    break;
                }

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "SACMA ACISI -%50";
                    upgrade1ID = 12;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "SACMA ACISI -%50";
                    upgrade2ID = 12;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "SACMA ACISI -%50";
                    upgrade3ID = 12;
                }
            }

            else if (randomID == 13)
            {
                if (this.gameObject.GetComponent<Expmanager>().expMultiplier >= 75)
                {
                    LevelUp();
                    break;
                }

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "EXP CARPANI +%25";
                    upgrade1ID = 13;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "EXP CARPANI +%25";
                    upgrade2ID = 13;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "EXP CARPANI +%25";
                    upgrade3ID = 13;
                }
            }

            else if (randomID == 14)
            {
                if (bullet.GetComponent<BulletScript>().explosion == true)
                {
                    LevelUp();
                    break;
                }

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "PATLAYAN MERMI";
                    upgrade1ID = 14;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "PATLAYAN MERMI";
                    upgrade2ID = 14;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "PATLAYAN MERMI";
                    upgrade3ID = 14;
                }
            }

            else if (randomID == 15)
            {
                if (bomb.damage >= 16 || bullet.GetComponent<BulletScript>().explosion == false)
                {
                    LevelUp();
                    break;
                }

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "PATLAYAN HASAR +%100";
                    upgrade1ID = 15;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "PATLAYAN HASAR +%100";
                    upgrade2ID = 15;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "PATLAYAN HASAR +%100";
                    upgrade3ID = 15;
                }
            }

            else if (randomID == 16)
            {
                if (player.GetComponent<AnimatedController>().doubleShot)
                {
                    LevelUp();
                    break;
                }

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "IKILI VURUS";
                    upgrade1ID = 16;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "IKILI VURUS";
                    upgrade2ID = 16;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "IKILI VURUS";
                    upgrade3ID = 16;
                }
            }

            else if (randomID == 17)
            {

                if (upgrade1.GetComponent<TMP_Text>().text == null)
                {
                    upgrade1.GetComponent<TMP_Text>().text = "YENIDEN DOGMA +1";
                    upgrade1ID = 17;
                }
                else if (upgrade2.GetComponent<TMP_Text>().text == null)
                {
                    upgrade2.GetComponent<TMP_Text>().text = "YENIDEN DOGMA +1";
                    upgrade2ID = 17;
                }
                else if (upgrade3.GetComponent<TMP_Text>().text == null)
                {
                    upgrade3.GetComponent<TMP_Text>().text = "YENIDEN DOGMA +1";
                    upgrade3ID = 17;
                }
            }
        }


    }

    public void Upgrade1()
    {
        ApplyUpgrades(upgrade1ID);
    }
    public void Upgrade2()
    {
        ApplyUpgrades(upgrade2ID);
    }
    public void Upgrade3()
    {
        ApplyUpgrades(upgrade3ID);
    }


    public void ApplyUpgrades(int ID)
    {
        if (ID == 0)
        {
            player.GetComponent<AnimatedController>().bulletInterval -= 0.08f;
        }
        if (ID == 1)
        {
            bullet.GetComponent<BulletScript>().damage += 2;
        }
        if (ID == 2)
        {
            player.GetComponent<AnimatedController>().moveSpeed += 2;
        }
        if (ID == 3)
        {
            player.GetComponent<AnimatedController>().DefenceScale += 25;
        }
        if (ID == 4)
        {
            foreach (var item in spawner.GetComponent<Spawner>().enemies)
            {
                item.GetComponent<EnemyHealthScript>().timeRewardScale += 50;
            }
            bulletRewardlvl++;
        }
        if (ID == 5)
        {
            yakanToplvl++;
            if (yakanToplvl == 1)
            {
                yakantop1.SetActive(true);
            }
            else if (yakanToplvl == 2)
            {
                yakantop2.SetActive(true);
            }

        }
        if (ID == 6)
        {
            player.GetComponent<AnimatedController>().invincibilityDuration += 4;
        }
        if (ID == 7)
        {
            bullet.GetComponent<BulletScript>().bulletHp += 1;
            cancelRicoShot = true;
        }
        if (ID == 8)
        {
            bullet.GetComponent<BulletScript>().spreadCount++;
        }
        if (ID == 9)
        {
            bullet.GetComponent<BulletScript>().simpleRicochet = true;
            bullet.GetComponent<BulletScript>().isRicochet = true;
            bullet.GetComponent<BulletScript>().bulletHp += 1;

        }
        if (ID == 10)
        {
            bullet.GetComponent<BulletScript>().criticalChance += 40;
        }
        if (ID == 11)
        {
            bullet.GetComponent<BulletScript>().criticalDamage += 50;
        }

        if (ID == 12)
        {
            bullet.GetComponent<BulletScript>().spreadAngle -= 10;
        }

        if (ID == 13)
        {
            this.gameObject.GetComponent<Expmanager>().expMultiplier += 25;
        }

        if (ID == 14)
        {
            bullet.GetComponent<BulletScript>().explosion = true;
        }

        if (ID == 15)
        {
            bomb.damage += 4;
        }

        if (ID == 16)
        {
            player.GetComponent<AnimatedController>().doubleShot = true;
            player.GetComponent<AnimatedController>().bulletInterval += 0.16f;
        }

        if (ID == 17)
        {
            player.GetComponent<AnimatedController>().resurrection++;
        }


        upgrade1.GetComponent<TMP_Text>().text = null;
        upgrade2.GetComponent<TMP_Text>().text = null;
        upgrade3.GetComponent<TMP_Text>().text = null;
        Time.timeScale = 1;
        upgrade1.transform.parent.parent.gameObject.SetActive(false);
    }
}
