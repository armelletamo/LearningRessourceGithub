using System;

namespace AméliorationDeCode
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void Message(IMessage message)
        {
            message.CustomMessage();
        }
    }
}
