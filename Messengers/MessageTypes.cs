namespace Messengers
{
    /// <summary>
    /// Use an enumeration for the messages to ensure consistency.
    /// 
    /// </summary>
    public enum MessageTypes
    {
        MSG_CUSTOMER_SELECTED_FOR_EDIT,	// Sent when a Customer is selected for editing
        MSG_CUSTOMER_SAVED				// Sent when a Customer is updated to the repository
    };
}