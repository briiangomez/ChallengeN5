using ChallengeN5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Infrastructure.Context.Apache_Kafka
{
    internal class ApacheMessageDbContext : DbContext
    {
        public ApacheMessageDbContext(DbContextOptions<ApacheMessageDbContext> options) : base(options) { }
        public DbSet<KafkaMessage> Messages { get; set; }
    }
}
