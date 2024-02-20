using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Domain.Entities
{
    public class KafkaMessage
    {
        public KafkaMessage(Guid id, string message)
        {
             Id = id;
            Message = message;
        }

        public Guid Id { get; private set; }

        public string Message { get; private set; } = string.Empty;
    }
}
