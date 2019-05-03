namespace BaseClasses
{
    /// <summary>
    /// Utilisez une énumération pour les messages pour assurer la cohérence 
    /// </summary>
    public enum MessageTypes
    {
        MSG_COMMAND_AFFICHAGE_FINDERMGR,	// Envoyé lorsqu'un client est sélectionné pour édition
        MSG_FINDER_MODIFIED_ADDED_OR_SAVED,
    };
}