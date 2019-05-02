namespace BaseClasses
{
    public enum NotificationResult
    {
        MessageNotRegistered,       // Le message n'avait aucun gestionnaire enregistré
        MessageHandled,             // Le message avait un ou plusieurs gestionnaires, et a été traité
        MessageAborted,             // Le message avait un gestionnaire qui a avorté le message
        MessageRegisteredNotHandled // Bien que le message ait un ou plusieurs gestionnaires, aucun d’entre eux ne semble le traiter.
    }
}
