using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProductionLineHolderUI : MonoBehaviour
{

    [SerializeField] private Button addFactoryButton;
    [SerializeField] private Button removeFactoryButton;

    [SerializeField] private Button removeProdLineButton;

    [SerializeField] private TextMeshProUGUI amountOfFactoriesText;

    private ProductionLineHolder _lineHolder;

    private void Start()
    {
        _lineHolder = GetComponent<ProductionLineHolder>();
        _lineHolder.Callback += FactoryCallback;
        addFactoryButton.onClick.AddListener(() => {
            _lineHolder.AddFactory();
        });
        removeFactoryButton.onClick.AddListener(() => {
            _lineHolder.RemoveFactory();
        });

        removeProdLineButton.onClick.AddListener(() => {
            _lineHolder.DeleteProductionLine();
        });

    }

    private void FactoryCallback(int amount)
    {
        amountOfFactoriesText.text = amount.ToString();
    }

}
