using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocean.Cms.Core.CodeGenerator;
using Ocean.Cms.Core.Models;
using Ocean.Cms.Core.Options;
using Ocean.Cms.IRepository;
using Ocean.Cms.Models;
using Ocean.Cms.Repository.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace Ocean.Cms.Test
{
    /// <summary>
    /// yangjb
    /// 2018.12.22
    /// 测试代码生成器
    /// </summary>
    public class GeneratorTest
    {
        [Fact]
        public void GeneratorModelForSqlServer()
        {
            var serviceProvider = BuildServiceForSqlServer();
            var codeGenerator = serviceProvider.GetRequiredService<CodeGenerator>();
            codeGenerator.GenerateTemplateCodesFromDatabase(true);
            Assert.Equal("SQLServer", DatabaseType.SqlServer.ToString(), ignoreCase: true);

        }

        [Fact]
        public void TestBaseFactory()
        {
            IServiceProvider serviceProvider = BuildServiceForSqlServer();
            IArticleCategoryRepository categoryRepository = serviceProvider.GetService<IArticleCategoryRepository>();
            var category = new ArticleCategory
            {
                Title = "随笔",
                ParentId = 0,
                ClassList = "",
                ClassLayer = 0,
                Sort = 0,
                ImageUrl = "",
                SeoTitle = "随笔的SEOTitle",
                SeoKeywords = "随笔的SeoKeywords",
                SeoDescription = "随笔的SeoDescription",
                IsDeleted = false,
            };
            var categoryId = categoryRepository.Insert(category);
            var list = categoryRepository.GetList();
            Assert.True(1 == list.Count());
            Assert.Equal("随笔", list.FirstOrDefault().Title);
            Assert.Equal("SQLServer", DatabaseType.SqlServer.ToString(), ignoreCase: true);
            categoryRepository.Delete(categoryId.Value);
            var count = categoryRepository.RecordCount();
            Assert.True(0 == count);
        }

        /// <summary>
        /// 构造依赖注入容器，然后传入参数
        /// </summary>
        /// <returns></returns>
        public IServiceProvider BuildServiceForSqlServer()
        {
            var services = new ServiceCollection();
            services.Configure<CodeGenerateOption>(options =>
            {
                options.ConnectionString = "Data Source=127.0.0.1;Initial Catalog=OceanCms;User ID=sa;Password=bao13253858716;Persist Security Info=True;Max Pool Size=50;Min Pool Size=0;Connection Lifetime=300;";
                options.DbType = DatabaseType.SqlServer.ToString();//数据库类型是SqlServer,其他数据类型参照枚举DatabaseType
                options.Author = "yangjb";//作者名称
                options.OutputPath = "C:\\OceanCmsCodeGenerator";//模板代码生成的路径
                options.ModelsNamespace = "Ocean.Cms.Models";//实体命名空间
                options.IRepositoryNamespace = "Ocean.Cms.IRepository";//仓储接口命名空间
                options.RepositoryNamespace = "Ocean.Cms.Repository.SqlServer";//仓储命名空间

            });
            services.AddSingleton<CodeGenerator>();//注入Model代码生成器
            services.Configure<DbOpion>("OceanCms", GetConfiguration().GetSection("DbOpion"));
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
            return services.BuildServiceProvider(); //构建服务提供程序
        }

        public IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
