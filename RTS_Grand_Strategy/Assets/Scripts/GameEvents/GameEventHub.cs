public static class GameEventHub
{

    #region GameStart

    public static Hub_GameStart GameStart = new Hub_GameStart();
    public static Hub_NationButtonPressed NationButtonPressed = new Hub_NationButtonPressed();

    #endregion

    #region LocalNation

    public static Hub_LocalNationChanged LocalNationChanged = new Hub_LocalNationChanged();
    public static Hub_PoliticalPowerChanged PoliticalPowerChanged = new Hub_PoliticalPowerChanged();
    public static Hub_StabilityChanged StabilityChanged = new Hub_StabilityChanged();
    public static Hub_WarSupportChanged WarSupportChanged = new Hub_WarSupportChanged();

    #endregion

    #region GameInitialized

    public static Hub_ProvinceCreation ProvinceCreation = new Hub_ProvinceCreation();
    public static Hub_CountriesLoaded CountriesLoaded = new Hub_CountriesLoaded();
    public static Hub_OnPoliticsSystemActivated PoliticsSystemActivated = new Hub_OnPoliticsSystemActivated();

    #endregion

    #region Agreements

    public static Hub_OnAcceptedAgreement AcceptedAgreement = new Hub_OnAcceptedAgreement();
    public static Hub_OnProvinceSelected ProvinceSelected = new Hub_OnProvinceSelected();

    #endregion

    #region Production

    public static Hub_AddedToStockpile AddedToStockpile = new Hub_AddedToStockpile();
    public static Hub_StockpileCreated StockpileCreated = new Hub_StockpileCreated();

    #endregion

    #region Research

    public static Hub_ResearchSlotClicked ResearchSlotClicked = new Hub_ResearchSlotClicked();

    #endregion

    #region Nation Details

    public static Hub_OnNationDetailToggle OnNationDetailToggle = new Hub_OnNationDetailToggle();

    #endregion

}
