using System;

namespace Redbus
{
    /// <summary>
    /// A Token representing a Subscription
    /// </summary>
    public class SubscriptionToken
    {
        internal SubscriptionToken(Type eventItemType)
        {
            Token = Guid.NewGuid();
            EventItemType = eventItemType;
        }

        private Guid _token;

        public Guid Token
        {
            get { return _token; }
            set { _token = value; }
        }

        private Type _EventItemType;

        public Type EventItemType
        {
            get { return _EventItemType; }
            set { _EventItemType = value; }
        }
    }
}