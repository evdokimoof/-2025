using ICities;
using UnityEngine;
using ColossalFramework.UI;

namespace PopulationUIMod
{
    // Информация о моде в меню
    public class ModInfo : IUserMod
    {
        public string Name => "Population Control Window";
        public string Description => "Окно управления населением (Mac OS)";
    }

    // Загрузка интерфейса при старте уровня
    public class LoadingExtension : LoadingExtensionBase
    {
        private GameObject uiGameObject;

        public override void OnLevelLoaded(LoadMode mode)
        {
            if (mode == LoadMode.NewGame || mode == LoadMode.LoadGame)
            {
                uiGameObject = new GameObject("PopulationWindowObject");
                uiGameObject.AddComponent<PopulationWindow>();
            }
        }

        public override void OnLevelUnloading()
        {
            if (uiGameObject != null)
            {
                Object.Destroy(uiGameObject);
            }
        }
    }

    // Класс самого окна
    public class PopulationWindow : UIPanel
    {
        private UITitleBar titleBar;
        private UITextField inputField;
        private UIButton applyButton;

        public override void Start()
        {
            // Настройка главного окна
            this.backgroundSprite = "MenuPanel2";
            this.width = 250;
            this.height = 150;
            this.relativePosition = new Vector3(100, 100);

            // Заголовок (позволяет перетаскивать окно)
            titleBar = this.AddUIComponent<UITitleBar>();
            titleBar.title = "Население";

            // Поле ввода
            UILabel label = this.AddUIComponent<UILabel>();
            label.text = "Введите число:";
            label.relativePosition = new Vector3(20, 50);

            inputField = this.AddUIComponent<UITextField>();
            inputField.width = 210;
            inputField.height = 30;
            inputField.relativePosition = new Vector3(20, 75);
            inputField.normalBgSprite = "TextFieldPanel";
            inputField.hoveredBgSprite = "TextFieldPanelHovered";
            inputField.focusedBgSprite = "TextFieldPanel";
            inputField.selectionSprite = "EmptySprite";
            inputField.builtinKeyNavigation = true;
            inputField.text = "10000";

            // Кнопка
            applyButton = this.AddUIComponent<UIButton>();
            applyButton.width = 210;
            applyButton.height = 30;
            applyButton.relativePosition = new Vector3(20, 110);
            applyButton.text = "Применить";
            applyButton.normalBgSprite = "ButtonMenu";
            applyButton.hoveredBgSprite = "ButtonMenuHovered";
            applyButton.pressedBgSprite = "ButtonMenuPressed";

            applyButton.eventClick += (component, eventParam) =>
            {
                string val = inputField.text;
                Debug.Log("Попытка установить население: " + val);
                // Здесь логика: например, резкое повышение спроса, пока население не достигнет val
            };
        }
    }

    // Вспомогательный класс для заголовка окна (чтобы его можно было двигать)
    public class UITitleBar : UIPanel
    {
        public string title;
        private UILabel label;
        private UIDragHandle dragHandle;

        public override void Start()
        {
            this.width = parent.width;
            this.height = 40;
            this.relativePosition = Vector3.zero;

            label = this.AddUIComponent<UILabel>();
            label.text = title;
            label.relativePosition = new Vector3(10, 10);

            dragHandle = this.AddUIComponent<UIDragHandle>();
            dragHandle.width = this.width;
            dragHandle.height = this.height;
            dragHandle.relativePosition = Vector3.zero;
            dragHandle.target = parent;
        }
    }
}