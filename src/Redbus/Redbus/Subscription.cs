﻿using System;
using Redbus.Events;
using Redbus.Interfaces;

namespace Redbus
{
    internal class Subscription<TEventBase> : ISubscription where TEventBase : EventBase
    {
        private SubscriptionToken _subscriptionToken;

        public SubscriptionToken SubscriptionToken
        {
            get { return _subscriptionToken; }
            set { _subscriptionToken = value; }
        }

        public Subscription(Action<TEventBase> action, SubscriptionToken token)
        {
            if (null == action)
            {
                throw new ArgumentNullException();
            }

            _action = action;

            if (null == token)
            {
                throw new ArgumentNullException();
            }

            SubscriptionToken = token;
        }

        public void Publish(EventBase eventItem)
        {
            if (!(eventItem is TEventBase))
                throw new ArgumentException("Event Item is not the correct type.");

            _action.Invoke(eventItem as TEventBase);
        }

        private readonly Action<TEventBase> _action;
    }
}