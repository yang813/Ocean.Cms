/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：后台管理菜单接口实现                                                    
*│　作    者：yangjb                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2018-12-22 15:58:56                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Ocean.Cms.Repository.SqlServer                                  
*│　类    名： MenuRepository                                      
*└──────────────────────────────────────────────────────────────┘
*/
using Ocean.Cms.Core.DbHelper;
using Ocean.Cms.Core.Options;
using Ocean.Cms.Core.Repository;
using Ocean.Cms.IRepository;
using Ocean.Cms.Models;
using Microsoft.Extensions.Options;
using System;

namespace Ocean.Cms.Repository.SqlServer
{
    public class MenuRepository:BaseRepository<Menu,Int32>, IMenuRepository
    {
        public MenuRepository(IOptionsSnapshot<DbOpion> options)
        {
            _dbOpion =options.Get("OceanCms");
            if (_dbOpion == null)
            {
                throw new ArgumentNullException(nameof(DbOpion));
            }
            _dbConnection = ConnectionFactory.CreateConnection(_dbOpion.DbType, _dbOpion.ConnectionString);
        }

    }
}