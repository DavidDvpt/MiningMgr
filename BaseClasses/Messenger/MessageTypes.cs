namespace BaseClasses
{
    /// <summary>
    /// Utilisez une énumération pour les messages pour assurer la cohérence 
    /// </summary>
    public enum MessageTypes
    {
        MSG_COMMAND_AFFICHAGE_FINDERMGR,	// Envoyé lorsqu choisi FinderMgr dans le menu
        MSG_COMMAND_SELECTED_FOR_CREATE,	// Envoyé lorsqu on cree un item
        MSG_COMMAND_SELECTED_FOR_UPDATE,	// Envoyé lorsqu'on modifie un item
        MSG_ITEM_SELECTED_FOR_EDIT,	// Envoyé lorsqu'on modifie un item
        MSG_COMMAND_AFFICHAGE_EDITPANEL_SUBMIT,	// Envoyé lorsqu'on sauvegarde une modif ou un nouvel item
        MSG_FINDER_MODIFIED_ADDED_OR_SAVED, // envoyé lorsque l'item est sauvegardé et créé
    };
}