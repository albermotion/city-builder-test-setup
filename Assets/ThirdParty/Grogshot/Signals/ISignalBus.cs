using System;
using System.Collections.Generic;

namespace Grogshot.Signals {
    public delegate void SignalHandler<SignalType>(SignalType signalData);

    public interface ISignalBus {
        bool Publish<SignalType>(SignalType signalData) where SignalType : ISignal;
        bool Subscribe<SignalType>(SignalHandler<SignalType> signalHandler) where SignalType : ISignal;
        bool Unsubscribe<SignalType>(SignalHandler<SignalType> signalHandler) where SignalType : ISignal;
        ICollection<Delegate> GetSubscriptors<SignalType>(SignalHandler<SignalType> signalHandler) where SignalType : ISignal;
    }
}