using ZaloVidoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoList.Api.Data{
    public class ZaloVidoDbContext: DbContext{
        public ZaloVidoDbContext(DbContextOptions<ZaloVidoDbContext> opt):base(opt){
            
        }

        public DbSet<FQAModel> FQA {get;set;}
        public DbSet<FQADetailModel> FQADetails { get; set; }

        
    }
}