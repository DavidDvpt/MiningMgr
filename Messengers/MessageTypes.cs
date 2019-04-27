namespace Messengers
{
    /// <summary>
    /// Utilisez une énumération pour les messages pour assurer la cohérence 
    /// </summary>
    public enum MessageTypes
    {
        MSG_CUSTOMER_SELECTED_FOR_EDIT,	// Envoyé lorsqu'un client est sélectionné pour édition
        MSG_CUSTOMER_SAVED				// Envoyé lorsqu'un client est mis à jour dans le référentiel
    };
}