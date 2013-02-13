DelegateInvoker
===============

Invoke methods via reflection without wrapping errors in a TargetInvocationException

### Example

    var invoker = DelegateInvoker.CreateInvoker(channel, invocation.TargetMethod);
    return invoker.Call(invocation.Arguments);
