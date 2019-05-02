namespace BaseClasses
{
    public class Message
    {
        #region Propriétés publiques

        /// <summary>
        /// Le message a-t-il été traité?
        /// </summary>
        public MessageHandledStatus HandledStatus { get; set; }

        /// <summary>
        /// Quel type de message est-ce
        /// </summary>
        public MessageTypes MessageType { get; private set; }

        /// <summary>
        /// Le payload pour le message
        /// </summary>
        public object Payload { get; set; }

        #endregion

        #region Constructor

        public Message(MessageTypes messageType)
        {
            MessageType = messageType;
        }

        #endregion
    }
}
