using System;
using System.Collections.Generic;
using System.Linq;

namespace Grogshot.Signals {
    public class SignalBus : ISignalBus {

        private readonly IDictionary<Type, ICollection<Delegate>> signalHandlers = new Dictionary<Type, ICollection<Delegate>>();

        public bool Publish<SignalType>(SignalType signalData) where SignalType : ISignal {
            if (signalData == null) {
                return false;
            }

            if (!signalHandlers.ContainsKey(typeof(SignalType))) {
                return false;
            }

            IReadOnlyCollection<SignalHandler<SignalType>> handlers = signalHandlers[typeof(SignalType)]
                .Cast<SignalHandler<SignalType>>()
                .ToList();

            if (handlers.Count == 0) {
                return false;
            }

            foreach (SignalHandler<SignalType> handler in handlers) {
                handler?.Invoke(signalData);
            }

            return true;
        }

        public bool Subscribe<SignalType>(SignalHandler<SignalType> signalHandler) where SignalType : ISignal {
            if (!signalHandlers.ContainsKey(typeof(SignalType))) {
                signalHandlers[typeof(SignalType)] = new List<Delegate>();
            }

            ICollection<Delegate> handlers = signalHandlers[typeof(SignalType)];

            if (!handlers.Contains(signalHandler)) {
                handlers.Add(signalHandler);

                return true;
            }

            return false;
        }

        public bool Unsubscribe<SignalType>(SignalHandler<SignalType> signalHandler) where SignalType : ISignal {
            if (!signalHandlers.ContainsKey(typeof(SignalType))) {
                return false;
            }

            ICollection<Delegate> handlers = signalHandlers[typeof(SignalType)];

            if (handlers.Contains(signalHandler)) {
                handlers.Remove(signalHandler);

                if (handlers.Count == 0) {
                    signalHandlers.Remove(typeof(SignalType));
                }

                return true;
            }
            
            return false;
        }

        public ICollection<Delegate> GetSubscriptors<SignalType>(SignalHandler<SignalType> signalHandler) where SignalType : ISignal {
            if (!signalHandlers.ContainsKey(typeof(SignalType))) {
                return null;
            }

            return signalHandlers[typeof(SignalType)];
        }
    }

}