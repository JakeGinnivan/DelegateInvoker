using System;
using NSubstitute;
using Xunit;

namespace DelegateInvokerTests
{
    public class DeletgateInvokerTests
    {
        [Fact]
        public void can_invoke_all_void_overloads()
        {
            var targetType = typeof (ITarget);
            var target = Substitute.For<ITarget>();

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void")).Call(new object[0]);
            target.Received().Void();

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void1")).Call(new object[]{1});
            target.Received().Void1(1);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void2")).Call(new object[] { 1, 2 });
            target.Received().Void2(1, 2);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void3")).Call(new object[] { 1, 2, 3 });
            target.Received().Void3(1, 2, 3);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void4")).Call(new object[] { 1, 2, 3, 4 });
            target.Received().Void4(1, 2, 3, 4);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void5")).Call(new object[] { 1, 2, 3, 4, 5 });
            target.Received().Void5(1, 2, 3, 4, 5);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void6")).Call(new object[] { 1, 2, 3, 4, 5, 6 });
            target.Received().Void6(1, 2, 3, 4, 5, 6);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void7")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7 });
            target.Received().Void7(1, 2, 3, 4, 5, 6, 7);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void8")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            target.Received().Void8(1, 2, 3, 4, 5, 6, 7, 8);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void9")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            target.Received().Void9(1, 2, 3, 4, 5, 6, 7, 8, 9);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void10")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            target.Received().Void10(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        }

        [Fact]
        public void can_invoke_all_void_overloads_that_throw_exceptions()
        {
            var targetType = typeof(ITarget);
            var target = Substitute.For<ITarget>();

            target.When(t => t.Void()).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void")).Call(new object[0]));

            target.When(t => t.Void1(1)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void1")).Call(new object[] { 1 }));

            target.When(t => t.Void2(1, 2)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void2")).Call(new object[] { 1, 2 }));

            target.When(t => t.Void3(1, 2, 3)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void3")).Call(new object[] { 1, 2, 3 }));

            target.When(t => t.Void4(1, 2, 3, 4)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void4")).Call(new object[] { 1, 2, 3, 4 }));

            target.When(t => t.Void5(1, 2, 3, 4, 5)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void5")).Call(new object[] { 1, 2, 3, 4, 5 }));

            target.When(t => t.Void6(1, 2, 3, 4, 5, 6)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void6")).Call(new object[] { 1, 2, 3, 4, 5, 6 }));

            target.When(t => t.Void7(1, 2, 3, 4, 5, 6, 7)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void7")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7 }));

            target.When(t => t.Void8(1, 2, 3, 4, 5, 6, 7, 8)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void8")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 }));

            target.When(t => t.Void9(1, 2, 3, 4, 5, 6, 7, 8, 9)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void9")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));

            target.When(t => t.Void10(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Void10")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
        }

        [Fact]
        public void can_invoke_all_returning_overloads()
        {
            var targetType = typeof(ITarget);
            var target = Substitute.For<ITarget>();

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns")).Call(new object[0]);
            target.Received().Returns();

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns1")).Call(new object[] { 1 });
            target.Received().Returns1(1);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns2")).Call(new object[] { 1, 2 });
            target.Received().Returns2(1, 2);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns3")).Call(new object[] { 1, 2, 3 });
            target.Received().Returns3(1, 2, 3);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns4")).Call(new object[] { 1, 2, 3, 4 });
            target.Received().Returns4(1, 2, 3, 4);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns5")).Call(new object[] { 1, 2, 3, 4, 5 });
            target.Received().Returns5(1, 2, 3, 4, 5);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns6")).Call(new object[] { 1, 2, 3, 4, 5, 6 });
            target.Received().Returns6(1, 2, 3, 4, 5, 6);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns7")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7 });
            target.Received().Returns7(1, 2, 3, 4, 5, 6, 7);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns8")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            target.Received().Returns8(1, 2, 3, 4, 5, 6, 7, 8);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns9")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            target.Received().Returns9(1, 2, 3, 4, 5, 6, 7, 8, 9);

            DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns10")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            target.Received().Returns10(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        }

        [Fact]
        public void can_invoke_all_returning_overloads_that_throw_exceptions()
        {
            var targetType = typeof(ITarget);
            var target = Substitute.For<ITarget>();

            target.When(t => t.Returns()).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns")).Call(new object[0]));

            target.When(t => t.Returns1(1)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns1")).Call(new object[] { 1 }));

            target.When(t => t.Returns2(1, 2)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns2")).Call(new object[] { 1, 2 }));

            target.When(t => t.Returns3(1, 2, 3)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns3")).Call(new object[] { 1, 2, 3 }));

            target.When(t => t.Returns4(1, 2, 3, 4)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns4")).Call(new object[] { 1, 2, 3, 4 }));

            target.When(t => t.Returns5(1, 2, 3, 4, 5)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns5")).Call(new object[] { 1, 2, 3, 4, 5 }));

            target.When(t => t.Returns6(1, 2, 3, 4, 5, 6)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns6")).Call(new object[] { 1, 2, 3, 4, 5, 6 }));

            target.When(t => t.Returns7(1, 2, 3, 4, 5, 6, 7)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns7")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7 }));

            target.When(t => t.Returns8(1, 2, 3, 4, 5, 6, 7, 8)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns8")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8 }));

            target.When(t => t.Returns9(1, 2, 3, 4, 5, 6, 7, 8, 9)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns9")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));

            target.When(t => t.Returns10(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)).Do(c => { throw new ArgumentException(); });
            Assert.Throws<ArgumentException>(() => DelegateInvoker.CreateInvoker(target, targetType.GetMethod("Returns10")).Call(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
        }

        public interface ITarget
        {
            void Void();
            void Void1(int a1);
            void Void2(int a1, int a2);
            void Void3(int a1, int a2, int a3);
            void Void4(int a1, int a2, int a3, int a4);
            void Void5(int a1, int a2, int a3, int a4, int a5);
            void Void6(int a1, int a2, int a3, int a4, int a5, int a6);
            void Void7(int a1, int a2, int a3, int a4, int a5, int a6, int a7);
            void Void8(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8);
            void Void9(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9);
            void Void10(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10);
            string Returns();
            string Returns1(int a1);
            string Returns2(int a1, int a2);
            string Returns3(int a1, int a2, int a3);
            string Returns4(int a1, int a2, int a3, int a4);
            string Returns5(int a1, int a2, int a3, int a4, int a5);
            string Returns6(int a1, int a2, int a3, int a4, int a5, int a6);
            string Returns7(int a1, int a2, int a3, int a4, int a5, int a6, int a7);
            string Returns8(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8);
            string Returns9(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9);
            string Returns10(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9, int a10);
        }
    }
}
