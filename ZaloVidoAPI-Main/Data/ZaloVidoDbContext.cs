using ZaloVidoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ZaloVidoAPI.Data{
    public class ZaloVidoDbContext: DbContext{
        public ZaloVidoDbContext(DbContextOptions<ZaloVidoDbContext> opt):base(opt){
            
        }
        public DbSet<MessageDetail> Messages{get;set;}
        public DbSet<ApplicationConfig> ApplicationConfigs { get; set; }

        public DbSet<FQAModel> FQA {get;set;}
        public DbSet<FQADetailModel> FQADetails { get; set; }
        public DbSet<CrispMessageSend> CrispMessages{get;set;}
        public DbSet<SenderModel> Senders{get;set;}

        
    }
}