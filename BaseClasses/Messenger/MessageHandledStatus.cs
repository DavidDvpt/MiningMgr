namespace BaseClasses
{
    public enum MessageHandledStatus
    {
        NotHandled,         // Le message n'a pas été traité
        HandledContinue,    // J'ai traité le message, mais j'en ai informé les autres
        HandledCompleted,   // J'ai traité le message mais je n'en parle à personne
        NotHandledAbort     // Je n'ai pas traité le message mais je veux quand même l'avorter
    }
}
