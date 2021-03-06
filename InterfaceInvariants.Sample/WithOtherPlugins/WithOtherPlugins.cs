using System;
using NUnit.Framework;
using InterfaceInvariants.Framework;
namespace InterfaceInvariants.Sample
{
	
	public interface ICanAdd {
		int Add(int i, int j); //dont ask me why you want different adders
	}
	interface shitbar : ICanAdd {
		void FooBar() ;
	}
	public class Adder1 : shitbar {
		public int Add(int i, int j) {
			return i + j;
		}
		public void FooBar() {}
	}
	public class Adder2Broken : ICanAdd {
		public int Add(int i, int j) {
			return 0;
		}
	}
	
	public class Adder2 : ICanAdd {
		public int Add(int i, int j) {
			return (i + 12) + (j - 12); //yeeeeeaaaah
		}
	}

    [InterfaceSpecification]
    public class WithOtherPlugins : AppliesToAll<ICanAdd>
    {
        [TestCase(1, 2, 3)]
        [TestCase(-1, 2, 1)]
        [TestCase(0, 0, 0)]
        public void CanAddOrSomething(int x, int y, int r)
        {
            Assert.AreEqual(subject.Add(x, y), r);
        }
    }
    
}

