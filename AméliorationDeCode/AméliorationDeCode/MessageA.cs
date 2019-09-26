using System;
using System.Collections.Generic;
using System.Text;

namespace AméliorationDeCode
{
    public class MessageA : IMessage
    {
        public void CustomMessage()
        {
            MyCustomMethodOnA();
        }

        private void MyCustomMethodOnA()
        {

        }
    }
}
