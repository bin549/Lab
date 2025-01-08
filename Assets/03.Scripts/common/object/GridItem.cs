using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GridItem : MonoBehaviour {
    public Image displayIcon;
    private float originalAlpha;
    [Range(0f, 1f)] public float targetAlpha = 1.0f;
    [SerializeField] private bool isActive = false;
    [SerializeField] private Button button;

    public bool IsActive {
        get => isActive;
        set => isActive = value;
    }

    private void Awake() {
        this.displayIcon = this.GetComponent<Image>();
    }

    private void Start() {
        originalAlpha = displayIcon.color.a;
        this.button = displayIcon.AddComponent<Button>();
        this.button.onClick.AddListener(OnIconClick);
    }

    public void OnDisplayIcon(bool isDisplay) {
        if (isDisplay) {
            this.IsActive = false;
            this.gameObject.SetActive(true);
        } else {
            this.IsActive = false;
            this.gameObject.SetActive(false);
        }
    }
    
    public void OnIconClick() {
        Color currentColor = displayIcon.color;
        if (!this.isActive) {
            displayIcon.color = new Color(currentColor.r, currentColor.g, currentColor.b, targetAlpha);
        } else {
            displayIcon.color = new Color(currentColor.r, currentColor.g, currentColor.b, originalAlpha);
        }
        this.isActive = !this.isActive;
    }
}