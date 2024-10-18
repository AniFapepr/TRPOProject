using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.interfaces;

namespace Assets.Scripts.Player
{
    public class Player : Entity
    {
        [Header("Стратегии")]
        private IMovementStrategy movementStrategy;
        private IAttackStrategy attackStrategy;
        private AnimateScript legAnimate;

        [Header("Движение")]
        public float acceleration = 5f;
        public float deceleration = 5f;
        public float legTimer = 0.08f;

        [Header("Компоненты")]
        private Rigidbody2D rb;
        private Sprite[] legSprites;
        private SpriteRenderer legsRenderer;
        private SpriteRenderer torsoRenderer;
        private Sprite[] torsoSprites;

        [Header("Оружие")]
        private GameObject currentWeapon = null;
        private Weapon currentWeaponCharacteristic;

        [SerializeField]
        private WeaponManager weaponManager; 
        public Transform firePoint;

        private ControlSystem controlSystem;


        void Start()
        {
            InitializeRigidbody();
            CatchLegSprites();
            CatchLegsRenderer();
            CatchTorsoSprites();
            CatchTorsoRenderer();
            CathchWeaponManager();
            CatchFirePoint();
            if(weaponManager == null)
                Debug.LogError("Can't found WeaponManager in PlayerObject");

            controlSystem = new ControlSystem();

            if (legsRenderer != null)
            {
                legAnimate = new AnimateScript(legSprites, legsRenderer, legTimer);
                movementStrategy = new PlayerMovementStrategy(controlSystem, legAnimate);
            }

            
            attackStrategy = currentWeaponCharacteristic.isGun ? gameObject.AddComponent<GunAttackStrategy>() : gameObject.AddComponent<MeleeAttackStrategy>(); // Обновляем стратегию атаки
                

        }
        void CathchWeaponManager()
        {
            // Ищем компонент WeaponManager на объекте игрока
            weaponManager = GetComponent<WeaponManager>();
            if(weaponManager == null)
                Debug.LogError("WeaponMAnager пуст!");
            
            // Получаем текущее оружие через WeaponManager
            currentWeapon = weaponManager.GetCurrentWeapon();
            if (currentWeapon != null)
            {
                currentWeaponCharacteristic = currentWeapon.GetComponent<Weapon>();
                Debug.Log("Характеристики оружия успешно получены");
            }
            else{
                Debug.LogError("Нет оружия в weaponmanager!");
            }
            if(currentWeapon == null)
                Debug.LogError("Weapon is null !");
            if(currentWeaponCharacteristic == null){
                Debug.LogError("Weapon characteristic is null!");
            }


            
        }


        private void InitializeRigidbody()
        {
            rb = GetComponent<Rigidbody2D>();

            if (rb == null)
            {
                Debug.LogError("Rigidbody2D component is missing from Player.");
            }
        }

        private void CatchLegSprites()
        {
            GameObject legsObject = transform.Find("Legs").gameObject;
            if (legsObject != null)
            {
                SpritesContainer2D spritesContainer2D = legsObject.GetComponent<SpritesContainer2D>();
                if(spritesContainer2D != null){
                    legSprites = spritesContainer2D.getSprites();
                }
                else{
                    Debug.Log("SpriteContainer for Legs is empty");
                }
                
            }
            else{
                Debug.Log("Can't found Legs");
            }

        }

        private void CatchTorsoSprites()
        {
            // Ищем объект по тегу "Torso"
            GameObject torsoObject = GameObject.FindWithTag("Torso");
            if (torsoObject != null)
            {
                SpritesContainer2D spritesContainer2D = torsoObject.GetComponent<SpritesContainer2D>();
                if (spritesContainer2D != null)
                {
                    torsoSprites = spritesContainer2D.getSprites();
                }
                else
                {
                    Debug.Log("SpriteContainer for Torso is empty");
                }
            }
            else
            {
                Debug.LogError("Can't find Torso object with tag 'Torso'");
            }
        }


        private void CatchFirePoint()
        {
            // Ищем объект "Torso" по тегу
            GameObject torsoObject = GameObject.FindWithTag("Torso");

            if (torsoObject != null)
            {
                // Ищем дочерний объект "firePoint" внутри "Torso"
                Transform firePointTransform = torsoObject.transform.Find("AttackPoint");

                if (firePointTransform != null)
                {
                    firePoint = firePointTransform; // Устанавливаем firePoint
                    Debug.Log("Fire point найден и установлен.");
                }
                else
                {
                    Debug.LogError("Не удалось найти AttackPoint внутри Torso.");
                }
            }
            else
            {
                Debug.LogError("Не удалось найти объект с тегом 'Torso'.");
            }
        }



        private void CatchTorsoRenderer()
        {
            // Ищем объект по тегу "Torso"
            GameObject torsoObject = GameObject.FindWithTag("Torso");
            if (torsoObject != null)
            {
                torsoRenderer = torsoObject.GetComponent<SpriteRenderer>();
            }
            else
            {
                Debug.LogError("Can't find Torso object with tag 'Torso'");
            }

            if (torsoRenderer == null)
            {
                Debug.LogError("SpriteRenderer component is missing from Torso.");
            }
        }



        private void CatchLegsRenderer()
        {
            GameObject legsObject = transform.Find("Legs").gameObject;
            if (legsObject != null)
            {
                legsRenderer = legsObject.GetComponent<SpriteRenderer>();
            }

            if (legsRenderer == null)
            {
                Debug.LogError("SpriteRenderer component is missing from Legs.");
            }
        }


        public override void Move()
        {
            movementStrategy?.Move(this, acceleration, deceleration);
        }

        public override void Rotate()
        {
            movementStrategy?.Rotate(this);
        }

        public override void Attack()
        {
            if(attackStrategy == null)
                Debug.LogError("AttackStrategy пуста во время атаки");
            if(firePoint == null)
                Debug.LogError("fire point пуста во время атаки");
            if(currentWeaponCharacteristic == null)
                Debug.LogError("CurrentWeaponCharacteristic пуста во время атаки");

            attackStrategy?.Attack(firePoint, currentWeaponCharacteristic);

        }

        public void ChangeWeapon()
        {
            // Вызываем WeaponManager для смены оружия
            if (weaponManager != null)
            {
                weaponManager.ChangeWeapon(this);
                currentWeapon = weaponManager.GetCurrentWeapon(); // Обновляем текущее оружие
                currentWeaponCharacteristic = currentWeapon.GetComponent<Weapon>();
                Debug.Log("Оружие изменено на: " + currentWeaponCharacteristic.WeaponName);
                if(currentWeaponCharacteristic == null){
                    Debug.LogError("При попытке смены оружия, характеристики текущего оружия пусты");
                }
                attackStrategy = currentWeaponCharacteristic.isGun ? gameObject.AddComponent<GunAttackStrategy>() : gameObject.AddComponent<MeleeAttackStrategy>(); // Обновляем стратегию атаки
                
            }
            else
            {
                Debug.LogError("WeaponManager is null, cannot change weapon.");
            }
        }

        void Update()
        {
            Move();
            Rotate();
            legAnimate?.SetMoving(movementStrategy.IsMoving()); // Передача состояния движения для анимации
           
            Move();
            Rotate();
            legAnimate?.SetMoving(movementStrategy.IsMoving()); // Передача состояния движения для анимации
            if(controlSystem == null)
                Debug.LogError("Контроль движений пуст!");
            
            if (controlSystem.IsAttackPressed()) // Удержание кнопки
            {
                attackStrategy?.EnableAutomaticAttack();
            }
            else
            {
                attackStrategy?.DisableAutomaticAttack();
            }

            if (controlSystem.IsAttackClicked()) // Одиночная атака
            {
               Attack();
            }

            if (controlSystem.IsThrowPressed()) // Если игрок нажал на кнопку смены оружия
            {
                ChangeWeapon();
            }
        }
    }
}
