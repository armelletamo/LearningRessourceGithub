using System;
using System.Collections.Generic;
using System.Text;

namespace AméliorationDeCode
{
    public class MessageB : IMessage
    {
        public void CustomMessage()
        {
            MyCustomMethodOnB();
            SomeAdditionalMethodOnB();
        }
        private void MyCustomMethodOnB()
        {

        }
        private void SomeAdditionalMethodOnB()
        {

        }
    }
}
