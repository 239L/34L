using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NearYouNameSpace.Coroutines;
namespace Tests
{
    public class FaderTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void FaderTestSimplePasses()
        {
            Fader f = new Fader();
            
            Assert.AreEqual(false, f.IsFaded);
        }

       
        
    }
}
