using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// This class builds an object to invoke a late-bound method, without using MethodInfo.InvokeAction and thus avoiding exceptions being wrapped 
/// as target invocation exceptions.
/// </summary>
// ReSharper disable CheckNamespace
public static class DelegateInvoker
// ReSharper restore CheckNamespace
{
    static T Get<T>(object o)
    {
        if (o == null)
            return default(T);

        return (T)o;
    }

    public interface IActionInvokerWrapper
    {
        object Call(object[] args);
    }

    public static IActionInvokerWrapper CreateInvoker(object target, MethodInfo method)
    {
        if (method.ReturnType == typeof(void))
            return CreateReturnVoidInvoker(target, method);
        var parameterTypes = new List<Type>();
        parameterTypes.AddRange(method.GetParameters().Select(x => x.ParameterType));
        parameterTypes.Add(method.ReturnType);

        var invokerType = InvokerTypes.SingleOrDefault(x => x.GetGenericArguments().Length == parameterTypes.Count);
        if (invokerType == null)
            throw new ArgumentException(string.Format("Could not create an invoker for the method '{0}'. This type of method is not supported. Try reducing the number of arguments in action.", method));

        invokerType = invokerType.MakeGenericType(parameterTypes.ToArray());

        var invokerWrapperType = InvokerWrapperTypes.SingleOrDefault(x => x.GetGenericArguments().Length == parameterTypes.Count);
        if (invokerWrapperType == null)
            throw new ArgumentException(string.Format("Could not create an invoker for the method '{0}'. This type of method is not supported. Try reducing the number of arguments in action.", method));

        invokerWrapperType = invokerWrapperType.MakeGenericType(parameterTypes.ToArray());

        var invoker = Delegate.CreateDelegate(invokerType, target, method);
        var wrapper = Activator.CreateInstance(invokerWrapperType, invoker);
        return (IActionInvokerWrapper)wrapper;
    }

    private static IActionInvokerWrapper CreateReturnVoidInvoker(object target, MethodInfo method)
    {
        var parameterTypes = new List<Type>();
        parameterTypes.AddRange(method.GetParameters().Select(x => x.ParameterType));

        var invokerType = VoidInvokerTypes.SingleOrDefault(x => x.GetGenericArguments().Length == parameterTypes.Count);
        if (invokerType == null)
            throw new ArgumentException(string.Format("Could not create an invoker for the method '{0}'. This type of method is not supported. Try reducing the number of arguments in action.", method));

        if (parameterTypes.Count > 0)
            invokerType = invokerType.MakeGenericType(parameterTypes.ToArray());

        var invokerWrapperType = VoidInvokerWrapperTypes.SingleOrDefault(x => x.GetGenericArguments().Length == parameterTypes.Count);
        if (invokerWrapperType == null)
            throw new ArgumentException(string.Format("Could not create an invoker for the method '{0}'. This type of method is not supported. Try reducing the number of arguments in action.", method));

        if (parameterTypes.Count > 0)
            invokerWrapperType = invokerWrapperType.MakeGenericType(parameterTypes.ToArray());

        var invoker = Delegate.CreateDelegate(invokerType, target, method);
        var wrapper = Activator.CreateInstance(invokerWrapperType, invoker);
        return (IActionInvokerWrapper)wrapper;
    }

    #region Generated
    // ReSharper disable TypeParameterCanBeVariant
    private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10);
    private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9);
    private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8);
    private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7);
    private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);
    private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);
    private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
    private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TArg3, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3);
    private delegate TReturn ActionInvoker<TArg0, TArg1, TArg2, TReturn>(TArg0 arg0, TArg1 arg1, TArg2 arg2);
    private delegate TReturn ActionInvoker<TArg0, TArg1, TReturn>(TArg0 arg0, TArg1 arg1);
    private delegate TReturn ActionInvoker<TArg0, TReturn>(TArg0 arg0);
    private delegate TReturn ActionInvoker<TReturn>();
    private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9, TArg10 arg10);
    private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, TArg9 arg9);
    private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8);
    private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7);
    private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);
    private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);
    private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
    private delegate void VoidActionInvoker<TArg0, TArg1, TArg2, TArg3>(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3);
    private delegate void VoidActionInvoker<TArg0, TArg1, TArg2>(TArg0 arg0, TArg1 arg1, TArg2 arg2);
    private delegate void VoidActionInvoker<TArg0, TArg1>(TArg0 arg0, TArg1 arg1);
    private delegate void VoidActionInvoker<TArg0>(TArg0 arg0);
    private delegate void VoidActionInvoker();
    // ReSharper restore TypeParameterCanBeVariant

    private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            var arg7 = Get<TArg7>(args[7]);
            var arg8 = Get<TArg8>(args[8]);
            var arg9 = Get<TArg9>(args[9]);
            var arg10 = Get<TArg10>(args[10]);
            var result = _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            var arg7 = Get<TArg7>(args[7]);
            var arg8 = Get<TArg8>(args[8]);
            var arg9 = Get<TArg9>(args[9]);
            var result = _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            var arg7 = Get<TArg7>(args[7]);
            var arg8 = Get<TArg8>(args[8]);
            var result = _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            var arg7 = Get<TArg7>(args[7]);
            var result = _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            var result = _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var result = _invoker(arg0, arg1, arg2, arg3, arg4, arg5);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var result = _invoker(arg0, arg1, arg2, arg3, arg4);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TArg2, TArg3, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TArg3, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var result = _invoker(arg0, arg1, arg2, arg3);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TArg1, TArg2, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TArg2, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TArg2, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var result = _invoker(arg0, arg1, arg2);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TArg1, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TArg1, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TArg1, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var result = _invoker(arg0, arg1);
            return result;
        }
    }

    private class ActionInvokerWrapper<TArg0, TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TArg0, TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TArg0, TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var result = _invoker(arg0);
            return result;
        }
    }

    private class ActionInvokerWrapper<TReturn> : IActionInvokerWrapper
    {
        private readonly ActionInvoker<TReturn> _invoker;

        public ActionInvokerWrapper(ActionInvoker<TReturn> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var result = _invoker();
            return result;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            var arg7 = Get<TArg7>(args[7]);
            var arg8 = Get<TArg8>(args[8]);
            var arg9 = Get<TArg9>(args[9]);
            var arg10 = Get<TArg10>(args[10]);
            _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            var arg7 = Get<TArg7>(args[7]);
            var arg8 = Get<TArg8>(args[8]);
            var arg9 = Get<TArg9>(args[9]);
            _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            var arg7 = Get<TArg7>(args[7]);
            var arg8 = Get<TArg8>(args[8]);
            _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            var arg7 = Get<TArg7>(args[7]);
            _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            var arg6 = Get<TArg6>(args[6]);
            _invoker(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            var arg5 = Get<TArg5>(args[5]);
            _invoker(arg0, arg1, arg2, arg3, arg4, arg5);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3, TArg4> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2, TArg3, TArg4> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            var arg4 = Get<TArg4>(args[4]);
            _invoker(arg0, arg1, arg2, arg3, arg4);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2, TArg3> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1, TArg2, TArg3> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2, TArg3> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            var arg3 = Get<TArg3>(args[3]);
            _invoker(arg0, arg1, arg2, arg3);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1, TArg2> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1, TArg2> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1, TArg2> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            var arg2 = Get<TArg2>(args[2]);
            _invoker(arg0, arg1, arg2);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0, TArg1> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0, TArg1> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0, TArg1> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            var arg1 = Get<TArg1>(args[1]);
            _invoker(arg0, arg1);
            return null;
        }
    }

    private class VoidActionInvokerWrapper<TArg0> : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker<TArg0> _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker<TArg0> invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            var arg0 = Get<TArg0>(args[0]);
            _invoker(arg0);
            return null;
        }
    }

    private class VoidActionInvokerWrapper : IActionInvokerWrapper
    {
        private readonly VoidActionInvoker _invoker;

        public VoidActionInvokerWrapper(VoidActionInvoker invoker)
        {
            _invoker = invoker;
        }

        public object Call(object[] args)
        {
            _invoker();
            return null;
        }
    }

    private readonly static Type[] InvokerTypes = new[] {
                                                                typeof(ActionInvoker<,,,,,,,,,,,>),
                                                                typeof(ActionInvoker<,,,,,,,,,,>),
                                                                typeof(ActionInvoker<,,,,,,,,,>),
                                                                typeof(ActionInvoker<,,,,,,,,>),
                                                                typeof(ActionInvoker<,,,,,,,>),
                                                                typeof(ActionInvoker<,,,,,,>),
                                                                typeof(ActionInvoker<,,,,,>),
                                                                typeof(ActionInvoker<,,,,>),
                                                                typeof(ActionInvoker<,,,>),
                                                                typeof(ActionInvoker<,,>),
                                                                typeof(ActionInvoker<,>),
                                                                typeof(ActionInvoker<>)};
    private readonly static Type[] InvokerWrapperTypes = new[] {
                                                                       typeof(ActionInvokerWrapper<,,,,,,,,,,,>),
                                                                       typeof(ActionInvokerWrapper<,,,,,,,,,,>),
                                                                       typeof(ActionInvokerWrapper<,,,,,,,,,>),
                                                                       typeof(ActionInvokerWrapper<,,,,,,,,>),
                                                                       typeof(ActionInvokerWrapper<,,,,,,,>),
                                                                       typeof(ActionInvokerWrapper<,,,,,,>),
                                                                       typeof(ActionInvokerWrapper<,,,,,>),
                                                                       typeof(ActionInvokerWrapper<,,,,>),
                                                                       typeof(ActionInvokerWrapper<,,,>),
                                                                       typeof(ActionInvokerWrapper<,,>),
                                                                       typeof(ActionInvokerWrapper<,>),
                                                                       typeof(ActionInvokerWrapper<>)};

    private readonly static Type[] VoidInvokerTypes = new[] {
                                                                    typeof(VoidActionInvoker<,,,,,,,,,,>),
                                                                    typeof(VoidActionInvoker<,,,,,,,,,>),
                                                                    typeof(VoidActionInvoker<,,,,,,,,>),
                                                                    typeof(VoidActionInvoker<,,,,,,,>),
                                                                    typeof(VoidActionInvoker<,,,,,,>),
                                                                    typeof(VoidActionInvoker<,,,,,>),
                                                                    typeof(VoidActionInvoker<,,,,>),
                                                                    typeof(VoidActionInvoker<,,,>),
                                                                    typeof(VoidActionInvoker<,,>),
                                                                    typeof(VoidActionInvoker<,>),
                                                                    typeof(VoidActionInvoker<>),
                                                                    typeof(VoidActionInvoker)};
    private readonly static Type[] VoidInvokerWrapperTypes = new[] {
                                                                           typeof(VoidActionInvokerWrapper<,,,,,,,,,,>),
                                                                           typeof(VoidActionInvokerWrapper<,,,,,,,,,>),
                                                                           typeof(VoidActionInvokerWrapper<,,,,,,,,>),
                                                                           typeof(VoidActionInvokerWrapper<,,,,,,,>),
                                                                           typeof(VoidActionInvokerWrapper<,,,,,,>),
                                                                           typeof(VoidActionInvokerWrapper<,,,,,>),
                                                                           typeof(VoidActionInvokerWrapper<,,,,>),
                                                                           typeof(VoidActionInvokerWrapper<,,,>),
                                                                           typeof(VoidActionInvokerWrapper<,,>),
                                                                           typeof(VoidActionInvokerWrapper<,>),
                                                                           typeof(VoidActionInvokerWrapper<>),
                                                                           typeof(VoidActionInvokerWrapper)};

    #endregion
}
