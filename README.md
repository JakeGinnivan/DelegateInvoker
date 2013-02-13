DelegateInvoker
===============

Invoke methods via reflection without wrapping errors in a TargetInvocationException

### Example

    MethodInfo targetMethod = targetObject.GetType().GetMethod("SomeMethod");
    var invoker = DelegateInvoker.CreateInvoker(targetObject, targetMethod);
    return invoker.Call(invocation.Arguments);
